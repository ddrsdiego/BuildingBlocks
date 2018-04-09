using Easynvest.BuildingBlocks.App.AggregateModel.TreasuryDirectAggregateModel;
using Easynvest.BuildingBlocks.KingsCross;
using Easynvest.BuildingBlocks.KingsCross.RabbitMq;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Easynvest.BuildingBlocks.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var security = new Security(15978, "", "", 123, 10000, 15000, new SymbolBaseSecurity("CDB", 1, 2, SymbolBaseMarket.FixedIncome));

            var applicationValue = new ApplicationValue(security.Price, 1000);

            var movimentoRendaFixa = new MovimentoRendaFixa(5090016, security);
            var movimentoRendaFixaCompra = new MovimentoRendaFixaCompra(movimentoRendaFixa, applicationValue);

            if (!movimentoRendaFixaCompra.VerificaLimite)
            {

            }
            new MovimentoRendaFixaRespository().Inserir(movimentoRendaFixa);

            var bus = Bus.Factory.CreateKingsCrossRabbitMq(configBus =>
            {
                var host = configBus.CreateHost("connectionString", parameters =>
                {
                    parameters.UserName("guest");
                    parameters.Password("guest");
                });

                configBus.ReceiveEndPoint(host, "customer_created_event", endPoint =>
                {
                    endPoint.SubScriber<CustomerCreatedEvent>();

                    endPoint.SubScriber<CustomerUpdatedEvent>(subscriberConfig =>
                    {

                    });
                });
            });

            //Bus.Factory.CreateKingsCrossInMemory()

            //var bus = Bus.Factory.CreateRabbitMq(configBus =>
            //{
            //    var host = configBus.CreateHost("connectionString", parameters =>
            //    {
            //        parameters.UserName("");
            //        parameters.Password("");
            //    });

            //    configBus.ReceiveEndPoint(host, "customer_created_event", endPoint =>
            //    {
            //        endPoint.SubScriber<CustomerCreatedEvent>();
            //    });

            //    configBus.ReceiveEndPoint(host, "customer_updated_event", endPoint =>
            //    {
            //        endPoint.SubScriber<CustomerUpdatedEvent>(configSubscriber =>
            //        {
            //            configSubscriber.DeadLetterExchange = true;
            //            configSubscriber.AutoDelete = false;
            //            configSubscriber.ExchangeType = "";
            //        });
            //    });
            //});

            //bus.Start();


        }
    }

    public class TreasuryDirectService
    {
        private ISellTreasuryDirectStepsService sellTreasuryDirectStepsService;
        public ISellTreasuryDirectStepsService SellTreasuryDirectStepsService
        {
            get
            {
                if (sellTreasuryDirectStepsService == null)
                    sellTreasuryDirectStepsService = new SellTreasuryDirectStepsService();

                return sellTreasuryDirectStepsService;
            }
        }


        private ITreasuryDirectRepository _treasuryDirectRepository;
        private ITreasuryDirectRepository TreasuryDirectRepository
        {
            get
            {
                if (_treasuryDirectRepository == null)
                    _treasuryDirectRepository = new TreasuryDirectIntelidataRepository();

                return _treasuryDirectRepository;
            }
        }

        public TreasuryDirectService()
        {

        }

        public TreasuryDirectService(ISellTreasuryDirectStepsService sellTreasuryDirectStepsService,
                                     ITreasuryDirectRepository treasuryDirectRepository)
        {
            _treasuryDirectRepository = treasuryDirectRepository;
            this.sellTreasuryDirectStepsService = sellTreasuryDirectStepsService;
        }

        public void SellTreasuryDirect(IEnumerable<SellTreasuryDirect> sells)
        {
            sells.ToList().ForEach(itemSell =>
            {
                var responseCheckStatusMarket = SellTreasuryDirectStepsService.Pull(new CheckStatusMarket(new CheckStatusMarketRequest())).Result;
                itemSell.AddCompleteStep(responseCheckStatusMarket);

                var responseChecksSaleCondition = SellTreasuryDirectStepsService.Pull(new ChecksSaleCondition(new ChecksSaleConditionRequest("32927484880", "159357"))).Result;
                itemSell.AddCompleteStep(responseChecksSaleCondition);

                var responseGetBaskIdFromMarket = SellTreasuryDirectStepsService.Pull(new GetBaskIdFromMarket(new GetBaskIdFromMarketResquest("32927484880", "159357"))).Result;
                itemSell.AddCompleteStep(responseGetBaskIdFromMarket);

                var responseProcessItemIntoBasket = SellTreasuryDirectStepsService.Pull(new ProcessItemIntoBasket(new ProcessItemIntoBasketRequest("32927484880", "159357", "BasketId", "SecurityId", 10000))).Result;
                itemSell.AddCompleteStep(responseProcessItemIntoBasket);

                var responseProcessSellTreasuryDirect = SellTreasuryDirectStepsService.Pull(new ProcessSellTreasuryDirect(new ProcessSellTreasuryDirectResquest("32927484880", "159357", "BasketId", "SecurityId", 10000))).Result;
                itemSell.AddCompleteStep(responseProcessSellTreasuryDirect);
            });

            _treasuryDirectRepository.PersistSellTreasuryDirect(sells);
        }
    }

    public interface ITreasuryDirectRepository
    {
        void PersistSellTreasuryDirect(SellTreasuryDirect sell);
        void PersistSellTreasuryDirect(IEnumerable<SellTreasuryDirect> sells);
    }

    public class TreasuryDirectIntelidataRepository : ITreasuryDirectRepository
    {
        public void PersistSellTreasuryDirect(IEnumerable<SellTreasuryDirect> sells)
        {
            throw new System.NotImplementedException();
        }

        public void PersistSellTreasuryDirect(SellTreasuryDirect sell)
        {
            throw new System.NotImplementedException();
        }
    }

    public class CustomerCreatedEvent : IRequest<Unit>
    {
        public CustomerCreatedEvent(string customerId, string name, string email)
        {
            CustomerId = customerId;
            Name = name;
            Email = email;
        }

        public string CustomerId { get; }
        public string Name { get; }
        public string Email { get; }
    }

    public class CustomerUpdatedEvent : IRequest<Unit>
    {
        public CustomerUpdatedEvent(string customerId, string name)
        {
            CustomerId = customerId;
            Name = name;
        }

        public string CustomerId { get; }
        public string Name { get; }
    }

    public class RequestBuyFixedIncomeCommand
    {
        public RequestBuyFixedIncomeCommand(string customerId, long accountNumber, string secuityIdSymbolbaseId, decimal quantity, string electronicSignature)
        {
            CustomerId = customerId;
            AccountNumber = accountNumber;
            SecuityIdSymbolbaseId = secuityIdSymbolbaseId;
            Quantity = quantity;
            ElectronicSignature = electronicSignature;
        }

        public string CustomerId { get; }
        public long AccountNumber { get; }
        public string SecuityIdSymbolbaseId { get; }
        public decimal Quantity { get; }
        public string ElectronicSignature { get; }
    }

    public class Security
    {
        public Security(int internalSecurityId, string issuerBankName, string stock, decimal price, decimal minimumValue, decimal limitValue, SymbolBaseSecurity symbolBaseSecurity)
        {
            InternalSecurityId = internalSecurityId;
            IssuerBankName = issuerBankName;
            Stock = stock;
            Price = price;
            MinimumValue = minimumValue;
            LimitValue = limitValue;
            SymbolBaseSecurity = symbolBaseSecurity;
        }

        public int InternalSecurityId { get; }
        public string IssuerBankName { get; }
        public string Stock { get; }
        public decimal Price { get; }
        public decimal MinimumValue { get; }
        public decimal LimitValue { get; }
        public SymbolBaseSecurity SymbolBaseSecurity { get; }
    }

    public class MovimentoRendaFixa
    {
        public MovimentoRendaFixa(long accountNumber, Security security)
        {
            Id = Guid.NewGuid().ToString("");
            AccountNumber = accountNumber;
            Security = security;
        }

        public string Id { get; }
        public long AccountNumber { get; }
        public Security Security { get; }
    }

    public class MovimentoRendaFixaCompra
    {
        public MovimentoRendaFixaCompra(MovimentoRendaFixa movimentoRendaFixa, ApplicationValue applicationValue)
        {
            MovimentoRendaFixa = movimentoRendaFixa;
            ApplicationValue = applicationValue;
        }

        public MovimentoRendaFixa MovimentoRendaFixa { get; }
        public ApplicationValue ApplicationValue { get; }

        public bool VerificaLimite
        {
            get
            {
                return MovimentoRendaFixa.Security.LimitValue >= ApplicationValue.Value;
            }
        }
    }

    public class ApplicationValue
    {
        //RoundMinimumValue(Convert.ToDecimal(dtR.Rows[0]["PRECO"]) * qtde);
        public ApplicationValue(decimal securityPrice, decimal quantity)
        {
            SecurityPrice = securityPrice;
            Quantity = quantity;
        }
        public decimal Value
        {
            get
            {
                return Math.Round((SecurityPrice * Quantity), 2);
            }
        }
        public decimal SecurityPrice { get; }
        public decimal Quantity { get; }
    }

    public class SymbolBaseSecurity
    {
        public SymbolBaseSecurity(string fixedIncomeSecurityType, decimal minTick, decimal minAdditionalPurchase, SymbolBaseMarket symbolBaseMarket)
        {
            FixedIncomeSecurityType = fixedIncomeSecurityType;
            MinTick = minTick;
            MinAdditionalPurchase = minAdditionalPurchase;
            SymbolBaseMarket = symbolBaseMarket;
        }

        public string FixedIncomeSecurityType { get; }
        public decimal MinTick { get; }
        public decimal MinAdditionalPurchase { get; }
        public SymbolBaseMarket SymbolBaseMarket { get; }
    }

    public enum SymbolBaseMarket
    {
        FixedIncome = 1,
        Fund = 2,
        COE = 3
    }

    public class MovimentoRendaFixaRespository
    {
        public void Inserir(MovimentoRendaFixa movimentoRendaFixa)
        {
            Console.WriteLine(movimentoRendaFixa);
        }
    }
}

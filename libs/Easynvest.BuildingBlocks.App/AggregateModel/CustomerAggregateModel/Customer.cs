namespace Easynvest.BuildingBlocks.App.AggregateModel.CustomerAggregateModel
{
    public class Customer
    {
        public string CustomerId { get; }
        public long AccountNumber { get; }
        public string Email { get; }

        protected Customer()
        {

        }

        public Customer(string customerId, long accountNumber, string email)
        {
            CustomerId = customerId;
            AccountNumber = accountNumber;
            Email = email;
        }
    }
}
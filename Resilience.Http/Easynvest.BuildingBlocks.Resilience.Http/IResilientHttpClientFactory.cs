using System;
using System.Collections.Generic;
using System.Text;

namespace Easynvest.BuildingBlocks.Resilience.Http
{
    public interface IResilientHttpClientFactory
    {
        ResilientHttpClient CreateResilientHttpClient();
    }
}

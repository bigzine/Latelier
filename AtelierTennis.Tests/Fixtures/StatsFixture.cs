using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtelierTennis.API.Models;

namespace AtelierTennis.Tests.Fixtures
{
    public static class StatsFixture
    {
        public static Stats GetStats => new Stats()
        {
            AverageBodyMassIndex = 67.2,
            CountryWithHighestWinRatio = "FR",
            MedianeHeight = 172
        };
    }
}

using System;
using Xunit;
using TenorPortfolioSorter;

namespace TenorPortfolioSorter.Tests
{
    public class TenorValuation
    {
        private readonly PortfolioTenor _portfolioTenor;


        public TenorValuation()
        {
            _portfolioTenor = new PortfolioTenor();
        }

        [Fact]
        public void TenorValuation_IsOneDay()
        {
            _portfolioTenor.Tenor = "1d";
            Assert.Equal(_portfolioTenor.TenorDayValue, 1);
        }

        [Fact]
        public void TenorValuation_IsOneYearOneMonthOneWeekOneDay()
        {
            _portfolioTenor.Tenor = "1y1m1w1d";
            Assert.Equal(_portfolioTenor.TenorDayValue, 403);
        }

        [Fact]
        public void TenorValuation_IsTwoYearTwoMonthTwoWeekTwoDayReverse()
        {
            _portfolioTenor.Tenor = "2d2w2m2y";
            Assert.Equal(_portfolioTenor.TenorDayValue, 806);
        }

        [Fact]
        public void TenorValuation_IsTwoMonthsThreeWeeksFourDays()
        {
            _portfolioTenor.Tenor = "2m3w4d";
            Assert.Equal(_portfolioTenor.TenorDayValue, 85);
            
        }

    }
}

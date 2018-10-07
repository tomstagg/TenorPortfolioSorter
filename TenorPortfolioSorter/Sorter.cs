using System.Collections.Generic;
using System.Linq;

namespace TenorPortfolioSorter
{
    public static class Sorter
    {
        public static List<PortfolioTenor> SortByTenorPorfolio(List<PortfolioTenor> portfolioTenors) => 
            portfolioTenors.OrderBy(t => t.TenorDayValue).ThenBy(p => p.PortfolioId).ToList();

        public static List<PortfolioTenor> SortByPortfolioTenor(List<PortfolioTenor> portfolioTenors) =>
            portfolioTenors.OrderBy(p => p.PortfolioId).ThenBy(t => t.TenorDayValue).ToList();
    }
}

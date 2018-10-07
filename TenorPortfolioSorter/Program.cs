namespace TenorPortfolioSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            var portfolioTenors = FileManagement.GetPortfolioTenors("data.txt");

            FileManagement.WriteFile(Sorter.SortByTenorPorfolio(portfolioTenors), "Tenor, PortfolioId, Value", "3.txt");
            FileManagement.WriteFile(Sorter.SortByPortfolioTenor(portfolioTenors), "Tenor, PortfolioId, Value", "4.txt");       
        }
    }
}

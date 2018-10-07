namespace TenorPortfolioSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            var portfolioTenors = FileManagement.GetPortfolioTenors("data.txt");

            FileManagement.WriteFile(Sorter.SortByTenorPorfolio(portfolioTenors) , "3.txt");
            FileManagement.WriteFile(Sorter.SortByPortfolioTenor(portfolioTenors), "4.txt");       
        }
    }
}

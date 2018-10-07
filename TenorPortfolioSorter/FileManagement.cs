using System.IO;
using System.Collections.Generic;
using System;

namespace TenorPortfolioSorter
{
    public static class FileManagement
    {
        public static List<PortfolioTenor> GetPortfolioTenors(string inputFile)
        {
            var portfolioTenors = new List<PortfolioTenor>();
            using (var reader = new StreamReader(inputFile))
            {
                var ignoreHeaderline = reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line != "")
                    {
                        var splitLine = line.Split(',');
                        int portfolioId =0;
                        int value = 0;

                        Int32.TryParse(splitLine[1], out portfolioId);
                        Int32.TryParse(splitLine[2], out value);

                        portfolioTenors.Add(new PortfolioTenor()
                        { 
                            Tenor = splitLine[0], PortfolioId = portfolioId, Value = value
                        });
                    }
                }
            }
            return portfolioTenors;
        }

        public static void WriteFile(List<PortfolioTenor> portfolioTenors, string headerCsv, string outputFileName)
        {
            using (TextWriter textWriter = new StreamWriter(outputFileName, false))
            {
                textWriter.WriteLineAsync(headerCsv);
                foreach (var portfolioTenor in portfolioTenors)
                {
                    textWriter.WriteLine(portfolioTenor.OutputCsv());
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TenorPortfolioSorter
{

    class RegexPeriods
    {
        public char Period {get; set;}
        public int  PeriodDayValue {get; set;}
    }
    public class PortfolioTenor
    {
        const char YEAR = 'y';
        const char MONTH = 'm';
        const char WEEK = 'w';
        const char DAY = 'd';

        public string Tenor {get; set;}
        public int PortfolioId {get; set;}
        public int Value {get; set;}

        public int TenorDayValue 
        {
            get 
            {
                var regexPeriods = new List<RegexPeriods>() 
                {
                    new RegexPeriods() {Period = YEAR, PeriodDayValue = 365},
                    new RegexPeriods() {Period = MONTH, PeriodDayValue = 30},
                    new RegexPeriods() {Period = WEEK, PeriodDayValue = 7},
                    new RegexPeriods() {Period = DAY, PeriodDayValue = 1},
                };

                int tenorDayValue = 0;

                foreach(var regexPeriod in regexPeriods)
                {
                    string regex = @"(\d+)(?=" + regexPeriod.Period + ")";

                    var match = Regex.Match(Tenor, regex);

                    if (match.Success)
                        tenorDayValue += Int32.Parse(match.Value) * regexPeriod.PeriodDayValue;
                }
                return tenorDayValue;
            }
            
        }
        // public int TenorDayValue
        // {
        //     get 
        //     {
        //         int tenorDayValue = 0;

        //         var yearMatch = Regex.Match(Tenor, @"(\d+)(?=y)");
        //         var monthMatch = Regex.Match(Tenor, @"(\d+)(?=m)");
        //         var weekMatch = Regex.Match(Tenor, @"(\d+)(?=w)");
        //         var dayMatch = Regex.Match(Tenor, @"(\d+)(?=d)");

        //         if (yearMatch.Success)
        //             tenorDayValue = Int32.Parse(yearMatch.Value) * 365;

        //         if (monthMatch.Success)
        //             tenorDayValue += Int32.Parse(monthMatch.Value) * 30;

        //         if (weekMatch.Success)
        //             tenorDayValue += Int32.Parse(weekMatch.Value) * 7;

        //         if (dayMatch.Success)
        //             tenorDayValue += Int32.Parse(dayMatch.Value);

        //         return tenorDayValue;   
        //     }
        // }
        public string OutputCsv ()
        {
            return string.Join(", ", Tenor, PortfolioId, Value);
        }
    }
}

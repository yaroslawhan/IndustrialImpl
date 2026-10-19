using System;
using System.Collections.Generic;

namespace IndustrialImpl.Models
{
    public class OverallCompanyFinancialMetrics
    {
        public double AnnualProfit { get; set; } // Expressed in millions of rubles
        public double BorrowedFundsRate { get; set; } // Expressed in %
        public double IncomeTaxRate { get; set; } // Expressed in %
        public double ShareCapitalPrice { get; set; } // Expressed in %
        public double BorrowedFundsVolume { get; set; } // Expressed in millions of rubles
        public double BorrowedCapitalPrice { get; set; } // Expressed in %
        public bool IsFinanciallyDependent { get; set; }
    }
}

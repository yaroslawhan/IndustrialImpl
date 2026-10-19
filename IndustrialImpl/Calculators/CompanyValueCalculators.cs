using IndustrialImpl.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialImpl.Calculators
{
    static class CompanyValueCalculators // Includes the value of a financially dependent and financially independent company calculators (practicum 3)
    {
        public static double CombinedCompanyValueCalculator(OverallCompanyFinancialMetrics OverallCompanyFinancialMetrics) { // Combined calculator of value of a financially dependent and financially independent company
            if (OverallCompanyFinancialMetrics.IsFinanciallyDependent) return FDCompanyValueCalculator(OverallCompanyFinancialMetrics);
            return FICompanyValueCalculator(OverallCompanyFinancialMetrics);
        }

        private static double FDCompanyValueCalculator(OverallCompanyFinancialMetrics OverallCompanyFinancialMetrics) { // Financial dependent company value calculator
            return (OverallCompanyFinancialMetrics.AnnualProfit * (1 - OverallCompanyFinancialMetrics.BorrowedFundsRate/100.0)) * ((1 - OverallCompanyFinancialMetrics.IncomeTaxRate / 100.0) / (OverallCompanyFinancialMetrics.BorrowedCapitalPrice / 100.0)) + OverallCompanyFinancialMetrics.BorrowedFundsVolume;
        }

        private static double FICompanyValueCalculator(OverallCompanyFinancialMetrics OverallCompanyFinancialMetrics) { // Financial independent company value calculator
            return (OverallCompanyFinancialMetrics.AnnualProfit)*((1 - OverallCompanyFinancialMetrics.IncomeTaxRate/100.0)/(OverallCompanyFinancialMetrics.ShareCapitalPrice/100.0));
        }
    }
}

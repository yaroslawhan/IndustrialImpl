using IndustrialImpl.Models;
using IndustrialImpl.Calculators;
using IndustrialImpl.Reports;

namespace IndustrialImpl.Practicums
{
    public static class Practicum3
    {
        public static void Run() // The only one method to run the practicum presentation
        {
            // Setting up data for 2 variant of practicum
            OverallCompanyFinancialMetrics OverallYadroFinancialMetrics = new OverallCompanyFinancialMetrics();
            OverallYadroFinancialMetrics.AnnualProfit = 800;
            OverallYadroFinancialMetrics.BorrowedFundsRate = 13;
            OverallYadroFinancialMetrics.IncomeTaxRate = 21.5;
            OverallYadroFinancialMetrics.ShareCapitalPrice = 18;
            OverallYadroFinancialMetrics.BorrowedFundsVolume = 1500;
            OverallYadroFinancialMetrics.BorrowedCapitalPrice = 25;
            OverallYadroFinancialMetrics.IsFinanciallyDependent = true;
            Company YadroCompany = new Company { Name = "ООО YADRO", OverallCompanyFinancialMetrics = OverallYadroFinancialMetrics };

            OverallCompanyFinancialMetrics OverallXCompanyFinancialMetrics = new OverallCompanyFinancialMetrics();
            OverallXCompanyFinancialMetrics.AnnualProfit = 800;
            OverallXCompanyFinancialMetrics.BorrowedFundsRate = 13;
            OverallXCompanyFinancialMetrics.IncomeTaxRate = 21.5;
            OverallXCompanyFinancialMetrics.ShareCapitalPrice = 18;
            OverallXCompanyFinancialMetrics.BorrowedFundsVolume = 1500;
            OverallXCompanyFinancialMetrics.BorrowedCapitalPrice = 25;
            OverallXCompanyFinancialMetrics.IsFinanciallyDependent = false;
            Company XCompany = new Company { Name = "ИКС Холдинг", OverallCompanyFinancialMetrics = OverallXCompanyFinancialMetrics };

            // Printing the data table
            string[] tableHeaders = { "№ вар.", "П, млн. руб.", "ПР, %", "T, %", "Price_АК, %", "Capital_ЗК, млн. руб.", "Price_ЗК, %", "ФЗО", "ФНО" };
            string[][] tableRows = new string[1][];
            tableRows[0] = new string[9] { "2", YadroCompany.OverallCompanyFinancialMetrics.AnnualProfit.ToString(), YadroCompany.OverallCompanyFinancialMetrics.BorrowedFundsRate.ToString(), YadroCompany.OverallCompanyFinancialMetrics.IncomeTaxRate.ToString(), YadroCompany.OverallCompanyFinancialMetrics.ShareCapitalPrice.ToString(), YadroCompany.OverallCompanyFinancialMetrics.BorrowedFundsVolume.ToString(), YadroCompany.OverallCompanyFinancialMetrics.BorrowedCapitalPrice.ToString(), YadroCompany.Name, XCompany.Name };
            ConsolePrinter.PrintTable(tableHeaders, tableRows);

            // Calculating and printing the values of a financially dependent and financially independent company
            double YadroValue = CompanyValueCalculators.CombinedCompanyValueCalculator(OverallYadroFinancialMetrics);
            double XCompanyValue = CompanyValueCalculators.CombinedCompanyValueCalculator(OverallXCompanyFinancialMetrics);
            Console.WriteLine("\nThe value of YADRO company (financially dependent) = " + Math.Round(YadroValue, 4, MidpointRounding.AwayFromZero).ToString() + " (mill. rubs)");
            Console.WriteLine("The value of X Holding company (financially independent) = " + Math.Round(XCompanyValue, 4, MidpointRounding.AwayFromZero).ToString() + " (mill. rubs)");
        }
    }
}
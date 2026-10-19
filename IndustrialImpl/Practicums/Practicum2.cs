using IndustrialImpl.Models;
using IndustrialImpl.Calculators;
using IndustrialImpl.Reports;

namespace IndustrialImpl.Practicums
{
    public static class Practicum2
    {
        public static void Run() // The only one method to run the practicum presentation
        {
            // Setting up data for 6 variant of practicum
            Company myCompany = new Company {Name = "myCompany"};
            string[] departmentsNames = {"Финансовый отдел", "Отдел ИТ", "Проектный отдел", "Отдел стратегического развития"};
            double[] departmentsEmployeesShares = {0.15, 0.35, 0.25, 0.25};
            double[] departmentsIncomesShares = {0.15, 0.2, 0.25, 0.4}; // Sorted by this values
            int departmentsCount = departmentsNames.Length;
            for (int i = 0; i < departmentsCount; i++) myCompany.Departments.Add(new Department {Name = departmentsNames[i], EmployeesShare = departmentsEmployeesShares[i], IncomeShare = departmentsIncomesShares[i]}); // Adds departments into the company
            double[] cumulatedDepartmentsEmployeesShares = ConcentrationCalculators.OrderedCrsCalculator(departmentsEmployeesShares); // Calculating the cumulated departments employees shares
            double[] cumulatedDepartmentsIncomesShares = ConcentrationCalculators.OrderedCrsCalculator(departmentsIncomesShares); // Calculating the cumulated departments incomes shares

            // Printing the data table
            string[] tableHeaders = {"Вид предприятия", "Доля сотрудников", "Доля дохода", "Накопленная доля сотрудников", "Накопленная доля дохода"};
            string[][] tableRows = new string[departmentsCount][];
            for (int i = 0; i < departmentsCount; i++) {
                tableRows[i] = new string[5] {departmentsNames[i], departmentsEmployeesShares[i].ToString(), departmentsIncomesShares[i].ToString(), cumulatedDepartmentsEmployeesShares[i].ToString(), cumulatedDepartmentsIncomesShares[i].ToString()};
            }
            ConsolePrinter.PrintTable(tableHeaders, tableRows);

            // Calculating and printing the array of Cr indexes
            double[] crs_income = cumulatedDepartmentsIncomesShares; // This is the same things
            Console.WriteLine("\nИндексы концентрации рынка (упорядоченные по доходам отделов) по доходам отделов:");
            for (int i = 0; i < departmentsCount; i++)
                Console.WriteLine($"Для {i+1} первых(первого) отделов(а): Cr_income = " + crs_income[i]);

            // Calculating and printing the Herfindahl-Hirshman index (rounded by 4 letters)
            Console.WriteLine("\nИндекс Херфиндаля-Хиршмана по доходам отделов:\nHHI = " + Math.Round(ConcentrationCalculators.HerfindahlHirshmanCalculator(departmentsIncomesShares), 4, MidpointRounding.AwayFromZero));

            // Calculating and printing the Gini coefficient (rounded by 4 letters)
            Console.WriteLine("\nКоэффициент Джини:\nG = " + Math.Round(ConcentrationCalculators.GiniCalculator(departmentsEmployeesShares, departmentsIncomesShares), 4, MidpointRounding.AwayFromZero));

            // Printing the Lorenz plot
            PlotPrinter.LorenzCurveChartPrinter(cumulatedDepartmentsEmployeesShares, cumulatedDepartmentsIncomesShares, tableHeaders[3], tableHeaders[4]);
        }
    }
}
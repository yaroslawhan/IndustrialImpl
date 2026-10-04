using IndustrialImpl.Models;
using IndustrialImpl.Calculators;

namespace IndustrialImpl.Labs
{
    public static class Lab2
    {
        public static void Run()
        {
            Company myCompany = new Company {Name = "myCompany"};
            string[] departmentsNames = {"Финансовый отдел", "Отдел ИТ", "Проектный отдел", "Отдел стратегического развития"};
            double[] departmentsEmployeesShares = {0.15, 0.35, 0.25, 0.25};
            double[] departmentsIncomesShares = {0.15, 0.2, 0.25, 0.4};
            int departmentsCount = departmentsNames.Length;
            for (int i = 0; i < departmentsCount; i++) myCompany.Departments.Add(new Department {Name = departmentsNames[i], EmployeesShare = departmentsEmployeesShares[i], IncomeShare = departmentsIncomesShares[i]});
            double[] crs_income = ConcentrationCalculator.OrderedCrsCalculator(departmentsIncomesShares);

            Console.WriteLine("\nИндексы концентрации рынка (упорядоченные по доходам отделов) по доходам отделов:");

            for (int i = 0; i < departmentsCount; i++)
                Console.WriteLine($"Для {i+1} первых(первого) отделов(а): Cr_income = " + crs_income[i]);

            Console.WriteLine("\nИндекс Херфиндаля-Хиршмана по доходам отделов:\nHHI = " + Math.Round(ConcentrationCalculator.HerfindahlHirshmanCalculator(departmentsIncomesShares), 4, MidpointRounding.AwayFromZero));

            Console.WriteLine("\nКоэффициент Джини:\nG = " + Math.Round(ConcentrationCalculator.GiniCalculator(departmentsEmployeesShares, departmentsIncomesShares), 4, MidpointRounding.AwayFromZero));
        }
    }
}
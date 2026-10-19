using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialImpl.Calculators
{
    static class ConcentrationCalculators // Includes market concentration index, Herfindahl-Hirshman index and Gini coefficient calculators (practicum 2)
    {
        public static double CrCalculator(double[] shares) { // Market concentration index calculator
            double metric = 0.0;
            int sharesLength = shares.Length;

            for (int i = 0; i < sharesLength; i++) {
                metric += shares[i];
            }

            return metric;
        }

        public static double[] OrderedCrsCalculator(double[] shares) { // Market concentration indexes calculator
            int sharesLength = shares.Length;
            double[] metrics = new double[sharesLength];

            for (int i = 1; i < sharesLength; i++) {
                metrics[i-1] = CrCalculator(shares[0..i]);
            }
            metrics[sharesLength-1] = CrCalculator(shares);

            return metrics;
        }

        public static double HerfindahlHirshmanCalculator(double[] shares) { // Herfindahl-Hirshman index calculator
            double metric = 0.0;
            int sharesLength = shares.Length;

            for (int i = 0; i < sharesLength; i++)
            {
                metric += shares[i]*shares[i];
            }

            return metric;
        }

        public static double GiniCalculator(double[] employeeShares, double[] incomeShares) { // Gini coefficient calculator
            double metric = 1;
            double[] cumulativeIncomeShares = ConcentrationCalculators.OrderedCrsCalculator(incomeShares);
            int sharesLength = employeeShares.Length;

            for (int i = 0; i < sharesLength; i++) metric -= 2 * (employeeShares[i] * cumulativeIncomeShares[i]);
            for (int i = 0; i < sharesLength; i++) metric += employeeShares[i] * incomeShares[i];

            return metric;
        }
    }
}

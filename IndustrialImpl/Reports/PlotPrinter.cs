using ScottPlot;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace IndustrialImpl.Reports
{
    public static class PlotPrinter // Prints many kinds of charts and diagrams
    {
        public static void LorenzCurveChartPrinter(double[] xCoordinates, double[] yCoordinates, string xLabel, string yLabel) {
            // Creating the plot
            var plot = new Plot();

            // Printing the equality line
            var equalityLine = plot.Add.Line(0, 0, 1, 1);
            equalityLine.LinePattern = LinePattern.Dashed;
            equalityLine.Color = Colors.Gray;
            equalityLine.LegendText = "Абсолютное равенство (y = x)";

            // Lorenz curve
            int coordinatesCount = xCoordinates.Length;
            int lorenzCurveCoordinatesCount = coordinatesCount + 1;
            double[] xlorenzCurveCoordinates = new double[lorenzCurveCoordinatesCount];
            xlorenzCurveCoordinates[0] = 0.0;
            double[] ylorenzCurveCoordinates = new double[lorenzCurveCoordinatesCount];
            ylorenzCurveCoordinates[0] = 0.0;
            for (int i = 1; i < lorenzCurveCoordinatesCount; i++) {
                xlorenzCurveCoordinates[i] = xCoordinates[i - 1];
                ylorenzCurveCoordinates[i] = yCoordinates[i - 1];
            }
            var lorenzLine = plot.Add.ScatterLine(xlorenzCurveCoordinates, ylorenzCurveCoordinates);
            lorenzLine.Color = Colors.Blue;
            lorenzLine.LineWidth = 2;
            lorenzLine.LegendText = "Кривая Лоренца";

            // Adding axis labels and title
            plot.Title($"Кривая Лоренца и линия абсолютного равенства");
            plot.XLabel(xLabel);
            plot.YLabel(yLabel);

            ScottPlot.WinForms.FormsPlotViewer.Launch(plot);
        }
    }
}

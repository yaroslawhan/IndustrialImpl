using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialImpl.Reports
{
    public static class ConsolePrinter // Class for console printing
    {
        public static void PrintTable(dynamic[] headers, dynamic[][] rows) // Prints the table into console
        {
            // Defining the width of every column
            int columnsCount = headers.Length;
            int[] columnWidths = new int[columnsCount];

            for (int i = 0; i < columnsCount; i++)
            {
                columnWidths[i] = headers[i].Length;
                foreach (var row in rows)
                {
                    if (row[i].Length > columnWidths[i])
                        columnWidths[i] = row[i].Length;
                }
            }

            // Setup and printing the top string separator
            string stringsSeparator = "+";
            for (int i = 0; i < columnsCount; i++)
                stringsSeparator += new string('-', columnWidths[i] + 2) + "+";
            Console.WriteLine(stringsSeparator);

            // Printing the headers
            string headerLine = "|";
            for (int i = 0; i < headers.Length; i++)
                headerLine += " " + headers[i].PadRight(columnWidths[i]) + " |";
            Console.WriteLine(headerLine);
            Console.WriteLine(stringsSeparator);

            // Printing the data rows
            foreach (var row in rows)
            {
                string line = "|";
                for (int i = 0; i < row.Length; i++)
                    line += " " + row[i].PadRight(columnWidths[i]) + " |";
                Console.WriteLine(line);
            }

            // Printing the bottom line separator
            Console.WriteLine(stringsSeparator);
        }
    }
}

using IndustrialImpl.Calculators;
using IndustrialImpl.Labs;
using IndustrialImpl.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialImpl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Выберите лабораторную работу (1-5, 0 - выход): ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "0": break;
                case "2": Lab2.Run(); break;
                    // ...
            }
        }
    }
}
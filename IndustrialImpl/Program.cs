using IndustrialImpl.Calculators;
using IndustrialImpl.Practicums;
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
            Console.Write("Выберите практикум (1-5, 0 - выход): ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "0": break;
                case "2": Practicum2.Run(); break;
                case "3": Practicum3.Run(); break;
                    // ...
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace Datacenter.Code
{
    class Program
    {
        private const int Generations = 6;

        private readonly IDataFactory<Computer> _factory;

        public Program()
        {
            _factory = new DataFactory<Computer>(
                new ComputerDataStringBuilder()
            );
        }

        public void Run(decimal budget)
        {
            for (int i = 1; i <= Generations; i++)
            {
                int entriesCount = CalculateEntries(i);
                Console.WriteLine($"Entries: {entriesCount}");
                var data = _factory.GenerateEntries(entriesCount);

                Console.WriteLine("Running...");
                var result = Optimiser.FindMaxScore(data, budget);
                Console.WriteLine($"Total efficiency: {result.Item1}");
                Console.WriteLine($"Total price: {result.Item2}");
                Console.WriteLine($"Leftover: {budget - result.Item2}");
                System.Console.WriteLine();
            }
        }

        private static int CalculateEntries(int i)
        {
            return 10 * (int)Math.Pow(2, i);
        }

        static void Main(string[] args)
        {
            var p = new Program();
            p.Run(50_000);
        }
    }
}

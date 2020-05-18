using System;
using System.Diagnostics;

namespace Datacenter.Code
{
    class Program
    {
        private const int Generations = 8;

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

                GC.Collect();
                GC.WaitForPendingFinalizers();

                var sw = new Stopwatch();
                sw.Start();
                var result = Optimiser.FindMaxScore(data, budget);
                sw.Stop();

                Console.WriteLine($"Solution found in {sw.ElapsedMilliseconds.ToString()}ms");
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

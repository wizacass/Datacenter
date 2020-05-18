using System;

namespace Datacenter.Code
{
    public static class Optimiser
    {
        public static Tuple<int, decimal> FindMaxScore(Computer[] data, decimal budget)
        {
            int totalScore = 0;
            decimal totalPrice = 0;
            Sort(data);
            foreach (var computer in data)
            {
                if(computer.Price <= budget)
                {
                    budget -= computer.Price;
                    totalPrice += computer.Price;
                    totalScore += computer.Benchmark;
                }
            }

            return new Tuple<int, decimal>(totalScore, totalPrice);
        }

        private static void Sort(Computer[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                var current = data[i];
                int j = i - 1;

                while (j >= 0 && data[j].CompareTo(current) > 0)
                {
                    data[j + 1] = data[j];
                    j--;
                }

                data[j + 1] = current;
            }
        }
    }
}

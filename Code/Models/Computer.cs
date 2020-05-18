using System;

namespace Datacenter.Code
{
    public class Computer : IComparable<Computer>, IEquatable<Computer>, IParsable
    {
        public int Benchmark { get; private set; }
        public decimal Price { get; private set; }

        public decimal Score => Benchmark / Price;

        public Computer(int benchmark, int price)
        {
            Benchmark = benchmark;
            Price = price;
        }

        public int CompareTo(Computer other)
        {
            return this.Score.CompareTo(other.Score);
        }

        public void Parse(string dataString)
        {
            Parse(dataString.Split());
        }

        public void Parse(string[] dataArray)
        {
            var dateValues = dataArray[0].Split('.');
            try
            {
                Benchmark = int.Parse(dateValues[0]);
                Price = decimal.Parse(dateValues[1]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in parsing Earning data! {ex.Message}");
            }
        }

        public bool Equals(Computer other)
        {
            return Price.Equals(other.Price);
        }
    }
}

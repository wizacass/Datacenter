using System;

namespace Datacenter.Code
{
    public class ComputerDataStringBuilder : IDataStringBuilder
    {
        private readonly Random _rnd;

        public ComputerDataStringBuilder()
        {
            _rnd = new Random(2020);
        }

        public ComputerDataStringBuilder(int seed)
        {
            _rnd = new Random(seed);
        }

        public string GenerateDataString()
        {
            int benchmark = _rnd.Next(1000, 40000);
            decimal price = _rnd.Next(300, 20000);
            return $"{benchmark} {price}";
        }
    }
}

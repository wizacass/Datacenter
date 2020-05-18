using System;

public class Computer: IComparable<Computer>
{
    public int Benchmark { get; }
    public decimal Price { get; }

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
}

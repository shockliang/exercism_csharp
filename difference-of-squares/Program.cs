using System;
using BenchmarkDotNet.Running;

namespace difference_of_squares
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting benchmarking.");
            BenchmarkRunner.Run<Benchmarking>();
        }
    }
}
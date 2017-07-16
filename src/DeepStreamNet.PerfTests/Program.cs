﻿using BenchmarkDotNet.Running;
using System;
using System.Reflection;

namespace DeepStreamNet.PerfTests
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).GetTypeInfo().Assembly).RunAll();

            Console.ReadKey();
        }
    }
}
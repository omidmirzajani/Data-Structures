﻿using System;
using TestCommon;

namespace A3
{
    public class Q3FibonacciLastDigit : Processor
    {
        public Q3FibonacciLastDigit(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            long a = 0;
            long b = 1;
            long c = 0;
            for (int i = 2; i <= n; i++) 
            {
                c = (a + b)%10;
                a = b;
                b = c;
            }
            return c;
        }
    }
}
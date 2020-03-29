using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q2FibonacciFast : Processor
    {
        public Q2FibonacciFast(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            if (n <= 1)
                return n;
            long[] arr = new long[n+1];
            arr[0] = 0;
            arr[1] = 1;
            for (int i = 2; i <= n; i++)
                arr[i] = arr[i - 1] + arr[i - 2];
            return arr[n];


        }
    }
}

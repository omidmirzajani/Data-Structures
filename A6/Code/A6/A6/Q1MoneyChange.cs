using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q1MoneyChange: Processor
    {
        private static readonly int[] COINS = new int[] {1, 3, 4};

        public Q1MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);

        public long Solve(long n)
        {
            long[] arr = new long[n+1];
            arr[0] = 0;
            arr[1] = 1;
            arr[2] = 2;
            arr[3] = 1;
            arr[4] = 1;
            for(int i=5;i<=n;i++)
            {
                arr[i] = Math.Min(Math.Min(arr[i - 1], arr[i - 3]), arr[i - 4]) + 1;
            }
            int c = 0;
            return arr[n];
        }
    }
}

using System;
using TestCommon;

namespace E1b
{
    public class Q4HungryFrog : Processor
    {
        public Q4HungryFrog(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


        public virtual long Solve(long n, long p, long[][] numbers)
        {
            long[] a = new long[n];
            long[] b = new long[n];
            a[0] = numbers[0][0];
            b[0] = numbers[1][0];
            for(int i=1;i<n;i++)
            {
                a[i] = numbers[0][i]+Math.Max(a[i - 1], b[i - 1] - p);
                b[i] = numbers[1][i]+Math.Max(b[i - 1], a[i - 1] - p);
            }
            return Math.Max(a[n - 1], b[n - 1]);

        }
    }
}

using System;
using TestCommon;

namespace A3
{
    public class Q7FibonacciSum : Processor
    {
        public Q7FibonacciSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            Q6FibonacciMod q = new Q6FibonacciMod("");
            long[] pizano = q.Pizano(10);
            long sumPizano = 0;
            for (int i = 0; i < pizano.Length; i++)
                sumPizano += pizano[i];
            long rPizano = 0;
            for (int i = 0; i <= n % pizano.Length; i++) 
                rPizano += pizano[i];

            return (sumPizano * (n / pizano.Length) + rPizano)%10;
        }
    }
}
//            if (n == 1)
//                return a;
//            long[] Mid1 = new long[n / 2];
//            for (int i = 0; i<n / 2; i++)
//                Mid1[i] = a[i];
//            long[] Mid2 = new long[n / 2];
//            for (int i = Convert.ToInt32(n / 2); i<n; i++)
//                Mid2[i] = (a[i]);
//            Mid1 = Solve(Mid1.Length, Mid1);
//Mid2 = Solve(Mid2.Length, Mid2);

//long[] mrg = Merged(Mid1, Mid2);
//            return mrg;
using System;
using TestCommon;

namespace A3
{
    public class Q9FibonacciSumSquares : Processor
    {
        public Q9FibonacciSumSquares(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            Q6FibonacciMod q = new Q6FibonacciMod("");
            long fibN = q.Solve(n, 10);
            long fibN1 = q.Solve(n-1, 10);
            return (fibN * (fibN + fibN1)) % 10;

        }
    }
}

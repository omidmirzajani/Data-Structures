using System;
using TestCommon;

namespace A3
{
    public class Q8FibonacciPartialSum : Processor
    {
        public Q8FibonacciPartialSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            Q7FibonacciSum q = new Q7FibonacciSum("");
            if (b > a)
                (a, b) = (b, a);
            long a1 = q.Solve(a);
            long a2 = q.Solve(b-1);
            if (a1 < a2)
                return a1 - a2 + 10;
            return a1 - a2;

        }
    }
}

using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q6FibonacciMod : Processor
    {
        public Q6FibonacciMod(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            long[] pizano = Pizano(b);
            return pizano[a % pizano.Length];
        }

        public long[] Pizano(long i)
        {
            List<long> list = new List<long>();
            list.Add(0);
            list.Add(1);
            while (true)
            {
                list.Add((list[list.Count - 1] + list[list.Count - 2]) % i);
                if (list[list.Count - 1] == 1 && list[list.Count - 2] == 0)
                {
                    List<long> res = new List<long>();
                    for (int j = 0; j < list.Count - 2; j++)
                        res.Add(list[j]);
                    return res.ToArray();
                }
            }
        }
    }
}

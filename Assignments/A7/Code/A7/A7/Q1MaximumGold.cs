using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;
using System.Linq;
namespace A7
{
    public class Q1MaximumGold : Processor
    {
        public Q1MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {
            long[,] DP = new long[W + 1, goldBars.Length + 1];
            for (int i = 0; i <= W; i++)
                DP[i, 0] = 0;
            for (int i = 0; i <= goldBars.Length; i++)
                DP[0, i] = 0;
            for (int i = 1; i <= W; i++) 
            {
                for (int j = 1; j <= goldBars.Length; j++) 
                {
                    long m1 = DP[i, j - 1];
                    long m2 = -1;
                    if(i>=goldBars[j-1])
                        m2 = DP[i - goldBars[j-1], j - 1]+goldBars[j-1];
                    DP[i, j] = Math.Max(m1, m2);
                }
            }
            return DP[W, goldBars.Length];
        }
    }
}

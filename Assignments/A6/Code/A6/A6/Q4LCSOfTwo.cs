using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q4LCSOfTwo : Processor
    {
        public Q4LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2)
        {
            long[,] arr = new long[seq1.Length + 1, seq2.Length + 1];
            for(int i=0;i<=seq1.Length;i++)
            {
                arr[i, 0] = 0;
            }
            for (int i = 0; i <= seq2.Length; i++)
            {
                arr[0, i] = 0;
            }
            for(int i=1;i<=seq1.Length;i++)
            {
                for (int j = 1; j <= seq2.Length; j++)
                {
                    arr[i, j] = Math.Max(arr[i - 1, j], arr[i, j - 1]);
                    if (seq1[i - 1] == seq2[j - 1])
                        arr[i, j]++;
                }
            }
            return arr[seq1.Length, seq2.Length];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A3
{
    public class Q1MergeSort : Processor
    {
        public Q1MergeSort(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public long[] Solve(long n, long[] a)
        {
            if (n == 1)
                return a;
            long[] Mid1 = new long[n/2];
            for (int i = 0; i < n / 2; i++)
                Mid1[i] = a[i];
            long[] Mid2;
            if (n % 2 != 0)
                Mid2 = new long[n / 2 + 1];
            else
                Mid2 = new long[n / 2];
            for (int i = Convert.ToInt32(n / 2); i < n; i++)
                Mid2[i- Convert.ToInt32(n / 2)] = (a[i]);
            Mid1 = Solve(Mid1.Length, Mid1);
            Mid2 = Solve(Mid2.Length, Mid2);

            long[] mrg = Merged(Mid1, Mid2);
            return mrg;            
        }

        private long[] Merged(long[] mid1, long[] mid2)
        {
            long n = mid1.Length + mid2.Length;
            List<long> res = new List<long>();
            long iter1 = 0;
            long iter2 = 0;
            while(res.Count!=n)
            {
                if (iter1 < mid1.Length && iter2 < mid2.Length)
                {
                    if (mid1[iter1] < mid2[iter2])
                    {
                        res.Add(mid1[iter1]);
                        iter1++;
                    }
                    else
                    {
                        res.Add(mid2[iter2]);
                        iter2++;
                    }
                }
                else
                {
                    for (long i = iter1; i < mid1.Length; i++)
                        res.Add(mid1[i]);
                    for (long i = iter2; i < mid2.Length; i++)
                        res.Add(mid2[i]);

                }
            }
            return res.ToArray();
        }
    }
}
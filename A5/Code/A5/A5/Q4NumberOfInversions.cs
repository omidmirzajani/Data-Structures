using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;
using System.Linq;

namespace A5
{
    public class Q4NumberOfInversions:Processor
    {

        public Q4NumberOfInversions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public virtual long Solve(long n, long[] a)
        {
            if (n < 2)
                return 0;
            long t1 = 0;
            long t2 = 0;
            t1 = (long)a.Length / 2;
            t2 = a.Length - t1;

            long[] mid1 = new long[t1];
            long[] mid2 = new long[t2];
            for (int i = 0; i < t1; i++)
                mid1[i] = a[i];
            for (long i = t1 ; i < a.Length; i++)
                mid2[i - t1 ] = a[i];
            long b = Solve(t1, mid1) + Solve(t2, mid2);
            mid1 = mid1.OrderBy(x => x).ToArray();
            mid2 = mid2.OrderBy(x => x).ToArray();
            long xi = 0;
            long xj = 0;
            long numOfIversion = 0;
            while(xi<t1 && xj<t2)
            {
                if (mid1[xi] > mid2[xj])
                {
                    xj++;
                    numOfIversion += t1 - xi;
                }
                else if (mid1[xi] <= mid2[xj])
                    xi++;
            }
            return numOfIversion + b;
            //long res = 0;
            //for(int i=0;i<t1;i++)
            //{
            //    long j = t2 - 1;
            //    while ((j>=0) && (mid2[j] >= mid1[i]))
            //        j--;
            //    if (j >= 0)
            //        res += (j+1);
            //}
            //return res + b;
        }
    }
}

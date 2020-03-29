using System;
using System.Collections.Generic;
using TestCommon;
using System.Linq;

namespace A9
{
    public class Q1ConvertIntoHeap : Processor
    {

        public Q1ConvertIntoHeap(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long[] b)
        {
            List<Tuple<long, long>> omid = new List<Tuple<long, long>>();

            long n = b.Length;
            for(int i=Convert.ToInt32(n/2);i>=0;i--)
            {
                SiftDown(b,i,omid);                
            }
            return omid.ToArray();
        }

        public void SiftDown(long[] b, long i, List<Tuple<long, long>> omid)
        {
            long n = b.Length;
            long maxIndex = i;
            long l = 2 * i + 1;
            if (l < n && b[l] < b[maxIndex])
                maxIndex = l;
            long r = 2 * i + 2;
            if (r < n && b[r] < b[maxIndex])
                maxIndex = r;
            if (i != maxIndex)
            {
                long swap = b[i];
                b[i] = b[maxIndex];
                b[maxIndex] = swap;
                omid.Add(new Tuple<long, long>(i, maxIndex));
                SiftDown(b,maxIndex,omid);
            }
        }
    }
}

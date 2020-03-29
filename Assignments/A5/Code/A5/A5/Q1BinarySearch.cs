using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q1BinarySearch : Processor
    {
        public Q1BinarySearch(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long [], long[]>)Solve);


        public virtual long[] Solve(long []a, long[] b) 
        {
            long[] res = new long[b.Length  ];
            for (int i = 0; i < b.Length; i++)
                res[i] = Binary(b[i], a,0,a.Length-1);
            return res;

        }

        public long Binary(long v, long[] a, long v1, long v2)
        {
            if (v1>v2)
                return -1;
            if (v1==v2)
                if (a[v1] == v)
                    return v1;
                else
                    return -1;
            long t1 = 0;
            long t2 = 0;
            t1 = (long)(v2 - v1 + 1) / 2;
            t2 = (long)(v2 - v1 + 1) - t1 - 1;            
            long mid = a[t1+v1];            
            if (mid == v)
                return t1+v1;
            if (v > mid)
            {
                
                long rec = Binary(v, a,v1+t1+1,v2);
                return rec;
            }
            else
            {
                long rec = Binary(v, a,v1,v1+t1-1);
                return rec;
            }
        }
    }
}

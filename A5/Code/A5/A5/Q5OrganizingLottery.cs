using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q5OrganizingLottery:Processor
    {
        public Q5OrganizingLottery(string testDataName) : base(testDataName)
        {}
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public virtual long[] Solve(long[] points, long[] startSegments, long[] endSegment)
        {
            long[] res = new long[points.Length];
            for(int i=0;i<points.Length;i++)
            {
                long t = 0;
                for(int j=0;j<startSegments.Length;j++)
                {
                    if (points[i] <= endSegment[j] && points[i] >= startSegments[j])
                        t++;
                }
                res[i] = t;
            }
            return res;
        }
    }
}

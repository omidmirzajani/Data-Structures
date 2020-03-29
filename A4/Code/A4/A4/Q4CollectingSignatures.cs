using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q4CollectingSignatures : Processor
    {
        public Q4CollectingSignatures(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long tenantCount, long[] startTimes, long[] endTimes)
        {
            long left = startTimes.Min();
            long right = endTimes.Max();
            //long[] Dots = new long[right+1];
            //for (long i = left; i <= right; i++) 
            //{
            //    Dots[i] = 0;
            //}
            //for (int i = 0; i < tenantCount; i++)
            //{
            //    for(long j = startTimes[i];j<=endTimes[i];j++)
            //    {
            //        Dots[j]++;
            //    }
            //}
            //while(!allNegative(Dots))
            //{
            //}
            for (int i = 0; i < tenantCount; i++)
            {
                for (int j = i + 1; j < tenantCount; j++)
                {
                    if (endTimes[i] > endTimes[j])
                    {
                        (startTimes[i], startTimes[j]) = (startTimes[j], startTimes[i]);
                        (endTimes[i], endTimes[j]) = (endTimes[j], endTimes[i]);
                    }
                }
            }
            long count=0;
            long[] visited = new long[tenantCount];
            for(int i=0;i<tenantCount;i++)
            {
                visited[i] = 0;
            }
            int c = 0;
            while(!AllVisited(visited))
            {
                while(visited[c]!=0)
                {
                    c++;
                }
                long end = endTimes[c];
                int k = 0;
                for(int j=0;j<tenantCount;j++)
                {
                    if (visited[j] == 0 && end >= startTimes[j] && end <= endTimes[j])
                    {
                        visited[j] = 1;
                        k = 1;
                    }
                }
                count += k;
                c++;
            }
            return count;
        }


        public bool AllVisited(long[] dots)
        {
            for (int i = 0; i < dots.Length; i++)
                if (dots[i] == 0)
                    return false;
            return true;
        }

    }
}

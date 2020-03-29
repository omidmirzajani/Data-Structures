using System;
using System.Collections.Generic;
using TestCommon;

namespace E1a
{
    public class Q1Stones : Processor
    {
        public Q1Stones(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] stones)
        {
            long s = 0;
            List<long> l = new List<long>();
            for(int i=0;i< stones.Length; i++)
            {
                s += stones[i];
                l.Add(s);
            }
            
            int c = 0;
            if (l[0] > n)
                return 1;
            for(int i=0;i<stones.Length-1;i++)
            {
                if (l[i] < n && l[i + 1] > n)
                    return i + 2;
                if (l[i] == n)
                    return i + 1;
                
            }
            if (n == l[stones.Length - 1])
                return stones.Length;
            return 0;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;
using System.Linq;
namespace A6
{
    public class Q2PrimitiveCalculator : Processor
    {
        public Q2PrimitiveCalculator(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) => 
            TestTools.Process(inStr, (Func<long, long[]>) Solve);

        public long[] Solve(long n)
        {
            // 1 2 2 3
            // 1 1 1 2
            List<long> t = new List<long>() { 0, 1};
            List<long> LastNum = new List<long>() { 0, 1};

            for (int i=2;i<=n;i++)
            {
                long a1 = int.MaxValue;
                long a2 = int.MaxValue;
                long a3 = t[i - 1];
                if (i % 3 == 0)
                    a1 = t[i / 3];
                if (i % 2 == 0)
                    a2 = t[i / 2];
                if (a1 <= Math.Min(a2, a3))
                {
                    LastNum.Add(i / 3);
                    t.Add(t[i / 3] + 1);
                }
                else if (a2 <= Math.Min(a1, a3))
                {
                    LastNum.Add(i / 2);
                    t.Add(t[i / 2] + 1);
                }                
                else
                {
                    LastNum.Add(i - 1);
                    t.Add(t[i - 1] + 1);
                }
            }
            List<long> res = new List<long>();
            res.Add(n);
            long ind = n;
            while(ind!=1)
            {
                ind = LastNum[(int)ind];
                res.Add(ind);
            }
            res.Reverse();
            return res.ToArray();
        }

        private long[] Omid(List<long> list, int i)
        {

            List<long> tmp = new List<long>();
            for(int j=0;j<list.Count;j++)
            {
                tmp.Add(list[j]);
            }
            tmp.Add(i);
            return tmp.ToArray();
        }
    }
}

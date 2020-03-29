using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q5MaximizeNumberOfPrizePlaces : Processor
    {
        public Q5MaximizeNumberOfPrizePlaces(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>) Solve);


        public virtual long[] Solve(long n)
        {
            if (n < 3)
                return new long[1] { n };
            if (n == 5)
                return new long[2] { 2, 3 };
            long i = (long)Math.Sqrt(2*n+2);
            while(true)
            {
                if(i==0)
                    return new long[2] { 2, 3 }; 
                long sum = i * (i + 1);
                sum = sum / 2;
                if (n - sum >= i)
                {
                    
                    List<long> list = new List<long>();
                    for (long j = 1; j <= i; j++)
                        list.Add(j);
                    list.Add(n - sum);
                    return list.ToArray();
                }
                i--;
            }
        }
    }
}


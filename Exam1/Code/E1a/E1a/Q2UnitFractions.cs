using System;
using System.Collections.Generic;
using TestCommon;

namespace E1a
{
    public class Q2UnitFractions : Processor
    {
        public Q2UnitFractions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);


        public virtual long Solve(long nr, long dr)
        {
            if (dr % nr == 0)
                return dr/nr;
            if (nr % dr == 0)
                return 1;
            long n = (long)(dr / nr) + 1;            
            long a1 = nr * n - dr;
            long a2 = dr * n;            
            return Solve(a1,a2);
            //if (nr % dr == 0)
            //    return 1;
            //if(num!=1)                
            //    num -= (int)num;
            //int i = 1;
            //long res = 0;
            //while(num>=(1.0/1996500924))
            //{
            //    if((1.0/i<=num))// || ((1.0/i-num< (0.000000001))&&(1.0/i>num)))
            //    {
            //        num -= (double)1.0 / i;
            //        res = i;
            //    }
            //    i++;
            //}
            //return res;
        }
    }
}

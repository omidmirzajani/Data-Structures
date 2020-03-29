using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;
using System.Linq;
namespace A5
{
    public class Q2MajorityElement:Processor
    {

        public Q2MajorityElement(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] a)
        {
            a = a.OrderBy(x => x).ToArray();
            for (int i=0;i<n/2;i++)
            {               
                if (a[i] == a[i + n / 2])
                    return 1;
            }
            return 0;
        }
    }
}

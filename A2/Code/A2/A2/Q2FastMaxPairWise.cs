using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q2FastMaxPairWise : Processor
    {
        public Q2FastMaxPairWise(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) => 
            Solve(inStr.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                 .Select(s => long.Parse(s))
                 .ToArray()).ToString();

        public virtual long Solve(long[] numbers)
        {
            long Max1 = 0;
            long Max2 = 0;
            int j = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > Max1)
                {
                    j = i;
                    Max1 = numbers[i];
                }
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > Max2 && j != i)
                    Max2 = numbers[i];
            }

            
            return Max1 * Max2;


        }
    }
}

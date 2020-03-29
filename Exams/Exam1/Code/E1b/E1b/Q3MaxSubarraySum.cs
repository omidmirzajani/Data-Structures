using System;
using System.Collections.Generic;
using TestCommon;

namespace E1b
{
    public class Q3MaxSubarraySum : Processor
    {
        public Q3MaxSubarraySum(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] numbers)
        {
            if (n == 1)
                return numbers[0];
            long t1 = 0;
            long t2 = 0;
            if(n%2==0)
            {
                t1 = (long)n / 2;
                t2 = (long)n / 2;
            }
            else
            {
                t1= (long)n / 2;
                t2 = n - t1;
            }
            long[] mid1 = new long[t1];
            long[] mid2 = new long[t2];
            for (int i = 0; i < t1; i++)
                mid1[i] = numbers[i];
            for (long i = t1; i < n; i++)
                mid2[i - t1] = numbers[i];
            long res1 = Solve(mid1.Length, mid1);
            long res2 = Solve(mid2.Length, mid2);

            long[] sum2 = new long[t2];
            sum2[0] = numbers[t1];
            for(int i=1;i<t2;i++)
            {
                sum2[i] = sum2[i - 1] + numbers[i + t1];
            }
            long[] sum1 = new long[t1];
            sum1[0] = numbers[t1-1];
            for (int i = 1;i<t1;i++ )
            { 
                sum1[i] = sum1[i - 1] + numbers[t1-i-1];
            }

            long res3 = Max(sum2) + Max(sum1);
            return (Math.Max(Math.Max(res1, res2), res3));
            //long[] sum = new long[n];
            //sum[0] = numbers[0];
            //for(int i=1;i<n;i++)
            //{
            //    sum[i] = sum[i - 1] + numbers[i];
            //}
            //List<long> res = new List<long>();   
            //for(int i=0;i<n;i++)
            //{
            //    for(int j = i; j<n;j++)
            //    {
            //        res.Add(sum[j] - sum[i]);
            //    }
            //}
            //return Max(res.ToArray());
        }

        private long Min(long[] sum)
        {
            long min = sum[0];
            for (int i = 0; i < sum.Length; i++)
                min = Math.Min(min, sum[i]);
            return min;
        }

        private long Max(long[] sum)
        {
            long max = sum[0];
            for (int i = 0; i < sum.Length; i++)
                max = Math.Max(max, sum[i]);
            return max;
        }

        private long MaximomFrom(long[] sum, int i)
        {
            if (i == sum.Length-1)
                return 0;
            long max = sum[i + 1];
            for (int j = i+1; j < sum.Length; j++)
                if (sum[j] > max)
                    max = sum[j];
            return max;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q2MaximizingLoot : Processor
    {
        public Q2MaximizingLoot(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long capacity, long[] weights, long[] values)
        {
            float[] better = new float[weights.Length];
            for(int i = 0;i<weights.Length;i++)
            {
                better[i] = (float)values[i] / weights[i];
            }
            for(int i=0;i<weights.Length;i++)
            {
                for(int j =i+1;j<weights.Length;j++)
                {
                    if(better[j]>better[i])
                    {
                        (better[i], better[j]) = (better[j], better[i]);
                        (weights[i], weights[j]) = (weights[j], weights[i]);
                        (values[i], values[j]) = (values[j], values[i]);
                    }
                }
            }
            double value = 0;
            for(int i = 0; i < weights.Length; i++)
            {
                if(weights[i]>capacity)
                {
                    value += (float)capacity * ((float)values[i]/weights[i]);
                    capacity =0;
                }
                else
                {
                    value += values[i];
                    capacity -=weights[i];
                }
            }
            return (long)value;
        }


        //public override Action<string, string> Verifier { get; set; } =
        //  TestTools.ApproximateLongVerifier;

    }
}

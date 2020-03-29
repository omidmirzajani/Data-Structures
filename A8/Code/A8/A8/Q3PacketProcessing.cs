using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q3PacketProcessing : Processor
    {
        public Q3PacketProcessing(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long[]>)Solve);

        public long[] Solve(long bufferSize, long[] arrivalTimes, long[] processingTimes)
        {
            long n = arrivalTimes.Length;
            List<long> res = new List<long>();
            Queue<long[]> buffer = new Queue<long[]>();
            long[][] Sarotah = new long[n][];
            long t = 0;
            long end = 0;
            long time = 0;

            for (long i = 0; i < n; i++)
                Sarotah[i] = new long[2] { arrivalTimes[i], processingTimes[i] };

            
            for (long i = 0; i < n; i++)            
                if (arrivalTimes[i] == time)
                {
                    while ((t > 0) && (buffer.Peek()[0]+buffer.Peek()[1] <= time))
                    {
						buffer.Dequeue();
                        t--;                        
                    }

                    if (bufferSize > t)
                    {
                        if (t == 0)
                            end = time + processingTimes[i];
                        else
                        {
                            Sarotah[i][0] = end;
                            end += processingTimes[i];
                        }
						buffer.Enqueue(Sarotah[i]);
                        t++;                        
                        res.Add(Sarotah[i][0]);
                    }
                    else
                        res.Add(-1);
                }
                else
                {
                    i--;
                    time++;
                }            
            return res.ToArray();
        }
    }
}

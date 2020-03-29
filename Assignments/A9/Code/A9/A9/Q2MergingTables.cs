using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q2MergingTables : Processor
    {
        long[] parent;
        long[] tableSizes;
        long[] rank;

        public Q2MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);


        public long[] Solve(long[] tableSizes, long[] targetTables, long[] sourceTables)
        {
            long[] id = new long[tableSizes.Length+1];
            long[] size = new long[tableSizes.Length+1];
            List<long> res = new List<long>();

            for (int i = 1; i <= tableSizes.Length; i++)
            {
                id[i] = i;
                size[i] = tableSizes[i-1];
            }
            for(int i=0;i<targetTables.Length;i++)
            {
                long a = targetTables[i];
                long b = sourceTables[i];
                long ida = id[a];
                long idb = id[b];
                long sizeb = size[b];
                long sizea = size[a];
                if(ida!=idb)
                {
                    for (int j = 0; j < id.Length; j++)
                    {
                        if (id[j] == ida)
                            size[j] += sizeb;
                        if (id[j] == idb)
                            size[j] += sizea;

                        if (id[j] == ida)
                            id[j] = idb;

                    }
                }
                res.Add(size.Max());
            }
            return res.ToArray();
        }

    }
}

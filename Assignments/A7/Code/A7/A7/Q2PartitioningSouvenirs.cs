using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q2PartitioningSouvenirs : Processor
    {
        public Q2PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            long Sum = sum(souvenirs);
            if (Sum % 3 != 0)
                return 0;
            bool[,] arr = new bool[souvenirsCount + 1, 1 + 2*Sum / 3];
            for (int i = 0; i <= souvenirsCount; i++)
                arr[i, 0] = true;
            for (int i = 1; i <= 2*Sum / 3; i++) 
                arr[0,i] = false;
            for (int i = 1; i <= souvenirsCount; i++) 
            {
                for (int j = 1; j <= 2*Sum / 3; j++) 
                {
                    bool a1 = arr[i - 1, j];
                    bool a2 = false;
                    if (j >= souvenirs[i - 1])
                        a2 = arr[i - 1, j - souvenirs[i - 1]];
                    if (a1 == true || a2 == true)
                        arr[i, j] = true;
                }
            }
            if (souvenirsCount == 0)
                return 0;
            if (arr[souvenirsCount, 2*Sum / 3] && arr[souvenirsCount, Sum / 3])
                return 1;
            return 0;            
        }
        public long sum(long[] souvenirs)
        {
            long s = 0;
            for (int I = 0; I < souvenirs.Length; I++)
                s += souvenirs[I];
            return s;
        }
    }
}

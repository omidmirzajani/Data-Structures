﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q3EditDistance : Processor
    {
        public Q3EditDistance(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string str1, string str2)
        {
            long[,] arr = new long[str1.Length+1, str2.Length+1];
            for(int i=0;i<=str1.Length;i++)
            {
                arr[i, 0] = i;
            }
            for (int i = 0; i <= str2.Length; i++)
            {
                arr[0, i] = i;
            }
            for(int i=1;i<=str1.Length;i++)
            {
                for(int j=1;j<=str2.Length;j++)
                {
                    long a1 = arr[i - 1, j]+1;
                    long a2 = arr[i, j - 1]+1;
                    long a3 = arr[i - 1, j - 1];
                    if (str1[i-1] != str2[j-1])
                        a3++;
                    arr[i, j] = Math.Min(a1, Math.Min(a2, a3));
                }
            }
            return arr[str1.Length, str2.Length];
        }
    }
}

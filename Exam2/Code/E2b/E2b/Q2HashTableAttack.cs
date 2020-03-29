﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestCommon;

namespace E2b
{
    public class Q2HashTableAttack : Processor
    {
        public Q2HashTableAttack(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr)
        {
            long bucketCount = long.Parse(inStr);
            return string.Join("\n", Solve(bucketCount));
        }

        public string[] Solve(long bucketCount)
        {
            long lb = bucketCount;            
            bucketCount = Convert.ToInt32(0.9 * bucketCount);
            List<string> s = new List<string>();
            s.Add("as");
            long gt = GetBucketNumber("as", lb);
			Random r1 = new Random();
            Random r2 = new Random();
            while (s.Count != bucketCount)
            {               
                string t = "";
                t += LowChars[r1.Next() % LowChars.Length];
                t += LowChars[r2.Next() % LowChars.Length];
                if (GetBucketNumber(t, lb) == gt)
                    s.Add(t);
            }
            return s.ToArray();
        }

        #region Chars
        static char[] LowChars = Enumerable
            .Range(0, 26)
            .Select(n => (char)('a' + n))
            .ToArray();

        static char[] CapChars = Enumerable
            .Range(0, 26)
            .Select(n => (char)('A' + n))
            .ToArray();

        static char[] Numbers = Enumerable
            .Range(0, 10)
            .Select(n => (char)('0' + n))
            .ToArray();

        static char[] AllChars =
            LowChars.Concat(CapChars).Concat(Numbers).ToArray();
        #endregion


        // پیاده‌سازی مورد استفاده دات‌نت برای پیدا کردن شماره باکت
        // https://referencesource.microsoft.com/#mscorlib/system/collections/generic/dictionary.cs,bcd13bb775d408f1
        public static long GetBucketNumber(string str, long bucketCount) =>
            (str.GetHashCode() & 0x7FFFFFFF) % bucketCount;

        

    }
}

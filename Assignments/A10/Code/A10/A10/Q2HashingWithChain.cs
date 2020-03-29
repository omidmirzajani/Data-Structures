using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A10
{
    public class Q2HashingWithChain : Processor
    {
        public Q2HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);

        protected Dictionary<long, LinkedList<string>> con = new Dictionary<long, LinkedList<string>>();
        long bucket_count = 0;
        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public string[] Solve(long bucketCount, string[] commands)
        {
            con.Clear();
            bucket_count = bucketCount;
            List<string> result = new List<string>();
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];

                switch (cmdType)
                {
                    case "add":
                        Add(arg);
                        break;
                    case "del":
                        Delete(arg);
                        break;
                    case "find":
                        result.Add(Find(arg));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg)));
                        break;
                }
            }
            return result.ToArray();
        }

        public static long PolyHash(
            string str, int start, int count,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            long Tx = 1;
            for (int i = start; i < start + count; i++)
            {
                long Increase = Tx * (long)str[i] % p;
                hash = (long)(hash + Increase) % p;
                Tx = (x * Tx) % p;
            }
            return hash;
        }

        public void Add(string str)
        {
            long n = PolyHash(str, 0, str.Length) % bucket_count;
            if (!con.ContainsKey(n))
            {
                LinkedList<string> add = new LinkedList<string>();
                add.AddFirst(str);
                con.Add(n, add);
            }
            else
                if (!con[n].Contains(str))
                    con[n].AddFirst(str);
        }

        public string Find(string str)
        {
            long n = PolyHash(str, 0, str.Length) % bucket_count;
            if (!con.ContainsKey(n))
                return "no";
            if (con.ContainsKey(n))
                if (con[n].Contains(str))
                    return "yes";
                else
                    return "no";
            return "";
        }


        public void Delete(string str)
        {
            long n = PolyHash(str, 0, str.Length) % bucket_count;
            if (con.ContainsKey(n))
                if (con[n].Contains(str))
                    con[n].Remove(str);
        }

        public string Check(int i)
        {
            string answer = "";
            if (!con.ContainsKey(i))
                return "-";
            if (con[i].Count == 0)
                return "-";
            for (int j = 0; j < con[i].Count; j++)
            {
                if (j != con[i].Count - 1)
                    answer += con[i].ElementAt(j) + " ";
                else
                    answer += con[i].ElementAt(j);
            }
            return answer;
            
        }
    }
}

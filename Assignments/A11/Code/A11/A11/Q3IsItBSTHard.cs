using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q3IsItBSTHard : Processor
    {
        public Q3IsItBSTHard(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);

        public bool Solve(long[][] nodes)
        {
            var t = InOrder(nodes);
            List<long> s = new List<long>();
            for (int i = 0; i < nodes.Length; i++)
                s.Add(nodes[i][0]);
            s.Sort();
            if (!Eq(s.ToArray(), t))
                return false;
            for (int r = 0; r < nodes.Length; r++)
            {
                if (nodes[r][1] != -1)
                {
                    long[] left = Left(nodes, r);
                    for (int i = 0; i < left.Length; i++)
                        if (Con(left, i + 1, left[i]))
                            return false;
                }
            }
            return true;

            #region Comment
            //Queue<long> leaf = new Queue<long>();
            //bool[] visited = new bool[nodes.Length];
            //long[] max = new long[nodes.Length];
            //long[] min = new long[nodes.Length];
            //Dictionary<long, long> father = new Dictionary<long, long>();
            //for (int i = 0; i < nodes.Length; i++)
            //{
            //    if (nodes[i][1] == -1 && nodes[i][2] == -1)
            //    {
            //        leaf.Enqueue(i);
            //        visited[i] = true;
            //        max[i] = nodes[i][0];
            //        min[i] = nodes[i][0];
            //    }
            //    if (nodes[i][1] != -1)
            //        father[nodes[i][1]] = i;
            //    if (nodes[i][2] != -1)
            //        father[nodes[i][2]] = i;
            //}
            //while (leaf.Count > 0)
            //{
            //    long x = leaf.Count;
            //    for (int i = 0; i < x; i++)
            //    {
            //        long sar = leaf.Peek();
            //        if (sar != 0)
            //            if (!leaf.Contains(father[sar]))
            //                leaf.Enqueue(father[sar]);
            //        leaf.Dequeue();

            //    }
            //    foreach (var e in leaf)
            //    {
            //        if (!visited[e])
            //        {
            //            long rightMax = long.MinValue;
            //            long leftMax = long.MinValue;
            //            if (nodes[e][2] != -1)
            //                rightMax = max[nodes[e][2]];
            //            if (nodes[e][1] != -1)
            //                leftMax = max[nodes[e][1]];
            //            max[e] = Math.Max(Math.Max(leftMax, rightMax), nodes[e][0]);

            //            long rightMin = long.MaxValue;
            //            long leftMin = long.MaxValue;
            //            if (nodes[e][2] != -1)
            //                rightMin = min[nodes[e][2]];
            //            if (nodes[e][1] != -1)
            //                leftMin = min[nodes[e][1]];
            //            min[e] = Math.Min(Math.Min(leftMin, rightMin), nodes[e][0]);

            //            visited[e] = true;

            //            if (nodes[e][0] <= leftMax || nodes[e][0] > rightMin)
            //                return false;
            //        }
            //    }
            //}
            //return true;
            #endregion
        }

        private bool Con(long[] left, int v1, long v2)
        {
            for (int i = v1; i < left.Length; i++)
                if (left[i] == v2)
                    return true;
            return false;
        }

        private bool Eq(long[] v, long[] t)
        {
            for (int i = 0; i < v.Length; i++)
                if (v[i] != t[i])
                    return false;
            return true;
        }
        public long[] InOrder(long[][] nodes)
        {
            List<long> res = new List<long>();
            Stack<long> s = new Stack<long>();
            long root = 0;
            while (true)
            {
                while (root != -1)
                {
                    s.Push(root);
                    root = nodes[root][1];
                }
                if (s.Count == 0)
                    return res.ToArray();
                root = s.Pop();
                res.Add(nodes[root][0]);
                root = nodes[root][2];
            }
        }
        public long[] Left(long[][] nodes,long r)
        {
            List<long> res = new List<long>();
            Stack<long> s = new Stack<long>();
            long root = r;
            while (true)
            {
                while (root != -1)
                {
                    s.Push(root);
                    root = nodes[root][1];
                }
                root = s.Pop();
                res.Add(nodes[root][0]);
                if (root == r)
                    return res.ToArray();
                root = nodes[root][2];
            }
        }
    }
}

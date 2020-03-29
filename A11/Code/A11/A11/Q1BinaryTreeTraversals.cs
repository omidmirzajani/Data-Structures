using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q1BinaryTreeTraversals : Processor
    {
        public Q1BinaryTreeTraversals(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);

        public long[][] Solve(long[][] nodes)
        {
            List<long[]> res = new List<long[]>();
            res.Add(InOrder(nodes));
            res.Add(PreOrder(nodes));
            res.Add(PostOrder(nodes));            
            return res.ToArray();
        }

        public long[] PostOrder(long[][] nodes)
        {
            Stack<long> s1 = new Stack<long>();
            Stack<long> s2 = new Stack<long>();
            List<long> res = new List<long>();
            long root = 0;
            s1.Push(root);
            while(s1.Count>0)
            {
                long tmp = s1.Pop();
                s2.Push(tmp);
                if (nodes[tmp][1] != -1)
                    s1.Push(nodes[tmp][1]);
                if (nodes[tmp][2] != -1)
                    s1.Push(nodes[tmp][2]);
            }
            while (s2.Count > 0)
                res.Add(nodes[s2.Pop()][0]);
            return res.ToArray();

        }

        public long[] PreOrder(long[][] nodes)
        {
            List<long> res = new List<long>();
            Stack<long> s = new Stack<long>();
            long root = 0;
            while(true)
            {
                while(root!=-1)
                {
                    res.Add(nodes[root][0]);
                    s.Push(root);
                    root = nodes[root][1];

                }
                if (s.Count == 0)
                    return res.ToArray();
                root = s.Pop();
                root = nodes[root][2];
            }
        }

        public long[] InOrder(long[][] nodes)
        {
            List<long> res = new List<long>();
            Stack<long> s = new Stack<long>();
            long root = 0;
            while (true)
            {
                while(root!=-1)
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
    }
}
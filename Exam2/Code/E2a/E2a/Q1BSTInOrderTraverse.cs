using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace E2a
{
    public class Q1BSTInOrderTraverse : Processor
    {
        public Q1BSTInOrderTraverse(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public long[] Solve(long n, long[] BST)
        {
            long root = 0;
            List<long> res = new List<long>();
            Stack<long> s = new Stack<long>();
            while (true)
            {
                while (BST[root] != -1)
                {
                    s.Push(root);
                    root = 2 * root + 1;
                }
                if (s.Count == 0)
                    return res.ToArray();
                res.Add(BST[s.Peek()]);
                root = s.Peek() * 2 + 2;
                s.Pop();
            }

        }

        
    }
}
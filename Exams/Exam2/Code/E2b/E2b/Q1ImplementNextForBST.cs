using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace E2b
{
    public class Q1ImplementNextForBST : Processor
    {
        public Q1ImplementNextForBST(string testDataName) : base(testDataName) 
        {
            //this.ExcludeTestCaseRangeInclusive(1, 10);
        }
        public override string Process(string inStr)
        {
            long n, node;
            var lines = inStr.Split(TestTools.NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            TestTools.ParseTwoNumbers(lines[0], out n, out node);
            var bst = lines[1].Split(TestTools.IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => long.Parse(x))
                .ToArray();

            return Solve(n, node, bst).ToString();
        }

        public long Solve(long n, long node, long[] BST)
        {
            long m4 = 2 * node + 2;
            long m3 = node;
            long m1 = node;
            long m2 = node;
            if (node % 2 == 0)
            {
                m1 = father(node);
                m1 = father(m1);
                
            }
            else
            {
                m2 = father(node);
                
            }
            if(BST[m4]!=-1)
            {
                long t = m4;
                while (BST[t] != -1)
                    t = 2 * t + 1;
                m3 = father(t);
            }
            if (m1 == node)
            {
                if (BST[node] > BST[m2] && BST[node] > BST[m3])
                    return -1;
                if (BST[m2] > BST[node] && BST[m3] > BST[node])
                {
                    if (BST[m2] > BST[m3])
                        return m3;
                    else
                        return m2;

                }
                if (BST[m2] > BST[node] && BST[m3] <= BST[node])
                {
                    return m2;
                }
                if (BST[m2] <= BST[node] && BST[m3] > BST[node])
                {
                    return m3;
                }

            }
            else if (m2 == node)
            {
                if (BST[node] > BST[m1] && BST[node] > BST[m3])
                    return -1;
                if (BST[m1] > BST[node] && BST[m3] > BST[node])
                {
                    if (BST[m1] > BST[m3])
                        return m3;
                    else
                        return m1;

                }
                if (BST[m1] > BST[node] && BST[m3] <= BST[node])
                {
                    return m1;
                }
                if (BST[m1] <= BST[node] && BST[m3] > BST[node])
                {
                    return m3;
                }
            }
            return -1;
        }
        private long father(long node)
        {
            if (node == 0)
                return 0;
            if (node % 2 == 0)
                return (long)(node / 2) - 1;
            return (long)(node / 2);
        }
    }
}
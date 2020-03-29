using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestCommon;

namespace E2a
{
    public class Q2ThreeChildrenMinHeap : Processor
    {
        public Q2ThreeChildrenMinHeap(string testDataName) : base(testDataName) { }
        public override string Process(string inStr)
        {
            long n;
            long changeIndex, changeValue;
            long[] heap;
            using (StringReader reader = new StringReader(inStr))
            {
                n = long.Parse(reader.ReadLine());

                string line = null;
                line = reader.ReadLine();

                TestTools.ParseTwoNumbers(line, out changeIndex, out changeValue);

                line = reader.ReadLine();
                heap = line.Split(TestTools.IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => long.Parse(x)).ToArray();
            }

            return string.Join("\n", Solve(n, changeIndex, changeValue, heap));

        }
        public long[] Solve(long n, long changeIndex, long changeValue, long[] heap)
        {
            heap[changeIndex] += changeValue;
            long l = Left(changeIndex);
            long m = Mid(changeIndex);
            long r = Right(changeIndex);
            long val = heap[changeIndex];
            if (val <= heap[l] && val <= heap[m] && val <= heap[r])
                return heap;
            var res = SiftDown(heap,changeIndex);
            return res.ToArray();

        }

        private List<long> SiftDown(long[] heap, long i)
        {
            long minindex=i;
            long l = Left(i);
            long m = Mid(i);
            long r = Right(i);
            if (l < heap.Length && heap[l] < heap[minindex])
                minindex = l;
            if (m < heap.Length && heap[m] < heap[minindex])
                minindex = m;
            if (r < heap.Length && heap[r] < heap[minindex])
                minindex = r;
            if(i!=minindex)
            {
                long tmp = heap[i];
                heap[i] = heap[minindex];
                heap[minindex] = tmp;
                return SiftDown(heap, minindex);
            }
            return heap.ToList();
            //long m = Mid(i);
            //long r = Right(i);
        }

        private long Right(long changeIndex)
        {
            return changeIndex * 3 + 3;
        }

        private long Mid(long changeIndex)
        {
            return changeIndex * 3 + 2;
        }

        private long Left(long changeIndex)
        {
            return changeIndex * 3 + 1;
        }

        private long father(long i)
        {
            if (i % 3 == 0)
                return (long)(i / 3) - 1;
            return (long)(i / 3);
        }
    }
}

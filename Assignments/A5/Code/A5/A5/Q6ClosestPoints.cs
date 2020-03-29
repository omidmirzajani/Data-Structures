using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;
using System.Linq;
namespace A5
{
    public class Q6ClosestPoints : Processor
    {
        public Q6ClosestPoints(string testDataName) : base(testDataName)
        { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], double>)Solve);

        public virtual double Solve(long n, long[] xPoints, long[] yPoints)
        {
            if (n == 1)
                return 1000;
            if (n < 2)
                return 0;
            if (n == 2)
            {
                long c = (xPoints[0] - xPoints[1]) * (xPoints[0] - xPoints[1]);
                long h = (yPoints[0] - yPoints[1]) * (yPoints[0] - yPoints[1]);
                return Math.Sqrt(c + h);
            }


            List<List<long>> Mokhtasat = new List<List<long>>();
            for (int i = 0; i < n; i++)
            {
                Mokhtasat.Add(new List<long> { xPoints[i], yPoints[i] });
            }
            Mokhtasat =  Mokhtasat.OrderBy(x => (double)x.First()).ToList();
            long[] mid = Mokhtasat[(int)(n / 2)].ToArray();
            List<long> newX1 = new List<long>();
            List<long> newY1 = new List<long>();

            List<long> newX2 = new List<long>();
            List<long> newY2 = new List<long>();

            for (int i = 0; i <= (int)(n / 2)-1; i++)
            {
                newX1.Add(Mokhtasat[i][0]);
                newY1.Add(Mokhtasat[i][1]);
            }
            for (int i = (int)(n / 2) + 1; i < n; i++)
            {
                newX2.Add(Mokhtasat[i][0]);
                newY2.Add(Mokhtasat[i][1]);
            }
            double d1 = Solve(newX1.Count, newX1.ToArray(), newY1.ToArray());
            double d2 = Solve(newX2.Count, newX2.ToArray(), newY2.ToArray());

            double d = d1;
            if (d2 < d1)
                d = d2;


            List<long> midX = new List<long>();
            List<long> midY = new List<long>();

            for (int i = 0; i < n; i++)
            {
                if (xPoints[i] < mid[0] + d && xPoints[i] > mid[0] - d)
                {
                    midX.Add(xPoints[i]);
                    midY.Add(yPoints[i]);
                }
            }
            double min = double.MaxValue;
            for (int i = 0; i < midX.Count; i++)
            {
                for (int j = i + 1; j < midX.Count; j++)
                {
                    min = Math.Min(min, Distance(midX[i], midX[j], midY[i], midY[j]));
                }
            }
            double res = (Math.Min(min, d)+0.00002) * 10000.0;
            int s = (int)res;
            return (double)s / 10000;
        }

        private double Distance(long v1, long v2, long v3, long v4)
        {
            long c = (v1 - v2) * (v1 - v2);
            long h = (v3 - v4) * (v3 - v4);
            return Math.Sqrt(c + h);
        }
    }
}
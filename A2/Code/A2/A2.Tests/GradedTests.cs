using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod()]
        public void SolveTest_Q1NaiveMaxPairWise()
        {
            RunTest(new Q1NaiveMaxPairWise("TD1"));
        }

        [TestMethod(), Timeout(1500)]
        public void SolveTest_Q2FastMaxPairWise()
        {
            RunTest(new Q2FastMaxPairWise("TD2"));
        }

        [TestMethod()]
        public void SolveTest_StressTest()
        {
            int x = 0;
            Stopwatch s = new Stopwatch();
            s.Start();
            while(s.Elapsed.TotalSeconds<=5)
            {
                x++;
                long[] random = RandomGen(500);
                Q1NaiveMaxPairWise o = new Q1NaiveMaxPairWise("");
                long a1 = o.Solve(random);
                Q2FastMaxPairWise o2 = new Q2FastMaxPairWise("");
                long a2 = o2.Solve(random);
                Assert.AreEqual(a1, a2);
            }
            //Assert.Inconclusive();
        }

        private long[] RandomGen(int v)
        {
            List<long> rnd = new List<long>();
            for(int i =0;i<v;i++)
            {
                rnd.Add(new Random().Next(1, 100000));
            }
            return rnd.ToArray();
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A2", p.Process, p.TestDataName, p.Verifier);
        }

    }
}
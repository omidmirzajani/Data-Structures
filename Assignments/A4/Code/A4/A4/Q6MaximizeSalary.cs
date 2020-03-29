using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q6MaximizeSalary : Processor
    {
        public Q6MaximizeSalary(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], string>) Solve);


        public virtual string Solve(long n, long[] numbers)
        {
            for(int i=0;i<n;i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[i].ToString()[0] <numbers[j].ToString()[0])
                    {
                        (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
                    }
                    else if(numbers[i].ToString()[0] == numbers[j].ToString()[0])
                    {
                        string a = AddString(numbers[i].ToString(), numbers[j].ToString());
                        string b = AddString(numbers[j].ToString(), numbers[i].ToString());
                        if (Convert.ToInt32(b)>Convert.ToInt32(a))
                            (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
                    }
                }
            }
            string res = "";
            for (int i = 0; i < n ; i++)
                res = AddString(res, numbers[i].ToString());
            return res;
        }

        private string AddString(string v1, string v2)
        {
            string result = "";
            for (int i = 0; i < v1.ToString().Length; i++)
                result += v1.ToString()[i];
            for (int i = 0; i < v2.ToString().Length; i++)
                result += v2.ToString()[i];
            return result;
        }
    }
}


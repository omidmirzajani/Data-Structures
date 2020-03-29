using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q1CheckBrackets : Processor
    {
        public Q1CheckBrackets(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string str)
        {            
            Stack<char> stack = new Stack<char>();
            Stack<long> num = new Stack<long>();

            long t = 0;
            for (int i=0;i<str.Length;i++){

                if (str[i] == '(' || str[i] == '[' || str[i] == '{'){
                    num.Push(i + 1);
                    stack.Push(str[i]);
                }
                else if(str[i] == ')' || str[i] == '}' || str[i] == ']'){
                    if (stack.Count == 0)
                        return i + 1;
                    if (str[i] == ')' && stack.Peek() != '(')
                        return i + 1;
                    if (str[i] == ']' && stack.Peek() != '[')
                        return i + 1;
                    if (str[i] == '}' && stack.Peek() != '{')
                        return i + 1;
                    stack.Pop();
                    num.Pop();
                }
            }

            if (stack.Count != 0)
                return num.ToArray()[0];
            return -1;
        }

    }
}

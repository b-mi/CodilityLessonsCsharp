using System;
using System.Collections.Generic;

namespace Codility
{
    internal class Brackets
    {
        public Brackets()
        {
            Console.WriteLine(solution("(]").ToString());
            Console.WriteLine(solution("{}([)()]").ToString());
            Console.WriteLine(solution("{[()()]}").ToString());
        }

        public int solution(string S)
        {
            if (S.Length == 0)
                return 1;
            if (S[0] == ']' || S[0] == '}' || S[0] == ')')
                return 0;

            var stack = new Stack<char>();

            bool isOpeningBracket = false;
            char oppositeChar = ' ';
            foreach (char c in S)
            {
                isOpeningBracket = false;
                switch (c)
                {
                    case '{':
                    case '[':
                    case '(':
                        isOpeningBracket = true;
                        break;
                    case '}':
                        oppositeChar = '{';
                        break;
                    case ']':
                        oppositeChar = '[';
                        break;
                    case ')':
                        oppositeChar = '(';
                        break;
                }

                if (isOpeningBracket)
                    stack.Push(c);
                else
                {
                    // closing brackets
                    if (stack.Count == 0)
                    {
                        return 0; // closing bracket to empty stack
                    }

                    var lastChar = stack.Peek();
                    if (lastChar == oppositeChar)
                    {
                        stack.Pop(); // remove unnecessary pair
                    }
                    else
                    {
                        // end if prev bracket is opening
                        if( lastChar == '[' || lastChar == '{' || lastChar == '(')
                            return 0;
                    }
                }
            }
            return stack.Count == 0 ? 1 : 0;
        }
    }
}
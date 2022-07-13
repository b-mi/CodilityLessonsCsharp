namespace Codility
{
    internal class Brackets
    {
        public Brackets()
        {
            solution("([)()]");
            //solution("{[()()]}");
        }

        public int solution(string S)
        {
            int curlBrackets = 0;
            int sqrBrackets = 0;
            int rndBrackets = 0;

            foreach (char c in S)
            {
                switch (c)
                {
                    case '{':
                        curlBrackets++;
                        break;
                    case '}':
                        curlBrackets--;
                        if (curlBrackets < 0)
                            return 0;
                        break;
                    case '[':
                        sqrBrackets++;
                        break;
                    case ']':
                        sqrBrackets--;
                        if (sqrBrackets < 0)
                            return 0;
                        break;
                    case '(':
                        rndBrackets++;
                        break;
                    case ')':
                        rndBrackets--;
                        if (rndBrackets < 0)
                            return 0;

                        break;
                    default:
                        break;
                }
            }
            return 0;
        }
    }
}
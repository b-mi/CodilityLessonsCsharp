using System.Diagnostics;

namespace Codility
{
    internal class Nesting
    {
        public Nesting()
        {
            Debug.Assert(solution("(()(())())") == 1);
            Debug.Assert(solution("())") == 0);
        }

        public int solution(string S)
        {
            if (S.Length == 0)
                return 1;
            if (S.Length % 2 != 0)
                return 0;

            int sum = 0;
            foreach (char c in S)
            {
                if (c == '(')
                    sum++;
                else
                    sum--;
                if (sum < 0)
                    return 0;
            }

            return sum == 0 ? 1 : 0;
        }
    }
}
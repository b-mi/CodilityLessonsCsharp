using System;
using System.Linq;

namespace Codility
{
    internal class MissingInteger
    {
        public MissingInteger()
        {
           // var rtn = solution(new int[] { 1, 3, 6, 4, 1, 2 });
           var rtn = solution(new int[] { -1, -3 });
           // var rtn = solution(new int[] { 7, 6, 0, -2, 1, 2, 3, 5, 5, 4 });
        }


        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var data = A.Where(i => i > 0).Distinct().ToArray();
            if (data.Length == 0)
            {
                return 1;
            }
            Array.Sort(data);
            var num = 1;
            foreach (var n in data)
            {
                if (num != n)
                {
                    return num;
                }
                num++;
            }

            return num;
        }
    }
}
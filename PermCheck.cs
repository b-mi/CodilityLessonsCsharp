using System;
using System.Linq;

namespace Codility
{
    internal class PermCheck
    {
        public PermCheck()
        {
            solution(new int[] { 4, 1, 3, 2 });
        }

        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A.Length == 0)
                return 0;
            Array.Sort(A);
            if (A[0] != 1 || A.Last() != A.Length)
                return 0;
            var current = A[0];
            foreach (var num in A)
            {
                if (num != current++)
                    return 0;
            }

            return 1;
        }

    }
}
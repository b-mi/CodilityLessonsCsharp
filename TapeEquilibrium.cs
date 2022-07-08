using System;
using System.Diagnostics;
using System.Linq;

namespace Codility
{
    internal class TapeEquilibrium
    {
        public TapeEquilibrium()
        {
           // Debug.Assert(solution(new int[] { 3, 1, 2, 4, 3 }) == 1);

            Debug.Assert(solution(new int[] { -5, 7 }) == 1);


        }

        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var minDiff = int.MaxValue;
            var leftSum = 0;
            var rightSum = A.Sum(p => p);
            for (int i = 0; i < A.Length - 1; i++)
            {
                leftSum += A[i];
                rightSum -= A[i];

                var diff = Math.Abs(leftSum - rightSum);
                if (diff < minDiff)
                    minDiff = diff;
            }

            return minDiff;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Codility
{
    internal class MaxProductOfThree
    {
        public MaxProductOfThree()
        {
            Debug.Assert(solution(new int[] { -3, 1, 2, -2, 5, 6 }) == 60);
            Debug.Assert(solution(new int[] { -5, -6, -4, -7, -10 }) == -120);
            Debug.Assert(solution(new int[] { -10, -2, -4 }) == -80);
            Debug.Assert(solution(new int[] { -10, -2, -4, -1 }) == -8);
            Debug.Assert(solution(new int[] { 4, 7, 3, 2, 1, -3, -5 }) == 105);
            Debug.Assert(solution(new int[] { -2, -3, -5, -6, 0 }) == 0);
        }

        public int solution(int[] A)
        {
            if (A.Length == 3)
                return A[0] * A[1] * A[2];
            Array.Sort(A); // from in to max (-13, -11, -4-, -1, 0, 2, 4, 77, 567, 7789)

            // 3 max positive, or 3 min negative include zero
            var max = -int.MaxValue;
            max = Math.Max(max, A[A.Length - 1] * A[A.Length - 2] * A[A.Length - 3]);

            // one positive, two negative
            max = Math.Max(max, A[A.Length - 1] * A[0] * A[1]);
            return max;
        }

    }
}
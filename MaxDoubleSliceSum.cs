using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Codility
{
    internal class MaxDoubleSliceSum
    {
        public MaxDoubleSliceSum()
        {
            Debug.Assert(solution(new int[] { 3, 2, 6, -1, 4, 5, -1, 2 }) == 17); // 17
            Debug.Assert(solution(new int[] { 3, 2, 6, -1, 4, 5, -2, 2, -4, 3, 12, -5, 0, 7, -1 }) == 34); // 34
            Debug.Assert(solution(new int[] { 1, 2, 3, 4, 5 }) == 7); // 7, 0-1-4
            Debug.Assert(solution(new int[] { -1, -2, -3, -4, -5 }) == -2); // -2,  0-2-3
            Debug.Assert(solution(new int[] { 10, 1, 0, 1, 10 }) == 2); // 
            Debug.Assert(solution(new int[] { 10, -2, 1, -3, 2, 10 }) == 3); // 1-3-5




        }

        public int solution(int[] A)
        {
            if (A.Length == 3)
                return 0;

            if (!A.Any(i => i < 0)) // positives only
            {
                var apos = A.Skip(1).Take(A.Length - 2).ToArray();
                return apos.Sum() - apos.Min();
            }
            else if (!A.Any(i => i > 0)) // negatives only
            {
                return 0;
            }

            // reduction
            var aA = new List<int>();
            aA.Add(A[0]);
            int idx = 1;
            bool isNegative = A[idx] < 0;
            int sum = 0;

            for (int i = idx; i < A.Length - 1; i++)
            {
                var aValue = A[i];
                if (isNegative && aValue < 0 || !isNegative && aValue > 0)
                    sum += aValue;
                else
                {
                    aA.Add(sum);
                    sum = aValue;
                    isNegative = !isNegative;
                }
            }
            aA.Add(sum);
            aA.Add(A[A.Length - 1]);

            var maxSum = int.MinValue;

            var start = 1;
            while (aA[start] < 0) start++; // find first positive group

            var end = aA.Count - 2;
            while (aA[end] < 0) end--; // find last positive group

            // finding max
            for (int i = start; i <= end; i += 2)
            {
                sum = aA[i];
                maxSum = Math.Max(sum, maxSum);
                var j = i + 2;
                while (j <= end)
                {
                    sum += aA[j];
                    maxSum = Math.Max(sum, maxSum);
                    sum += aA[j - 1];
                    j += 2;
                }
            }

            return maxSum;
        }

    }
}
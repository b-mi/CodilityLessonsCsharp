using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Codility
{
    internal class MaxSliceSum
    {
        public MaxSliceSum()
        {

            Debug.Assert(solution(new int[] { 3, -2, 3 }) == 4); // 4
            Debug.Assert(solution(new int[] { 3, 2, -6, 4, 0 }) == 5); // 5
            Debug.Assert(solution(new int[] { -7, -2, 3, 2, -6, 4, 3, 2, -1, 0, 7, -4, -5, 8, -13, 1, -5, -3, 8 }) == 15);
            Debug.Assert(solution(new int[] { -7, -2, 3, 2, -6, 4, 3, 2, -1, 0, 7, -4, -5, 8, -13 }) == 15);
        }

        public int solution(int[] A)
        {
            var hasPositives = A.Any(i => i > 0);
            var hasNegatives = A.Any(i => i < 0);
            if (!hasNegatives)
                return A.Sum();
            if (!hasPositives)
                return A.Max();

            // has positives and negatives,  –2,147,483,648 and 2,147,483,647 .
            int maxValue = A.Max();
            int maxSum = Math.Max(A.Sum(), maxValue);

            // reduction
            var newA = new List<int>();
            int idx = 0;
            while (A[idx] <= 0) idx++; // skip negatives
            bool isNegative = false;
            int sum = 0;
            for (int i = idx; i < A.Length; i++)
            {
                var aValue = A[i];
                if (aValue == 0) continue;
                if (isNegative && aValue < 0 || !isNegative && aValue > 0)
                    sum += aValue;
                else
                {
                    newA.Add(sum);
                    sum = aValue;
                    isNegative = !isNegative;
                }
            }
            if (sum > 0)
                newA.Add(sum);

            maxSum = Math.Max(newA.Max(), maxSum);

            // finding max
            for (int i = 0; i < newA.Count - 0; i += 2)
            {
                sum = newA[i];
                for (int j = i + 1; j < newA.Count - 0; j += 2)
                {
                    sum += newA[j] + newA[j + 1];
                    maxSum = Math.Max(sum, maxSum);
                }
            }

            return maxSum;
        }
    }
}
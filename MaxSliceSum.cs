using System;
using System.Linq;

namespace Codility
{
    internal class MaxSliceSum
    {
        public MaxSliceSum()
        {

            solution(new int[] { 3, -2, 3 }); // 4

            solution(new int[] { 3, 2, -6, 4, 0 });
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
            int maxSum = A.Sum();

            var idx = 0;
            var grps = A.GroupBy(i => i < 0 ? idx++ : idx);

            foreach (var g in grps)
            {
                var max = g.Where(i => i > 0).Sum();
                if (max > maxSum)
                    maxSum = max;
            }

            return maxSum;
        }
    }
}
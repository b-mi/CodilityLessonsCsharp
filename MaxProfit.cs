using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Codility
{
    internal class MaxProfit
    {
        public MaxProfit()
        {

            Debug.Assert(solution(new int[] { 8, 9, 3, 6, 1, 2 }) == 3);
            Debug.Assert(solution(new int[] { 5, 4, 3, 2, 1 }) == 0);
            Debug.Assert(solution(new int[] { 23171, 21011, 21123, 21366, 21013, 21367 }) == 356);
            Debug.Assert(solution(new int[] { }) == 0);
            Debug.Assert(solution(new int[] { 3, 3 }) == 0);



        }
        public int solution(int[] A)
        {
            if (A.Length == 0)
                return 0;

            var lst = new List<int[]>();
            var bestProfit = int.MinValue;

            int startValue = A[0];
            var maxValue = startValue;

            for (int i = 1; i < A.Length; i++)
            {
                var currentValue = A[i];
                if (currentValue >= maxValue)
                    maxValue = currentValue;
                else
                {
                    updateMax(lst, maxValue, startValue);
                    startValue = maxValue = currentValue;
                }
            }
            updateMax(lst, maxValue, startValue);

            bestProfit = lst.Max(i => i[1] - i[0]);
            return bestProfit;
        }

        private static void updateMax(List<int[]> lst, int maxValue, int startValue)
        {
            int j = lst.Count - 1;
            while (j >= 0 && lst[j][1] < maxValue && lst[j][0] < maxValue)
            {
                lst[j][1] = maxValue;
                j--;
            }
            lst.Add(new int[] { startValue, maxValue });
        }
    }
}
using System;
using System.Diagnostics;
using System.Linq;

namespace Codility
{
    internal class MaxProfit
    {
        public MaxProfit()
        {

            Debug.Assert(solution(new int[] { 8, 9, 3, 6, 1, 2 }) == 3);

            //Debug.Assert(solution(new int[] { 5, 4, 3, 2, 1 }) == 0);
            //Debug.Assert(solution(new int[] { 23171, 21011, 21123, 21366, 21013, 21367 }) == 356);
            //Debug.Assert(solution(new int[] { }) == 0);
            //Debug.Assert(solution(new int[] { 3, 3 }) == 0);



        }
        public int solution(int[] A)
        {
            if (A.Length == 0)
                return 0;
            int idx = 0;
            var a = A.Select(i => new { idx = idx++, data = i }).OrderBy(i => i.data).ToArray();
            while (true)
            {

            }
            var minValue = a.First();
            var maxValue = a.LastOrDefault(i => i.idx > minValue.idx);
            if (maxValue == null)
                return 0;
            int bestProfit = maxValue.data - minValue.data;

            return Math.Max(0, bestProfit);
        }
    }
}
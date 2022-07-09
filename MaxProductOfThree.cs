using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility
{
    internal class MaxProductOfThree
    {
        public MaxProductOfThree()
        {

            //int rtn = solution(new int[] { -3, 1, 2, -2, 5, 6 }); // 60
            //int rtn = solution(new int[] { -10, -2, -4 }); // -80
            //int rtn = solution(new int[] { -10, -2, -4, -1 }); // -8
            //int rtn = solution(new int[] { 4, 7, 3, 2, 1, -3, -5 }); // 105
            //int rtn = solution(new int[] { -2, -3, -5, -6, 0 }); // 0
            int rtn = solution(new int[] { -5, -6, -4, -7, -10 }); // -120
            





        }

        public int solution(int[] A)
        {

            var sorted = A.OrderByDescending(i => Math.Abs(i));
            
            var sPositive = new List<int>();
            var sNegative = new List<int>();
            var isZero = false;
            foreach (var item in sorted)
            {
                if (item == 0)
                {
                    isZero = true;
                    continue;
                }
                if (item > 0 && sPositive.Count < 3)
                {
                    sPositive.Add(item);
                    continue;
                }
                if (item < 0 && sNegative.Count < 3)
                {
                    sNegative.Add(item);
                    continue;
                }

                if (sPositive.Count > 3 && sNegative.Count > 3)
                    break;
            }

            var max = -int.MaxValue;
            if (sPositive.Count == 3) // 3 max positive numbers
                max = Math.Max(max, sPositive[0] * sPositive[1] * sPositive[2]);
            if (sPositive.Count > 0 && sNegative.Count > 1) // one +, two -
                max = Math.Max(max, sPositive[0] * sNegative[0] * sNegative[1]);
            if (sPositive.Count > 1 && sNegative.Count > 0) // two +, one -
                max = Math.Max(max, sPositive[0] * sPositive[1] * sNegative[0]);
            if (sNegative.Count > 2) // all negatives
                max = Math.Max(max, sNegative[0] * sNegative[1] * sNegative[2]);
            if (max < 0 && isZero)
                max = 0;


            return max;
        }

    }
}
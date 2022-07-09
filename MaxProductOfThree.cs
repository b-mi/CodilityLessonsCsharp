using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility
{
    internal class MaxProductOfThree
    {
        public MaxProductOfThree()
        {

            //int rtn = solution(new int[] { -3, 1, 2, -2, 5, 6 });
            //int rtn = solution(new int[] { -10, -2, -4 });
            //int rtn = solution(new int[] { -10, -2, -4, -1 });
            int rtn = solution(new int[] { 4, 7, 3, 2, 1, -3, -5 }); // 105

        }

        public int solution(int[] A)
        {
            var sorted = A.OrderByDescending(i => Math.Abs(i)).ToArray();
            var data = new List<int>();
            int idx = 0;
            data.Add(sorted[idx++]);
            data.Add(sorted[idx++]);
            data.Add(sorted[idx++]);

            while (idx < A.Length)
            {
                var negs = data.Where(x => x < 0).OrderBy(x => x);
                var negsCount = negs.Count();
                if (negsCount % 2 == 1)
                {
                    data.Remove(negs.First());
                    data.Add(sorted[idx++]);
                }
                else
                    break;
            }

            return data[0] * data[1] * data[2];

        }
    }
}
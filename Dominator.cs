using System.Diagnostics;
using System.Linq;

namespace Codility
{
    internal class Dominator
    {
        public Dominator()
        {
            Debug.Assert(solution(new int[] { 3, 4, 3, 2, 3, -1, 3, 3, 3 }) == 0);
            Debug.Assert(solution(new int[] { 3, 4, 3, 2, 3, -1, 3, 2, 1 }) == -1);
            Debug.Assert(solution(new int[] { }) == -1);
            Debug.Assert(solution(new int[] { 4 }) == 0);

        }

        public int solution(int[] A)
        {
            int max = -1;
            var half = A.Length / 2;
            int idx = 0;
            foreach (var item in A.Select(i => new { idx = idx++, data = i }).GroupBy(i => i.data))
            {
                if (item.Count() > max)
                {
                    max = item.Count();
                    if (max > half)
                    {
                        return item.First().idx;
                    }
                }
            }
            return -1;
        }
    }
}
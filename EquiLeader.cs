using System.Diagnostics;
using System.Linq;

namespace Codility
{
    internal class EquiLeader
    {
        public EquiLeader()
        {
            Debug.Assert(solution(new int[] { }) == 0);
            Debug.Assert(solution(new int[] { 0 }) == 0);
            Debug.Assert(solution(new int[] { 0, 0 }) == 1);
            Debug.Assert(solution(new int[] { 4, 3, 4, 4, 4, 2 }) == 2);
        }

        public int solution(int[] A)
        {
            if (A.Length == 0)
                return 0;
            var leader = getLeader(A);
            if( leader == int.MinValue)
                return 0; // no leader
            int leadersLeft = 0, nonLeadersLeft = 0, equiLeadersCount = 0;
            var leadersRight = A.Count(i => i == leader);
            var nonLeadersRight = A.Length - leadersRight;

            for (int S = 0; S < A.Length; S++)
            {
                var s = A[S];
                if (s == leader)
                {
                    leadersLeft++;
                    leadersRight--;
                }
                else
                {
                    nonLeadersLeft++;
                    nonLeadersRight--;
                }

                if (leadersLeft > nonLeadersLeft && leadersRight > nonLeadersRight)
                    equiLeadersCount++;
            }

            return equiLeadersCount;
        }


        int getLeader(int[] A)
        {
            int max = int.MinValue;
            var half = A.Length / 2;
            int idx = 0;
            foreach (var item in A.Select(i => new { idx = idx++, data = i }).GroupBy(i => i.data))
            {
                if (item.Count() > max)
                {
                    max = item.Count();
                    if (max > half)
                    {
                        return item.Key;
                    }
                }
            }
            return max;
        }
    }
}
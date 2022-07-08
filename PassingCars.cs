using System.Diagnostics;

namespace Codility
{
    internal class PassingCars
    {
        public PassingCars()
        {
            solution(new int[] { 0, 1, 0, 1, 0, 1 });
            solution(new int[] { 0, 1, 0, 1, 0, 1, 0, 1 });
            solution(new int[] { 0, 1, 0, 1, 1 });
            solution(new int[] { 1, 0, 0, 0, 1 });
            solution(new int[] { 0, 0, 1, 0, 0 });
            solution(new int[] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 });
            solution(new int[] { 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 1 });
            solution(new int[] { 0, 0 });
            solution(new int[] { 1 });
            solution(new int[] { 1, 1 });

            /*
             0, 1 = 1
             0, 1, 0, 1 = 2 + 1 = 1 + 1 + 1
             0, 1, 0, 1, 0, 1 = 3 + 2 + 1 = 
             0, 1, 0, 1, 0, 1, 0, 1 = 4 + 3 + 2 + 1
             0, 1, 0, 1, 0, 1, 0, 1, 0, 1 = 5 + 4 + 3 + 2 + 1
             
             */

        }
        public int solution(int[] A)
        {
            int total = 0;
            int oneCount = 0;
            int prevOneCount = 0;

            for (int i = A.Length - 1; i >= 0; i--)
            {
                if (A[i] == 1)
                {
                    oneCount++;
                }
                else
                {
                    // value == 0
                    total += oneCount + prevOneCount;
                    if (total > 1000000000)
                        return -1;
                    prevOneCount += oneCount;
                    oneCount = 0;
                }

            }
            return total;
        }
    }
}
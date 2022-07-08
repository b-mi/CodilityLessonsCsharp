using System;
using System.Diagnostics;

namespace Codility
{
    internal class MaxCounter
    {
        public MaxCounter()
        {
            var rtn = solution(5, new int[] { 3 });
            rtn = solution(5, new int[] { 6 });
            rtn = solution(99999, new int[] { 3, 4, 4, 104, 1, 4, 4, 3, 4, 4, 104, 1, 4, 4, 3, 4, 4, 104, 1, 4, 4, 3, 4, 4, 6, 1, 4, 4, 3, 4, 4, 6, 1, 4, 4, 3, 4, 4, 6, 1, 4, 4 });
            var N = 55555;
            rtn = solution(N, new int[] { 3, 4, 4, N + 1, 1, 4, 4, 3, 4, 4, N + 1, 1, 4, 4 });
            rtn = solution(5, new int[] { 3, 4, 4, 6, 1, 4, 4 });
            rtn = solution(5, new int[] { });
        }


        public int[] solution(int N, int[] A)
        {
            var batchSize = 1000;

            var batchCount = N / batchSize;
            int lastMax = -1;

            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var counters = new int[N];
            int max = 0;
            foreach (var operation in A)
            {
                if (operation <= N)
                {
                    var newValue = counters[operation - 1] = counters[operation - 1] + 1;
                    if (newValue > max)
                        max = newValue;
                }
                else
                {
                    if (max == lastMax)
                        continue;
                    // block copy
                    for (int i = 0; i < Math.Min(N, batchSize); i++)
                        counters[i] = max;

                    int iFrom = batchSize;

                    for (int batch = 1; batch < batchCount; batch++)
                    {
                        Array.Copy(counters, 0, counters, iFrom, batchSize);
                        iFrom += batchSize;
                    }
                    while (iFrom < counters.Length)
                    {
                        counters[iFrom++] = max;
                    }
                    lastMax = max;
                }
            }
            return counters;

        }
    }

}
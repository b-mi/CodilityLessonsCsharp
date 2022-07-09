using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Codility
{
    internal class MinAvgTwoSlice
    {
        public MinAvgTwoSlice()
        {
            var sw = new Stopwatch();
            var N = 100_000;
            var data = getSampleData(N);
            sw.Start();
            var rtn = solution(data);
            sw.Stop();
            var ela = sw.ElapsedMilliseconds;

            //var data = new int[] { 4, 2, 2, 5, 1, 5, 8 };
            //var rtn = getBruteForce(data);

            //var data = new int[] { 4, 2, 1, 5, 1, 5, 8 };
            //var rtn = getBruteForce(data);

            //solution(new int[] { 4, 2, 1, 5, 1, 5, 8 });
        }

        public int solution(int[] A)
        {
            var minAvg = double.MaxValue;
            int bestStartIdx = -1;
            int count = 0;
            int sum = 0;
            double avg;
            for (int start = 0; start < A.Length - 1; start++)
            {
                count = 1;
                sum = A[start];
                for (int j = start + 1; j < A.Length; j++)
                {
                    sum += A[j];
                    count++;
                    avg = (double)sum / (double)count;
                    if (avg < minAvg)
                    {
                        minAvg = avg;
                        bestStartIdx = start;
                    }
                }
            }
            return bestStartIdx;
        }

        private int[] getSampleData(int n)
        {
            var rnd = new Random(7);
            var lst = new List<int>();
            for (int i = 0; i < n; i++)
            {
                lst.Add(rnd.Next(-10_000, 10_000));
            }
            return lst.ToArray();
        }
    }
}
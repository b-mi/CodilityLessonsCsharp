using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Codility
{
    internal class MinAvgTwoSlice
    {
        private readonly int MAX_LENGTH = 4; // slightly speculative

        public MinAvgTwoSlice()
        {
            var sw = new Stopwatch();
            var N = 100_000;
            var data = getSampleData(N);
            sw.Start();
            var rtn = solution(data, out var bestLength);
            sw.Stop();
            var ela = sw.ElapsedMilliseconds;
            Console.WriteLine($"{ela}, {rtn}, {bestLength}");
        }

        public int solution(int[] A, out int bestLength)
        {
            var minAvg = double.MaxValue;
            int bestStartIdx = -1;
            bestLength = -1;
            int sumLength = 0;
            int sum = 0;
            double avg;
            for (int start = 0; start < A.Length - 1; start++)
            {
                sumLength = 1;
                sum = A[start];
                for (int j = start + 1; j < A.Length; j++)
                {
                    sum += A[j];
                    sumLength++;
                    if( sumLength > MAX_LENGTH)
                    {
                        break;
                    }
                    avg = (double)sum / (double)sumLength;
                    if (avg < minAvg)
                    {
                        minAvg = avg;
                        bestStartIdx = start;
                        bestLength = sumLength;
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
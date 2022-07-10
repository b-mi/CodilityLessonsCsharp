using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Codility
{
    internal class Triangle
    {
        public Triangle()
        {
            //test();
            var lst = new List<int>();
            var rnd = new Random(7);
            for (int i = 0; i < 100_000; i++)
            {
                lst.Add(rnd.Next(-1_000_000, 0));
            }
            var sw = new Stopwatch();
            sw.Start();
            var aa = solution(lst.ToArray());
            sw.Stop();
            Console.WriteLine($"{sw.Elapsed}: {aa}");
            //var aa = new int[] { 10, 2, 5, 1, 8, 20 };
            //solution(new int[] { 20, int.MinValue, int.MaxValue, int.MinValue, int.MaxValue }); // 5, 8, 10
            //solution(new int[] { 10, 2, 5, 1, 8, 20, int.MinValue, int.MaxValue }); // 5, 8, 10


        }

        /*
         
large_negative
chaotic sequence of negative values from [-1M..-1], length=100K✘TIMEOUT ERROR
Killed. Hard limit reached: 6.000 sec.      
         */


        public int solution(int[] A)
        {
            if (A.Length < 3)
                return 0; // no triangle
            Array.Sort(A);

            int pValue, qValue, rValue;
            int? lastPValue = null;
            long maxValue;
            for (int p = 0; p < A.Length - 2; p++)
            {
                pValue = A[p];
                if (lastPValue.HasValue && pValue == lastPValue.Value)
                    continue;
                lastPValue = pValue;
                for (int q = p + 1; q < A.Length - 1; q++)
                {
                    qValue = A[q];
                    maxValue = (long)pValue + (long)qValue - 1;
                    rValue = A[q + 1];

                    if ((long)rValue <= maxValue)
                        return 1;
                }
            }
            return 0;
        }


        private void test()
        {

            var a = isTriangle(10, 5, 8);
            int pMin = 12, pMax = 12;
            int qMin = 1000, qMax = 1000;
            int rMin = -3000, rMax = 3000;


            for (int p = pMin; p <= pMax; p++)
            {
                for (int q = qMin; q <= qMax; q++)
                {
                    for (int r = rMin; r <= rMax; r++)
                    {
                        if (isTriangle(p, q, r))
                            Console.WriteLine($"{p}, {q}, {r}");
                    }
                }
            }
        }

        private static bool isTriangle(int p, int q, int r)
        {
            return p + q > r && q + r > p && r + p > q;
        }
    }

    /*
12, 12, 1
12, 12, 2
12, 12, 3
12, 12, 4
12, 12, 5
12, 12, 6
12, 12, 7
12, 12, 8
12, 12, 9
12, 12, 10
12, 12, 11
12, 12, 12
12, 12, 13
12, 12, 14
12, 12, 15
12, 12, 16
12, 12, 17
12, 12, 18
12, 12, 19
12, 12, 20
12, 12, 21
12, 12, 22
12, 12, 23
done

12, 13, 2
12, 13, 3
12, 13, 4
12, 13, 5
12, 13, 6
12, 13, 7
12, 13, 8
12, 13, 9
12, 13, 10
12, 13, 11
12, 13, 12
12, 13, 13
12, 13, 14
12, 13, 15
12, 13, 16
12, 13, 17
12, 13, 18
12, 13, 19
12, 13, 20
12, 13, 21
12, 13, 22
12, 13, 23
12, 13, 24
done

12, 56, 45
12, 56, 46
12, 56, 47
12, 56, 48
12, 56, 49
12, 56, 50
12, 56, 51
12, 56, 52
12, 56, 53
12, 56, 54
12, 56, 55
12, 56, 56
12, 56, 57
12, 56, 58
12, 56, 59
12, 56, 60
12, 56, 61
12, 56, 62
12, 56, 63
12, 56, 64
12, 56, 65
12, 56, 66
12, 56, 67
done



     */

}
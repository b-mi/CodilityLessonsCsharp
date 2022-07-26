using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Codility
{
    internal partial class MaxDoubleSliceSum
    {
        public MaxDoubleSliceSum()
        {
            rnd = new Random(7);

            //test(500, -1, 1);
            //test(20, -10, 10);
            //test(50, -1, 1);

            //solution(new int[] { 3, -50, -50, 100, 2, -50, -50, 2, -3, 4, -5, 6, 2 });
            //solution(new int[] { 0, 1, 0, -1, 0, 1, -1, 1, 1, 1, 0, 1, 0, -1, 1, 0, 1, 0, 1, -1, 1, 0, -1, 0, 0, -1, 1, -1, 0, 1, 1, -1, -1, -1, -1, -1, 1, -1, 0, 1, 1, 0, -1, -1, 0, 1, 1, 0, 1, -1, -1, 1, 1, 1, 0, 1, 1, -1, 0, 0, 1, -1, 0, -1, -1, -1, 1, -1, -1, 1, 0, 0, 1, 1, -1, -1, 0, -1, 1, 0, -1, 0, -1, 0, 0, 1, 0, -1, 0, -1, 0, 0, 0, -1, -1, 1, -1, 1, 1, 0, -1, 0, 0, -1, 0, 0, -1, 1, 1, 0, 0, 0, -1, -1, -1, 0, 1, -1, 0, -1, 0, 0, 1, 1, 0, 1, -1, 0, 1, -1, 1, 0, -1, 0, -1, 1, 1, -1, 1, 1, 1, 1, 0, -1, 1, 1, 0, -1, -1, 1, -1, -1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, -1, 0, 0, 1, 0, 1, 1, -1, 0, 0, 0, 1, 0, 1, -1, 0, 1, 0, 0, 1, 0, 1, -1, 1, -1, -1, 0, 1, -1, -1, 0, -1, 0, -1, 1, 1, 0, 1, -1, 0, -1, -1, 0, 0, 1, 0, 0, -1, -1, -1, 1, 1, -1, 0, -1, -1, -1, 1, 1, -1, -1, -1, -1, 0, -1, -1, -1, -1, 1, -1, -1, 1, 0, -1, 0, 0, 0, 1, -1, 0, 1, 0, 0, -1, -1, 1, -1, -1, -1, 0, 1, 1, -1, -1, -1, -1, -1, 1, 0, 0, 0, 0, -1, -1, 1, -1, 0, 1, 1, 1, 1, 0, 0, 0, -1, 1, 1, 1, -1, -1, -1, -1, 1, 0, 0, 0, 1, -1, 1, 0, 0, 0, 0, 1, 1, 0, -1, 0, -1, -1, -1, -1, -1, 0, 1, -1, -1, 0, 1, -1, 0, -1, 0, -1, -1, 0, 0, 1, 0, 0, -1, 0, -1, 0, -1, -1, 1, 1, 0, 1, 0, 0, 1, -1, -1, -1, 1, -1, 0, -1, 0, -1, -1, 1, -1, -1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, -1, 1, -1, 1, 0, -1, -1, -1, 0, -1, 0, 0, 1, -1, 0, 0, -1, -1, 1, -1, -1, -1, -1, -1, -1, 0, -1, 1, 1, -1, 0, 1, -1, 0, -1, -1, 1, 1, 1, -1, -1, 1, -1, -1, 1, 0, 0, 0, -1, 0, -1, 0, 1, 1, 0, 1, 0, -1, 0, -1, -1, -1, 0, 0, 0, 0, -1, 0, -1, -1, 0, 0, 0, 1, -1, 0, -1, -1, -1, 1, 1, 1, 1, -1, 1, -1, 1, 0, -1, -1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, -1, 0, 1, -1, 1, 1, -1, 1, -1, 0, 0, -1, 1, -1, 0, 0, -1, 0, 0, 1, 0, -1, 1, 1, 1, -1, 1, 1, -1, 1, 0, 0, 1, 0, 0, -1, 1, -1, -1, -1, 1 });
            //solution(new int[] { 0, 1, 0, -1, 0, 1, -1, 1, 1, 1, 0, 1, 0, -1, 1, 0, 1, 0, 1, -1, 1, 0, -1, 100, 0, -1, 1, -1, 0, 1, 1, -1, -1, -1, -1, -1, 1, -1, 0, 1, 1, 0, -1, -1, 0, 1, 1, 0, 1, -1, -1, 1, 1, 1, 0, 1, 1, -1, 0, 0, 1, -1, 0, -1, -1, -1, 1, -1, -1, 1, 0, 0, 1, 1, -1, -1, 0, -1, 1, 0, -1, 0, -1, 0, 0, 1, 0, -1, 0, -1, 0, 0, 0, -1, -1, 1, -1, 1, 1, 0, -1, 0, 0, -1, 0, 0, -1, 1, 1, 0, 0, 0, -1, -1, -1, 0, 1, -1, 0, -1, 0, 0, 1, 1, 0, 1, -1, 0, 1, -1, 1, 0, -1, 0, -1, 1, 1, -1, 1, 1, 1, 1, 0, -1, 1, 1, 0, -1, -1, 1, -1, -1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, -1, 0, 0, 1, 0, 1, 1, -1, 0, 0, 0, 1, 0, 1, -1, 0, 1, 0, 0, 1, 0, 1, -1, 1, -1, -1, 0, 1, -1, -1, 0, -1, 0, -1, 1, 1, 0, 1, -1, 0, -1, -1, 0, 0, 1, 0, 0, -1, -1, -1, 1, 1, -1, 0, -1, -1, -1, 1, 1, -1, -1, -1, -1, 0, -1, -1, -1, -1, 1, -1, -1, 1, 0, -1, 0, 0, 0, 1, -1, 0, 1, 0, 0, -1, -1, 1, -1, -1, -1, 0, 1, 1, -1, -1, -1, -1, -1, 1, 0, 0, 0, 0, -1, -1, 1, -1, 0, 1, 1, 1, 1, 0, 0, 0, -1, 1, 1, 1, -1, -1, -1, -1, 1, 0, 0, 0, 1, -1, 1, 0, 0, 0, 0, 1, 1, 0, -1, 0, -1, -1, -1, -1, -1, 0, 1, -1, -1, 0, 1, -1, 0, -1, 0, -1, -1, 0, 0, 1, 0, 0, -1, 0, -1, 0, -1, -1, 1, 1, 0, 1, 0, 0, 1, -1, -1, -1, 1, -1, 0, -1, 0, -1, -1, 1, -1, -1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, -1, 1, -1, 1, 0, -1, -1, -1, 0, -1, 0, 0, 1, -1, 0, 0, -1, -1, 1, -1, -1, -1, -1, -1, -1, 0, -1, 1, 1, -1, 0, 1, -1, 0, -1, -1, 1, 1, 1, -1, -1, 1, -1, -1, 1, 0, 0, 0, -1, 0, -1, 0, 1, 1, 0, 1, 0, -1, 0, -1, -1, -1, 0, 0, 0, 0, -1, 0, -1, -1, 0, 0, 0, 1, -1, 0, -1, -1, -1, 1, 1, 1, 1, -1, 1, -1, 1, 0, -1, -1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, -1, 0, 1, -1, 1, 1, -1, 1, -1, 0, 0, -1, 1, -1, 0, 0, -1, 0, 0, 1, 0, -1, 1, 1, 1, -1, 1, 1, -1, 1, 0, 0, 1, 0, 0, -1, 1, -1, -1, -1, 1 });
            //solution(new int[] { -2, 8, 3, -9, -3, 4, -10, 10, 7, 7, -1, 9, -1, -8, 8, -2, 6, -3, 8, -12, -7, -10 });
            solution(new int[] { -1, -1, -1, -1, -1, 1 , -1, -1, 1, 1, 1, 1, 1, -1, -1, -1, 1, 1, 1, 1, 1, 1, -1, 1, 1, 1, 1, 1, 1, 1, -1, -1 });

            //solution(new int[] { -2, -2, -2, 3, 4, 5, -10, 3, 4, 5, -100, -100, -2, -2, 3, 4, 6, -10, 3, 4, 5, -1, -1, 1 });


            //solution(new int[] { 0, 1, 0, -1, 0, 1, -1, 1, 1, 1, 0, 1, 0, -1, 1, 0, 1, 0, 1, -1, 1, 0, -1, 0, 0, -1, 1, -1, 0, 1, 1, -1, -1, -1, -1, -1, 1, -1, 0, 1, 1, 0, -1, -1, 0, 1, 1, 0, 1, -1 });
            //solution(new int[] { 3, 2, 6, -1, 4, 5, -2, 2, -4, 3, 12, -5, 0, 7, -1 });
            //solution(new int[] { 1, 2, 3, 4, 5 }); // 7, 0-1-4
            //solution(new int[] { -1, -2, -3, -4, -5 }); // vsetko zaporne je max 0
            //solution(new int[] { 10, 1, 0, 1, 10 }); // 
            //solution(new int[] { 10, -2, 1, -3, 2, 10 }); // 1-3-5



            //Debug.Assert(solution(new int[] { -2, 8, 3, -9, -3, 4, -10, 10, 7, 7, -1, 9, -1, -8, 8, -2, 6, -3, 8, -10 }) == 48);
            //Debug.Assert(solution(new int[] { 0, 1, 0, -1, 0, 1, -1, 1, 1, 1, 0, 1, 0, -1, 1, 0, 1, 0, 1, -1, 1, 0, -1, 0, 0, -1, 1, -1, 0, 1, 1, -1, -1, -1, -1, -1, 1, -1, 0, 1, 1, 0, -1, -1, 0, 1, 1, 0, 1, -1 }) == 7);
            //Debug.Assert(solution(new int[] { 3, 2, 6, -1, 4, 5, -1, 2 }) == 17);
            //Debug.Assert(solution(new int[] { 3, 2, 6, -1, 4, 5, -2, 2, -4, 3, 12, -5, 0, 7, -1 }) == 34);
            //Debug.Assert(solution(new int[] { 1, 2, 3, 4, 5 }) == 7); // 7, 0-1-4
            //Debug.Assert(solution(new int[] { -1, -2, -3, -4, -5 }) == 0); // vsetko zaporne je max 0
            //Debug.Assert(solution(new int[] { 10, 1, 0, 1, 10 }) == 2); // 
            //Debug.Assert(solution(new int[] { 10, -2, 1, -3, 2, 10 }) == 3); // 1-3-5


        }


        public int solution(int[] A)
        {
            var c = A.Skip(1).Take(A.Length - 2).ToArray();
            var hasPositives = c.Any(i => i > 0);
            var hasNegatives = c.Any(i => i < 0);
            if (!hasNegatives)
            {
                var bn = brute(A, out int xn, out int yn, out int zn);
                var rtn = c.Sum() - c.Min();
                Debug.WriteLine($"Brute: max: {bn}, max sol: {rtn}, arr: {string.Join(",", A)}");

                return rtn;
            }
            if (!hasPositives)
            {
                Debug.WriteLine($"negatives: 0, arr: {string.Join(",", A)}");
                return 0;
            }

            #region reduction, result in b
            //var lstR = new List<int>();

            //lstR.Add(0);
            //int idx = 0;
            //int sumR = 0;
            //bool hasPos = false;
            //while (idx < c.Length)
            //{
            //    var value = c[idx++];
            //    if (value < 0)
            //    {
            //        if (hasPos) // add positives sum
            //        {
            //            lstR.Add(sumR);
            //            sumR = 0;
            //            hasPos = false;
            //        }

            //        lstR.Add(value);
            //    }
            //    else
            //    {
            //        sumR += value;
            //        hasPos = true;
            //    }

            //}
            //if (hasPos)
            //    lstR.Add(sumR);
            //lstR.Add(0);

            //if (c.Sum() != lstR.Sum())
            //{
            //    throw new NotImplementedException();
            //}

            //var b = lstR.ToArray();
            #endregion

            var b = A;

            var bruteRtn = brute(b, out int xR, out int yR, out int zR);

            //var bruteRtn = 48;
            //int xR = 6, yR = 13, zR = 19;


            //var bruteRtn = 14;
            //int xR = 119, yR = 126, zR = 184;

            int sum = 0, sum2 = 0, x = 0, y = 1, z = 2, maxPoint = 0, minPoint = 0, summin = 0, summin2 = 0;

            sum2 = A.Sum() - A[0] - A[1] - A[A.Length - 1];
            int maxSum = int.MinValue;
            int minSum = int.MaxValue;


            while (y < b.Length - 2)
            {

                sum += b[y];
                y++;
                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxPoint = y;
                    Debug.WriteLine($"U: y: {y}, sum: {sum}, sum2 {sum2},");
                }
                if (summin < minSum)
                {
                    minSum = summin;
                    minPoint = y;
                    Debug.WriteLine($"Umin: y: {y}, summin: {summin}, summin2 {summin2},");
                }

                sum2 -= b[y];
                if (sum2 > maxSum)
                {
                    maxSum = sum2;
                    maxPoint = y;
                    Debug.WriteLine($"D: y: {y}, sum: {sum}, sum2 {sum2},");
                }
                if (summin2 < minSum)
                {
                    minSum = summin2;
                    minPoint = y;
                    Debug.WriteLine($"Dmin: y: {y}, summmin: {summin}, summmin2 {summin2},");
                }
            }

            //
            //hladanie od bestPoint v oboch smeroch
            // 
            sum = 0;
            var maxR = int.MinValue;
            for (int idx = maxPoint + 1; idx < A.Length - 1; idx++)
            {
                sum += A[idx];
                if (sum > maxR)
                    maxR = sum;
            }

            sum = 0;
            int maxL = int.MinValue;
            for (int idx = maxPoint - 1; idx > 0; idx--)
            {
                sum += A[idx];
                if (sum > maxL)
                    maxL = sum;
            }

            maxL = Math.Max(0, maxL);
            maxR = Math.Max(0, maxR);
            maxSum = maxL + maxR;

            if (maxSum == bruteRtn)
            {
                Debug.WriteLine("OK");
            }
            else
            {
                Debug.WriteLine($"BAD {bruteRtn} != {maxSum}, bestPoint: {maxPoint}, BR: ({xR}-{yR}-{zR})");
                Debug.WriteLine($"{string.Join(",", A)}");

            }

            //// y => last z
            //while (z < b.Length - 1)
            //{
            //    sum += b[z];
            //    z++;
            //    if (sum > maxSum)
            //    {
            //        maxSum = Math.Max(maxSum, sum);
            //        bestX = x; bestY = y; bestZ = z;
            //    }
            //}
            //Debug.WriteLine($"PH1: x: {bestX}, y: {bestY}, z: {bestZ}, sum: {maxSum}");


            //// y => z - 1
            //while (y < z - 1)
            //{
            //    sum += b[y] - b[y + 1];
            //    y++;
            //    if (sum > maxSum)
            //    {
            //        maxSum = Math.Max(maxSum, sum);
            //        bestX = x; bestY = y; bestZ = z;
            //    }
            //}
            //Debug.WriteLine($"PH2: x: {bestX}, y: {bestY}, z: {bestZ}, sum: {maxSum}");

            //// x => y - 1
            //while (x < y - 1)
            //{
            //    x++;
            //    sum -= b[x];
            //    if (sum > maxSum)
            //    {
            //        maxSum = Math.Max(maxSum, sum);
            //        bestX = x; bestY = y; bestZ = z;
            //    }
            //}
            //Debug.WriteLine($"PH3: x: {bestX}, y: {bestY}, z: {bestZ}, sum: {maxSum}");
            //Debug.WriteLine($"Brute: x: {xR}, y: {yR}, z: {zR}, max: {bruteRtn}, arr: {string.Join(",", A)}");
            //Debug.WriteLine($"BR: ({xR}-{yR}-{zR}), brMax: {bruteRtn}");
            //Debug.WriteLine(string.Join(",", A));
            Debug.WriteLine("---");


            return maxSum;
        }
    }
}
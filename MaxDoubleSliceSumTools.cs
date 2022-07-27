using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Codility
{
    internal partial class MaxDoubleSliceSum
    {
        Random rnd;


        public int solution_old1(int[] A)
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


        private int[] reduceLst(int[] lst)
        {
            var lst2 = new List<int>();
            lst2.Add(lst.First());
            var sign = Math.Sign(lst[1]);
            int i = 1;
            int sum = 0;
            while (i < lst.Length - 1)
            {
                while (i < lst.Length - 1 && lst[i] < 0)
                    lst2.Add(lst[i++]);

                sum = 0;
                while (i < lst.Length - 1 && lst[i] >= 0)
                    sum += lst[i++];
                lst2.Add(sum);
            }

            lst2.Add(lst.Last());
            var sum1 = lst.Sum();
            var sum2 = lst2.Sum();
            if (sum1 != sum2)
            {
                throw new AggregateException();
            }


            return lst2.ToArray();
        }

        private int genData(int N, int MIN, int MAX, out int X, out int Y, out int Z, out int[] lst, bool useBrute)
        {
            var lstx = new List<int>();

            for (int i = 0; i < N; i++)
            {
                lstx.Add(rnd.Next(MIN, MAX + 1));
            }
            lst = lstx.ToArray();
            if (useBrute)
            {
                var bres = brute(lst, out X, out Y, out Z);
                return bres;
            }
            else
            {
                X = Y = Z = 0;
            }
            return 0;
        }


        private int brute(int[] ints, out int X, out int Y, out int Z)
        {
            int max = int.MinValue;
            X = Y = Z = 0;
            //sLst = String.Join(", ", ints);
            for (int i = 0; i < ints.Length - 2; i++)
            {
                for (int j = i + 1; j < ints.Length - 1; j++)
                {
                    for (int k = j + 1; k < ints.Length - 0; k++)
                    {
                        var sum = 0;
                        var x = i + 1;
                        var txj = Tuple.Create(x, j);
                        while (x < j)
                            sum += ints[x++];

                        x = j + 1;
                        var txk = Tuple.Create(x, k);
                        while (x < k)
                            sum += ints[x++];

                        if (sum > max)
                        {
                            max = sum;
                            X = i;
                            Y = j;
                            Z = k;

                        }
                        //Console.WriteLine($"{i}, {j}, {k}");
                    }
                }
            }
            //sLst = $"Debug.Assert(solution(new int[] {{ {sLst} }}) == {max});";

            return max;
        }

        private int test(int N, int MIN, int MAX)
        {
            var rtn = genData(N, MIN, MAX, out var X, out var Y, out var Z, out var lst, true); // 14
            var aa = solution(lst);
            //var lstReduced = reduceLst(lst).ToArray();
            //var rtnRed = brute(lstReduced, out int XR, out int YR, out int ZR, out string str);
            return rtn;
        }

        private int test2(int[] A)
        {
            var rtn = brute(A, out var x, out var y, out var z);
            //var reducedList = reduceLst(A);
            //var rtnR = brute(reducedList, out var xr, out var yr, out var zr, out string s2);
            //if (rtn != rtnR)
            //{
            //    throw new NotImplementedException();
            //}
            return rtn;
        }

    }
}
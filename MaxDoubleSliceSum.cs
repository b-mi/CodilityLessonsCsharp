using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Codility
{
    internal class MaxDoubleSliceSum
    {
        Random rnd;

        public MaxDoubleSliceSum()
        {
            rnd = new Random(7);

            //test(500, -1, 1);
            //test(20, -10, 10);
            //test(50, -1, 1);


            solution(new int[] { -2, 8, 3, -9, -3, 4, -10, 10, 7, 7, -1, 9, -1, -8, 8, -2, 6, -3, 8, -10 });
            solution(new int[] { 0, 1, 0, -1, 0, 1, -1, 1, 1, 1, 0, 1, 0, -1, 1, 0, 1, 0, 1, -1, 1, 0, -1, 0, 0, -1, 1, -1, 0, 1, 1, -1, -1, -1, -1, -1, 1, -1, 0, 1, 1, 0, -1, -1, 0, 1, 1, 0, 1, -1 });
            solution(new int[] { 3, 2, 6, -1, 4, 5, -1, 2 });
            solution(new int[] { 3, 2, 6, -1, 4, 5, -2, 2, -4, 3, 12, -5, 0, 7, -1 });
            solution(new int[] { 1, 2, 3, 4, 5 }); // 7, 0-1-4
            solution(new int[] { -1, -2, -3, -4, -5 }); // vsetko zaporne je max 0
            solution(new int[] { 10, 1, 0, 1, 10 }); // 
            solution(new int[] { 10, -2, 1, -3, 2, 10 }); // 1-3-5



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
                return rtn;
            }
            if (!hasPositives)
            {
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

            int maxSum = int.MinValue;
            int sum = 0, x = 0, y = 1, z = 2, bestZ = 0, bestY = 0;
            // finding best z
            while (z < b.Length - 1)
            {
                sum += b[z];
                z++;
                if (sum > maxSum)
                {
                    maxSum = Math.Max(maxSum, sum);
                    bestZ = z;
                    //Debug.WriteLine($"BestZ: {z}, max: {maxSum}");
                }
            }

            // finding best y
            sum = maxSum;
            while (y < bestZ - 1)
            {
                sum += b[y] - b[y + 1];
                y++;
                if (sum > maxSum)
                {
                    maxSum = Math.Max(maxSum, sum);
                    bestY = y;
                    //Debug.WriteLine($"BestY: {y}, max: {maxSum}");
                }
            }
            Debug.WriteLine($"Brute: x: {xR}, y: {yR}, z: {zR}, max: {bruteRtn}, bestY: {bestY}, bestZ: {bestZ}, max: {maxSum}");

            return maxSum;
        }

        private void validate(string id, int[] a, int x, int y, int z, int sum, int maxSum, int tempMax)
        {
            var sum2 = 0;
            for (int i = x + 1; i < y; i++)
            {
                sum2 += a[i];
            }
            for (int i = y + 1; i < z; i++)
            {
                sum2 += a[i];
            }
            Debug.WriteLine($"{id}) x: {x}, y: {y}, z:{z}, sum: {sum}, validSum: {sum2}, maxSum: {maxSum}, tempMax: {tempMax}");

            if (sum != sum2)
            {
                throw new InvalidProgramException();
            }
        }

        //private int[] reduceLst(int[] lst)
        //{
        //    var lst2 = new List<int>();
        //    lst2.Add(lst.First());
        //    var sign = Math.Sign(lst[1]);
        //    int i = 1;
        //    int sum = 0;
        //    while (i < lst.Length - 1)
        //    {
        //        while (i < lst.Length - 1 && lst[i] < 0)
        //            lst2.Add(lst[i++]);

        //        sum = 0;
        //        while (i < lst.Length - 1 && lst[i] >= 0)
        //            sum += lst[i++];
        //        lst2.Add(sum);
        //    }

        //    lst2.Add(lst.Last());
        //    var sum1 = lst.Sum();
        //    var sum2 = lst2.Sum();
        //    if (sum1 != sum2)
        //    {
        //        throw new AggregateException();
        //    }


        //    return lst2.ToArray();
        //}

        private int genData(int N, int MIN, int MAX, out int X, out int Y, out int Z, out int[] lst)
        {
            var lstx = new List<int>();

            for (int i = 0; i < N; i++)
            {
                lstx.Add(rnd.Next(MIN, MAX + 1));
            }
            var bres = brute(lstx.ToArray(), out X, out Y, out Z);
            lst = lstx.ToArray();
            return bres;
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
            var rtn = genData(N, MIN, MAX, out var X, out var Y, out var Z, out var lst); // 14
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
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

            test2(new int[] { -2, 8, 3, -9, -3, 4, -10, 10, 7, 7, -1, 9, -1, -8, 8, -2, 6, -3, 8, -10 });
            //test2(new int[] { 3, 2, 6, -1, 4, 5, -1, 2 });

            //Debug.Assert(solution(new int[] { 0, 1, 0, -1, 0, 1, -1, 1, 1, 1, 0, 1, 0, -1, 1, 0, 1, 0, 1, -1, 1, 0, -1, 0, 0, -1, 1, -1, 0, 1, 1, -1, -1, -1, -1, -1, 1, -1, 0, 1, 1, 0, -1, -1, 0, 1, 1, 0, 1, -1 }) == 7);
            //Debug.Assert(solution(new int[] { 3, 2, 6, -1, 4, 5, -1, 2 }) == 17);
            //Debug.Assert(solution(new int[] { 3, 2, 6, -1, 4, 5, -2, 2, -4, 3, 12, -5, 0, 7, -1 }) == 34);
            //Debug.Assert(solution(new int[] { 1, 2, 3, 4, 5 }) == 7); // 7, 0-1-4
            //Debug.Assert(solution(new int[] { -1, -2, -3, -4, -5 }) == 0); // vsetko zaporne je max 0
            //Debug.Assert(solution(new int[] { 10, 1, 0, 1, 10 }) == 2); // 
            //Debug.Assert(solution(new int[] { 10, -2, 1, -3, 2, 10 }) == 3); // 1-3-5


        }

        private int test(int N, int MIN, int MAX)
        {
            var rtn = genData(N, MIN, MAX, out var X, out var Y, out var Z, out var lst, out var sLst); // 14
            var lstReduced = reduceLst(lst).ToArray();
            var rtnRed = brute(lstReduced, out int XR, out int YR, out int ZR, out string str);
            return rtn;
        }

        private int test2(int[] A)
        {
            var rtn = brute(A, out var x, out var y, out var z, out string s1);
            var reducedList = reduceLst(A);
            var rtnR = brute(reducedList, out var xr, out var yr, out var zr, out string s2);
            if (rtn != rtnR)
            {
                throw new NotImplementedException();
            }
            return rtn;
        }

        public int solution(int[] A)
        {
            var a = A.Skip(1).Take(A.Length - 2).ToArray();
            var hasPositives = a.Any(i => i > 0);
            var hasNegatives = a.Any(i => i < 0);
            if (!hasNegatives)
                return a.Sum() - a.Min();
            if (!hasPositives)
                return 0;

            // reduction
            var bLst = new List<int>();

            int idx = 0;
            int sumR = 0;
            bool hasPos = false;
            while (idx < a.Length)
            {
                var value = a[idx++];
                if (value < 0)
                {
                    if (hasPos) // add positives sum
                    {
                        bLst.Add(sumR);
                        sumR = 0;
                        hasPos = false;
                    }

                    bLst.Add(value);
                }
                else
                {
                    sumR += value;
                    hasPos = true;
                }

            }
            if (hasPos)
                bLst.Add(sumR);


            // debug
            if (a.Sum() != bLst.Sum())
            {
                throw new NotImplementedException();
            }

            //b = a.ToList();

            int maxSum = int.MinValue;
            int sum = 0;
            // finding max
            int start = 0, stop = 0;
            for (int i = 0; i < a.Length; i += 2)
            {
                sum = a[i];
                for (int j = i + 1; j < a.Length; j += 2)
                {
                    var v2 = a[j] + a[j + 1];
                    sum += v2;
                    if (v2 > 0)
                    {
                        if (sum > maxSum)
                        {
                            maxSum = Math.Max(sum, maxSum);
                            start = i; stop = j + 1;
                        }
                    }
                }
            }

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

        private int genData(int N, int MIN, int MAX, out int X, out int Y, out int Z, out int[] lst, out string sLst)
        {
            var lstx = new List<int>();

            for (int i = 0; i < N; i++)
            {
                lstx.Add(rnd.Next(MIN, MAX + 1));
            }
            var bres = brute(lstx.ToArray(), out X, out Y, out Z, out sLst);
            lst = lstx.ToArray();
            return bres;
        }


        private int brute(int[] ints, out int X, out int Y, out int Z, out string sLst)
        {
            int max = int.MinValue;
            X = Y = Z = 0;
            sLst = String.Join(", ", ints);
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
            sLst = $"Debug.Assert(solution(new int[] {{ {sLst} }}) == {max});";

            return max;
        }

    }
}
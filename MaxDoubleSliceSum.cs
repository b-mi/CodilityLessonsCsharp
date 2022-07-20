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

            var rtn = genData(20, -10, 10, out var X, out var Y, out var Z, out var lst, out var sLst); // 48
            Debug.Assert(solution(new int[] { -2, 8, 3, -9, -3, 4, -10, 10, 7, 7, -1, 9, -1, -8, 8, -2, 6, -3, 8, -10 }) == 48);
            //                                                       *                        *                    *         
            //                                     11  -6  -12 1   -6  0   17 14 6   8   8  -9  0   6  4   3  5 
            // 6, 13, 19
            var lst2 = reduceLst(lst);
            var rtn2 = brute(lst2.ToArray(), out var X2, out var Y2, out var Z2, out var sLst2);



            //Debug.Assert(solution(new int[] { 0, 1, 0, -1, 0, 1, -1, 1, 1, 1, 0, 1, 0, -1, 1, 0, 1, 0, 1, -1, 1, 0, -1, 0, 0, -1, 1, -1, 0, 1, 1, -1, -1, -1, -1, -1, 1, -1, 0, 1, 1, 0, -1, -1, 0, 1, 1, 0, 1, -1 }) == 7);
            //Debug.Assert(solution(new int[] { 3, 2, 6, -1, 4, 5, -1, 2 }) == 17);
            //Debug.Assert(solution(new int[] { 3, 2, 6, -1, 4, 5, -2, 2, -4, 3, 12, -5, 0, 7, -1 }) == 34);
            //Debug.Assert(solution(new int[] { 1, 2, 3, 4, 5 }) == 7); // 7, 0-1-4
            //Debug.Assert(solution(new int[] { -1, -2, -3, -4, -5 }) == 0); // vsetko zaporne je max 0
            //Debug.Assert(solution(new int[] { 10, 1, 0, 1, 10 }) == 2); // 
            //Debug.Assert(solution(new int[] { 10, -2, 1, -3, 2, 10 }) == 3); // 1-3-5


        }

        private List<int> reduceLst(List<int> lst)
        {
            var lst2 = new List<int>();
            lst2.Add(lst.First());
            var sign = Math.Sign(lst[1]);
            int i = 1;
            int sum = 0;
            while (i < lst.Count - 1)
            {
                while (i < lst.Count - 1 && Math.Sign(lst[i]) == sign)
                    sum += lst[i++];
                lst2.Add(sum);
                sign = Math.Sign(lst[i]);
                sum = 0;
            }

            lst2.Add(lst.Last());
            var sum1 = lst.Sum();
            var sum2 = lst2.Sum();
            if( sum1 != sum2)
            {

            }


            return lst2;
        }

        private int genData(int N, int MIN, int MAX, out int X, out int Y, out int Z, out List<int> lst, out string sLst)
        {
            lst = new List<int>();

            for (int i = 0; i < N; i++)
            {
                lst.Add(rnd.Next(MIN, MAX + 1));
            }
            var bres = brute(lst.ToArray(), out X, out Y, out Z, out sLst);
            return bres;
        }

        public int solution(int[] A)
        {
            if (A.Length == 3)
                return 0;

            if (!A.Any(i => i < 0)) // positives only
            {
                var apos = A.Skip(1).Take(A.Length - 2).ToArray();
                return apos.Sum() - apos.Min();
            }
            else if (!A.Any(i => i > 0)) // negatives only
            {
                return 0;
            }

            // reduction
            var aA = new List<int>();
            aA.Add(A[0]);
            int idx = 1;
            bool isNegative = A[idx] < 0;
            int sum = 0;

            for (int i = idx; i < A.Length - 1; i++)
            {
                var aValue = A[i];
                if (isNegative && aValue < 0 || !isNegative && aValue >= 0)
                    sum += aValue;
                else
                {
                    aA.Add(sum);
                    sum = aValue;
                    isNegative = !isNegative;
                }
            }
            aA.Add(sum);
            aA.Add(A[A.Length - 1]);

            var maxSum = int.MinValue;

            var start = 1;
            while (aA[start] < 0) start++; // find first positive group

            var end = aA.Count - 2;
            while (aA[end] < 0) end--; // find last positive group

            // finding max
            var jResults = new Dictionary<int, int>();
            for (int i = start; i <= end; i += 2)
            {
                sum = aA[i];
                maxSum = Math.Max(sum, maxSum);
                var j = i + 2;

                var locMaxSum = int.MinValue;
                if (jResults.ContainsKey(j))
                {
                    locMaxSum = jResults[j];
                }
                else
                {
                    while (j <= end)
                    {
                        sum += aA[j];
                        locMaxSum = Math.Max(sum, locMaxSum);
                        sum += aA[j - 1];
                        j += 2;
                    }
                    jResults.Add(i + 2, locMaxSum);
                }
                maxSum = Math.Max(locMaxSum, maxSum);

            }

            return maxSum;
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
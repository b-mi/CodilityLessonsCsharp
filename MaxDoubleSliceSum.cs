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

            //var rtn = genData(20, -10, 10, out var X, out var Y, out var Z, out var lst, out var sLst); // 48
            //var rtn = genData(500, -1, 1, out var X, out var Y, out var Z, out var lst, out var sLst); // 14
            //var rtn = genData(50, -1, 1, out var X, out var Y, out var Z, out var lst, out var sLst); // 7


            //var arr = new int[] { -2, 8, 3, -9, -3, 4, -10, 10, 7, 7, -1, 9, -1, -8, 8, -2, 6, -3, 8, -10 }; // 48
            var arr = new int[] { 3, 2, 6, -1, 4, 5, -1, 2 }; // 17

            var rtn = brute(arr, out var X2, out var Y2, out var Z2, out var sLst2);
            var lstReduced = reduceLst(arr.ToList());
            var rtnReduced = brute(arr, out X2, out Y2, out Z2, out sLst2);
            var solRtn = solution(arr);
            //            Debug.Assert(solution(arr) == 48);

            //var lstReduced = reduceLst(lst);
            //var rtnReduced = brute(lstReduced.ToArray(), out var X2, out var Y2, out var Z2, out var sLst2);

            if (rtn != rtnReduced)
            {
                throw new AggregateException();
            }


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

            var aLen = A.Length;
            int maxSum = int.MinValue;
            int sumTotal = A.Sum();
            int x = 0, y = 1, z = 2, sumBtwXandY = 0, sum = 0; ;

            sum = sumBtwXandY;

            while (true)
            {

                // OK
                int tempMax = int.MinValue, diff = 0;
                while (z < aLen - 1)
                {
                    var value = A[z];
                    sum += value;
                    if (value > 0 && sum > maxSum)
                    {
                        maxSum = tempMax = sum;
                    }
                    ++z;
                    validate("z++", A, x, y, z, sum, maxSum, tempMax);
                }

                // move y down, OK - zatial bez riesenia konca
                while (y < z - 1)
                {
                    diff = A[y] - A[y + 1];
                    sum += diff;
                    if (diff > 0 && sum > maxSum)
                        maxSum = sum;
                    y++;
                    validate("y++", A, x, y, z, sum, maxSum, tempMax);
                }


                // move z UP
                while (z > y + 1)
                {
                    z--;
                    sum -= A[z];
                    validate("z--", A, x, y, z, sum, maxSum, tempMax);
                }

                // move X UP
                x++;
                sum -= A[x];
                validate("x++", A, x, y, z, sum, maxSum, tempMax);
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

        private List<int> reduceLst(List<int> lst)
        {
            var lst2 = new List<int>();
            lst2.Add(lst.First());
            var sign = Math.Sign(lst[1]);
            int i = 1;
            int sum = 0;
            while (i < lst.Count - 1)
            {
                while (i < lst.Count - 1 && lst[i] < 0)
                    lst2.Add(lst[i++]);

                sum = 0;
                while (i < lst.Count - 1 && lst[i] >= 0)
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
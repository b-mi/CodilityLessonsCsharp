using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Codility
{
    internal partial class MaxDoubleSliceSum
    {
        Random rnd;

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
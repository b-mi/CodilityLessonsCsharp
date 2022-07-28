using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Codility
{
    internal partial class MaxDoubleSliceSum
    {

        bool useBrute = false;
        bool useOptimiztion = true;
        bool useReduction = true;
        bool useLog = false;

        string logFile;

        public MaxDoubleSliceSum()
        {
            rnd = new Random(7);

            //int brute = 153;
            genData(100_000, -1, 1, out int _, out int _, out int _, out var lst, false); // spravny vysledok by mal byt 153
            //genData(70, -10_000, 10_000, out int _, out int _, out int _, out var lst, false); // spravny vysledok by mal byt 153

            //useOptimiztion = false;
            var x = solution(lst);

            //useOptimiztion = true;
            //x = solution(lst);

            //Debug.WriteLine($"result: {x}, brute: 153, time: {sw.ElapsedMilliseconds / 1000} sec.");


            return;

            //test(500, -1, 1);
            //test(20, -10, 10);
            //test(50, -1, 1);

            //sw = new Stopwatch();
            //sw.Start();
            //sw.Stop();
            //var ela = sw.ElapsedMilliseconds;

            solution(new int[] { 3, -50, -50, 100, 2, -50, -50, 2, -3, 4, -5, 6, 2 });
            solution(new int[] { 0, 1, 0, -1, 0, 1, -1, 1, 1, 1, 0, 1, 0, -1, 1, 0, 1, 0, 1, -1, 1, 0, -1, 0, 0, -1, 1, -1, 0, 1, 1, -1, -1, -1, -1, -1, 1, -1, 0, 1, 1, 0, -1, -1, 0, 1, 1, 0, 1, -1, -1, 1, 1, 1, 0, 1, 1, -1, 0, 0, 1, -1, 0, -1, -1, -1, 1, -1, -1, 1, 0, 0, 1, 1, -1, -1, 0, -1, 1, 0, -1, 0, -1, 0, 0, 1, 0, -1, 0, -1, 0, 0, 0, -1, -1, 1, -1, 1, 1, 0, -1, 0, 0, -1, 0, 0, -1, 1, 1, 0, 0, 0, -1, -1, -1, 0, 1, -1, 0, -1, 0, 0, 1, 1, 0, 1, -1, 0, 1, -1, 1, 0, -1, 0, -1, 1, 1, -1, 1, 1, 1, 1, 0, -1, 1, 1, 0, -1, -1, 1, -1, -1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, -1, 0, 0, 1, 0, 1, 1, -1, 0, 0, 0, 1, 0, 1, -1, 0, 1, 0, 0, 1, 0, 1, -1, 1, -1, -1, 0, 1, -1, -1, 0, -1, 0, -1, 1, 1, 0, 1, -1, 0, -1, -1, 0, 0, 1, 0, 0, -1, -1, -1, 1, 1, -1, 0, -1, -1, -1, 1, 1, -1, -1, -1, -1, 0, -1, -1, -1, -1, 1, -1, -1, 1, 0, -1, 0, 0, 0, 1, -1, 0, 1, 0, 0, -1, -1, 1, -1, -1, -1, 0, 1, 1, -1, -1, -1, -1, -1, 1, 0, 0, 0, 0, -1, -1, 1, -1, 0, 1, 1, 1, 1, 0, 0, 0, -1, 1, 1, 1, -1, -1, -1, -1, 1, 0, 0, 0, 1, -1, 1, 0, 0, 0, 0, 1, 1, 0, -1, 0, -1, -1, -1, -1, -1, 0, 1, -1, -1, 0, 1, -1, 0, -1, 0, -1, -1, 0, 0, 1, 0, 0, -1, 0, -1, 0, -1, -1, 1, 1, 0, 1, 0, 0, 1, -1, -1, -1, 1, -1, 0, -1, 0, -1, -1, 1, -1, -1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, -1, 1, -1, 1, 0, -1, -1, -1, 0, -1, 0, 0, 1, -1, 0, 0, -1, -1, 1, -1, -1, -1, -1, -1, -1, 0, -1, 1, 1, -1, 0, 1, -1, 0, -1, -1, 1, 1, 1, -1, -1, 1, -1, -1, 1, 0, 0, 0, -1, 0, -1, 0, 1, 1, 0, 1, 0, -1, 0, -1, -1, -1, 0, 0, 0, 0, -1, 0, -1, -1, 0, 0, 0, 1, -1, 0, -1, -1, -1, 1, 1, 1, 1, -1, 1, -1, 1, 0, -1, -1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, -1, 0, 1, -1, 1, 1, -1, 1, -1, 0, 0, -1, 1, -1, 0, 0, -1, 0, 0, 1, 0, -1, 1, 1, 1, -1, 1, 1, -1, 1, 0, 0, 1, 0, 0, -1, 1, -1, -1, -1, 1 });
            solution(new int[] { 0, 1, 0, -1, 0, 1, -1, 1, 1, 1, 0, 1, 0, -1, 1, 0, 1, 0, 1, -1, 1, 0, -1, 100, 0, -1, 1, -1, 0, 1, 1, -1, -1, -1, -1, -1, 1, -1, 0, 1, 1, 0, -1, -1, 0, 1, 1, 0, 1, -1, -1, 1, 1, 1, 0, 1, 1, -1, 0, 0, 1, -1, 0, -1, -1, -1, 1, -1, -1, 1, 0, 0, 1, 1, -1, -1, 0, -1, 1, 0, -1, 0, -1, 0, 0, 1, 0, -1, 0, -1, 0, 0, 0, -1, -1, 1, -1, 1, 1, 0, -1, 0, 0, -1, 0, 0, -1, 1, 1, 0, 0, 0, -1, -1, -1, 0, 1, -1, 0, -1, 0, 0, 1, 1, 0, 1, -1, 0, 1, -1, 1, 0, -1, 0, -1, 1, 1, -1, 1, 1, 1, 1, 0, -1, 1, 1, 0, -1, -1, 1, -1, -1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, -1, 0, 0, 1, 0, 1, 1, -1, 0, 0, 0, 1, 0, 1, -1, 0, 1, 0, 0, 1, 0, 1, -1, 1, -1, -1, 0, 1, -1, -1, 0, -1, 0, -1, 1, 1, 0, 1, -1, 0, -1, -1, 0, 0, 1, 0, 0, -1, -1, -1, 1, 1, -1, 0, -1, -1, -1, 1, 1, -1, -1, -1, -1, 0, -1, -1, -1, -1, 1, -1, -1, 1, 0, -1, 0, 0, 0, 1, -1, 0, 1, 0, 0, -1, -1, 1, -1, -1, -1, 0, 1, 1, -1, -1, -1, -1, -1, 1, 0, 0, 0, 0, -1, -1, 1, -1, 0, 1, 1, 1, 1, 0, 0, 0, -1, 1, 1, 1, -1, -1, -1, -1, 1, 0, 0, 0, 1, -1, 1, 0, 0, 0, 0, 1, 1, 0, -1, 0, -1, -1, -1, -1, -1, 0, 1, -1, -1, 0, 1, -1, 0, -1, 0, -1, -1, 0, 0, 1, 0, 0, -1, 0, -1, 0, -1, -1, 1, 1, 0, 1, 0, 0, 1, -1, -1, -1, 1, -1, 0, -1, 0, -1, -1, 1, -1, -1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, -1, 1, -1, 1, 0, -1, -1, -1, 0, -1, 0, 0, 1, -1, 0, 0, -1, -1, 1, -1, -1, -1, -1, -1, -1, 0, -1, 1, 1, -1, 0, 1, -1, 0, -1, -1, 1, 1, 1, -1, -1, 1, -1, -1, 1, 0, 0, 0, -1, 0, -1, 0, 1, 1, 0, 1, 0, -1, 0, -1, -1, -1, 0, 0, 0, 0, -1, 0, -1, -1, 0, 0, 0, 1, -1, 0, -1, -1, -1, 1, 1, 1, 1, -1, 1, -1, 1, 0, -1, -1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, -1, 0, 1, -1, 1, 1, -1, 1, -1, 0, 0, -1, 1, -1, 0, 0, -1, 0, 0, 1, 0, -1, 1, 1, 1, -1, 1, 1, -1, 1, 0, 0, 1, 0, 0, -1, 1, -1, -1, -1, 1 });
            solution(new int[] { -2, 8, 3, -9, -3, 4, -10, 10, 7, 7, -1, 9, -1, -8, 8, -2, 6, -3, 8, -12, -7, -10 });
            solution(new int[] { 3, 2, 6, -1, 4, 5, -1, 2 });
            solution(new int[] { -1, -1, -1, -1, -1, 1, -1, -1, 1, 1, 1, 1, 1, -1, -1, -1, 1, 1, 1, 1, 1, 1, -1, 1, 1, 1, 1, 1, 1, 1, -1, -1 });
            solution(new int[] { -2, -2, -2, 3, 4, 5, -10, 3, 4, 5, -100, -100, -2, -2, 3, 4, 6, -10, 3, 4, 5, -1, -1, 1 });
            solution(new int[] { 0, 1, 0, -1, 0, 1, -1, 1, 1, 1, 0, 1, 0, -1, 1, 0, 1, 0, 1, -1, 1, 0, -1, 0, 0, -1, 1, -1, 0, 1, 1, -1, -1, -1, -1, -1, 1, -1, 0, 1, 1, 0, -1, -1, 0, 1, 1, 0, 1, -1 });
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
                Debug.WriteLine($"Brute: max: {bn}, max sol: {rtn}, arr: {string.Join(",", A)}");

                return rtn;
            }
            if (!hasPositives)
            {
                Debug.WriteLine($"negatives: 0, arr: {string.Join(",", A)}");
                return 0;
            }

            var aOrigLen = A.Length;
            if (useReduction)
            {
                A = reduceLst(A);
            }
            if (useLog)
            {
                logFile = $"R{(useReduction ? 1 : 0)}_O{(useOptimiztion ? 1 : 0)}_OL{aOrigLen}_RL{A.Length}.txt";
                if (File.Exists(logFile))
                    File.Delete(logFile);
            }

            int bruteRtn = 0, xR = 0, yR = 0, zR = 0;
            if (useBrute)
            {

                bruteRtn = brute(A, out xR, out yR, out zR);
            }
            else
            {
            }

            var sw = new Stopwatch();
            sw.Start();

            // y value, Range 1, Length-1
            int maxSumTotal = 0;

            int yLastToUp = A.Length - 2, yLastToDn = 1, sumUp, sumDn;
            for (int y = 1; y < A.Length - 2; y++)
            {

                if (useOptimiztion)
                {
                    yLastToUp = getMaxForY(A, y, 1, yLastToUp, out sumUp);
                    yLastToDn = getMaxForY(A, y, -1, yLastToDn, out sumDn);
                }
                else
                {
                    getMaxForY(A, y, 1, yLastToUp, out sumUp);
                    getMaxForY(A, y, -1, yLastToDn, out sumDn);
                }
                if (useLog)
                {
                    File.AppendAllText(logFile, $"y: {y}, UP: sum: {sumUp}, DN: sum: {sumDn}{Environment.NewLine}");
                    //File.AppendAllText(logFile, $"y: {y}, UP: sum: {sumUp}, DN: sum: {sumDn}, toYUP: {yLastToUp}, toYDN: {yLastToDn}{Environment.NewLine}");
                }
                //Debug.WriteLine($"y: ({sumDn}) {yLastToDn} <= {y} =>  {yLastToUp} ({sumUp}), val: {A[y]}, total: {sumUp + sumDn}");
                maxSumTotal = Math.Max(maxSumTotal, sumUp + sumDn);
            }
            sw.Stop();

            var msg = $"Brute: {bruteRtn}, ({xR}-{yR}-{zR}), maxSumTotal: {maxSumTotal}, Elapsed ms: {sw.ElapsedMilliseconds}";
            if (useLog)
                File.AppendAllText(logFile, msg + Environment.NewLine);
            Debug.WriteLine(msg);

            return maxSumTotal;
        }

        private int getMaxForY(int[] A, int y, int direction, int yTo, out int max)
        {
            int sum, newYTo;
            newYTo = yTo;

            //if (y == 19 && direction == 1 && useOptimiztion)
            //{

            //}

            sum = max = 0;
            if (direction == 1) // down
            {
                if (yTo < y && direction == 1)
                    yTo = A.Length - 2;
                while (y < yTo)
                {
                    y++;
                    sum += A[y];
                    if (sum > max)
                    {
                        max = sum;
                        newYTo = y;
                    }
                }
            }
            else
            {
                while (y > yTo)
                {
                    y--;
                    sum += A[y];
                    if (sum > max)
                    {
                        max = sum;
                        newYTo = y;
                    }
                }

            }

            max = Math.Max(0, max);



            return newYTo;
        }
    }
}
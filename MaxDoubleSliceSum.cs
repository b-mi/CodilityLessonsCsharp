using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Codility
{
    internal partial class MaxDoubleSliceSum
    {
        private const int dirUnderY = 1;
        private const int dirAboveY = -1;

        bool useBrute = false;
        bool useOptimization = true;
        bool useReduction = true;
        bool useLog = false;

        string logFile;

        public MaxDoubleSliceSum()
        {
            rnd = new Random(7);

            //int brute = 153;
            genData(1_500, -1, 1, out int _, out int _, out int _, out var lst, false); // spravny vysledok by mal byt brute = 24, sol2sec = 24, 579-581-622 (reduced pole)

            //genData(100_000, -1, 1, out int _, out int _, out int _, out var lst, false); // spravny vysledok by mal byt 153
            //var sw = new Stopwatch();
            //sw.Start();
            //var a = solutionMSS(lst);
            //sw.Stop();
            //var ela = sw.ElapsedMilliseconds;

            //sw.Restart();
            //var b = solution1sec(lst, null);
            //sw.Stop();
            //var ela2 = sw.ElapsedMilliseconds;

            //genData(1_000, -1, 1, out int _, out int _, out int _, out var lst, false); // spravny vysledok by mal byt 14
            //genData(70, -10_000, 10_000, out int _, out int _, out int _, out var lst); // spravny vysledok by mal byt ??

            //var xx = solution1sec(lst, null);

            solution(lst);
            //solution1sec(lst);
            //return;

            //test(500, -1, 1);
            //test(20, -10, 10);
            //test(50, -1, 1);

            //sw = new Stopwatch();
            //sw.Start();
            //sw.Stop();
            //var ela = sw.ElapsedMilliseconds;

            // [0, 10, -5, -2, 0] = correct = 10

            //solution2(new int[] { 3, 2, 6, -1, 4, 5, -1, 2 });
            //solution2(new int[] { 0, 10, -5, -2, 0 });
            //solution(new int[] { 3, -50, -50, 100, 2, -50, -50, 2, -3, 4, -5, 6, 2 });
            //solution(new int[] { 0, 1, 0, -1, 0, 1, -1, 1, 1, 1, 0, 1, 0, -1, 1, 0, 1, 0, 1, -1, 1, 0, -1, 0, 0, -1, 1, -1, 0, 1, 1, -1, -1, -1, -1, -1, 1, -1, 0, 1, 1, 0, -1, -1, 0, 1, 1, 0, 1, -1, -1, 1, 1, 1, 0, 1, 1, -1, 0, 0, 1, -1, 0, -1, -1, -1, 1, -1, -1, 1, 0, 0, 1, 1, -1, -1, 0, -1, 1, 0, -1, 0, -1, 0, 0, 1, 0, -1, 0, -1, 0, 0, 0, -1, -1, 1, -1, 1, 1, 0, -1, 0, 0, -1, 0, 0, -1, 1, 1, 0, 0, 0, -1, -1, -1, 0, 1, -1, 0, -1, 0, 0, 1, 1, 0, 1, -1, 0, 1, -1, 1, 0, -1, 0, -1, 1, 1, -1, 1, 1, 1, 1, 0, -1, 1, 1, 0, -1, -1, 1, -1, -1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, -1, 0, 0, 1, 0, 1, 1, -1, 0, 0, 0, 1, 0, 1, -1, 0, 1, 0, 0, 1, 0, 1, -1, 1, -1, -1, 0, 1, -1, -1, 0, -1, 0, -1, 1, 1, 0, 1, -1, 0, -1, -1, 0, 0, 1, 0, 0, -1, -1, -1, 1, 1, -1, 0, -1, -1, -1, 1, 1, -1, -1, -1, -1, 0, -1, -1, -1, -1, 1, -1, -1, 1, 0, -1, 0, 0, 0, 1, -1, 0, 1, 0, 0, -1, -1, 1, -1, -1, -1, 0, 1, 1, -1, -1, -1, -1, -1, 1, 0, 0, 0, 0, -1, -1, 1, -1, 0, 1, 1, 1, 1, 0, 0, 0, -1, 1, 1, 1, -1, -1, -1, -1, 1, 0, 0, 0, 1, -1, 1, 0, 0, 0, 0, 1, 1, 0, -1, 0, -1, -1, -1, -1, -1, 0, 1, -1, -1, 0, 1, -1, 0, -1, 0, -1, -1, 0, 0, 1, 0, 0, -1, 0, -1, 0, -1, -1, 1, 1, 0, 1, 0, 0, 1, -1, -1, -1, 1, -1, 0, -1, 0, -1, -1, 1, -1, -1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, -1, 1, -1, 1, 0, -1, -1, -1, 0, -1, 0, 0, 1, -1, 0, 0, -1, -1, 1, -1, -1, -1, -1, -1, -1, 0, -1, 1, 1, -1, 0, 1, -1, 0, -1, -1, 1, 1, 1, -1, -1, 1, -1, -1, 1, 0, 0, 0, -1, 0, -1, 0, 1, 1, 0, 1, 0, -1, 0, -1, -1, -1, 0, 0, 0, 0, -1, 0, -1, -1, 0, 0, 0, 1, -1, 0, -1, -1, -1, 1, 1, 1, 1, -1, 1, -1, 1, 0, -1, -1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, -1, 0, 1, -1, 1, 1, -1, 1, -1, 0, 0, -1, 1, -1, 0, 0, -1, 0, 0, 1, 0, -1, 1, 1, 1, -1, 1, 1, -1, 1, 0, 0, 1, 0, 0, -1, 1, -1, -1, -1, 1 });
            //solution(new int[] { 0, 1, 0, -1, 0, 1, -1, 1, 1, 1, 0, 1, 0, -1, 1, 0, 1, 0, 1, -1, 1, 0, -1, 100, 0, -1, 1, -1, 0, 1, 1, -1, -1, -1, -1, -1, 1, -1, 0, 1, 1, 0, -1, -1, 0, 1, 1, 0, 1, -1, -1, 1, 1, 1, 0, 1, 1, -1, 0, 0, 1, -1, 0, -1, -1, -1, 1, -1, -1, 1, 0, 0, 1, 1, -1, -1, 0, -1, 1, 0, -1, 0, -1, 0, 0, 1, 0, -1, 0, -1, 0, 0, 0, -1, -1, 1, -1, 1, 1, 0, -1, 0, 0, -1, 0, 0, -1, 1, 1, 0, 0, 0, -1, -1, -1, 0, 1, -1, 0, -1, 0, 0, 1, 1, 0, 1, -1, 0, 1, -1, 1, 0, -1, 0, -1, 1, 1, -1, 1, 1, 1, 1, 0, -1, 1, 1, 0, -1, -1, 1, -1, -1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, -1, 0, 0, 1, 0, 1, 1, -1, 0, 0, 0, 1, 0, 1, -1, 0, 1, 0, 0, 1, 0, 1, -1, 1, -1, -1, 0, 1, -1, -1, 0, -1, 0, -1, 1, 1, 0, 1, -1, 0, -1, -1, 0, 0, 1, 0, 0, -1, -1, -1, 1, 1, -1, 0, -1, -1, -1, 1, 1, -1, -1, -1, -1, 0, -1, -1, -1, -1, 1, -1, -1, 1, 0, -1, 0, 0, 0, 1, -1, 0, 1, 0, 0, -1, -1, 1, -1, -1, -1, 0, 1, 1, -1, -1, -1, -1, -1, 1, 0, 0, 0, 0, -1, -1, 1, -1, 0, 1, 1, 1, 1, 0, 0, 0, -1, 1, 1, 1, -1, -1, -1, -1, 1, 0, 0, 0, 1, -1, 1, 0, 0, 0, 0, 1, 1, 0, -1, 0, -1, -1, -1, -1, -1, 0, 1, -1, -1, 0, 1, -1, 0, -1, 0, -1, -1, 0, 0, 1, 0, 0, -1, 0, -1, 0, -1, -1, 1, 1, 0, 1, 0, 0, 1, -1, -1, -1, 1, -1, 0, -1, 0, -1, -1, 1, -1, -1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, -1, 1, -1, 1, 0, -1, -1, -1, 0, -1, 0, 0, 1, -1, 0, 0, -1, -1, 1, -1, -1, -1, -1, -1, -1, 0, -1, 1, 1, -1, 0, 1, -1, 0, -1, -1, 1, 1, 1, -1, -1, 1, -1, -1, 1, 0, 0, 0, -1, 0, -1, 0, 1, 1, 0, 1, 0, -1, 0, -1, -1, -1, 0, 0, 0, 0, -1, 0, -1, -1, 0, 0, 0, 1, -1, 0, -1, -1, -1, 1, 1, 1, 1, -1, 1, -1, 1, 0, -1, -1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, -1, 0, 1, -1, 1, 1, -1, 1, -1, 0, 0, -1, 1, -1, 0, 0, -1, 0, 0, 1, 0, -1, 1, 1, 1, -1, 1, 1, -1, 1, 0, 0, 1, 0, 0, -1, 1, -1, -1, -1, 1 });
            solution(new int[] { -2, 8, 3, -9, -3, 4, -10, 10, 7, 7, -1, 9, -1, -8, 8, -2, 6, -3, 8, -12, -7, -10 });
            //solution(new int[] { -1, -1, -1, -1, -1, 1, -1, -1, 1, 1, 1, 1, 1, -1, -1, -1, 1, 1, 1, 1, 1, 1, -1, 1, 1, 1, 1, 1, 1, 1, -1, -1 });
            //solution(new int[] { -2, -2, -2, 3, 4, 5, -10, 3, 4, 5, -100, -100, -2, -2, 3, 4, 6, -10, 3, 4, 5, -1, -1, 1 });
            //solution(new int[] { 0, 1, 0, -1, 0, 1, -1, 1, 1, 1, 0, 1, 0, -1, 1, 0, 1, 0, 1, -1, 1, 0, -1, 0, 0, -1, 1, -1, 0, 1, 1, -1, -1, -1, -1, -1, 1, -1, 0, 1, 1, 0, -1, -1, 0, 1, 1, 0, 1, -1 });
            //solution(new int[] { 3, 2, 6, -1, 4, 5, -2, 2, -4, 3, 12, -5, 0, 7, -1 });
            //solution(new int[] { 1, 2, 3, 4, 5 }); // 7, 0-1-4
            //solution(new int[] { -1, -2, -3, -4, -5 }); // vsetko zaporne je max 0
            //solution(new int[] { 10, 1, 0, 1, 10 }); // 
            //solution(new int[] { 10, -2, 1, -3, 2, 10 }); // 1-3-5

        }



        public int solution(int[] A)
        {
            #region check negatives / positives
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
            #endregion
            if (useReduction)
            {
                A = reduceLst(A);
            }

            var validData = GetValidCollection(A, out int result);


            var lst = new List<Tuple<int, int, int>>();
            getRanges(A, 2, lst);

            if (useLog)
            {
                logFile = $"R{(useReduction ? 1 : 0)}_O{(useOptimization ? 1 : 0)}_OL{A.Length}_RL{A.Length}.txt";
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
            int maxSumTotalU = 0, maxSumTotalA = 0, sumTot = 0;

            int lastUnderY = A.Length - 2, lastAboveY = 1, maxUnderY = 0, maxAboveY = 0;
            int yFrom, y = 1, yStart = 0, sumUnderY = 0, sumAboveY = 0;
            if (useOptimization)
            {
                lastUnderY = getMaxForY(A, y, 1, lastUnderY, out maxUnderY, out sumUnderY, out yFrom);  // y sa prehladava smerom ku koncu (len - 2)
                lastAboveY = getMaxForY(A, y, -1, lastAboveY, out maxAboveY, out sumAboveY, out yFrom); // y sa prehladava smerom k zaciatku (1)
                validData[y].SetComputed(maxAboveY, maxUnderY);
                if (useLog)
                    addLog(A, lastUnderY, lastAboveY, maxUnderY, maxAboveY, y, sumUnderY, sumAboveY);
                yStart = 2;
            }
            else
            {
                yStart = 1;
            }
            for (y = yStart; y < A.Length - 2; y++)
            {
                if (y == 99)
                {

                }

                if (y > lastUnderY)
                {
                    lastUnderY = getMaxForY(A, y, 1, lastUnderY, out maxUnderY, out sumUnderY, out yFrom);  // y sa prehladava smerom ku koncu (len - 2)
                    validData[y].SetComputed(maxAboveY, maxUnderY);
                    continue;
                }
                var value = A[y];
                var vdPrev = validData[y - 1];
                var vdAct = validData[y];
                var calcUnderY = Math.Max(0, vdPrev.validUnderY - value);
                //lastUnderY = getMaxForY(A, y, dirUnderY, lastUnderY, out maxUnderY, out sumUnderY);
                lastAboveY = getMaxForY(A, y, dirAboveY, lastAboveY, out maxAboveY, out sumAboveY, out yFrom);

                validData[y].SetComputed(maxAboveY, calcUnderY);
                if (useLog)
                    addLog(A, lastUnderY, lastAboveY, maxUnderY, maxAboveY, y, sumUnderY, sumAboveY);
                //Debug.WriteLine($"y: ({sumDn}) {yLastToDn} <= {y} =>  {yLastToUp} ({sumUp}), val: {A[y]}, total: {sumUp + sumDn}");
                if (maxUnderY + maxAboveY > sumTot)
                {
                    sumTot = maxUnderY + maxAboveY;
                    maxSumTotalU = maxUnderY;
                    maxSumTotalA = maxAboveY;
                }
            }
            sw.Stop();

            var msg = $"Brute: {bruteRtn}, ({xR}-{yR}-{zR}), maxSumTotal: {sumTot} ({maxSumTotalA}+{maxSumTotalU}), Elapsed ms: {sw.ElapsedMilliseconds}";
            if (useLog)
                File.AppendAllText(logFile, msg + Environment.NewLine);
            Debug.WriteLine(msg);

            return sumTot;
        }

        private void getRanges(int[] A, int fromIdx, List<Tuple<int, int, int>> lst)
        {
            int sum = 0, max = 0, maxIdx = 0, min = 0, minIdx = 0;
            while (A[fromIdx] < 0) fromIdx++; // opt. zaporne nezlepsia vysledok
            for (int idx = fromIdx; idx < A.Length - 1; idx++)
            {
                sum += A[idx];
                if (sum < min)
                {
                    min = sum;
                    minIdx = idx;
                }
                if (sum - min > max)
                {
                    max = sum - min;
                    maxIdx = idx;
                    Debug.WriteLine($"max: {max}, min: {min}, idx: {minIdx}-{maxIdx}");
                }
            }
            if (maxIdx == 0)
            {
                maxIdx = A.Length - 2;
                lst.Add(Tuple.Create(fromIdx, maxIdx, max));
            }
            else
            {
                lst.Add(Tuple.Create(fromIdx, maxIdx, max));
                getRanges(A, maxIdx + 1, lst);

            }
        }

        private MDSItem[] GetValidCollection(int[] a, out int result)
        {
            var lst = new List<MDSItem>();
            lst.Add(new MDSItem(0, 0, 0, 0, 0, 0));
            bool ur = useReduction, ub = useBrute;
            useReduction = false;
            useBrute = false;
            result = solution1sec(a, (itm) =>
            {
                lst.Add(itm);
            });
            var mx = lst.Max(i => i.validUnderY + i.validAboveY);
            if (mx != result)
                throw new InvalidOperationException();
            useReduction = ur;
            useBrute = ub;
            return lst.ToArray();

        }

        public int solution1sec(int[] A, Action<MDSItem> addItem)
        {
            //A = A.Reverse().ToArray();

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
                logFile = $"R{(useReduction ? 1 : 0)}_O{(useOptimization ? 1 : 0)}_OL{aOrigLen}_RL{A.Length}.txt";
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
            int maxSumTotal = 0, yFrom;

            int lastUnderY = A.Length - 2, lastAboveY = 1, maxUnderY = 0, maxAboveY = 0, y = 1, yStart = 0, sumUnderY = 0, sumAboveY = 0;
            if (useOptimization)
            {
                lastUnderY = getMaxForY(A, y, 1, lastUnderY, out maxUnderY, out sumUnderY, out yFrom);  // y sa prehladava smerom ku koncu (len - 2)
                lastAboveY = getMaxForY(A, y, -1, lastAboveY, out maxAboveY, out sumAboveY, out yFrom); // y sa prehladava smerom k zaciatku (1)
                if (useLog)
                    addLog(A, lastUnderY, lastAboveY, maxUnderY, maxAboveY, y, sumUnderY, sumAboveY);
                if (addItem != null)
                    addItem(new MDSItem(y, A[y], maxAboveY, maxUnderY, lastAboveY, lastUnderY));
                yStart = 2;
            }
            else
            {
                yStart = 1;
            }
            for (y = yStart; y < A.Length - 2; y++)
            {

                if (useOptimization)
                {
                    lastUnderY = getMaxForY(A, y, dirUnderY, lastUnderY, out maxUnderY, out sumUnderY, out yFrom);
                    lastAboveY = getMaxForY(A, y, dirAboveY, lastAboveY, out maxAboveY, out sumAboveY, out yFrom);
                    if (addItem != null)
                        addItem(new MDSItem(y, A[y], maxAboveY, maxUnderY, lastAboveY, lastUnderY));
                }
                else
                {
                    getMaxForY(A, y, dirUnderY, lastUnderY, out maxUnderY, out sumUnderY, out yFrom);
                    getMaxForY(A, y, dirAboveY, lastAboveY, out maxAboveY, out sumAboveY, out yFrom);
                }
                if (useLog)
                    addLog(A, lastUnderY, lastAboveY, maxUnderY, maxAboveY, y, sumUnderY, sumAboveY);
                //Debug.WriteLine($"y: ({sumDn}) {yLastToDn} <= {y} =>  {yLastToUp} ({sumUp}), val: {A[y]}, total: {sumUp + sumDn}");
                maxSumTotal = Math.Max(maxSumTotal, maxUnderY + maxAboveY);
            }
            sw.Stop();

            var msg = $"Brute: {bruteRtn}, ({xR}-{yR}-{zR}), maxSumTotal: {maxSumTotal}, Elapsed ms: {sw.ElapsedMilliseconds}";
            if (useLog)
                File.AppendAllText(logFile, msg + Environment.NewLine);
            Debug.WriteLine(msg);

            return maxSumTotal;
        }

        private int getMaxForY(int[] A, int y, int direction, int yTo, out int max, out int sum, out int yFrom)
        {
            int newYTo;
            yFrom = 0;
            newYTo = yTo;
            sum = max = 0;
            var newY = y;
            if (direction == dirUnderY) // sum under y
            {
                if (yTo < y)
                    yTo = A.Length - 2;
                while (newY < yTo)
                {
                    newY++;
                    sum += A[newY];
                    if (sum > max)
                    {
                        max = sum;
                        newYTo = newY;
                        if (yFrom == 0)
                            yFrom = newY;
                    }
                }
            }
            else
            {
                while (newY > yTo)
                {
                    newY--;
                    sum += A[newY];

                    if (sum > max)
                    {
                        max = sum;
                        newYTo = newY;
                        if (yFrom == 0)
                            yFrom = newY;
                    }
                }
            }
            max = Math.Max(0, max);
            return newYTo;
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

        private void solution2(int[] A)
        {
            useLog = true;
            useOptimization = true;
            solution(A);
            useOptimization = false;
            solution(A);
        }

        public int solutionMSS(int[] A)
        {
            var hasPositives = A.Any(i => i > 0);
            var hasNegatives = A.Any(i => i < 0);
            if (!hasNegatives)
                return A.Sum();
            if (!hasPositives)
                return A.Max();

            // has positives and negatives,  –2,147,483,648 and 2,147,483,647 .
            int maxValue = A.Max();
            int maxSum = Math.Max(A.Sum(), maxValue);

            // reduction
            var newA = new List<int>();
            int idx = 0;
            while (A[idx] <= 0) idx++; // skip negatives
            bool isNegative = false;
            int sum = 0;
            for (int i = idx; i < A.Length; i++)
            {
                var aValue = A[i];
                if (aValue == 0) continue;
                if (isNegative && aValue < 0 || !isNegative && aValue > 0)
                    sum += aValue;
                else
                {
                    newA.Add(sum);
                    sum = aValue;
                    isNegative = !isNegative;
                }
            }
            if (sum > 0)
                newA.Add(sum);

            maxSum = Math.Max(newA.Max(), maxSum);

            // finding max
            for (int i = 0; i < newA.Count; i += 2)
            {
                sum = newA[i];
                for (int j = i + 1; j < newA.Count; j += 2)
                {
                    sum += newA[j] + newA[j + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        //Debug.WriteLine($"{i}, {j}, {maxSum}");
                    }
                }
            }

            return maxSum;
        }


        private void addLog(int[] A, int lastUnderY, int lastAboveY, int maxUnderY, int maxAboveY, int y, int sumUnderY, int sumAboveY)
        {
            //  addLog(A, lastUnderY, lastAboveY, maxUnderY, maxAboveY, y, sumUnderY, sumAboveY);

            //var msgl = $"y: {y},\tA[y]: {A[y],-5}, maxUnderY: {maxUnderY,-5}, lastUnderY: {lastUnderY}, sumUnderY: {sumUnderY,-5}, maxAboveY: {maxAboveY,-5}, lastAboveY: {lastAboveY}, sumAboveY: {sumAboveY,-5}, total: {maxUnderY + maxAboveY,-5}{Environment.NewLine}";
            var msgl = $"y: {y},\tA[y]: {A[y],-5}, maxUnderY: {maxUnderY,-5}, lastUnderY: {lastUnderY}, maxAboveY: {maxAboveY,-5}, lastAboveY: {lastAboveY}, total: {maxUnderY + maxAboveY,-5}{Environment.NewLine}";
            File.AppendAllText(logFile, msgl);
        }
    }

    //[DebuggerDisplay("y: {y}, validAboveY: {validAboveY}, calcAboveY: {calcAboveY}, validUnderY: {validUnderY}, calcUnderY: {calcUnderY}")]
    [DebuggerDisplay("y: {y}, value: {value}, validUnderY: {validUnderY}, calcUnderY: {calcUnderY}, validEndUnderY: {validEndUnderY}")]
    public class MDSItem
    {

        public int y { get; }

        public int value { get; }

        public int validAboveY { get; }

        public int validUnderY { get; }
        public int validEndAboveY { get; }
        public int validEndUnderY { get; }
        public int calcAboveY { get; set; }

        public int calcUnderY { get; set; }

        public MDSItem(int y, int value, int vAboveY, int vUnderY, int vEndAboveY, int vEndUnderY)
        {
            this.y = y;
            this.value = value;
            this.validAboveY = vAboveY;
            this.validUnderY = vUnderY;
            this.validEndAboveY = vEndAboveY;
            this.validEndUnderY = vEndUnderY;

        }

        internal void SetComputed(int maxAboveY, int maxUnderY)
        {
            calcAboveY = maxAboveY;
            calcUnderY = maxUnderY;
            if (calcAboveY != validAboveY)
            {

            }
            if (calcUnderY != validUnderY)
            {

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Codility
{
    internal class GenomicRangeQuery
    {
        public GenomicRangeQuery()
        {
            var N_MAX = 100_000;
            var M_MAX = 50_000;

            //var bb0 = solution("CAGCCTA", new int[] { 2, 5, 0 }, new int[] { 4, 5, 6 });
            //return;
            getRandomData(N_MAX, M_MAX, out var s, out var p, out var q);
            var sw = new Stopwatch();
            sw.Start();
            var bb = solution(s, p, q);
            sw.Stop();
            var ela = sw.ElapsedMilliseconds;
        }



        public int[] solution(string S, int[] P, int[] Q)
        {
            List<int> results = new List<int>();

            //search preparations
            int lastIdxFactor1 = -2, lastIdxFactor2 = -2, lastIdxFactor3 = -2;

            // decode factors
            var lstFactors = new List<int>();
            for (int i = 0; i < S.Length; i++)
            {
                int f;
                var c = S[i];
                if (c == 'A')
                    f = 1;
                else if (c == 'C')
                    f = 2;
                else if (c == 'G')
                    f = 3;
                else
                    f = 4;

                lstFactors.Add(f);
            }
            var iS = lstFactors.ToArray();

            /// Item1 - closest right index for factor 1
            /// Item2 - closest right index for factor 2
            /// Item3 - closest right index for factor 3
            var iS2 = new List<Tuple<int, int, int>>();

            // enumerate factors
            for (int i = 0; i < iS.Length; i++)
            {
                // find nearest indexes with optimizations
                if (lastIdxFactor1 < i)
                {
                    lastIdxFactor1 = Array.FindIndex(iS, i, (x) => x == 1);
                    if (lastIdxFactor1 < 0)
                        lastIdxFactor1 = iS.Length;
                }
                if (lastIdxFactor2 < i)
                {
                    lastIdxFactor2 = Array.FindIndex(iS, i, (x) => x == 2);
                    if (lastIdxFactor2 < 0)
                        lastIdxFactor2 = iS.Length;
                }
                if (lastIdxFactor3 < i)
                {
                    lastIdxFactor3 = Array.FindIndex(iS, i, (x) => x == 3);
                    if (lastIdxFactor3 < 0)
                        lastIdxFactor3 = iS.Length;

                }

                iS2.Add(new Tuple<int, int, int>(lastIdxFactor1, lastIdxFactor2, lastIdxFactor3));
            }

            // enumerate requests
            for (int idxRequest = 0; idxRequest < P.Length; idxRequest++)
            {
                var start = P[idxRequest];
                var end = Q[idxRequest];
                var data = iS2[start];
                if (data.Item1 <= end)
                    results.Add(1);
                else if (data.Item2 <= end)
                    results.Add(2);
                else if (data.Item3 <= end)
                    results.Add(3);
                else
                    results.Add(4);

            }

            return results.ToArray();
        }

        private void getRandomData(int N, int M, out string S, out int[] P, out int[] Q)
        {
            /*
             N 1..100000 - dlzka S
             M 1..50000 - pocet requestov
             */
            var rnd = new Random(7);
            var sb = new StringBuilder();
            var lstP = new List<int>();
            var lstQ = new List<int>();
            for (int i = 0; i < N; i++)
            {
                var iC = rnd.Next(4);
                char c;
                if (iC == 0) c = 'A'; else if (iC == 1) c = 'C'; else if (iC == 2) c = 'G'; else c = 'T';
                sb.Append(c);
            }

            for (int i = 0; i < M; i++)
            {
                var start = rnd.Next(100, N) - 100;
                var end = start + rnd.Next(50);
                //var end = rnd.Next(N);
                if (start > end)
                {
                    var x = start;
                    start = end;
                    end = x;
                }
                lstP.Add(start);
                lstQ.Add(end);
            }
            S = sb.ToString();
            P = lstP.ToArray();
            Q = lstQ.ToArray();
        }


    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Codility
{
    internal class GenomicRangeQuery
    {
        public GenomicRangeQuery()
        {
            //var bigS = new string('G', 100000);
            //var sw = new Stopwatch();
            //sw.Start();
            //var aa = solution(bigS, new int[] { 2, 5, 0 }, new int[] { 4, 5, 6 });
            //sw.Stop();
            //var ela = sw.ElapsedMilliseconds;
            var bb = solution("CAGCCTA", new int[] { 2, 5, 0 }, new int[] { 4, 5, 6 });
        }

        Dictionary<Tuple<int, int>, int> memo = new Dictionary<Tuple<int, int>, int>();
        private string S;
        public int[] solution(string S, int[] P, int[] Q)
        {
            List<int> results = new List<int>();
            this.S = S;
            for (int iRange = 0; iRange < P.Length; iRange++)
                results.Add(getFactor(P[iRange], Q[iRange]));

            return results.ToArray();
        }

        private int getFactor(int start, int end)
        {
            var tpl = new Tuple<int, int>(start, end);
            if (memo.ContainsKey(tpl))
                return memo[tpl];

            //  Nucleotides of types A, C, G and T have impact factors of 1, 2, 3 and 4, respectively.
            if (start == end)
            {
                return getCharFactor(S[start]);
            }

            var f = Math.Min(getCharFactor(S[end]), getFactor(start, end - 1));
            memo.Add(tpl, f);
            return f;
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int getCharFactor(char c)
        {
            if (c == 'A')
                return 1;
            else if (c == 'C')
                return 2;
            else if (c == 'G')
                return 3;
            return 4;

        }
    }
}
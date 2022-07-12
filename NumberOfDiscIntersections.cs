using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility
{
    internal class NumberOfDiscIntersections
    {
        public NumberOfDiscIntersections()
        {
            solution(new int[] { 1, 5, 2, 1, 4, 0 });
        }

        public int solution(int[] A)
        {
            var data = new Dictionary<int, HashSet<int>>();
            var hsResults = new HashSet<Tuple<int, int>>();

            for (int posX = 0; posX < A.Length; posX++)
            {
                var radius = A[posX];
                for (int i = posX - radius; i <= posX + radius; i++)
                {
                    if (!data.ContainsKey(i))
                    {
                        var hs = new HashSet<int>();
                        hs.Add(posX);
                        data.Add(i, hs);

                    }
                    else
                    {
                        var di = data[i];
                        foreach (var prevX in di)
                        {
                            var tpl = Tuple.Create(posX, prevX);
                            hsResults.Add(tpl);
                        }
                        di.Add(posX);
                    }
                }
            }
            return hsResults.Count;
        }
    }
}
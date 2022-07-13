using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Codility
{
    internal class NumberOfDiscIntersections
    {
        public NumberOfDiscIntersections()
        {
            solution(new int[] { 1, 2147483647, 0 }); //; 2
            solution(new int[] { 1, 5, 2, 1, 4, 0 }); //; 11
            solution(new int[] { 1, 1, 1 }); //; 3
        }

        public int solution(int[] A)
        {
            var lstData = new List<Tuple<long, bool>>();
            for (long i = 0; i < A.Length; i++)
            {
                int radius = A[i];
                lstData.Add(Tuple.Create(i - radius, true));
                lstData.Add(Tuple.Create(i + radius, false));
            }
            var data = lstData.OrderBy(i => i.Item1).ThenByDescending(i => i.Item2).ToArray();

            long count = 0;
            var level = -1;
            foreach (var item in data)
            {
                if (item.Item2) // disk starts
                {
                    level++;
                    count += level;
                }
                else
                    level--;
                if (count > 10000000)
                    return -1;

            }

            return (int)count;
        }
    }



}
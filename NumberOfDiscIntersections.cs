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
            //solution(new int[] { 1, 5, 2, 1, 4, 0 }); //; 11
            //solution(new int[] { 1, 1, 1 }); //; 3
        }

        public int solution(int[] A)
        {
            var lstRanges = new List<Tuple<long, long>>();

            for (long posX = 0; posX < A.Length; posX++)
            {
                long radius = A[posX];
                var range = Tuple.Create(posX - radius, posX + radius);
                lstRanges.Add(range);
            }
            int count = 0;
            var ranges = lstRanges.OrderBy(i => i.Item1).ThenBy(i => i.Item2).ToArray();

            var lstData = new List<Tuple<long, bool>>();
            foreach (var item in lstRanges)
            {
                lstData.Add(Tuple.Create(item.Item1, true));
                lstData.Add(Tuple.Create(item.Item2, false));
            }
            var data = lstData.OrderBy(i => i.Item1).ThenByDescending(i => i.Item2).ToArray();

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
                Debug.WriteLine($"{level}, {item.Item1}, {item.Item2}");

            }
            Debug.WriteLine($"count: {count}");

            return count;
        }
    }



}
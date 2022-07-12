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
            //solution(new int[] { 1, 2147483647, 0 }); //; 2
            //solution(new int[] { 1, 5, 2, 1, 4, 0 }); //; 11
            solution(new int[] { 1, 1, 1 }); //; 3
        }

        public int solution(int[] A)
        {
            var ranges = new Dictionary<long, Tuple<long, long>>();

            for (long posX = 0; posX < A.Length; posX++)
            {
                long radius = A[posX];
                var range = Tuple.Create(posX - radius, posX + radius);
                ranges.Add(posX, range);
            }

            int count = 0;
            for (int i = 0; i < A.Length - 1; i++)
            {
                var iRange = ranges[i];
                for (int j = i + 1; j < A.Length; j++)
                {
                    var jRange = ranges[j];
                    var overlap = iRange.Item1 <= jRange.Item2 && jRange.Item1 <= iRange.Item2;
                    if (overlap)
                    {
                        count++;
                    }

                }
            }
            return count;
        }
    }



}
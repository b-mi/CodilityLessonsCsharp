using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility
{
    internal class Fish
    {
        public Fish()
        {
            //solution(new int[] { 1 }, new int[] { 0 });
            solution(new int[] { 0, 1 }, new int[] { 1, 1 });
            //solution(new int[] { 4, 3, 2, 1, 5 }, new int[] { 0, 1, 0, 0, 0 });

            var q = new Queue<int>();
            

        }

        /*
          A[0] = 4    B[0] = 0
          A[1] = 3    B[1] = 1
          A[2] = 2    B[2] = 0
          A[3] = 1    B[3] = 0
          A[4] = 5    B[4] = 0 

            1 - down, 0 up
         */

        public int solution(int[] A, int[] B)
        {
            var lst = new List<Tuple<int, int>>();
            for (int i = 0; i < A.Length; i++)
                lst.Add(new Tuple<int, int>(A[i], B[i]));

            Tuple<int, int> fishDown;
            int idx = 0;
            var lstToDelete = new List<Tuple<int, int>>();
            while (idx < A.Length && lst[idx].Item2 != 1) idx++; // first downFish
            if (idx < A.Length)
            {
                fishDown = lst[idx];
                while (idx < A.Length && lst[idx].Item2 == 1)
                {
                    if (lst[idx].Item1 > fishDown.Item1)
                        fishDown = lst[idx]; // find biggest fish
                    idx++;
                }

                while (fishDown != null && idx < A.Length)
                {
                    var fish = lst[idx];
                    if (fish.Item2 == 0) // fish to eat
                    {
                        if (fishDown.Item1 > fish.Item1)
                        {
                            lstToDelete.Add(fish);
                        }
                        else
                        {
                            lstToDelete.Add(fishDown);
                            fishDown = null;
                        }
                    }
                    else
                    {
                        // fish in the same direction
                        if (fish.Item1 > fishDown.Item1)
                            fishDown = fish;
                    }
                    idx++;
                }

            }
            return A.Length - lstToDelete.Count;
        }
    }
}
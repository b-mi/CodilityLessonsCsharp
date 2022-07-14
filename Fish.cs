using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility
{
    internal class Fish
    {
        public Fish()
        {
            solution(new int[] { 1 }, new int[] { 0 }); // 1
            //solution(new int[] { 0, 1 }, new int[] { 1, 1 }); // 2
            //solution(new int[] { 4, 3, 2, 1, 5 }, new int[] { 0, 1, 0, 0, 0 }); // 2

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

            var stackDownFishes = new Stack<Tuple<int, int>>();
            int survivedUpFishCount = 0;

            Tuple<int, int> eatingFish = null;
            for (int i = 0; i < lst.Count; i++)
            {
                var fish = lst[i];
                if (fish.Item2 == 0) // fish up
                {
                    if (eatingFish == null)
                        survivedUpFishCount++; //add live fish
                    else
                    {
                        if (eatingFish.Item1 > fish.Item1) // eatingFish is bigger so eat upstream fish
                        {
                            // fish was eaten, no add to count
                        }
                        else
                        {
                            // eating fish was eaten
                            if (stackDownFishes.Count > 0)
                            {
                                eatingFish = stackDownFishes.Pop(); // new eating fish
                                i--; // restart
                                continue;
                            }
                            else
                            {
                                eatingFish = null; // no eating fish
                                survivedUpFishCount++;
                            }
                        }
                    }
                }
                else
                {
                    //fish down
                    if (eatingFish != null)
                        stackDownFishes.Push(eatingFish);
                    eatingFish = fish;
                }
            }


            return survivedUpFishCount + stackDownFishes.Count + (eatingFish == null ? 0 : 1);
        }
    }
}
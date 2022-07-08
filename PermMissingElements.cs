using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Codility
{
    internal class PermMissingElements
    {
        public PermMissingElements()
        {

            Debug.Assert(solution(new int[] { 2, 3, 1, 5 }) == 4);
            Debug.Assert(solution(new int[0]) == 1);
            Debug.Assert(solution(new int[] { 2 }) == 1);
            Debug.Assert(solution(new int[] { 1 }) == 2);
            Debug.Assert(solution(new int[] { 2, 3, 1, 4, 5 }) == 6);
            Debug.Assert(solution(new int[] { 2, 3, 4, 5 }) == 1);
            Debug.Assert(solution(new int[] { 1, 2 }) == 3);


            Console.WriteLine("done");

            Console.ReadKey();
        }


        public int solution(int[] A)
        {
            if (A.Length == 0)
                return 1;
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            Array.Sort(A);

            int i;
            for (i = 0; i < A.Length; i++)
            {
                if (A[i] != i + 1)
                    return i + 1;
            }
            return i + 1;
        }
    }
}
using System;

namespace Codility
{
    internal class CyclicRotation
    {
        public CyclicRotation()
        {
            //for (int k = 0; k < 10; k++)
            //{
            //    var x = solution(new int[] { 3, 8, 9, 7, 6 }, k);

            //}
            var x = solution(new int[] { 3, 8, 9, 7, 6 }, 3);
            x = solution(new int[] { 0, 0, 0 }, 1);
            x = solution(new int[] { 1, 2, 3, 4 }, 4);

            x = solution(new int[] { 3, 8, 9, 7, 6 }, 1000);
            x = solution(new int[] { 0, 0, 0 }, 1000);
            x = solution(new int[] { 1, 2, 3, 4 }, 1000);

            Console.ReadKey();
        }

        public int[] solution(int[] A, int K)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (K <= 0)
                return A; // no rotation
            if (A == null || A.Length <= 1)
                return A; // small array, no rotation
            if (K == A.Length)
                return A; // no rotation

            var idxDst = K % A.Length;

            var aNew = new int[A.Length];
            for (int idxSrc = 0; idxSrc < A.Length; idxSrc++)
            {
                aNew[idxDst++] = A[idxSrc];
                if (idxDst == A.Length)
                    idxDst = 0;
            }

            //Console.WriteLine($"{string.Join(", ", A)}, K: {K}, Result: {string.Join(", ", aNew)}");

            return aNew;
        }
    }
}
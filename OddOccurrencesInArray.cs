using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Codility
{
    internal class OddOccurrencesInArray
    {
        public OddOccurrencesInArray()
        {
            Debug.Assert(solution(new int[] { 9, 3, 9, 3, 9, 7, 9 }) == 7);
        }

        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var dct = new Dictionary<int, int>();
            foreach (var num in A)
            {
                if (dct.ContainsKey(num))
                    dct[num]++;
                else
                    dct.Add(num, 1);
            }
            foreach (var keyValue in dct)
            {
                if (keyValue.Value % 2 == 1)
                    return keyValue.Key;
            }
            throw new NotImplementedException();
        }
    }
}
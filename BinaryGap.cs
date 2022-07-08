using System;
using System.Diagnostics;
using System.Linq;

namespace Codility
{
    internal class BinaryGap
    {
        public BinaryGap()
        {
            Debug.Assert(solution(1041) == 52 );
            Debug.Assert(solution(32) == 0);
            Debug.Assert(solution(69) == 3);
            Console.ReadKey();
        }

        public int solution(int N)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var strBin = Convert.ToString(N, 2);
            strBin = strBin.Trim('0');
            if (strBin.Length == 0)
                return 0; // all are 0

            var oneCount = strBin.Count(c => c == '1');
            if (oneCount == strBin.Length)
            {
                return 0; // all are 1, no gap
            }

            if (oneCount == 2)
            {
                return strBin.Length - 2; // all inside is 0
            }

            var maxLen = strBin.Length - oneCount; // set max possible gap length
            if (maxLen > 0)
            {
                var zeroString = new string('0', maxLen);
                while (!strBin.Contains(zeroString))
                {
                    zeroString = zeroString.Substring(0, --maxLen);
                }
                return zeroString.Length;
            }
            return 0;
        }

    }
}
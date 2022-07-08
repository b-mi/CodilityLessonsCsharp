using System;

namespace Codility
{
    internal class CountDiv
    {
        public CountDiv()
        {

            solution(11, 345, 17);
            solution(10, 10, 5);
            solution(10, 10, 7);
            solution(10, 10, 20);


            solution(5, 9, 2);
            solution(5, 10, 2);
            solution(5, 11, 2);

            solution(6, 9, 2);
            solution(6, 10, 2);
            solution(6, 11, 2);

            solution(7, 9, 2);
            solution(7, 10, 2);
            solution(7, 11, 2);


            solution(7, 20, 3);
            solution(0, 0, 1);
            solution(7, 7, 7);
            solution(0, 13, 3);
            solution(0, 20, 3);
            solution(0, 2, 3);

            Console.ReadKey();
        }

        public int solution(int A, int B, int K)
        {
            var min = A / K;
            if (A % K > 0)
                min++;
            min *= K;
            var max = B / K * K;
            var cnt = (max - min) / K + 1;
            return cnt;
        }

    }
}
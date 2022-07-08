using System;

namespace Codility
{
    internal class FrogJmp
    {
        public FrogJmp()
        {
            Console.WriteLine(solution(10, 85, 30));
            Console.WriteLine(solution(10, 10, 30));
            Console.WriteLine(solution(10, 19, 10));
            Console.WriteLine(solution(10, 20, 10));
            Console.WriteLine(solution(10, 21, 10));
            Console.WriteLine(solution(10, 1000000000, 354));


            Console.ReadKey();
        }

        public int solution(int X, int Y, int D)
        {
            //Console.Write($"{X} -> {Y} [{D}]: ");
            if (X == Y)
                return 0;

            var distance = Y - X;
            var leapsCount = distance / D;
            var rest = distance % D;
            if (rest == 0)
                return leapsCount; // jump exactly to the target
            return leapsCount + 1; // need one smaller jump
        }
    }
}
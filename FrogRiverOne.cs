namespace Codility
{
    internal class FrogRiverOne
    {
        public FrogRiverOne()
        {
            var aa = solution(5, new int[] { 1, 3, 1, 4, 2, 3, 5, 4 });
        }

        public int solution(int X, int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var leaves = new bool[X];
            var leavesCount = 0;
            for (int idx = 0; idx < A.Length; idx++)
            {
                var leaf = A[idx];
                if (!leaves[leaf - 1])
                {
                    leaves[leaf - 1] = true;
                    leavesCount++;
                    if (leavesCount == X)
                    {
                        return idx;
                    }
                }
            }
            return -1;
        }

    }
}
using System.Collections.Generic;

namespace Codility
{
    internal class StoneWall
    {
        public StoneWall()
        {
            var result = solution(new int[] { 8, 8, 5, 7, 9, 8, 7, 4, 8 });
        }

        public int solution(int[] H)
        {
            if( H.Length == 1)
            {
                return 1;
            }
            var stack = new Stack<int>();
            int blocksCount = 1;
            stack.Push(H[0]);
            var peekHeight = H[0];
            for (int i = 1; i < H.Length; i++)
            {
                var newHeight = H[i];
                if (newHeight == peekHeight)
                    continue;

                if (newHeight < peekHeight)
                {
                    while (stack.Count > 0)
                    {
                        peekHeight -= stack.Pop();
                        if (peekHeight <= newHeight)
                            break;
                    }

                    if (peekHeight < newHeight)
                    {
                        stack.Push(newHeight - peekHeight);
                        peekHeight = newHeight;
                        blocksCount++;
                    }

                }
                else
                {
                    // newHeight > peekHeight
                    stack.Push(newHeight - peekHeight);
                    peekHeight = newHeight;
                    blocksCount++;
                }
            }


            return blocksCount;
        }
    }
}
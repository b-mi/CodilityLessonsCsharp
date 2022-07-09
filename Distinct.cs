using System.Linq;

namespace Codility
{
    internal class Distinct
    {
        public Distinct()
        {
            var rtn = solution( new int[] { 2, 1, 1, 2, 3, 1 } );
        }
        public int solution(int[] A)
        {
            return A.Distinct().Count();
        }
    }
}
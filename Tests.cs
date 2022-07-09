using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace Codility
{
    internal class Tests
    {
        public Tests()
        {
        }


        internal void TestPointTuple()
        {
            int max = 100_000;
            var sw = new Stopwatch();

            for (int i = 0; i < 3; i++)
            {
                sw.Restart();
                TestDctDct(max);
                sw.Stop();
                Console.WriteLine($"TestPoint: {sw.ElapsedMilliseconds}");

                sw.Restart();
                TestTuple(max);
                sw.Stop();
                Console.WriteLine($"TestTuple: {sw.ElapsedMilliseconds}");


            }

        }


        internal void TestTuple(int max)
        {
            var dct = new Dictionary<Tuple<int, int>, int>();
            for (int i = 0; i <= max; i++)
            {
                var p = new Tuple<int, int>(i, i);
                if (!dct.ContainsKey(p))
                {
                    dct.Add(p, i);
                }
            }
            int x;
            for (int i = 0; i <= max; i++)
            {
                var p = new Tuple<int, int>(i, i);
                if (dct.ContainsKey(p))
                    x = dct[p];
            }
        }

        internal void TestDctDct(int max)
        {
            var dct = new Dictionary<int, Dictionary<int, int>>();
            for (int i = 0; i <= max; i++)
            {
                if (!dct.ContainsKey(i))
                {
                    var dct2 = new Dictionary<int, int>();
                    dct2.Add(i, i);
                    dct.Add(i, dct2);
                }
            }
            int x;
            for (int i = 0; i <= max; i++)
            {
                if (dct[i].ContainsKey(i))
                    if (dct[i].ContainsKey(i))
                        x = dct[i][i];
            }
        }


    }
}
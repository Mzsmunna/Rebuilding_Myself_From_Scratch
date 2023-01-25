using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP
{
    public static class TrappingRainWater
    {
        public static int Trap(int[] height)
        {
            //var height = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            //var height = new int[] { 4, 2, 0, 3, 2, 5 };
            //var height = new int[] { 4, 2, 0, 3, 2 };
            //var height = new int[] { 0, 2, 3, 4, 2, 0 };
            //var height = new int[] { 4, 2, 0, 0, 2, 3 };
            //var height = new int[] { 3, 2, 0, 0, 2, 4 };
            //var height = new int[] { 3, 2, 0, 0, 3, 4 };
            //var height = new int[] { 5, 0, 0, 4, 1, 2 };
            //var height = new int[] { 5, 4, 1, 2 };
            //var height = new int[] { 0 };

            //                  _
            //        _        | |
            //       | |* * * *| | 
            //       | |* *| |*| |
            //       | | |*| | | |
            //       | | |*| | | |
            //        4 2 0 3 2 5  => input array
            //        output => ********* = 9

            var heights = height.ToList();
            heights = heights.OrderByDescending(x => x).ToList();
            var result = 0;
            var max = heights[0];
            var premax = 0;

            for (int i = 0; i < height.Length - 1; i++)
            {
                var val = height[i];

                heights.Remove(val);

                if (val == max)
                    max = heights[0];

                if (val >= premax)
                {
                    premax = val;
                }
                else if (heights[0] > val)
                {
                    if (premax < max)
                        result += premax - val;
                    else
                        result += max - val;
                }
            }

            return result;
        }
    }
}

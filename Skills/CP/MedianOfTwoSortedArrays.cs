using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP
{
    public static class MedianOfTwoSortedArrays
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            double result = 0;

            List<int> list1 = nums1.ToList();
            List<int> list2 = nums2.ToList();

            list1.AddRange(list2);
            list1 = list1.OrderBy(x => x).ToList();

            if (list1.Count % 2 == 0)
            {
                var midPosition = list1.Count / 2;

                var val1 = (double)list1[midPosition];
                var val2 = (double)list1[midPosition - 1];

                result = ((val1 + val2) / 2);
            }
            else
            {
                int midPosition = list1.Count / 2;

                result = (double)list1[midPosition];
            }

            return result;
        }
    }
}

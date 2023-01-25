using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP
{
    public static class ReverseInteger
    {
        public static int Reverse(int x)
        {
            //int x = -123;

            try
            {
                var s = x.ToString();
                bool isNegative = false;

                var r = string.Empty;

                if (s.StartsWith("-"))
                {
                    isNegative = true;
                    s = s.Substring(1, s.Length - 1);
                }

                for (int i = s.Length - 1; i >= 0; i--)
                {
                    r += s[i];
                }

                x = Convert.ToInt32(r);

                if (isNegative)
                    x = x * -1;
            }
            catch (Exception ex)
            {
                x = 0;
            }

            return x;
        }
    }
}

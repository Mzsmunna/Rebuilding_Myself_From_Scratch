using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CP
{
    public static class StringToIntegerAtoi
    {
        public static int MyAtoi(string s)
        {
            //var s = "   wow -44 ";
            //var s = "  -44 words and 987 ";
            //var s = "   +0 123";
            //var s = "-91283472332";
            //var s = "3.14159";
            //var s = " - 0012a42";
            //s = s.Split().First(x => int.TryParse(x, out result));

            double result = 0;
            s = s.Trim();
            bool isNegative = false;

            if (!string.IsNullOrEmpty(s))
            {
                if (s.StartsWith("-"))
                {
                    isNegative = true;

                    if (s.Length > 1)
                        s = s.Substring(1, s.Length - 1);
                }
                else if (s.StartsWith("+"))
                {
                    isNegative = false;

                    if (s.Length > 1)
                        s = s.Substring(1, s.Length - 1);
                }

                if (Char.IsNumber(s[0]))
                {
                    s = Regex.Match(s, @"(?<!\d+)?\d+").Value;

                    double.TryParse(s, out result);

                    if (isNegative)
                        result = result * -1;

                    if (!(result >= Int32.MinValue && result <= Int32.MaxValue))
                    {
                        if (result >= Int32.MaxValue)
                            result = Int32.MaxValue;
                        else
                            result = Int32.MinValue;
                    }
                }
            }

            return (int)result;
        }
    }
}

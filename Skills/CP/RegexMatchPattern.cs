using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CP
{
    public static class RegexMatchPattern
    {
        public static bool IsMatch(string s, string p)
        {

            bool result = false;

            try
            {
                //result = Regex.IsMatch(s, @p);

                Regex rx = new Regex(@p);
                Match m = rx.Match(s);

                if (m.Length == s.Length)
                    result = true;
                else
                    result = false;
            }
            catch (Exception ex)
            {

                //Console.WriteLine(ex.Message);
                result = false;
            }

            return result;
        }
    }
}

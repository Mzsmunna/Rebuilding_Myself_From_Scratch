using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP
{
    public static class LongestValidParentheses
    {
        public static int LongestValidParenthese(string s)
        {
            //var s = "";
            //var s = "(()";
            //var s = ")()())";
            //var s = ")())())";
            //var s = "()(())";
            //var s = "()(()";
            //var s = "(()()";
            //var s = "))))((()((";

            List<string> patterns = new List<string>();
            int result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                string c = s[i].ToString();

                if (c.Equals("("))
                    patterns.Add("(");

                if (c.Equals(")") && patterns.Contains("("))
                {
                    var m = patterns.Where(p => p.Equals("(")).LastOrDefault();

                    if (!string.IsNullOrEmpty(m))
                    {
                        m += ")";

                        int index = patterns.Select((elem, index) => new { elem, index })
                                    .Last(p => p.elem == "(")
                                    .index;

                        patterns.RemoveAt(index);
                        patterns.Add(m);
                    }

                }
                else if (c.Equals(")"))
                    patterns.Add(")");
            }

            if (patterns.Count > 0)
            {
                var max = 0;

                foreach (var p in patterns)
                {
                    if (p.Equals("()"))
                        result = result + 2;
                    else
                    {
                        if (result > max)
                            max = result;

                        result = 0;
                    }
                }

                if (max > result)
                    result = max;
            }

            return result;
        }
    }
}

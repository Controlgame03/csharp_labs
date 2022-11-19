using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace mylib
{
    public class Class1
    {
        public static MatchCollection Find(string s, string signature)
        {
            Regex regex = new Regex(signature, RegexOptions.IgnoreCase);
            if (s != null)
            {
                MatchCollection matches = regex.Matches(s);
                return matches;
            }
            else
            {
                return null;
            }
        }
        public static MatchCollection Date(string s)
        {
            Regex regex = new Regex(@"([0-1]?\d|2[0-3]):([0-5]?\d):([0-5]?\d)");
            if (s != null)
            {
                MatchCollection matches = regex.Matches(s);
                return matches;
            }
            else
            {
                return null;
            }
        }
    }
}


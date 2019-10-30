using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    static class Service
    {
        public static int? TuNull(this string s)
        {
            int i;
            if (int.TryParse(s.ToString(), out i)) return i;
            return null;
        }

        public static string GetValue(this string str)
        {
            if (str.Length == 0)
                throw new Exception();
            return str;
        }
    }
}

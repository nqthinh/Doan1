using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    public class function
    {
        public static string upperfirst(string s)
        {
            if (String.IsNullOrEmpty(s))
                return s;
            string result = "";
            var str = s.Trim();
            result = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
            return result.Trim();
        }

        public static string upperfirstword(string s)
        {
            string result = "";
            string[] getword = s.Trim().Split(' ');
            string kytudau = "";
            for (int i = 0; i < getword.Length; i++)
            {
                kytudau = getword[i].Substring(0, 1);
                result += kytudau.ToUpper() + getword[i].Remove(0, 1) + " ";
            }
            return result;
        }
    }
}

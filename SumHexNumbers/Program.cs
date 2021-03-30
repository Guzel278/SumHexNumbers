using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SumHexNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();         
            if (Validate(s1) && Validate(s2)) //checking that a hexadecimal number was entered
            {               
                if (s1.Length != s2.Length) //checking that the numbers are the same length, if not, then zeros are added to the short string at the beginning of the string
                {
                    int count = Math.Abs(s1.Length - s2.Length);
                    if (s1.Length > s2.Length)
                    {
                        s2 = GetEqualLenght(s2, count);
                    }
                    else
                    {
                       s1 = GetEqualLenght(s1, count);
                    }                   
                }
                string result = GetSum(s1, s2);

                Console.WriteLine(result);
            }                                
        }

        public static bool Validate(string s)
        {
            try
            {
                int.Parse(s, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture);
                return true;
            }
            catch
            {
                Console.Write("this isn't a hexadecimal number");
                return false;
            }
        }
        public static string GetEqualLenght(string s, int c)
        {       
            for (int i = 0; i < c; i++)
            {
                s = s.Insert(i, "0");              
            }
            return s;
        }
        public static string GetSum(string s1, string s2)
        {
            char[] strArr1 = s1.ToArray();
            char[] strArr2 = s2.ToArray();
            Array.Reverse(strArr1);
            Array.Reverse(strArr2);
            StringBuilder res = new StringBuilder();
            int sum = 0, num1, num2, overflow = 0;
          
            for (int i = 0; i < strArr1.Length && i < strArr2.Length; i++)
            {               
                if (int.TryParse(strArr1[i].ToString(), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out num1) 
                 && int.TryParse(strArr2[i].ToString(), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out num2))
                {                  
                        sum = num1 + num2 + overflow;
                    overflow = 0;
                    if (sum >= 16)
                    {
                        sum = Math.Abs(sum - 16);
                        overflow = 1;
                    }
                }            
                res.Insert(0, sum.ToString("X"));
            }

            if (overflow != 0)
                res.Insert(0,"1");
            
            return res.ToString();
        }
    }
}

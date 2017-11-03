using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TestWork.Shared.Extension
{
    public static class ArrayExtension
    {
        private static bool IsOnlyMembers(this string source)
        {
            const string reg = "^[0-9 ]+$";
            return Regex.IsMatch(source, reg);
        }        

        public static int IsInRange(this string source)
        {
            int result = 0;
            if (int.TryParse(source, out result))
            {
                return (result >= 2) && (result <= 100) ?
                       result :
                       throw new ArgumentException("Неверные данные!");
            }
            else
                throw new ArgumentException("Неверные данные!");
        }

        public static int[] GetCountMessages(this string source, int n)
        {
            if (!source.IsOnlyMembers())
                throw new ArgumentException("Неверные данные!");

            try
            {
                var a = source.Split(new char[] { ' ' })
                              .Select(x => int.Parse(x))
                              .Where(x => x >= 0 && x <=100)
                              .ToArray();

                return (a.Any() && a.Count() == n) ? a:
                    throw new ArgumentException("Неверные данные!");

            }
            catch (Exception)
            {
                throw new ArgumentException("Неверные данные!");
            }
        }
    }
}

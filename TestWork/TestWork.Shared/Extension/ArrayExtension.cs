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

        public static int[] GetCountMessages(this string source)
        {
            if (!source.IsOnlyMembers())
                throw new ArgumentException("Неверные данные!");

            try
            {
                return source.Split(new char[] { ' ' })
                             .Select(x => int.Parse(x))
                             .ToArray();
            }
            catch (Exception)
            {
                throw new ArgumentException("Неверные данные!");
            }
        }
    }
}

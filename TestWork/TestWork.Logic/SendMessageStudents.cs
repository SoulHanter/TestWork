using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestWork.Shared.Models;

namespace TestWork.Logic
{
    public static class SendMessageStudents
    {
        public static string SendMessage(int n, int[] a)
        {
            if (!a.Any() || a.Count() != n)
                throw new ArgumentException("Неверные данные!");

            if (IsImpossibleCommunicate(n, a))
                return "-1";



            return null;
        }

        private static bool IsImpossibleCommunicate(int n, int[] a)
        {
            return !(a[0] > 0 && a.Sum() >= (n - 1));
        }
    }
}

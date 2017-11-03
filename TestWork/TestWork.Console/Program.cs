using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestWork.Logic;
using TestWork.Shared.Extension;
using TestWork.Shared.Models;

namespace TestWork.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string resultMessage = "";

            try
            {
                System.Console.Write("Введите количество студентов: n = ");
                var n = System.Console.ReadLine().IsInRange();

                System.Console.WriteLine("Введите количество сообщений для каждого студента: A{a1, a2, ... an} = ");
                var a = System.Console.ReadLine().GetCountMessages(n);

                resultMessage = SendMessageStudents.SendMessage(n, a);
            }
            catch (Exception e)
            {
                resultMessage = e.Message;
            }
            finally
            {
                System.Console.WriteLine(resultMessage);
                System.Console.ReadKey();
            }

        }

    }
}

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
            if (IsImpossibleCommunicate(n, a))
                return "-1";

            var sequence = GetSequenceMessage(a);

            string resultMessage = $"k {sequence.Count}\n";

            foreach (var mess in sequence)
            {
                resultMessage += $"{mess.FromStudent} => {mess.ToStudent}\n";
            }

            return resultMessage;
        }

        private static bool IsImpossibleCommunicate(int n, int[] a) => !(a[0] > 0 && a.Sum() >= (n - 1));

        private static List<Message> GetSequenceMessage(int[] a)
        {
            var student = new List<Student>();

            for (int i = 1; i < a.Length; i++)
            {
                student.Add(new Student
                {
                    Position = i + 1,
                    CountMessages = a[i]
                });
            }

            return Send(student, 1, a[0]);
        }

        private static List<Student> GetNextStudents(List<Student> studens, int countMessages)
        {
            var nextStudents = new List<Student>();

            if (!studens.Any())
                return nextStudents;

            for (int i = 0; i < countMessages; i++)
            {
                var student = studens.OrderByDescending(x => x.CountMessages)
                                     .First();

                nextStudents.Add(student);
                studens.Remove(student);
            }

            return nextStudents;
        }

        private static List<Message> Send(List<Student> studens, int currentStudent, int countMessages)
        {
            var nextStudents = GetNextStudents(studens, countMessages);

            if (!nextStudents.Any())
                return new List<Message>();

            var messages = new List<Message>();

            foreach (var student in nextStudents)
            {
                messages.Add(new Message
                {
                    FromStudent = currentStudent,
                    ToStudent = student.Position
                });
                messages.AddRange(Send(studens, student.Position, student.CountMessages));
            }

            return messages;
        }
    }
}

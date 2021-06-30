using System;
using System.Text;
using System.Collections.Generic;

namespace Binary_tree
{
    class StudentInfo
    {
        private readonly string studentName;
        private readonly string testName;
        private readonly DateTime testDate;
        private readonly int rating;
        public StudentInfo(string sN, string tN, DateTime d, int r)
        {
            studentName = sN;
            testName = tN;
            testDate = d;
            rating = r;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendJoin(' ', studentName, testName,
                                     testDate.ToString(), Convert.ToString(rating));
            return stringBuilder.ToString();
        }
        internal int CompareTo(StudentInfo val)
        {
            if (studentName != val.studentName)
            {
                for (int i = 0; i < studentName.Length; i++)
                {
                    if (studentName[i] > val.studentName[i])
                    {
                        return -1;
                    }
                    else if (studentName[i] < val.studentName[i])
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }
    }
    class Node
    {
        private Node parent;
        private Node left;
        private Node right;
        public Node()
        {

        }
        public void Add()
        {

        }
        public void Remove()
        {

        }
        public Node Search()
        {

        }
    }

    class Program
    {
        private static StudentInfo InputStudent()
        {
            Console.WriteLine("Enter student name:");
            string sN = Console.ReadLine();
            Console.WriteLine("Enter test name:");
            string tN = Console.ReadLine();
            Console.WriteLine("Enter test date:");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter student result:");
            int result = Convert.ToInt32(Console.ReadLine());
            return new StudentInfo(sN, tN, date, result);
        }
        private static void PrintStudent(StudentInfo student)
        {
            string[] studentArray = student.ToString().Split(' ');
            Console.WriteLine($"\nName: {studentArray[0]}");
            Console.WriteLine($"Test: {studentArray[1]}");
            Console.WriteLine($"Date: {studentArray[3]}");
            Console.WriteLine($"Rating: {studentArray[4]}");
        }
        static void Main()
        {
            StudentInfo student1 = InputStudent();
            PrintStudent(student1);
        }
    }
}

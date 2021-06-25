using System;

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
    }
    class BinaryTree
    {

    }
    class Program
    {
        private StudentInfo InputStudent()
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
        static void Main()
        {

        }
    }
}

using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Binary_tree
{
    class StudentInfo : IComparable<StudentInfo>
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
        public int CompareTo(StudentInfo other)
        {
            //правильно реализовать
            int value = studentName.CompareTo(other.studentName);
            if (value == 0)
            {
                if (testName == other.testName && testDate == other.testDate)
                {
                    return value;
                }
                return 1;
            }
            return value;
        }
        public override string ToString()
        {
            return $"{studentName} {testName} {testDate} {Convert.ToString(rating)}";
        }
    }

    public class BinaryTreeNode<T> : IComparable<BinaryTreeNode<T>> where T : IComparable<T>
    {
        public BinaryTreeNode(T value)
        {
            Value = value;
        }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
        public T Value { get; private set; }
        public int CompareTo(BinaryTreeNode<T> other)
        {
            return Value.CompareTo(other.Value);
        }
        //переделать
        public void Add(T son)
        {
            if (Value.CompareTo(son) < 0)
            {
                if (Left == null)
                {
                    Left = new(son);
                }
            }
            else if (Value.CompareTo(son) > 0)
            {
                if (Right == null)
                {
                    Right = new(son);
                }
            }
        }

        //удаление 
        //поиск
        //вывод на печать
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
            /*
            BinaryTreeNode<int> node1 = new(5);
            node1.Add(node1);
            node1.Add(new BinaryTreeNode<int>(3));
            node1.Add(new BinaryTreeNode<int>(8));
            Console.WriteLine($"Left node: {node1.Left.Value}");
            Console.WriteLine($"Right node: {node1.Right.Value}");
            */
            BinaryTreeNode<StudentInfo> student = new(InputStudent());

        }
    }
}

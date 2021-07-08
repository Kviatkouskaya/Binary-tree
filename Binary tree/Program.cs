using System;
using System.Text;
using System.Collections.Generic;

namespace Binary_tree
{
    public class StudentInfo : IComparable<StudentInfo>
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
            int value = studentName.CompareTo(other.studentName);
            if (value == 0)
            {
                int testCompare = testName.CompareTo(other.testName);
                if (testCompare == 0)
                {
                    return testDate.CompareTo(other.testDate);
                }
                return testCompare;
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
        public void Add(T son)
        {
            if (Value.CompareTo(son) > 0)
            {
                if (Left == null)
                {
                    Left = new(son);
                }
                else if (Left != null)
                {
                    Left.Add(son);
                }
            }
            else if (Value.CompareTo(son) < 0)
            {
                if (Right == null)
                {
                    Right = new(son);
                }
                else if (Right != null)
                {
                    Right.Add(son);
                }
            }
        }
        public bool Remove(T son)
        {
            //вершина не имеет поддеревьев
            BinaryTreeNode<T> binarySonTree = new(son);
            if (binarySonTree.Left == null && binarySonTree.Right == null)
            {
                if (Left.Value.CompareTo(son) == 0)
                {
                    Left = null;
                }
                if (Right.Value.CompareTo(son) == 0)
                {
                    Right = null;
                }
                return true;
            }
            //у вершины есть только правое или левое поддерево



            //у вершины есть оба поддерева
            return false;
        }

        public bool Search(T son)
        {
            if (Value.CompareTo(son) == 0)
            {
                return true;
            }
            if (Value.CompareTo(son) > 0)
            {
                if (Left != null)
                {
                    return Left.Search(son);
                }
            }
            if (Value.CompareTo(son) < 0)
            {
                if (Right != null)
                {
                    return Right.Search(son);
                }
            }
            return false;
        }
        public override string ToString()
        {
            StringBuilder builder = new();
            if (Left != null)
            {
                builder.Append(Left.ToString());
            }
            builder.Append(Value.ToString() + " \n");
            if (Right != null)
            {
                builder.Append(Right.ToString());
            }
            return builder.ToString();
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
            StudentInfo student1 = new("Vit", "Test1", DateTime.Parse("2021-06-21"), 1);
            StudentInfo student2 = new("Vol", "Test2", DateTime.Parse("2021-06-21"), 2);
            StudentInfo student3 = new("Oleg", "Test3", DateTime.Parse("2021-06-21"), 1);
            StudentInfo student4 = new("Zidan", "Test1", DateTime.Parse("2021-06-21"), 1);
            BinaryTreeNode<StudentInfo> tree = new(student1);
            tree.Add(student2);
            tree.Add(student3);
            tree.Add(student4);
            Console.WriteLine(tree);
            Console.WriteLine();
            // tree.Remove(student3);
            Console.WriteLine(tree.FindParentRoot(student4, out _));


        }
    }
}

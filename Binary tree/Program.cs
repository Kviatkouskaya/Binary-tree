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
        public StudentInfo(string studentName, string testName, DateTime testDate, int rating)
        {
            this.studentName = studentName;
            this.testName = testName;
            this.testDate = testDate;
            this.rating = rating;
        }
        public int CompareTo(StudentInfo other)
        {
            int value = rating.CompareTo(other.rating);
            if (value != 0)
            {
                return value;
            }
            int testCompare = testName.CompareTo(other.testName);
            if (testCompare == 0)
            {
                return studentName.CompareTo(other.studentName);
            }
            return testCompare;
        }
        public override string ToString()
        {
            return $"{studentName} {testName} {testDate} {Convert.ToString(rating)}";
        }
    }

    public class TreeNode<T> : IComparable<TreeNode<T>> where T : IComparable<T>
    {
        public TreeNode(T value)
        {
            Value = value;
        }
        public TreeNode<T> Left { get; private set; }
        public TreeNode<T> Right { get; private set; }
        public TreeNode<T> Parent { get; private set; }
        public T Value { get; private set; }
        public int CompareTo(TreeNode<T> other)
        {
            return Value.CompareTo(other.Value);
        }
        public void Add(T son)
        {
            var compareResult = Value.CompareTo(son);
            if (compareResult == 0)
            {
                return;
            }
            if (compareResult > 0)
            {
                if (Left == null)
                {
                    Left = new(son);
                }
                Left.Add(son);
                Left.Parent = this;
                return;
            }
            if (Right == null)
            {
                Right = new(son);
            }
            Right.Add(son);
            Right.Parent = this;
        }
        public void Remove(T son)
        {
            TreeNode<T> found = Search(son);
            found.PerformRemoval();
        }
        private TreeNode<T> PerformRemoval()
        {
            if (Left == null && Right == null)
            {
                Detach(null);
            }
            if (Left == null || Right == null)
            {
                Detach(Left ?? Right);
            }
            else
            {
                TreeNode<T> leftLeaf = Right.FindMostLeft();
                leftLeaf.PerformRemoval();
                Detach(leftLeaf);
                leftLeaf.Left = Left;
                leftLeaf.Right = Right;
            }
            return this;
        }
        private void Detach(TreeNode<T> replacement)
        {
            if (Parent != null)
            {
                if (Parent.Left == this) Parent.Left = replacement;
                if (Parent.Right == this) Parent.Right = replacement;
            }
        }
        private TreeNode<T> FindMostLeft()
        {
            return Left == null ? this : Left.FindMostLeft();
        }
        public TreeNode<T> Search(T son)
        {
            TreeNode<T> found = null;
            if (Value.CompareTo(son) == 0)
            {
                return this;
            }
            if (Left != null)
            {
                found = Left.Search(son);
            }
            if (found == null && Right != null)
            {
                return Right.Search(son);
            }
            return found;
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
            StudentInfo student1 = new("Vit", "Test1", DateTime.Parse("2021-06-21"), 5);
            StudentInfo student2 = new("Ben", "Test2", DateTime.Parse("2021-06-21"), 3);
            StudentInfo student3 = new("Oleg", "Test3", DateTime.Parse("2021-06-21"), 6);
            StudentInfo student4 = new("Zidan", "Test1", DateTime.Parse("2021-06-21"), 7);
            TreeNode<StudentInfo> tree = new(student1);
            tree.Add(student2);
            tree.Add(student3);
            tree.Add(student4);
            Console.WriteLine(tree);
            Console.WriteLine();
            PrintStudent(tree.Search(student3).Value);
            Console.WriteLine();
            tree.Remove(student3);
            TreeNode<StudentInfo> searchRes = tree.Search(student3);
            if (searchRes == null)
            {
                Console.WriteLine("Element unfound!");
                PrintStudent(student3);
            }
        }
    }
}

﻿using System;
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
            int value = rating.CompareTo(other.rating);
            if (value == 0)
            {
                int testCompare = testName.CompareTo(other.testName);
                if (testCompare == 0)
                {
                    return studentName.CompareTo(other.studentName);
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
            if (Value.CompareTo(son) > 0)
            {
                if (Left == null)
                {
                    Left = new(son);                        //в одной части присвоение, в другой вызов метода
                }                                           // тернарный оператор невозможно применить
                else if (Left != null)
                {
                    Left.Add(son);
                }
                Left.Parent = this;
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
                Right.Parent = this;
            }
        }
        public bool Remove(T son)
        {
            TreeNode<T> parentS = Search(son);
            //проверка на существование в дереве
            if (parentS == null) return false;

            //вершина не имеет поддеревьев

            //у вершины есть только правое или левое поддерево



            //у вершины есть оба поддерева
            return false;
        }
        public TreeNode<T> Search(T son)
        {
            TreeNode<T> found = null;
            if (Value.CompareTo(son) == 0)
            {
                found = this;
            }
            else
            {
                if (Left != null)
                {
                    found = Left.Search(son);
                }
                if (found == null && Right != null)
                {
                    return Right.Search(son);
                }
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
            Console.WriteLine(student4);
            Console.WriteLine(tree.Remove(student4));
            Console.WriteLine(tree);

        }
    }
}

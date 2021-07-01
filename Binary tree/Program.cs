using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    class BinaryTreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
    {
        public BinaryTreeNode(TNode value)
        {
            Value = value;
        }
        public BinaryTreeNode<TNode> parent;
        public BinaryTreeNode<TNode> Left { get; set; }
        public BinaryTreeNode<TNode> Right { get; set; }
        public TNode Value { get; private set; }
        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }
        public int CompareNode(BinaryTreeNode<TNode> other)
        {
            return Value.CompareTo(other.Value);
        }
        public void Add(BinaryTreeNode<TNode> son)
        {
            if (parent == null)
            {
                parent = son;
            }
            else if (parent.CompareNode(son) >= 0)
            {
                Left = son;
            }
            else if (parent.CompareNode(son) < 0)
            {
                Right = son;
            }
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

            // StudentInfo student1 = InputStudent();
            // PrintStudent(student1);
            BinaryTreeNode<int> node1 = new(5);
            BinaryTreeNode<int> node2 = new(3);
            BinaryTreeNode<int> node3 = new(8);
            node1.Add(node1);
            node1.Add(new BinaryTreeNode<int>(3));
            node1.Add(new BinaryTreeNode<int>(8));
            Console.WriteLine($"Left node: {node1.Left.Value}");
            Console.WriteLine($"Right node: {node1.Right.Value}");

        }
    }
}

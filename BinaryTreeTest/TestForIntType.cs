using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binary_tree;

namespace BinaryTreeTest
{
    [TestClass]
    public class TestForIntType
    {
        [DataRow(5, 3, 8)]
        [DataRow(7, 5, 9)]
        [DataRow(6, 5, 7)]
        [TestMethod]
        public void AddTwoNodesRightLeft(int n, int n1, int n2)
        {
            BinaryTreeNode<int> node1 = new(n);
            node1.Add(n1);
            node1.Add(n2);
            Assert.IsTrue(node1.Left.Value == n1 && node1.Right.Value == n2);
        }

        [DataRow(4, 2, 1)]
        [DataRow(6, 3, 2)]
        [DataRow(8, 3, 0)]
        [TestMethod]
        public void AddTwoNodesLeftLeft(int n, int n1, int n2)
        {
            BinaryTreeNode<int> node1 = new(n);
            node1.Add(n1);
            node1.Add(n2);
            Assert.IsTrue(node1.Left.Value == n1 && node1.Left.Left.Value == n2);
        }

        [DataRow(4, 5, 6)]
        [DataRow(5, 7, 9)]
        [DataRow(6, 8, 10)]
        [TestMethod]
        public void AddTwoNodesRightRight(int n, int n1, int n2)
        {
            BinaryTreeNode<int> node1 = new(n);
            node1.Add(n1);
            node1.Add(n2);
            Assert.IsTrue(node1.Right.Value == n1 && node1.Right.Right.Value == n2);
        }
    }

    [TestClass]
    public class TestForStudentInfoClass
    {
        [DataRow("Vit", "Test1", "2021-06-21", 1, "Val", "Test2", "2021-06-21", 2, "Alex", "Test1", "2021-06-21", 1)]
        [DataRow("Zidan", "Test2", "2021-06-21", 2, "Vlad", "Test3", "2021-06-21", 3, "Jeff", "Test2", "2021-06-21", 5)]
        [DataRow("John", "Test4", "2021-06-21", 5, "Alice", "Test5", "2021-06-21", 1, "Victor", "Test2", "2021-06-21", 2)]
        [TestMethod]
        public void AddTwoNodesRightLeft(string nSt, string tN, string date, int r,
                                         string nSt1, string tN1, string date1, int r1,
                                         string nSt2, string tN2, string date2, int r2)
        {
            StudentInfo student1 = new(nSt, tN, System.DateTime.Parse(date), r);
            BinaryTreeNode<StudentInfo> node = new(student1);
            node.Add(new StudentInfo(nSt1, tN1, System.DateTime.Parse(date1), r1));
            node.Add(new StudentInfo(nSt2, tN2, System.DateTime.Parse(date2), r2));
            Assert.IsTrue(node.Left.Value.CompareTo(new StudentInfo(nSt1, tN1, System.DateTime.Parse(date1), r1)) == 0);
        }
    }
}

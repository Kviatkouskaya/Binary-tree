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
            Assert.IsTrue(node1.Value == n && node1.Left.Value == n1 && node1.Right.Value == n2);
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
            Assert.IsTrue(node1.Value == n && node1.Left.Value == n1 && node1.Left.Left.Value == n2);
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
            Assert.IsTrue(node1.Value == n && node1.Right.Value == n1 && node1.Right.Right.Value == n2);
        }

        [DataRow(1, 3, 4, 2, 5, 1)]
        [DataRow(3, 4, 5, 6, 7, 5)]
        [DataRow(6, 7, 5, 9, 10, 10)]
        [TestMethod]
        public void SearchNode(int n, int n1, int n2, int n3, int n4, int searching)
        {
            BinaryTreeNode<int> node = new(n);
            node.Add(n1);
            node.Add(n2);
            node.Add(n3);
            node.Add(n4);
            Assert.IsTrue(node.Search(searching));
        }

        [DataRow(1, 3, 4, 2, 5, 10)]
        [DataRow(3, 4, 5, 6, 7, 2)]
        [DataRow(6, 7, 5, 9, 10, 4)]
        [TestMethod]
        public void SearchNodeFalse(int n, int n1, int n2, int n3, int n4, int searching)
        {
            BinaryTreeNode<int> node = new(n);
            node.Add(n1);
            node.Add(n2);
            node.Add(n3);
            node.Add(n4);
            Assert.IsFalse(node.Search(searching));
        }

        [DataRow(6, 7, 8, 9, 2)]
        [DataRow(5, 6, 7, 8, 2)]
        [DataRow(6, 2, 3, 4, 7)]
        [TestMethod]
        public void RemoveIntLeaf(int a, int a1, int a2, int a3, int a4)
        {
            BinaryTreeNode<int> node = new(a);
            node.Add(a1);
            node.Add(a2);
            node.Add(a3);
            node.Add(a4);
            Assert.IsTrue(node.Remove(a4));
        }

        [DataRow(10, 6, 11, 5, 4, 7, 8, 11, 14, 13, 12, 15, 5)]
        [DataRow(10, 6, 11, 5, 4, 7, 8, 11, 14, 13, 12, 15, 13)]
        [DataRow(10, 6, 11, 5, 4, 7, 8, 11, 14, 13, 12, 15, 7)]
        [TestMethod]
        public void RemoveIntNodeWhithLeaf(int a, int a1, int a2, int a3, int a4,int a5,int a6,
                                           int a7,int a8,int a9,int a10,int a11, int removing)
        {
            BinaryTreeNode<int> node = new(a);
            node.Add(a1);       node.Add(a2);       node.Add(a3);       node.Add(a4);
            node.Add(a5);       node.Add(a6);       node.Add(a7);       node.Add(a8);
            node.Add(a9);       node.Add(a10);      node.Add(a11);
            Assert.IsTrue(node.Remove(removing) && !node.Search(removing));
        }

        [DataRow(4, 3, 7, 9, 1, 7)]
        [DataRow(5, 6, 7, 8, 2, 6)]
        [DataRow(6, 2, 3, 7, 8, 7)]
        [TestMethod]
        public void RemoveIntMiddle(int a, int a1, int a2, int a3, int a4, int removing)
        {
            BinaryTreeNode<int> node = new(a);
            node.Add(a1);
            node.Add(a2);
            node.Add(a3);
            node.Add(a4);
            Assert.IsTrue(node.Remove(removing) && node.Search(removing));
        }
    }

    [TestClass]
    public class TestForStudentInfoClass
    {
        [DataRow("Vit", "Test1", "2021-06-21", 1, "Val", "Test2", "2021-06-21", 2, "Zidan", "Test1", "2021-06-21", 1)]
        [DataRow("Jack", "Test2", "2021-06-21", 2, "Bob", "Test3", "2021-06-21", 3, "Jeff", "Test2", "2021-06-21", 5)]
        [DataRow("John", "Test4", "2021-06-21", 5, "Alice", "Test5", "2021-06-21", 1, "Victor", "Test2", "2021-06-21", 2)]
        [TestMethod]
        public void AddTwoNodesRightLeft(string nSt, string tN, string date, int r,
                                         string nSt1, string tN1, string date1, int r1,
                                         string nSt2, string tN2, string date2, int r2)
        {
            StudentInfo student1 = new(nSt, tN, System.DateTime.Parse(date), r);
            BinaryTreeNode<StudentInfo> node = new(student1);
            StudentInfo student2 = new(nSt1, tN1, System.DateTime.Parse(date1), r1);
            StudentInfo student3 = new(nSt2, tN2, System.DateTime.Parse(date2), r2);
            node.Add(student2);
            node.Add(student3);
            Assert.IsTrue(node.Value.CompareTo(student1) == 0 &&
                          node.Left.Value.CompareTo(student2) == 0 &&
                          node.Right.Value.CompareTo(student3) == 0);
        }
        [DataRow("Vit", "Test1", "2021-06-21", 1, "Val", "Test2", "2021-06-21", 2, "Val", "Test1", "2021-06-21", 1)]
        [DataRow("Vit", "Test1", "2021-06-21", 1, "Val", "Test2", "2021-06-21", 2, "Jeff", "Test1", "2021-06-21", 1)]
        [DataRow("Val", "Test6", "2021-06-21", 1, "Vit", "Test2", "2021-06-21", 2, "Vol", "Test7", "2021-06-21", 1)]
        [TestMethod]
        public void SearchTreeNodes(string nSt, string tN, string date, int r,
                                   string nSt1, string tN1, string date1, int r1,
                                   string nSt2, string tN2, string date2, int r2)
        {
            StudentInfo student1 = new(nSt, tN, System.DateTime.Parse(date), r);
            BinaryTreeNode<StudentInfo> node = new(student1);
            StudentInfo student2 = new(nSt1, tN1, System.DateTime.Parse(date1), r1);
            StudentInfo student3 = new(nSt2, tN2, System.DateTime.Parse(date2), r2);
            node.Add(student2);
            node.Add(student3);
            Assert.IsTrue(node.Search(student1) && node.Search(student2) && node.Search(student3));
        }

        [DataRow("Alex5", "Test1", "2021-06-21", 1, "Alex4", "Test2", "2021-06-21", 2, "Alex2", "Test1", "2021-06-21", 1)]
        [DataRow("Jack", "Test2", "2021-06-21", 2, "Bob", "Test3", "2021-06-21", 3, "Ben", "Test2", "2021-06-21", 5)]
        [DataRow("John", "Test4", "2021-06-21", 5, "Antony", "Test5", "2021-06-21", 1, "Alice", "Test2", "2021-06-21", 2)]
        [TestMethod]
        public void SearchLeftNode(string nSt, string tN, string date, int r,
                                   string nSt1, string tN1, string date1, int r1,
                                   string nSt2, string tN2, string date2, int r2)
        {
            StudentInfo student1 = new(nSt, tN, System.DateTime.Parse(date), r);
            BinaryTreeNode<StudentInfo> node = new(student1);
            StudentInfo student2 = new(nSt1, tN1, System.DateTime.Parse(date1), r1);
            StudentInfo student3 = new(nSt2, tN2, System.DateTime.Parse(date2), r2);
            node.Add(student2);
            node.Add(student3);
            Assert.IsTrue(node.Search(student3));

        }

        [DataRow("Alex5", "Test1", "2021-06-21", 1, "Alex6", "Test2", "2021-06-21", 2, "Alex8", "Test1", "2021-06-21", 1)]
        [DataRow("Jack", "Test2", "2021-06-21", 2, "John", "Test3", "2021-06-21", 3, "Sid", "Test2", "2021-06-21", 5)]
        [DataRow("John", "Test4", "2021-06-21", 5, "John", "Test5", "2021-06-21", 1, "John", "Test6", "2021-06-21", 2)]
        [TestMethod]
        public void SearchRightNode(string nSt, string tN, string date, int r,
                                   string nSt1, string tN1, string date1, int r1,
                                   string nSt2, string tN2, string date2, int r2)
        {
            StudentInfo student1 = new(nSt, tN, System.DateTime.Parse(date), r);
            BinaryTreeNode<StudentInfo> node = new(student1);
            StudentInfo student2 = new(nSt1, tN1, System.DateTime.Parse(date1), r1);
            StudentInfo student3 = new(nSt2, tN2, System.DateTime.Parse(date2), r2);
            node.Add(student2);
            node.Add(student3);
            Assert.IsTrue(node.Search(student3));
        }

        [DataRow("Alex5", "Test1", "2021-06-21", 1, "Alex6", "Test2", "2021-06-21", 2, "Alex8", "Test1", "2021-06-21", 1)]
        [DataRow("Jack", "Test2", "2021-06-21", 2, "John", "Test3", "2021-06-21", 3, "Bob", "Test2", "2021-06-21", 5)]
        [DataRow("John", "Test4", "2021-06-21", 5, "John", "Test5", "2021-06-21", 1, "Alex", "Test6", "2021-06-21", 2)]
        [TestMethod]
        public void SearchRoot(string nSt, string tN, string date, int r,
                                   string nSt1, string tN1, string date1, int r1,
                                   string nSt2, string tN2, string date2, int r2)
        {
            StudentInfo student1 = new(nSt, tN, System.DateTime.Parse(date), r);
            BinaryTreeNode<StudentInfo> node = new(student1);
            StudentInfo student2 = new(nSt1, tN1, System.DateTime.Parse(date1), r1);
            StudentInfo student3 = new(nSt2, tN2, System.DateTime.Parse(date2), r2);
            node.Add(student2);
            node.Add(student3);
            Assert.IsTrue(node.Search(student3));
        }
    }
}

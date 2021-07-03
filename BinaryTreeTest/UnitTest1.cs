using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binary_tree;

namespace BinaryTreeTest
{
    [TestClass]
    public class UnitTest1
    {
        [DataRow(5,3,8)]
        [TestMethod]
        public void TestMethod1(int n,int n1,int n2)
        {
            BinaryTreeNode<int> node1 = new(5);
            node1.Add(3);
            node1.Add(8);
            Assert.IsTrue(node1.Value == 3);
        }
    }
}

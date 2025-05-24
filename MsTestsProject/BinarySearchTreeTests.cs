using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algo_II.BinarySearchTree;

namespace MsTestsProject
{
	[TestClass]
	public class BinarySearchTreeTests
	{
		[TestMethod]
		public void BinarySearchTree_AddValueHappyPath()
		{
			int[] arr = { 3, 1, 2, 0, 5, 4, 6 };
			BinarySearchTree<int> tree = new BinarySearchTree<int>(arr);

			Assert.AreEqual(tree.Count, 7);

			Assert.AreEqual(3, tree.RootNode.Data);
			Assert.AreEqual(1, tree.RootNode.LeftChild.Data);
			Assert.AreEqual(2, tree.RootNode.LeftChild.RightChild.Data);
			Assert.AreEqual(0, tree.RootNode.LeftChild.LeftChild.Data);
			Assert.AreEqual(5, tree.RootNode.RightChild.Data);
			Assert.AreEqual(4, tree.RootNode.RightChild.LeftChild.Data);
			Assert.AreEqual(6, tree.RootNode.RightChild.RightChild.Data);
		}

		[TestMethod]
		public void BinarySearchTree_AddDuplicateValue()
		{
			int[] arr = { 3, 1, 2, 0, 5, 4, 6 };
			BinarySearchTree<int> tree = new BinarySearchTree<int>(arr);

			tree.AddValue(2);

			Assert.AreEqual(tree.Count, 8);
			Assert.AreEqual(2, tree.RootNode.LeftChild.RightChild.LeftChild.Data);
		}

		[TestMethod]
		public void BinarySearchTree_ClearHappyPath()
		{
			int[] arr = { 3, 1, 2, 0, 5, 4, 6 };
			BinarySearchTree<int> tree = new BinarySearchTree<int>(arr);

			tree.Clear();

			Assert.AreEqual(tree.Count, 0);
			Assert.AreEqual(tree.RootNode, null);
		}

		[TestMethod]
		public void BinarySearchTree_ClearEmptyTree()
		{
			BinarySearchTree<int> tree = new BinarySearchTree<int>();

			tree.Clear();

			Assert.AreEqual(tree.Count, 0);
			Assert.AreEqual(tree.RootNode, null);
		}
	}
}

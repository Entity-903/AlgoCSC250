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
			int[] arr = { 3, 1, 0, 2, 5, 4, 6 };
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
			int[] arr = { 3, 1, 0, 2, 5, 4, 6 };
			BinarySearchTree<int> tree = new BinarySearchTree<int>(arr);

			tree.AddValue(2);

			Assert.AreEqual(tree.Count, 8);
			Assert.AreEqual(2, tree.RootNode.LeftChild.RightChild.LeftChild.Data);
		}

		//----------------------------------------------------------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void BinarySearchTree_ClearHappyPath()
		{
			int[] arr = { 3, 1, 0, 2, 5, 4, 6 };
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

		//----------------------------------------------------------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void BinarySearchTree_ContainsHappyPath()
		{
			int[] arr = { 3, 1, 0, 2, 5, 4, 6 };
			BinarySearchTree<int> tree = new BinarySearchTree<int>(arr);

			bool expected = true;
			bool actual = tree.Contains(2);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void BinarySearchTree_ContainsNot()
		{
			int[] arr = { 3, 1, 0, 2, 5, 4, 6 };
			BinarySearchTree<int> tree = new BinarySearchTree<int>(arr);

			bool expected = false;
			bool actual = tree.Contains(10);

			Assert.AreEqual(expected, actual);
		}

		//----------------------------------------------------------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void BinarySearchTree_RemoveHappyPath()
		{
			int[] arr = { 3, 1, 0, 2, 5, 4, 6 };
			BinarySearchTree<int> tree = new BinarySearchTree<int>(arr);
			
			tree.Remove(5);
		
			string expected = "3, 1, 0, 2, 4, 6";
			string actual = tree.PreOrder();
		
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void BinarySearchTree_RemoveValueNotPresent()
		{
			int[] arr = { 3, 1, 0, 2, 5, 4, 6 };
			BinarySearchTree<int> tree = new BinarySearchTree<int>(arr);

			tree.Remove(10);

			string expected = "3, 1, 0, 2, 5, 4, 6";
			string actual = tree.PreOrder();

			Assert.AreEqual(expected, actual);
		}

		//----------------------------------------------------------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void BinarySearchTree_HeightHappyPath()
		{
			int[] arr = { 3, 1, 0, 2, 5, 4, 6 };
			BinarySearchTree<int> tree = new BinarySearchTree<int>(arr);

			int expected = 3;
			int actual = tree.Height();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void BinarySearchTree_HeightEmptyTree()
		{
			BinarySearchTree<int> tree = new BinarySearchTree<int>();

			int expected = -1;
			int actual = tree.Height();

			Assert.AreEqual(expected, actual);
		}

		//----------------------------------------------------------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void BinarySearchTree_ToArrayHappyPath()
		{
			int[] arr = { 3, 1, 0, 2, 5, 4, 6 };
			BinarySearchTree<int> tree = new BinarySearchTree<int>(arr);

			int[] expectedArr = { 0, 1, 2, 3, 4, 5, 6 };
			int[] actualArr = tree.ToArray();

			for (int i = 0; i < arr.Length; i++)
			{
				Assert.AreEqual(actualArr[i], expectedArr[i]);
			}
		}

		[TestMethod]
		public void BinarySearchTree_ToArrayEmptyTree()
		{
			BinarySearchTree<int> tree = new BinarySearchTree<int>();

			int[] expectedArr = { };
			int[] actualArr = tree.ToArray();

			for (int i = 0; i < actualArr.Length; i++)
			{
				Assert.AreEqual(actualArr[i], expectedArr[i]);
			}
		}

		//----------------------------------------------------------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void BinarySearchTree_InOrderHappyPath()
		{
			int[] arr = { 5, 3, 1, 2, 0, 4, 8, 6, 7 };
			BinarySearchTree<int> tree = new BinarySearchTree<int>(arr);
		
			string expected = "0, 1, 2, 3, 4, 5, 6, 7, 8";
			string actual = tree.InOrder();
		
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void BinarySearchTree_InOrderEmptyTree()
		{
			BinarySearchTree<int> tree = new BinarySearchTree<int>();

			string expected = "";
			string actual = tree.InOrder();

			Assert.AreEqual(expected, actual);
		}

		//----------------------------------------------------------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void BinarySearchTree_PreOrderHappyPath()
		{
			int[] arr = { 3, 1, 0, 2, 5, 4, 6 };
			BinarySearchTree<int> tree = new BinarySearchTree<int>(arr);

			string expected = "3, 1, 0, 2, 5, 4, 6";
			string actual = tree.PreOrder();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void BinarySearchTree_PreOrderEmptyTree()
		{
			BinarySearchTree<int> tree = new BinarySearchTree<int>();

			string expected = "";
			string actual = tree.PreOrder();

			Assert.AreEqual(expected, actual);
		}

		//----------------------------------------------------------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void BinarySearchTree_PostOrderHappyPath()
		{
			int[] arr = { 3, 1, 0, 2, 5, 4, 6 };
			BinarySearchTree<int> tree = new BinarySearchTree<int>(arr);

			string expected = "0, 2, 1, 4, 6, 5, 3";
			string actual = tree.PostOrder();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void BinarySearchTree_PostOrderEmptyTree()
		{
			BinarySearchTree<int> tree = new BinarySearchTree<int>();

			string expected = "";
			string actual = tree.PostOrder();

			Assert.AreEqual(expected, actual);
		}
	}
}

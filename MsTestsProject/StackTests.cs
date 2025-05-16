//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Algo_II.Stack
{
	[TestClass]
	public class StackTests
	{
		[TestMethod]
		public void Stack_GetHappyPath()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			Stack<int> input = new Stack<int>(arr);

			int actual = input.Get(2);
			int expected = 3;

			Assert.AreEqual(actual, expected);
		}

		[TestMethod]
		[ExpectedException(typeof(IndexOutOfRangeException))]
		public void Stack_GetOutsideStack()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			Stack<int> input = new Stack<int>(arr);

			int actual = input.Get(10);
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void Stack_ContainsHappyPath()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			Stack<int> input = new Stack<int>(arr);

			bool expected = true;
			bool actual = input.Contains(5);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Stack_ContainsInverse()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			Stack<int> input = new Stack<int>(arr);

			bool expected = false;
			bool actual = input.Contains(7);

			Assert.AreEqual(expected, actual);
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void Stack_PeekHappyPath()
		{
			int[] arr = { 8, 2, 4, 7, 1 };
			Stack<int> input = new Stack<int>(arr);

			int expected = 8;
			int actual = input.Peek();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Stack_PeekNullCollectionNumber()
		{
			Stack<int> input = new Stack<int>();

			int expected = 0;
			int actual = input.Peek();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Stack_PeekNullCollectionObject()
		{
			Stack<string> input = new Stack<string>();

			string actual = input.Peek();

			Assert.IsNull(actual);
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void Stack_PopHappyPath()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			Stack<int> input = new Stack<int>(arr);

			int expected = 1;
			int actual = input.Pop();

			Assert.AreEqual(expected, actual);

			int[] expectedArr = { 2, 3, 4, 5 };
			Stack<int> expectedStack = new Stack<int>(expectedArr);

			for (int i = 0; i < arr.Length - 1; i++)
			{
				Assert.AreEqual(input.Get(i), expectedStack.Get(i));
			}
		}

		[TestMethod]
		public void Stack_PopNullStackNumber()
		{
			Stack<int> input = new Stack<int>();

			int expected = 0;
			int actual = input.Pop();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Stack_PopNullStackObject()
		{
			Stack<string> input = new Stack<string>();

			string actual = input.Pop();

			Assert.IsNull(actual);
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void Stack_PushHappyPath()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			Stack<int> input = new Stack<int>(arr);

			input.Push(0);

			int[] expectedArr = { 0, 1, 2, 3, 4, 5};
			Stack<int> expectedStack = new Stack<int>(expectedArr);

			for (int i = 0; i < arr.Length - 1; i++)
			{
				Assert.AreEqual(input.Get(i), expectedStack.Get(i));
			}
		}

		[TestMethod]
		public void Stack_PushNullCollection()
		{
			Stack<int> input = new Stack<int>();

			input.Push(1);

			int[] expectedArr = { 1 };
			Stack<int> expectedStack = new Stack<int>(expectedArr);

			for (int i = 0; i < expectedArr.Length - 1; i++)
			{
				Assert.AreEqual(input.Get(i), expectedStack.Get(i));
			}
		}

	}
}

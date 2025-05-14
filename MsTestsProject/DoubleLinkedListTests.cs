using Algo_II.DoubleLinkedList;

namespace MsTestsProject
{
	[TestClass]
	public class DoubleLinkedListTests
	{
		[TestMethod]
		public void DoubleLinkedList_AddHappyPath()
		{
			int[] arr = { 1, 2, 3, 4, 5};
			DoubleLinkedList<int> input = new DoubleLinkedList<int>(arr);

			input.Add(6);

			int[] expected = { 1, 2, 3, 4, 5, 6};
			DoubleLinkedList<int> expectedList = new DoubleLinkedList<int>(expected);
			
			for (int i = 0; i < expected.Length; i++)
			{
				Assert.AreEqual(input.Get(i), expectedList.Get(i));
			}

		}

		[TestMethod]
		public void DoubleLinkedList_CountIncrementsUponAdd()
		{
			DoubleLinkedList<int> sll = new DoubleLinkedList<int>();

			sll.Add(10);

			Assert.AreEqual(1, sll.Count);
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void DoubleLinkedList_InsertHappyPath()
		{
			int[] arr = { 1, 2, 3, 5 };
			DoubleLinkedList<int> input = new DoubleLinkedList<int>(arr);

			input.Insert(4, 3);

			int[] expected = { 1, 2, 3, 4, 5 };
			DoubleLinkedList<int> expectedList = new DoubleLinkedList<int>(expected);

			for (int i = 0; i < expected.Length; i++)
			{
				Assert.AreEqual(input.Get(i), expectedList.Get(i));
			}
		}

		[TestMethod]
		[ExpectedException(typeof(IndexOutOfRangeException))]
		public void DoubleLinkedList_InsertOutsideCollection()
		{
			int[] arr = { 1, 2, 3, 5 };
			DoubleLinkedList<int> input = new DoubleLinkedList<int>(arr);

			input.Insert(4, 10);
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void DoubleLinkedList_GetHappyPath()
		{
			int[] arr = { 6, 2, 7, 4, 3 };
			DoubleLinkedList<int> input = new DoubleLinkedList<int>(arr);

			int expected = 7;
			int actual = input.Get(2);

			Assert.AreEqual(actual, expected);
		}

		[TestMethod]
		[ExpectedException(typeof(IndexOutOfRangeException))]
		public void DoubleLinkedList_GetOutsideCollection()
		{
			int[] arr = { 6, 2, 7, 4, 3 };
			DoubleLinkedList<int> input = new DoubleLinkedList<int>(arr);

			int actual = input.Get(10);
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void DoubleLinkedList_RemoveHappyPath()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			DoubleLinkedList<int> input = new DoubleLinkedList<int>(arr);

			int dataRemoved = input.Remove();

			int[] expectedArr = { 2, 3, 4, 5 };
			DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArr);

			Assert.AreEqual(dataRemoved, 1);

			for (int i = 0; i < expected.Count; i++)
			{
				Assert.AreEqual(input.Get(i), expected.Get(i));
			}
		}

		[TestMethod]
		public void DoubleLinkedList_RemoveEmptyCollectionObject()
		{
			DoubleLinkedList<string> input = new DoubleLinkedList<string>();
			string? actual = input.Remove();

			Assert.IsNull(actual);
		}

		[TestMethod]
		public void DoubleLinkedList_RemoveEmptyCollectionNumber()
		{
			DoubleLinkedList<int> input = new DoubleLinkedList<int>();
			int actual = input.Remove();

			Assert.AreEqual(0, actual);
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void DoubleLinkedList_RemoveAtHappyPath()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			DoubleLinkedList<int> input = new DoubleLinkedList<int>(arr);

			int dataRemoved = input.RemoveAt(3);

			Assert.AreEqual(dataRemoved, 4);

			int[] expectedArr = { 1, 2, 3, 5 };
			DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArr);

			for (int i = 0; i < expected.Count; i++)
			{
				Assert.AreEqual(input.Get(i), expected.Get(i));
			}
		}

		[TestMethod]
		[ExpectedException(typeof(IndexOutOfRangeException))]
		public void DoubleLinkedList_RemoveAtOutsideCollection()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			DoubleLinkedList<int> input = new DoubleLinkedList<int>(arr);

			int dataRemoved = input.RemoveAt(12);
		}

		[TestMethod]
		public void DoubleLinkedList_RemoveAtFirstElement()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			DoubleLinkedList<int> input = new DoubleLinkedList<int>(arr);

			int dataRemoved = input.RemoveAt(0);

			Assert.AreEqual(dataRemoved, 1);

			int[] expectedArr = { 2, 3, 4, 5 };
			DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArr);

			for (int i = 0; i < expected.Count; i++)
			{
				Assert.AreEqual(input.Get(i), expected.Get(i));
			}
		}

		[TestMethod]
		public void DoubleLinkedList_RemoveAtLastElement()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			DoubleLinkedList<int> input = new DoubleLinkedList<int>(arr);

			int dataRemoved = input.RemoveAt(4);

			Assert.AreEqual(dataRemoved, 5);

			int[] expectedArr = { 1, 2, 3, 4 };
			DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArr);

			for (int i = 0; i < expected.Count; i++)
			{
				Assert.AreEqual(input.Get(i), expected.Get(i));
			}
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void DoubleLinkedList_RemoveLastHappyPath()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			DoubleLinkedList<int> input = new DoubleLinkedList<int>(arr);

			int dataRemoved = input.RemoveLast();

			Assert.AreEqual(dataRemoved, 5);

			int[] expectedArr = { 1, 2, 3, 4 };
			DoubleLinkedList<int> expected = new DoubleLinkedList<int>(expectedArr);

			for (int i = 0; i < expected.Count; i++)
			{
				Assert.AreEqual(input.Get(i), expected.Get(i));
			}
		}

		[TestMethod]
		public void DoubleLinkedList_RemoveLastEmptyCollectionNumber()
		{
			DoubleLinkedList<int> input = new DoubleLinkedList<int>();

			int dataRemoved = input.RemoveLast();

			Assert.AreEqual(dataRemoved, 0);
		}

		[TestMethod]
		public void DoubleLinkedList_RemoveLastEmptyCollectionObject()
		{
			DoubleLinkedList<string> input = new DoubleLinkedList<string>();

			string dataRemoved = input.RemoveLast();

			Assert.IsNull(dataRemoved);
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void DoubleLinkedList_ToStringHappyPath()
		{
			int[] arr = { 7, 2, 4, 5, 0, 1 };
			DoubleLinkedList<int> input = new DoubleLinkedList<int>(arr);

			string expected = "7, 2, 4, 5, 0, 1";
			string actual = input.ToString();

			for (int i = 0; i < expected.Length; i++)
			{
				Assert.AreEqual(expected[i], actual[i]);
			}
		}

		[TestMethod]
		public void DoubleLinkedList_ToStringEmptyCollection()
		{
			DoubleLinkedList<int> input = new DoubleLinkedList<int>();

			string expected = "";
			string actual = input.ToString();

			for (int i = 0; i < expected.Length; i++)
			{
				Assert.AreEqual(expected[i], actual[i]);
			}
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void DoubleLinkedList_ClearHappyPath()
		{
			int[] arr = { 7, 2, 4, 5, 0, 1 };
			DoubleLinkedList<int> input = new DoubleLinkedList<int>(arr);

			int expectedCount = 0;
			DoubleLinkedList<int> expectedCollection = new DoubleLinkedList<int>();

			input.Clear();

			Assert.AreEqual(expectedCount, input.Count);
			for (int i = 0; i < expectedCollection.Count; i++)
			{
				Assert.AreEqual(expectedCollection.Get(i), input.Get(i));
			}
		}

		[TestMethod]
		public void DoubleLinkedList_ClearEmptyCollection()
		{
			DoubleLinkedList<int> input = new DoubleLinkedList<int>();

			int expectedCount = 0;
			DoubleLinkedList<int> expectedCollection = new DoubleLinkedList<int>();

			input.Clear();

			Assert.AreEqual(expectedCount, input.Count);
			for (int i = 0; i < expectedCollection.Count; i++)
			{
				Assert.AreEqual(expectedCollection.Get(i), input.Get(i));
			}
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void DoubleLinkedList_SearchHappyPath()
		{
			int[] arr = { 7, 2, 4, 5, 0, 4 };
			DoubleLinkedList<int> input = new DoubleLinkedList<int>(arr);

			int actual = input.Search(4);
			int expected = 2;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DoubleLinkedList_SearchNotFound()
		{
			int[] arr = { 7, 2, 4, 5, 0, 4 };
			DoubleLinkedList<int> input = new DoubleLinkedList<int>(arr);

			int actual = input.Search(999);
			int expected = -1;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DoubleLinkedList_SearchEmptyCollection()
		{
			DoubleLinkedList<int> input = new DoubleLinkedList<int>();

			int actual = input.Search(4);
			int expected = -1;

			Assert.AreEqual(expected, actual);
		}

		//----------------------------------------------------------------------------------------------------------------
	}
}

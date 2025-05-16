using Algo_II.SingleLinkedList;

namespace MsTestsProject
{
	[TestClass]
	public class SingleLinkedListTests
	{
		[TestMethod]
		public void SingleLinkedList_AddHappyPath()
		{
			int[] arr = { 1, 2, 3, 4, 5};
			SingleLinkedList<int> input = new SingleLinkedList<int>(arr);

			input.Add(6);

			int[] expected = { 1, 2, 3, 4, 5, 6};
			SingleLinkedList<int> expectedList = new SingleLinkedList<int>(expected);
			
			for (int i = 0; i < expected.Length; i++)
			{
				Assert.AreEqual(input.Get(i), expectedList.Get(i));
			}

		}

		[TestMethod]
		public void SingleLinkedList_CountIncrementsUponAdd()
		{
			SingleLinkedList<int> sll = new SingleLinkedList<int>();

			sll.Add(10);

			Assert.AreEqual(1, sll.Count);
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void SingleLinkedList_InsertHappyPath()
		{
			int[] arr = { 1, 2, 3, 5 };
			SingleLinkedList<int> input = new SingleLinkedList<int>(arr);

			input.Insert(4, 3);

			int[] expected = { 1, 2, 3, 4, 5 };
			SingleLinkedList<int> expectedList = new SingleLinkedList<int>(expected);

			for (int i = 0; i < expected.Length; i++)
			{
				Assert.AreEqual(input.Get(i), expectedList.Get(i));
			}
		}

		[TestMethod]
		public void SingleLinkedList_InsertFirstElement()
		{
			int[] arr = { 1, 2, 3, 4 };
			SingleLinkedList<int> input = new SingleLinkedList<int>(arr);

			input.Insert(0, 0);

			int[] expected = { 0, 1, 2, 3, 4 };
			SingleLinkedList<int> expectedList = new SingleLinkedList<int>(expected);

			for (int i = 0; i < expected.Length; i++)
			{
				Assert.AreEqual(input.Get(i), expectedList.Get(i));
			}
		}

		[TestMethod]
		[ExpectedException(typeof(IndexOutOfRangeException))]
		public void SingleLinkedList_InsertOutsideCollection()
		{
			int[] arr = { 1, 2, 3, 5 };
			SingleLinkedList<int> input = new SingleLinkedList<int>(arr);

			input.Insert(4, 10);
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void SingleLinkedList_GetHappyPath()
		{
			int[] arr = { 6, 2, 7, 4, 3 };
			SingleLinkedList<int> input = new SingleLinkedList<int>(arr);

			int expected = 7;
			int actual = input.Get(2);

			Assert.AreEqual(actual, expected);
		}

		[TestMethod]
		[ExpectedException(typeof(IndexOutOfRangeException))]
		public void SingleLinkedList_GetOutsideCollection()
		{
			int[] arr = { 6, 2, 7, 4, 3 };
			SingleLinkedList<int> input = new SingleLinkedList<int>(arr);

			int actual = input.Get(10);
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void SingleLinkedList_RemoveHappyPath()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			SingleLinkedList<int> input = new SingleLinkedList<int>(arr);

			int dataRemoved = input.Remove();

			int[] expectedArr = { 2, 3, 4, 5 };
			SingleLinkedList<int> expected = new SingleLinkedList<int>(expectedArr);

			Assert.AreEqual(dataRemoved, 1);

			for (int i = 0; i < expected.Count; i++)
			{
				Assert.AreEqual(input.Get(i), expected.Get(i));
			}
		}

		[TestMethod]
		public void SingleLinkedList_RemoveEmptyCollectionObject()
		{
			SingleLinkedList<string> input = new SingleLinkedList<string>();
			string? actual = input.Remove();

			Assert.IsNull(actual);
		}

		[TestMethod]
		public void SingleLinkedList_RemoveEmptyCollectionNumber()
		{
			SingleLinkedList<int> input = new SingleLinkedList<int>();
			int actual = input.Remove();

			Assert.AreEqual(0, actual);
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void SingleLinkedList_RemoveAtHappyPath()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			SingleLinkedList<int> input = new SingleLinkedList<int>(arr);

			int dataRemoved = input.RemoveAt(3);

			Assert.AreEqual(dataRemoved, 4);

			int[] expectedArr = { 1, 2, 3, 5 };
			SingleLinkedList<int> expected = new SingleLinkedList<int>(expectedArr);

			for (int i = 0; i < expected.Count; i++)
			{
				Assert.AreEqual(input.Get(i), expected.Get(i));
			}
		}

		[TestMethod]
		[ExpectedException(typeof(IndexOutOfRangeException))]
		public void SingleLinkedList_RemoveAtOutsideCollection()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			SingleLinkedList<int> input = new SingleLinkedList<int>(arr);

			int dataRemoved = input.RemoveAt(12);
		}

		[TestMethod]
		public void SingleLinkedList_RemoveAtFirstElement()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			SingleLinkedList<int> input = new SingleLinkedList<int>(arr);

			int dataRemoved = input.RemoveAt(0);

			Assert.AreEqual(dataRemoved, 1);

			int[] expectedArr = { 2, 3, 4, 5 };
			SingleLinkedList<int> expected = new SingleLinkedList<int>(expectedArr);

			for (int i = 0; i < expected.Count; i++)
			{
				Assert.AreEqual(input.Get(i), expected.Get(i));
			}
		}

		[TestMethod]
		public void SingleLinkedList_RemoveAtLastElement()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			SingleLinkedList<int> input = new SingleLinkedList<int>(arr);

			int dataRemoved = input.RemoveAt(4);

			Assert.AreEqual(dataRemoved, 5);

			int[] expectedArr = { 1, 2, 3, 4 };
			SingleLinkedList<int> expected = new SingleLinkedList<int>(expectedArr);

			for (int i = 0; i < expected.Count; i++)
			{
				Assert.AreEqual(input.Get(i), expected.Get(i));
			}
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void SingleLinkedList_RemoveLastHappyPath()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			SingleLinkedList<int> input = new SingleLinkedList<int>(arr);

			int dataRemoved = input.RemoveLast();

			Assert.AreEqual(dataRemoved, 5);

			int[] expectedArr = { 1, 2, 3, 4 };
			SingleLinkedList<int> expected = new SingleLinkedList<int>(expectedArr);

			for (int i = 0; i < expected.Count; i++)
			{
				Assert.AreEqual(input.Get(i), expected.Get(i));
			}
		}

		[TestMethod]
		public void SingleLinkedList_RemoveLastEmptyCollectionNumber()
		{
			SingleLinkedList<int> input = new SingleLinkedList<int>();

			int dataRemoved = input.RemoveLast();

			Assert.AreEqual(dataRemoved, 0);
		}

		[TestMethod]
		public void SingleLinkedList_RemoveLastEmptyCollectionObject()
		{
			SingleLinkedList<string> input = new SingleLinkedList<string>();

			string dataRemoved = input.RemoveLast();

			Assert.IsNull(dataRemoved);
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void SingleLinkedList_ToStringHappyPath()
		{
			int[] arr = { 7, 2, 4, 5, 0, 1 };
			SingleLinkedList<int> input = new SingleLinkedList<int>(arr);

			string expected = "7, 2, 4, 5, 0, 1";
			string actual = input.ToString();

			for (int i = 0; i < expected.Length; i++)
			{
				Assert.AreEqual(expected[i], actual[i]);
			}
		}

		[TestMethod]
		public void SingleLinkedList_ToStringEmptyCollection()
		{
			SingleLinkedList<int> input = new SingleLinkedList<int>();

			string expected = "";
			string actual = input.ToString();

			for (int i = 0; i < expected.Length; i++)
			{
				Assert.AreEqual(expected[i], actual[i]);
			}
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void SingleLinkedList_ClearHappyPath()
		{
			int[] arr = { 7, 2, 4, 5, 0, 1 };
			SingleLinkedList<int> input = new SingleLinkedList<int>(arr);

			int expectedCount = 0;
			SingleLinkedList<int> expectedCollection = new SingleLinkedList<int>();

			input.Clear();

			Assert.AreEqual(expectedCount, input.Count);
			for (int i = 0; i < expectedCollection.Count; i++)
			{
				Assert.AreEqual(expectedCollection.Get(i), input.Get(i));
			}
		}

		[TestMethod]
		public void SingleLinkedList_ClearEmptyCollection()
		{
			SingleLinkedList<int> input = new SingleLinkedList<int>();

			int expectedCount = 0;
			SingleLinkedList<int> expectedCollection = new SingleLinkedList<int>();

			input.Clear();

			Assert.AreEqual(expectedCount, input.Count);
			for (int i = 0; i < expectedCollection.Count; i++)
			{
				Assert.AreEqual(expectedCollection.Get(i), input.Get(i));
			}
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void SingleLinkedList_SearchHappyPath()
		{
			int[] arr = { 7, 2, 4, 5, 0, 4 };
			SingleLinkedList<int> input = new SingleLinkedList<int>(arr);

			int actual = input.Search(4);
			int expected = 2;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void SingleLinkedList_SearchNotFound()
		{
			int[] arr = { 7, 2, 4, 5, 0, 4 };
			SingleLinkedList<int> input = new SingleLinkedList<int>(arr);

			int actual = input.Search(999);
			int expected = -1;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void SingleLinkedList_SearchEmptyCollection()
		{
			SingleLinkedList<int> input = new SingleLinkedList<int>();

			int actual = input.Search(4);
			int expected = -1;

			Assert.AreEqual(expected, actual);
		}

		//----------------------------------------------------------------------------------------------------------------
	}
}

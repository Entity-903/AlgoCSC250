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
		public void SingleLinkedList_GetOutsideCollection()
		{
			int[] arr = { 6, 2, 7, 4, 3 };
			SingleLinkedList<int> input = new SingleLinkedList<int>(arr);

			int expected = 7;
			int actual = input.Get(2);

			Assert.AreEqual(actual, expected);
		}

		//----------------------------------------------------------------------------------------------------------------
	}
}

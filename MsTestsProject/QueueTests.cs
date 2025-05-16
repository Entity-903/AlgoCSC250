namespace Algo_II.Queue
{
	[TestClass]
	public class QueueTests
	{
		[TestMethod]
		public void Queue_GetHappyPath()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			Queue<int> input = new Queue<int>(arr);

			int actual = input.Get(2);
			int expected = 3;

			Assert.AreEqual(actual, expected);
		}

		[TestMethod]
		[ExpectedException(typeof(IndexOutOfRangeException))]
		public void Queue_GetOutsideQueue()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			Queue<int> input = new Queue<int>(arr);

			int actual = input.Get(10);
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void Queue_ContainsHappyPath()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			Queue<int> input = new Queue<int>(arr);

			bool expected = true;
			bool actual = input.Contains(5);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Queue_ContainsInverse()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			Queue<int> input = new Queue<int>(arr);

			bool expected = false;
			bool actual = input.Contains(7);

			Assert.AreEqual(expected, actual);
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void Queue_PeekHappyPath()
		{
			int[] arr = { 8, 2, 4, 7, 1 };
			Queue<int> input = new Queue<int>(arr);

			int expected = 8;
			int actual = input.Peek();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Queue_PeekNullCollectionNumber()
		{
			Queue<int> input = new Queue<int>();

			int expected = 0;
			int actual = input.Peek();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Queue_PeekNullCollectionObject()
		{
			Queue<string> input = new Queue<string>();

			string actual = input.Peek();

			Assert.IsNull(actual);
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void Queue_DequeueHappyPath()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			Queue<int> input = new Queue<int>(arr);

			int expected = 1;
			int actual = input.Dequeue();

			Assert.AreEqual(expected, actual);

			int[] expectedArr = { 2, 3, 4, 5 };
			Queue<int> expectedQueue = new Queue<int>(expectedArr);

			for (int i = 0; i < arr.Length - 1; i++)
			{
				Assert.AreEqual(input.Get(i), expectedQueue.Get(i));
			}
		}

		[TestMethod]
		public void Queue_DequeueNullQueueNumber()
		{
			Queue<int> input = new Queue<int>();

			int expected = 0;
			int actual = input.Dequeue();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Queue_DequeueNullQueueObject()
		{
			Queue<string> input = new Queue<string>();

			string actual = input.Dequeue();

			Assert.IsNull(actual);
		}

		//----------------------------------------------------------------------------------------------------------------

		[TestMethod]
		public void Queue_EnqueueHappyPath()
		{
			int[] arr = { 1, 2, 3, 4, 5 };
			Queue<int> input = new Queue<int>(arr);
			
			input.Enqueue(6);

			int[] expectedArr = { 1, 2, 3, 4, 5, 6 };
			Queue<int> expectedQueue = new Queue<int>(expectedArr);

			for (int i = 0; i < arr.Length - 1; i++)
			{
				Assert.AreEqual(input.Get(i), expectedQueue.Get(i));
			}
		}

		[TestMethod]
		public void Queue_EnqueueNullCollection()
		{
			Queue<int> input = new Queue<int>();

			input.Enqueue(1);

			int[] expectedArr = { 1 };
			Queue<int> expectedQueue = new Queue<int>(expectedArr);

			for (int i = 0; i < expectedArr.Length - 1; i++)
			{
				Assert.AreEqual(input.Get(i), expectedQueue.Get(i));
			}
		}
	}
}

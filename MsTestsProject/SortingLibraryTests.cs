using SorterLibrary;
/**
 * These test use MsTests
 *  //https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert?view=mstest-net-3.8
    //https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert.throws?view=mstest-net-3.8
 */

namespace MsTestsProject
{   
    [TestClass]
    public class SorterTests
    {
        #region Generation Code
        private static readonly int Seed = 12271978;

        public static int[] GenerateRandom(int size)
        {
            var rand = new Random(Seed);
            return Enumerable.Range(0, size)
                             .Select(_ => rand.Next(100001))
                             .ToArray();
        }

        public static int[] GenerateAscending(int size)
        {
            return GenerateRandom(size).OrderBy(x => x).ToArray();
        }

        public static int[] GenerateDescending(int size)
        {
            return GenerateRandom(size).OrderByDescending(x => x).ToArray();
        }

        public static Person[] GeneratePersonList(int size, PersonOrder order)
        {
            return PersonGenerator.Generate(size, Seed, order);
        }

		public static int romanToInt(string s)
		{
			
			int result = 0;
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == 'M') { result += 1000; continue; }
				// There is no need to check if the next character is 'M', since that would equal 'D'. Therefore "DM" is redundant
				if (s[i] == 'D') { result += 500; continue; }

				if (s[i] == 'C')
				{
					if (i != s.Length - 1)
					{
						if (s[i + 1] == 'D') { result += 400; i++; continue; }
						if (s[i + 1] == 'M') { result += 900; i++; continue; }
					}
					i += 100; continue;
				}

				if (s[i] == 'L')
				{
					if (i != s.Length - 1)
					{
						// No need to check if the next character is 'C'. See s[i] == 'D' for explaination
						if (s[i + 1] == 'D') { result += 450; i++; continue; }
						if (s[i + 1] == 'M') { result += 950; i++; continue; }
					}
					result += 50; continue;
				}

				if (s[i] == 'X')
				{
					if (i != s.Length - 1)
					{
						if (s[i + 1] == 'L') { result += 40; i++; continue; }
						if (s[i + 1] == 'C') { result += 90; i++; continue; }
						if (s[i + 1] == 'D') { result += 490; i++; continue; }
						if (s[i + 1] == 'M') { result += 990; i++; continue; }
					}
					result += 10; continue;
				}

				if (s[i] == 'V')
				{
					if (i != s.Length - 1)
					{
						// No need to check if the next character is 'X'. See s[i] == 'D' for explaination
						if (s[i + 1] == 'L') { result += 45; i++; continue; }
						if (s[i + 1] == 'C') { result += 95; i++; continue; }
						if (s[i + 1] == 'D') { result += 495; i++; continue; }
						if (s[i + 1] == 'M') { result += 995; i++; continue; }
					}
					result += 5; continue;
				}

				if (s[i] == 'I')
				{
					if (i != s.Length - 1)
					{
						if (s[i + 1] == 'V') { result += 4; i++; continue; }
						if (s[i + 1] == 'X') { result += 9; i++; continue; }
						if (s[i + 1] == 'L') { result += 49; i++; continue; }
						if (s[i + 1] == 'C') { result += 99; i++; continue; }
						if (s[i + 1] == 'D') { result += 499; i++; continue; }
						if (s[i + 1] == 'M') { result += 999; i++; continue; }
					}
					result += 1; continue;
				}
				// Character was invalid. Inform user
				return -1;
			}
			return result;
		}

		#endregion

		[TestMethod]
        public void ExampleTestMethod()
        {
            //Assemble
            //int[] testArray = { 5, 4, 3, 2, 1 };
            int[] testArray = GenerateDescending(5);
            //int[] expectedResult = { 1, 2, 3, 4, 5};
            int[] expectedResult = GenerateAscending(5);

            //Act
            Sorter<int>.BubbleSort(testArray);

            //Assert
            CollectionAssert.AreEqual(expectedResult, testArray);

        }

		//////////////////////////////////////////////////////////////////////////////////////////////////////

		[TestMethod]
		public void BubbleSortHappyPath()
		{
			int[] input    = { 7, 2, 8, 3, 1, 12, 15 };
			int[] expected = { 1, 2, 3, 7, 8, 12, 15};

			Sorter<int>.BubbleSort(input);

			CollectionAssert.AreEqual(expected, input);
		}

		[TestMethod]
		public void BubbleSortBestCase()
		{
			int[] input =    { 1, 2, 3, 7, 8, 12, 15 };
			int[] expected = { 1, 2, 3, 7, 8, 12, 15 };

			Sorter<int>.BubbleSort(input);

			CollectionAssert.AreEqual(expected, input);
		}

		[TestMethod]
		public void BubbleSortWorseCase()
		{
			int[] input	   = { 15, 12, 8, 7, 3, 2, 1 };
			int[] expected = { 1, 2, 3, 7, 8, 12, 15 };

			Sorter<int>.BubbleSort(input);

			CollectionAssert.AreEqual(expected, input);
		}

		[TestMethod]
		public void BubbleSortNegativeValues()
		{
			int[] input    = { -10,  3, 1, -2, 4 };
			int[] expected = { -10, -2, 1,  3, 4 };

			Sorter<int>.BubbleSort(input);

			CollectionAssert.AreEqual(expected, input);
		}

		[TestMethod]
		public void BubbleSortDuplicateElements()
		{
			int[] input    = { 9, 7, 5, 5, 3, 2, 2, 1 };
			int[] expected = { 1, 2, 2, 3, 5, 5, 7, 9 };

			Sorter<int>.BubbleSort(input);

			CollectionAssert.AreEqual(expected, input);
		}

		//Test generated via ChatGPT
		[TestMethod]
		public void BubbleSortSingleElement()
		{
			int[] input = { 42 };
			int[] expected = { 42 };

			Sorter<int>.BubbleSort(input);

			CollectionAssert.AreEqual(expected, input);
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////

		[TestMethod]
		public void SelectionSortHappyPath()
		{
			int[] input    = { 5, 4, 3, 2, 1 };
			int[] expected = { 1, 2, 3, 4, 5 };

			Sorter<int>.SelectionSort(input);

			CollectionAssert.AreEqual(expected, input);
		}

		[TestMethod]
		public void SelectionSortNegativeNumbers()
		{
			int[] input    = {  0, -1, -2, -3, -4, -5 };
			int[] expected = { -5, -4, -3, -2, -1,  0 };

			Sorter<int>.SelectionSort(input);

			CollectionAssert.AreEqual(expected, input);
		}

		[TestMethod]
		public void SelectionSortEmptyArray()
		{
			int[] input    = { };
			int[] expected = { };

			Sorter<int>.SelectionSort(input);

			CollectionAssert.AreEqual(expected, input);
		}

		[TestMethod]
		public void SelectionSortBestCase()
		{
			int[] input    = { 1, 2, 3, 4, 5 };
			int[] expected = { 1, 2, 3, 4, 5 };

			Sorter<int>.SelectionSort(input);

			CollectionAssert.AreEqual(expected, input);
		}

		[TestMethod]
		public void SelectionSortDuplicateNumbers()
		{
			int[] input    = { 5, 2, 5, 3, 1, 2, 4 };
			int[] expected = { 1, 2, 2, 3, 4, 5, 5 };

			Sorter<int>.SelectionSort(input);

			CollectionAssert.AreEqual(expected, input);
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////

		[TestMethod]
		public void InsertionSortHappyPath()
		{
			int[] input = { 5, 4, 3, 2, 1 };
			int[] expected = { 1, 2, 3, 4, 5 };

			Sorter<int>.InsertionSort(input);

			CollectionAssert.AreEqual(expected, input);
		}

		[TestMethod]
		public void InsertionSortNegativeNumbers()
		{
			int[] input = { 0, -1, -2, -3, -4, -5 };
			int[] expected = { -5, -4, -3, -2, -1, 0 };

			Sorter<int>.InsertionSort(input);

			CollectionAssert.AreEqual(expected, input);
		}

		[TestMethod]
		public void InsertionSortEmptyArray()
		{
			int[] input = { };
			int[] expected = { };

			Sorter<int>.InsertionSort(input);

			CollectionAssert.AreEqual(expected, input);
		}

		[TestMethod]
		public void InsertionSortSingleElement()
		{
			int[] input = { 5 };
			int[] expected = { 5 };

			Sorter<int>.InsertionSort(input);

			CollectionAssert.AreEqual(expected, input);
		}

		[TestMethod]
		public void InsertionSortBestCase()
		{
			int[] input = { 1, 2, 3, 4, 5 };
			int[] expected = { 1, 2, 3, 4, 5 };

			Sorter<int>.InsertionSort(input);

			CollectionAssert.AreEqual(expected, input);
		}

		[TestMethod]
		public void InsertionSortDuplicateNumbers()
		{
			int[] input = { 5, 2, 5, 3, 1, 2, 4 };
			int[] expected = { 1, 2, 2, 3, 4, 5, 5 };

			Sorter<int>.InsertionSort(input);

			CollectionAssert.AreEqual(expected, input);
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////

		[TestMethod]
		public void romanToIntHappypath()
		{
			string input = "XCII";
			int expected = 92;
			int result = romanToInt(input);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void romanToIntEmptyString()
		{
			string input = "";
			int expected = 0;
			int result = romanToInt(input);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void romanToIntIncorrectCharacter()
		{
			string input = "XCIIA";
			int expected = -1;
			int result = romanToInt(input);
			Assert.AreEqual(expected, result);
		}

	}
}

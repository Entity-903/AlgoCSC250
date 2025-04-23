using SorterLibrary;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
		public void ExactIsomorphConversionHappyPath()
		{
			string input = "alphabet";
			// "0 1 2 3 0 4 5 6"
			string expected = "0 1 2 3 0 4 5 6";
			string output = Sorter<string>.ExactIsomorphConversion(input);

			Assert.AreEqual(expected, output);
		}

		//Should return the same expected output as happy path
		[TestMethod]
		public void ExactIsomorphConversionProperCapitalization()
		{
			string input = "Alphabet";
			// "0 1 2 3 0 4 5 6"
			string expected = "0 1 2 3 0 4 5 6";
			string output = Sorter<string>.ExactIsomorphConversion(input);

			Assert.AreEqual(expected, output);
		}

		[TestMethod]
		public void LooseIsomorphConversionHappyPath()
		{
			string input = "alphabet";
			// "1 1 1 1 1 1 2"
			string expected = "1 1 1 1 1 1 2";
			string output = Sorter<string>.LooseIsomorphConversion(input);

			Assert.AreEqual(expected, output);
		}

		//Should return the same expected output as happy path
		[TestMethod]
		public void LooseIsomorphConversionProperCapitalization()
		{
			string input = "Alphabet";
			// "1 1 1 1 1 1 2"
			string expected = "1 1 1 1 1 1 2";
			string output = Sorter<string>.LooseIsomorphConversion(input);

			Assert.AreEqual(expected, output);
		}
		//////////////////////////////////////////////////////////////////////////////////////////////////////

		[TestMethod]
		public void SortIsomorphsAlphabeticallyHappyPath()
		{
			string[] input = { "took", "seer", "seep", "meet", "look"};
			string[] expected = { "look", "meet", "seep", "seer", "took" };

			Sorter<string>.SortIsomorphsAlphabetically(input);

			//Assert.AreEqual(input, expected);
			CollectionAssert.AreEqual(input, expected);
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////

			//"Loose Isomorphs:\n" +
			//				  "1 1 1: ate bar eat fit sap\n" +
			//				  "1 1 2: look meet seep seer took\n" +
			//				  "1 2: add egg foo gag tot yay\n" +
			//				  "Exact Isomorphs:\n" +
			//				  "0 1 0: gag tot yay\n" +
			//				  "0 1 1: add egg foo\n" +
			//				  "0 1 1 2: look meet seep seer took\n" +
			//				  "0 1 2: ate bar eat fit sap\n" +
			//				  "Non-isomorphs: aaa fear mates"


		[TestMethod]
		public void IsomorphicSortHappyPath()
		{
			string[] input = ["aaa", "fear", "mates", "gag", "egg", "add", "foo", "sap", "yay", "tot", "look", "meet", "took", "seer", "seep", "ate", "bar", "eat", "fit"];
			string expected = "Loose Isomorphs:\n" +
							  "1 2 gag egg add foo yay tot\n" +
							  "1 1 1 sap ate bar eat fit\n" +
							  "1 1 2 look meet took seer seep\n" +
							  "Exact Isomorphs:\n" +
							  "0 1 0 gag yay tot\n" +
							  "0 1 1 egg add foo\n" +
							  "0 1 2 sap ate bar eat fit\n" +
							  "0 1 1 2 look meet took seer seep\n" +
							  "Non-Isomorphs: aaa fear mates ";

			string output = Sorter<string>.IsomorphicSort(input);

			Assert.AreEqual(expected, output);
		}

		[TestMethod]
		public void IsomorphicSortSameIsomorph()
		{

			//string expected = "Loose Isomorphs:\n" +
			//	  "1 1 1: ate bar eat fit sap\n" +
			//	  "1 2: add egg foo gag\n" +
			//	  "Exact Isomorphs:\n" +
			//	  "0 1 0: gag tot yay\n" +
			//	  "0 1 1: add egg foo\n" +
			//	  "0 1 2: ate bar eat fit sap\n" +
			//	  "Non-isomorphs: ";

			//Quick and simple test to ensure everything is sorted into their proper collections
			string[] input = ["add", "ate", "bar", "eat", "egg", "fit", "foo", "gag", "sap"];
			string expected = "Loose Isomorphs:\n" +
							  "1 2 add egg foo gag\n" +
							  "1 1 1 ate bar eat fit sap\n" +
							  "Exact Isomorphs:\n" +
							  "0 1 1 add egg foo\n" +
							  "0 1 2 ate bar eat fit sap\n" +
							  "Non-Isomorphs: ";

			string output = Sorter<string>.IsomorphicSort(input);

			Assert.AreEqual(expected, output);
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////

		[TestMethod]
		public void BinarySearchHappyPath()
		{
			int[] inputArray = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
			int inputFind = 20;
			int expected = 1;

			int actual = Sorter<int>.BinarySort(inputArray, inputFind);

			Assert.AreEqual(expected, actual);
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////

		[TestMethod]
		public void BinarySearchEmptyOrNullCollection()
		{
			int expected = -1;
			int inputFind = 0;

			//Null
			int[] inputArray = null;
			//Empty
			int[] emptyArray = { };

			int actual = Sorter<int>.BinarySort(inputArray, inputFind);
			Assert.AreEqual(expected, actual);

			actual = Sorter<int>.BinarySort(emptyArray, inputFind);
			Assert.AreEqual(expected, actual);
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////

		[TestMethod]
		public void BinarySearchImpossibleChronology()
		{
			// Returns -1 if inputFind is not found
			int[] inputArray = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
			int inputFind = 20;
			int expected = -1;
			int start = 10;
			int end   =  5;

			int actual = Sorter<int>.BinarySort(inputArray, inputFind, start, end);
			Assert.AreEqual(expected, actual);

			start = -5;
			end   = 10;

			actual = Sorter<int>.BinarySort(inputArray, inputFind, start, end);
			Assert.AreEqual(expected, actual);
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////

		[TestMethod]
		public void BinarySearchUnsortedCollection()
		{
			//Implements a bubble sort to ensure the collection is sorted
			int[] inputArray = { 90, 20, 50, 30, 40, 100, 10, 70, 60, 80 };
			
			int inputFind = 20;
			int expected = 1;

			int actual = Sorter<int>.BinarySort(inputArray, inputFind);

			Assert.AreEqual(expected, actual);
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////

		[TestMethod]
		public void BinarySearchNotInArray()
		{
			// Returns -1 if inputFind is not found
			int[] inputArray = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
			int inputFind = 35;
			int expected = -1;

			int actual = Sorter<int>.BinarySort(inputArray, inputFind);

			Assert.AreEqual(expected, actual);
		}

		//Generated via ChatGPT
		[TestMethod]
		public void BinarySearchFirstElement()
		{
			int[] inputArray = { 10, 20, 30, 40, 50 };
			int inputFind = 10;
			int expected = 0;

			int actual = Sorter<int>.BinarySort(inputArray, inputFind);
			Assert.AreEqual(expected, actual);
		}

		//Generated via ChatGPT
		[TestMethod]
		public void BinarySearchLastElement()
		{
			int[] inputArray = { 10, 20, 30, 40, 50 };
			int inputFind = 50;
			int expected = 4;

			int actual = Sorter<int>.BinarySort(inputArray, inputFind);
			Assert.AreEqual(expected, actual);
		}

	}
}

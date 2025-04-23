/*
 *https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1?view=net-8.0
 */
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace SorterLibrary
{
    public class Sorter<T> where T : IComparable<T>
    {
        //Time Complexity:  O(n^2)
        //Space Complexity: O(1)
        //Iterates through the array, swapping elements until the array is sorted from least to greatest
        //Array is sorted when no elements are swapped in an iteration
        public static void BubbleSort(T[] arr)
        {
			//If no swaps are made, the array is sorted
            //Track the number of iterations
            int iterations = 0;
            // Initialize here to make the while statement happy
			bool sorted = false;
            do
            {
				sorted = true;
				//Iterate through the entire array, starting at the beginning
				//At the end of each iteration, iterate through the array.Length - 1 - number of iterations
                //This ignores the element moved furthest to the right, since it is already sorted
				for (int i = 0; i < arr.Length - 1 - iterations; i++)
                {
                    //Compare elements at index and index + 1
                    // if first is >, swap
                    if (arr[i].CompareTo(arr[i + 1]) > 0)
                    {
                        T temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        sorted = false;
                    }
                }
            } while (!sorted);
		}
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//Time Complexity:  O(n^2)
		//Space Complexity: O(1)
		//Iterates through the array, finds the smallest element in the array, starting with the first element, and swaps said element with the beginning of the unsorted array
		//This is repeated until the array is sorted
		public static void SelectionSort(T[] arr)
        {
            int smallestValueAt;
            //Starting with the first element... 
            for (int i = 0; i < arr.Length - 1; i++)
            {
                smallestValueAt = i;
				//Compare the value with the other values in the unsorted array
                for (int j = i + 1; j < arr.Length; j++)
                {
                    //If smallestValue is greater than compared value, update smallestValueAt
                    if (arr[smallestValueAt].CompareTo(arr[j]) > 0)
                    {
                        smallestValueAt = j;
                    }
                }
				//Swap smallestValue with beginning of unsorted array if smallestValueAt was updated
				if (smallestValueAt != i)
				{
					T temp = arr[i];
					arr[i] = arr[smallestValueAt];
					arr[smallestValueAt] = temp;
				}
			}
		}
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//Time Complexity:  O(n^2)
		//Space Complexity: O(1)
		//Starting with the second element, check each previous element in the array, starting with the immediate left of the element in question
		//If the previous element value is less than the current value, place the current element value in (previous element + 1),
		//otherwise copy the previous element value forward to the next element value
		public static void InsertionSort(T[] arr)
		{
            //Start at the second element
            //First element of array is considered sorted in this context
            for (int i = 1; i < arr.Length; i++)
            {
                T tempCurrentValue = arr[i];
                //Check as many previous elements as necessary until a desired condition is met
                for (int j = 1; j <= i; j++)
                {
                    if (tempCurrentValue.CompareTo(arr[i - j]) < 0)
                    {
						//Copy the previous element value forward to the next element value
						arr[i - j + 1] = arr[i - j];
                        if (i == j)
                        {
                            //tempCurrentValue is less than all elements in the sorted list
							//Store tempCurrentValue to first element
							arr[0] = tempCurrentValue;
						}
					}
                    else
                    {
						//Store tempCurrentValue to arr[previousElement + 1]
						arr[i - j + 1] = tempCurrentValue;
                        //No need to check remaining elements in sorted list
                        break;
					}
                }
            }
		}
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//Converts every string passed in into an isomorph and organises the passed in strings based on their isomorphic value
        //Seperate lists will be made for loose, exact, and non-isomorphs

        //TODO: Update isomorph generation methods to return string
        public static string IsomorphicSort(string[] arr)
        {
            //KEY   - isomorphic value
            //VALUE - all strings that have the isomorphic value of KEY
            Dictionary<string, List<string>> exactIsomorphs = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> looseIsomorphs = new Dictionary<string, List<string>>();
			//Convert every string into an exact/loose isomorph and store results into their proper dictionary
            for (int i = 0; i < arr.Length; i++)
            {

				// "aaa", "fear", "mates", "gag", "egg", "add", "foo", "sap", "yay", "tot", "look", "meet", "took", "seer", "seep", "ate", "bar", "eat", "fit"

				// "add", "ate", "bar", "eat", "egg", "fit", "foo", "gag", "sap"

				string looseTemp = LooseIsomorphConversion(arr[i]);
                string exactTemp = ExactIsomorphConversion(arr[i]);

                //if (exactIsomorphs.ContainsKey(exactTemp.SequenceEqual()))
                if(exactIsomorphs.TryGetValue(exactTemp, out List<string> temp))
                {
                    // Both an exact and loose isomorphic key exist for this value
					//List<string> temp = exactIsomorphs[exactTemp];
					temp.Add(arr[i]);
                    temp = looseIsomorphs[looseTemp];
					temp.Add(arr[i]);

				}
				else
				{
					// An exact isomorphic key does not exist for this string, create that key/value pair
					exactIsomorphs.Add(exactTemp, new List<string> { arr[i] } );
					// However, a loose isomorphic value could still exist in this context
                    if (looseIsomorphs.TryGetValue(looseTemp, out temp))
                    {
						//List<string> temp = looseIsomorphs[looseTemp];
						temp.Add(arr[i]);
					}
                    else
                    {
                        // A loose isomorphic key does not exist for this string, create that key/value pair
						looseIsomorphs.Add(looseTemp, new List<string> { arr[i] });
					}
				}  
            }

			//Find the non-isomorphs
			string[] nonIsomorphs = new string[looseIsomorphs.Count];
            int tracker = 0;
            foreach (KeyValuePair<string, List<string>> isomorphs in looseIsomorphs)
            {
                //Remove non-isomorphs from the loose list
                if (isomorphs.Value.Count == 1)
                {
                    nonIsomorphs[tracker++] = isomorphs.Value.First();
                    looseIsomorphs.Remove(isomorphs.Key);
                }
            }

            //Non-isomorphs can also exist in the exact collection, iterate through exact collection and remove any stragglers
            foreach (KeyValuePair<string, List<string>> isomorphs in exactIsomorphs)
            {
				if (isomorphs.Value.Count == 1)
				{
					exactIsomorphs.Remove(isomorphs.Key);
				}
			}

			StringBuilder printThisYouFilthyCasual = new StringBuilder("Loose Isomorphs:\n");

            // Add every loose isomorph and affiliates to string
            foreach (KeyValuePair<string, List<string>> isomorphs in looseIsomorphs)
            {
				// Sort the groups of loose isomorphs alphabetically
				string[] sortedValues = SortIsomorphsAlphabetically(isomorphs.Value.ToArray());
				printThisYouFilthyCasual.Append(isomorphs.Key + ": ");
				for (int i = 0; i < sortedValues.Count(); i++)
                {
                    if (i != sortedValues.Count() - 1)
                    {
                        printThisYouFilthyCasual.Append(sortedValues[i] + " ");
                    }
                    else
                    {
						printThisYouFilthyCasual.Append(sortedValues[i] + "\n");
					}
                }
            }

			printThisYouFilthyCasual.Append("Exact Isomorphs:\n");
			// Add every exact isomorph and affiliates to string
			foreach (KeyValuePair<string, List<string>> isomorphs in exactIsomorphs)
			{
				// Sort the groups of exact isomorphs alphabetically
				string[] sortedValues = SortIsomorphsAlphabetically(isomorphs.Value.ToArray());
				printThisYouFilthyCasual.Append(isomorphs.Key + ": ");
                //Iterate through each key
				for (int i = 0; i < isomorphs.Value.Count; i++)
				{
					if (i != sortedValues.Count() - 1)
					{
						printThisYouFilthyCasual.Append(sortedValues[i] + " ");
					}
					else
					{
						printThisYouFilthyCasual.Append(sortedValues[i] + "\n");
					}
				}
			}

			printThisYouFilthyCasual.Append("Non-Isomorphs: ");
			// Add every non-isomorph to string
			for (int i = 0; i < nonIsomorphs.Length; i++)
			{
                if (nonIsomorphs[i] != null)
                {
                    printThisYouFilthyCasual.Append(nonIsomorphs[i] + " ");
                }
			}

			return printThisYouFilthyCasual.ToString();
        }
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// Input:  A string containing letters
		// Output: A string where each unique character is replaced with a unique number
		// Example: "alphabet" becomes "0 1 2 3 0 4 5 6"
		public static string ExactIsomorphConversion(string s)
        {
            //Stores previously found characters and their numeric value
            Dictionary<char, int> characterReference = new Dictionary<char, int>();
            //Ensures unique values are distributed
            int tracker = 0;
			//Stores the exact isomorphic value of the passed in string
			StringBuilder result = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                //If we already found that character before, replace that character with its proper value
                if (characterReference.ContainsKey(s.ToLower()[i]))
                {
                    //There is no need to check if i == 0 here
                    //If characterReference contains the character already, we have seen it before and therefore, "i" cannot be 0
                    result.Append(" " + characterReference[s.ToLower()[i]]);
                }
                else //Otherwise, assign that character a unique value and save it to the dictionary, then replace the character with its assigned value
                {
                    characterReference.Add(s.ToLower()[i], tracker++);
                    //Don't add a space in front of the first character of result
                    if (i == 0)
                    {
                        result.Append("" + characterReference[s.ToLower()[i]]);
                        //result[i] = characterReference[s.ToLower()[i]];
					}
                    else
                    {
						result.Append(" " + characterReference[s.ToLower()[i]]);
						//result[i] = characterReference[s.ToLower()[i]];
                    }
                }
            }
            return result.ToString();
        }

		// Input:  A string containing letters
		// Output: A string comtaining the numeric representation of the frequency of unique characters. The resulting values are then sorted from least to greatest
        // Example: "alphabet" becomes "1 1 1 1 1 1 2"
		public static string LooseIsomorphConversion(string s)
		{
			//Stores previously found characters and how many times they were found
			Dictionary<char, int> characterReference = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
				//If we already found that character before, update the number of occurrences of that character accordingly
				if (characterReference.ContainsKey(s.ToLower()[i]))
				{
                    //Increment the number of occurrences for that character
					characterReference[s.ToLower()[i]]++;
				}
				else //Otherwise, assign that character a value of one and save it to the dictionary
				{
					characterReference.Add(s.ToLower()[i], 1);
				}
			}

			//Stores the raw isomorphic value of the passed in string
			int[] rawResult = new int[characterReference.Count];
            int tracker = 0;

            //Ensures that every unique character is added only once
            //List<char> foundCharacters = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                //If not a found character, append character to result for sorting and make value 0
                //Value of 0 denotes an already found character and should skip that value
                if (characterReference[s.ToLower()[i]] != 0)
                {
                    rawResult[tracker++] = characterReference[s.ToLower()[i]];
                    characterReference[s.ToLower()[i]] = 0;
                }
            }

            //Sorts the contained values to provide proper representation of the loose isomorph
			Sorter<int>.InsertionSort(rawResult);

            //Store the loose isomorph as a string
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < rawResult.Length; i++)
            {
                //Don't add a space in front of the first character
                if (i == 0)
                {
                    result.Append("" + rawResult[i]);
                }
                else
                {
					result.Append(" " + rawResult[i]);
				}
            }

			return result.ToString();
		}

        // Input: A collection of strings confirmed to have the same exact/loose isomorphic value
        // Output A sorted collection of strings organised alphabetically
        public static string[] SortIsomorphsAlphabetically(string[] collection)
        {
            Sorter<string>.InsertionSort(collection);
            return collection;
        }
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Finds the value in a sorted array by comparing what we are looking for with the middle element
        // O(n^2) due to the implementation of Insertion Sort.
        // However, presuming the user is giving already sorted collections, which they SHOULD, The Big O is usually n
        // Excluding the sort, we have a Big O of log(n)
		public static int BinarySort(int[] arr, int seek)
        {
			//Check if arr is null
			if (arr == null)
			{
				return -1;
			}

            int end = arr.Length - 1;

			//Check if array is empty
			if (end == -1)
			{
				//Empty array
				return -1;
			}
			else
			{
				//Ensures sorted array
				Sorter<int>.InsertionSort(arr);
			}

			return BinarySort(arr, seek, 0, end);
        }

        //Recursive Method of BinarySort
		public static int BinarySort(int[] arr, int seek, int start, int end)
        {

			//Ensure start is less than end and start is a non-negative value
			if (start <= end && start >= 0)
            {
				//Correct

                int middle = (end + start) / 2;
                //If less, round up
                if ((float)middle < (float)(end - start) / 2)
                {
                    middle++;
                }

                if (seek == arr[middle])
                {
                    return middle;
                }
                else if (seek < arr[middle]) // Seek is to the left of the middle
                {
                    return BinarySort(arr, seek, start, middle - 1);
                }
                else // Seek is to the right of the middle
                {
					return BinarySort(arr, seek, middle + 1, end);
				}
            }
            else
            {
                //Impossible Chonology
                return -1;
            }
	    }
	}
}
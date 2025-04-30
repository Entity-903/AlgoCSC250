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
                //Impossible Chronology
                return -1;
            }
	    }

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void MergeSort(T[] arr)
        {
            if (arr == null)
            {
                return;
            }
			// Divide the collection until we have groups of 1 element
            // In the case of an odd number of elements, secondHalf will have one more element than firstHalf
            int tracker = 0;
			T[] firstHalf = new T[arr.Length / 2]; // 5 / 2 = 2.5 -> 2
			T[] secondHalf = new T[arr.Length - firstHalf.Length]; // 5 - 2 = 3
            // We divide the collection as many times as needed until we have collections that have a maximum size of 1
			if (arr.Length > 1)
            {
                for (int i = 0; i < firstHalf.Length; i++)
                {
                    firstHalf[i] = arr[tracker++];
                }
                for (int i = 0; i < secondHalf.Length; i++)
                {
                    secondHalf[i] = arr[tracker++];
                }

                MergeSort(firstHalf);
                MergeSort(secondHalf);
            }
            else
            {
                return;
            }
            // Sort these smaller collections, then recombine those smaller collections by comparing the first elements of each "unsorted" collection
            //     This is how we merge these collections
            int firstTracker  = 0;
            int secondTracker = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                // If we already sorted through a half of the array, add the remaining elements from the other half
                if (firstTracker > firstHalf.Length - 1)
                {
                    arr[i] = secondHalf[secondTracker++];
                    continue;
                }
                if (secondTracker > secondHalf.Length - 1)
                {
                    arr[i] = firstHalf[firstTracker++];
                    continue;
                }
                // Sort by comparing the first element of each half
                if (firstHalf[firstTracker].CompareTo(secondHalf[secondTracker]) <= 0) // The <= should make this a stable sort
                {
                    arr[i] = firstHalf[firstTracker++];
                    continue;
                }
                else
                {
                    arr[i] = secondHalf[secondTracker++];
                    continue;
                }
            }
        }

        //Unit tests:
        // QuickSortHappyPath
        // QuickSortTwoElements
        // QuickSortDuplicateElements
        public static void QuickSort(T[] arr)
        {
            //Ensure Existence
            if (arr == null || arr.Length == 0)
            {
                return;
            }

            //Find the index of the pivot 
            int pivot = ChoosePivot(arr);
            //  If the arr has either TWO or THREE elements, return; The array is sorted due to implementation of ChoosePivot()
            if (pivot == -1)
            {
                return;
            }

            //If an element on the left of the pivot is greater than the pivot, move the element to the right of the pivot
            //If an element on the right of the pivot is less than the pivot, move the element to the left of the pivot
            T leftValue  = arr[pivot];
            T rightValue = arr[pivot];

            // Due to the implementation of ChoosePivot(), We do not need to compare the furthest elements of the array
            int i = 1;
            int j = arr.Length - 2;

            do
            {
			    //When preforming our swaps, find a value greater than the pivot on the left, then look for a value less than the pivot on the right.
			    //This way, we can swap both values at once
                for (; i < pivot; i++)
                {
                    // If we find a value greater than the pivot, save the element to leftValue;
                    if (arr[i].CompareTo(arr[pivot]) > 0)
                    {
                        leftValue = arr[i];
                        break;
                    }
                }

                for (; j > pivot; j--)
                {
					// If we find a value less than the pivot, save the element to rightValue;
					if (arr[j].CompareTo(arr[pivot]) < 0)
					{
						rightValue = arr[j];
                        break;
					}
				}
                // These comparisons ensure that our temp value holders and our positions in the array are up-to-date
                if (arr[i].CompareTo(leftValue) == 0 && arr[j].CompareTo(rightValue) == 0)
                {
                    arr[j] = leftValue;
                    arr[i] = rightValue;
                }
				else //Only one element needs to be swapped, bubble the element until it is on the correct side of the pivot
				{
					//leftValue = 3

					// 3 2 1 4 5 6
					// 0 1 2 3 4 5
					// ^   ^
					// x   p

					//bubble up

					// 2 2 1 4 5 6
					// 0 1 2 3 4 5
					//   ^ ^
					//   x p

					//bubble up

					// 2 1 1 4 5 6
					// 0 1 2 3 4 5
					//   ^ ^
					//   P x

					//inject leftValue

					// 2 1 3 4 5 6
					// 0 1 2 3 4 5
					//   ^ ^
					//   P x

					//happypath

					//-----------------------------------

                    //rightValue = 4

					// 1 2 3 6 5 4
					// 0 1 2 3 4 5
					//       ^   ^
					//       p   x

					//bubble down

					// 1 2 3 6 5 5
					// 0 1 2 3 4 5
					//       ^ ^
					//       p x

					//bubble down

					// 1 2 3 6 6 5
					// 0 1 2 3 4 5
					//       ^ ^
					//       x p

					//inject rightValue

					// 1 2 3 4 6 5
					// 0 1 2 3 4 5
					//       ^ ^
					//       p x

					//happypath

                    //Never update 'i' here; It is imperitive to the do while loop
					if (arr[i].CompareTo(leftValue) == 0)
                    {
                        pivot--;
                        for (int x = i; x <= pivot + 1; x++)
                        {
                            arr[x] = arr[x + 1];
                            if (x == pivot + 1)
                            {
                                arr[x] = leftValue;
                            }
                        }
                    } else 
                    if (arr[j].CompareTo(rightValue) == 0)
                    {
						pivot++;
						for (int x = i; x >= pivot - 1; x--)
						{
							arr[x] = arr[x - 1];
							if (x == pivot - 1)
							{
								arr[x] = rightValue;
							}
						}
					}
                } // If if statements in else return false, then neither is up-to-date and both i and j are equal to the pivot
			} while (i != pivot && j != pivot);


			//Once the pivot is in its proper place in the collection, call QuickSort again on each side of the pivot

			// 3 2 1 5 9 8 7
			// 0 1 2 3 4 5 6
			//       ^

			// 3 2 5 9 8 7
			// 0 1 2 3 4 5
			//     ^

			// QuickSort left side
			T[] arrLeft = new T[pivot];
            for (int x = 0; x < pivot; x++)
            {
                arrLeft[x] = arr[x];
            }
            QuickSort(arrLeft);
            // QuickSort right side
            T[] arrRight;
			if (arr.Length % 2 == 0)
            {
				// arr has an even number of elements; arrRight gets one more element than arrLeft
				arrRight = new T[arrLeft.Length + 1];
			}
            else
            {
				// arr has an odd number of elements; arrRight gets same number of elements as arrLeft
		        arrRight = new T[arrLeft.Length];
			}
			for (int x = 0; x < pivot; x++)
			{
				arrRight[x] = arr[x];
			}
			QuickSort(arrRight);

			//  This is repeated recursively until every subcollection of 1-3 elements are confirmed to be sorted
		}

        //Takes in the array and returns the middle index.
        //The first, middle, and last elements will be sorted before we return the pivot index
        //Shouldn't need to return the index of the middle element, since we already find that to pass it in
        public static int ChoosePivot(T[] arr)
        {   
            if (arr.Length == 2)
            {
                //Use this presuming if(ChoosePivot(arr) == -1) changes the values of arr accordingly
                if (arr[0].CompareTo(arr[1]) > 0)
                {
                    T temp = arr[0];
                    arr[0] = arr[1];
                    arr[1] = temp;
                }
                return -1;
            }

            // In the event of an even number of elements choose the left center element
            int first = 0;
            int middle = arr.Length / 2;
            int last = arr.Length - 1;

			T smallestValue;
            T pivotValue;
            T largestValue;
            
			if (arr[first].CompareTo(arr[middle]) <= 0)
            {
                if (arr[middle].CompareTo(arr[last]) < 0)
                {
                    // 1 2 3
                    smallestValue = arr[first];
                    pivotValue    = arr[middle];
                    largestValue  = arr[last];
                }
                else
                {
                    if (arr[first].CompareTo(arr[last]) < 0)
                    {
						// 1 3 2
						smallestValue = arr[first];
						pivotValue    = arr[last];
						largestValue  = arr[middle];
					}
                    else
                    {
						// 2 3 1
						smallestValue = arr[last];
						pivotValue    = arr[first];
						largestValue  = arr[middle];
					}
                }
            }
            else
            {
                if (arr[middle].CompareTo(arr[last]) > 0)
                {
					// 3 2 1
					smallestValue = arr[last];
					pivotValue    = arr[middle];
					largestValue  = arr[first];
				}
                else
                {
                    if (arr[first].CompareTo(arr[last]) < 0)
                    {
						// 2 1 3
						smallestValue = arr[middle];
						pivotValue    = arr[first];
						largestValue  = arr[last];

					}
                    else
                    {
						// 3 1 2
						smallestValue = arr[middle];
						pivotValue    = arr[last];
						largestValue  = arr[first];
					}
                }
            }

            //Update arr with sorted elements
            arr[first]  = smallestValue;
            arr[middle] = pivotValue;
            arr[last]   = largestValue;

            // If the array only has three elements, ChoosePivot() already sorted them
            if (arr.Length == 3)
            {
                return -1;
            }

            //Return the index of the pivot (middle)
            return middle;
		}
	}
}
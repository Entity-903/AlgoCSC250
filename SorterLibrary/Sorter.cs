/*
 *https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1?view=net-8.0
 */
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

	}
}

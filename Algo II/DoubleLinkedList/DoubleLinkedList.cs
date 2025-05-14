using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_II.DoubleLinkedList
{
	public class DoubleLinkedList<T>
	{
		public Node<T>? HeadNode { get; set; }
		public Node<T>? TailNode { get; set; }
		public int Count { get; set; } = 0;

		// Default
		public DoubleLinkedList()
		{

		}

		// Initializes a value as a node
		public DoubleLinkedList(T value)
		{
			Add(value);
		}

		// Initializes an array of values as nodes
		public DoubleLinkedList(T[] values)
		{
			for (int i = 0; i < values.Count(); i++)
			{
				Add(values[i]);
			}
		}

		/// <summary>
		/// Puts a new value at the tail end of the list
		/// </summary>
		/// <param name="val"> Data to add to the list </param>
		public void Add(T val)
		{
			// Create the new node
			Node<T> newNode = new Node<T>(val);
			if (Count > 0)
			{
				// Find the last node
				Node<T> currentTail = HeadNode;
				for (int i = 0; i < Count - 1; i++)
				{
					currentTail = currentTail.Next;
				}
				// Have the new tail point to the old tail
				newNode.Previous = currentTail;
				// Have the old tail point to the new tail
				currentTail.Next = newNode;
			}
			else
			{
				// No nodes in list, newNode is the first node
				HeadNode = newNode;
			}
			TailNode = newNode;
			Count++;
		}

		// 
		/// <summary>
		/// Inserts a new value at a given index, pushing the existing value at that index to the next index spot
		/// </summary>
		/// <param name="val"> Data to add to the list </param>
		/// <param name="index"> Intended location for data </param>
		/// <exception cref="IndexOutOfRangeException"> index is outside the range of nodes </exception>
		public void Insert(T val, int index)
		{
			if (index >= 0 && index < Count)
			{
				// Find insertion location
				Node<T> updateThis = HeadNode;
				for (int i = 0; i < index - 1; i++)
				{
					updateThis = updateThis.Next;
				}
				// Create new node with proper Next.Previous values
				Node<T> newNode = new Node<T>(val, updateThis.Next, updateThis);
				// Update Previous value to point to new node
				updateThis.Next.Previous = newNode;
				// updateThis to point at the new node
				updateThis.Next = newNode;

				Count++;
			}
			else
			{
				throw new IndexOutOfRangeException("Index is outside the range of nodes!");
			}
		}

		/// <summary>
		/// Returns the value at the given index
		/// </summary>
		/// <param name="index"></param>
		/// <returns> Data from the specified node </returns>
		/// <exception cref="IndexOutOfRangeException"> index is outside the range of nodes </exception>
		public T Get(int index)
		{
			if (index >= 0 && index < Count)
			{
				// 1 2 3 4 5
				//       *
				// 1 2 3 4 5 6
				//       *
				Node<T> retriever;
				if (index > (Count / 2 + 0.5))
				{
					retriever = TailNode;
					for (int i = Count; i > index; i--)
					{
						retriever = retriever.Previous;
					}
				}
				else
				{
					retriever = HeadNode;
					for (int i = 0; i < index; i++)
					{
						retriever = retriever.Next;
					}
				}
				return retriever.Data;
			}
			else
			{
				throw new IndexOutOfRangeException("Index is outside the range of nodes!");
			}
		}

		/// <summary>
		/// Removes the first value in the list
		/// </summary>
		/// <returns> the removed first value in the list</returns>
		public T? Remove()
		{
			if (Count > 0)
			{
				// Remember old node
				Node<T> oldHead = HeadNode;
				// Update HeadNode
				HeadNode = oldHead.Next;
				HeadNode.Previous = null;
				// Disconnect old head
				oldHead.Next = null;

				Count--;
				return oldHead.Data;
			}
			else
			{
				return default(T);
			}
		}

		// Removes and returns the value at the given index
		public T RemoveAt(int index)
		{
			if (index >= 0 && index < Count)
			{

				// If removing at index 0
				if (index == 0)
				{
					return Remove();
				}
				// If removing the last element in the list
				if (index == Count - 1)
				{
					return RemoveLast();
				}

				Node<T> target = HeadNode;
				for (int i = 0; i < index - 1; i++)
				{
					target = target.Next;
				}

				Node<T> killThisMan = target.Next;

				target.Next = target.Next.Next;
				target.Next.Previous = target;
				killThisMan.Next	 = null;
				killThisMan.Previous = null;

				Count--;
				return killThisMan.Data;
			}
			else
			{
				throw new IndexOutOfRangeException("Index is outside the range of nodes!");
			}

		}

		// Removes and returns the last value in the list
		public T? RemoveLast()
		{
			if (Count > 0)
			{
				Node<T> newTail = TailNode.Previous;
				TailNode = newTail;
				Node<T> deadTail = newTail.Next;
				newTail.Next.Previous = null;
				newTail.Next = null;

				Count--;

				return deadTail.Data;
			}
			else
			{
				return default(T);
			}
		}
		
		// Creates and returns a string representation of all values in the list
		// i.e. "6, 1, 4, 2, 6, 3, 8"
		public string ToString()
		{
			StringBuilder sb = new StringBuilder();
			Node<T> tracker = HeadNode;

			for (int i = 0; i < Count; i++)
			{
				if (i < Count - 1)
				{
					sb.Append(tracker.Data + ", ");
					tracker = tracker.Next;
				}
				else
				{
					sb.Append(tracker.Data + "\n");
				}
			}

			return sb.ToString();
		}

		/// <summary>
		/// Removes all values in the list
		/// </summary>
		public void Clear()
		{
			HeadNode = null;
			TailNode = null;
			Count = 0;
		}

		/// <summary>
		/// Searches for a value in the list
		/// </summary>
		/// <param name="val"></param>
		/// <returns> returns the first index of that value when found. If not found, return -1 </returns>
		public int Search(T val)
		{
			if (HeadNode == null)
			{
				return -1;
			}
			Node<T> tracker = HeadNode;
			for (int i = 0; i < Count; i++)
			{
				if (tracker.Data.Equals(val))
				{
					return i;
				}
				tracker = tracker.Next;
			}
			return -1;
		}
	}
}

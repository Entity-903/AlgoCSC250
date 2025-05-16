using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algo_II.SingleLinkedList;

namespace Algo_II.Queue
{
	// Have Queue add to the end of the collection, while Stack adds to the beginning of the collection
	// Stack and Queue returns the HeadNode
	public class Queue<T>
	{
		// Enqueue() Purpose
		// Add item to the end of the list

		// Enqueue()
		// Start at the Head node. 
		// Copy the passed in value into a temperary node called "newNode"; newNode's Next value will be null
		// Start a loop where you continue until tail.next == null
		// Have the tail.next point to newNode
		// If there is no head node, make the new node the head node
		// Increment Count
		private SingleLinkedList<T> sll { get; set; }

		public Queue()
		{

		}

		public Queue(T[] values)
		{
			sll = new SingleLinkedList<T>(values);
		}

		/// <summary>
		/// Obtains data at the specified index
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public T Get(int index)
		{
			return sll.Get(index);
		}

		/// <summary>
		/// Checks if a value is contained within the queue
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		public bool Contains(T val)
		{
			return (sll.Search(val) != -1);
		}

		/// <summary>
		/// Shows the next value to process in the queue without removing the value
		/// </summary>
		/// <returns></returns>
		public T? Peek()
		{
			if (sll != null)
			{
				return sll.HeadNode.Data;
			}
			else
			{
				return default(T);
			}
		}

		/// <summary>
		/// Returns and removes the next value in the queue
		/// </summary>
		/// <returns></returns>
		public T? Dequeue()
		{
			return sll.Remove();
		}

		/// <summary>
		/// Adds a value to the end of the queue
		/// </summary>
		/// <param name="data"></param>
		public void Enqueue(T data)
		{
			sll.Add(data);
		}
	}
}

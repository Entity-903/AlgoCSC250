using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algo_II.SingleLinkedList;

namespace Algo_II.Queue
{
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
		/// BigO(n)
		/// </summary>
		/// <param name="index"></param>
		/// <returns> Data at the specified node </returns>
		public T Get(int index)
		{
			return sll.Get(index);
		}

		/// <summary>
		/// Checks if a value is contained within the queue
		/// BigO(n)
		/// </summary>
		/// <param name="val"></param>
		/// <returns> True if value is found, else false </returns>
		public bool Contains(T val)
		{
			return (sll.Search(val) != -1);
		}

		/// <summary>
		/// Shows the next value to process in the queue without removing the value
		/// BigO(1)
		/// </summary>
		/// <returns> Next value in the queue </returns>
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
		/// Removes the next value in the queue
		/// BigO(1)
		/// </summary>
		/// <returns> Next value in the queue </returns>
		public T? Dequeue()
		{
			if(sll != null)
			{
				return sll.Remove();
			}
			else
			{ 
				return default(T); 
			}
		}

		/// <summary>
		/// Adds a value to the end of the queue
		/// BigO(n)
		/// </summary>
		/// <param name="data"> Data to add to the queue </param>
		public void Enqueue(T data)
		{
			if (sll != null)
			{
				sll.Add(data);
			}
			else
			{
				sll = new SingleLinkedList<T>(data);
			}
		}
	}
}

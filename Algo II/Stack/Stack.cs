using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algo_II.SingleLinkedList;

namespace Algo_II.Stack
{
	public class Stack<T>
	{
		// Have Queue add to the end of the collection, while Stack adds to the beginning of the collection
		// Stack and Queue returns the HeadNode
		private SingleLinkedList<T> sll { get; set; }

		public Stack()
		{

		}

		public Stack(T[] values)
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
		/// Checks if a value is contained within the stack
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		public bool Contains(T val)
		{
			return (sll.Search(val) != -1);
		}

		/// <summary>
		/// Shows the next value o process in the stack without removing the value
		/// </summary>
		/// <returns></returns>
		public T? Peek()
		{
			return sll.HeadNode.Data;
		}

		/// <summary>
		/// Returns and removes the next value in the stack
		/// </summary>
		/// <returns></returns>
		public T? Pop()
		{
			return sll.Remove();
		}

		/// <summary>
		/// Adds a value to the end of the queue
		/// </summary>
		/// <param name="data"></param>
		public void Push(T data)
		{
			sll.Insert(data, 0);
		}
	}
}

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
		/// BigO(n)
		/// </summary>
		/// <param name="index"></param>
		/// <returns> Data at the specified node </returns>
		public T Get(int index)
		{
			return sll.Get(index);
		}

		/// <summary>
		/// Checks if a value is contained within the stack
		/// BigO(n)
		/// </summary>
		/// <param name="val"></param>
		/// <returns> True if value is found, else false </returns>
		public bool Contains(T val)
		{
			return (sll.Search(val) != -1);
		}

		/// <summary>
		/// Shows the top value in the stack without removing the value
		/// BigO(1)
		/// </summary>
		/// <returns> Top value in the stack </returns>
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
		/// Removes the top value in the stack
		/// BigO(1)
		/// </summary>
		/// <returns> Top value in the stack </returns>
		public T? Pop()
		{
			if (sll != null)
			{
				return sll.Remove();
			}
			else
			{
				return default(T);
			}
		}

		/// <summary>
		/// Adds a value to the top of the stack
		/// BigO(1)
		/// </summary>
		/// <param name="data"> Data to add to the stack </param>
		public void Push(T data)
		{
			if (sll != null)
			{
				sll.Insert(data, 0);
			}
			else
			{
				sll = new SingleLinkedList<T>(data);
			}
		}
	}
}

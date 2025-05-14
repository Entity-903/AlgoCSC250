using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_II.SingleLinkedList
{
	public class Node <T>
	{
		public T Data { get; set; }
		public Node<T> Next { get; set; }

		public Node()
		{

		}

		// Creates a node whose Next value is null
		public Node(T data)
		{
			Data = data;
		}

		// Creates a node that points to another existing node
		public Node(T data, Node<T> next)
		{
			Data = data;
			Next = next;
		}
	}
}

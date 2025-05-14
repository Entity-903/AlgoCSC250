using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_II.DoubleLinkedList
{
	public class Node <T>
	{
		public T Data { get; set; }
		public Node<T> Next { get; set; }
		public Node<T> Previous { get; set; }

		public Node()
		{

		}

		// Creates a node whose Next and Pevious values are null
		public Node(T data)
		{
			Data = data;
		}

		// Creates a head or tail node that points to another existing node
		public Node(T data, Node<T> otherNode, bool isHead)
		{
			if (isHead)
			{
				Data = data;
				Next = otherNode;
			}
			else // isTail
			{
				Data = data;
				Previous = otherNode;
			}
		}

		// Creates a node that points to existing nodes
		public Node(T data, Node<T> next, Node<T> previous)
		{
			Data = data;
			Next = next;
			Previous = previous;
		}
	}
}

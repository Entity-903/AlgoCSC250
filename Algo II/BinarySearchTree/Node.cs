using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Algo_II.BinarySearchTree
{
	public class Node<T>
	{
		public T Data { get; set; }
		public Node<T> LeftChild { get; set; }
		public Node<T> RightChild { get; set; }

		public Node()
		{

		}

		// Creates a node whose children are null
		public Node(T data)
		{
			Data = data;
		}

		// Creates a node that points to another existing node
		public Node(T data, Node<T> leftChild, Node<T> rightChild)
		{
			Data = data;
			LeftChild = leftChild;
			RightChild = rightChild;
		}
	}
}
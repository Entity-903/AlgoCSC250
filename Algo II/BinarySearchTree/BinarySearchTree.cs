using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_II.BinarySearchTree
{
	public class BinarySearchTree<T> where T : IComparable<T>
	{
		public Node<T> RootNode;
		public int Count { get; private set; }

		// Default
		public BinarySearchTree()
		{

		}

		// Initialize with a single value
		public BinarySearchTree(T value)
		{
			AddValue(value);
		}

		// Initialize with a collection of values
		public BinarySearchTree(T[] values)
		{
			for (int i = 0; i < values.Length; i++)
			{
				AddValue(values[i]);
			}
		}

		public void AddValue(T value)
		{
			// If the root node is null, create a new node with no children to hold our passed-in data, referred to as "value", as the root node
			// otherwise...
			// Repeat this until we find a location to store value, with "currentNode" starting at the root node, and moving through the tree through the curentNode's children, LeftChild and RightChild
			// The location is found when we notice the node we want to repeat our logic with is null
			// {
			// Compare value with the data stored in the currentNode
			// if value <= the data stored in currentNode, LeftChild
			//		if currentNode.LeftChild == null, set LeftChild to equal a node that contains value and has no children
			//			else currentNode = currentNode.LeftChild
			// else RightChild
			//		if currentNode.RightChild == null, set RightChild to equal a node that contains value and has no children
			//			else currentNode = curentNode.RightChild
			// }
			// Increment Count

			if (RootNode == null)
			{
				RootNode = new Node<T>(value);
			}
			else
			{
				Node<T> currentNode = RootNode;
				bool nodeAdded = false;
				
				while (!nodeAdded)
				{

					//if (value <= currentNode.Data)
					if (value.CompareTo(currentNode.Data) <= 0)
					{
						if (currentNode.LeftChild == null)
						{
							Node<T> newNode = new Node<T>(value);
							currentNode.LeftChild = newNode;
							nodeAdded = true;
						}
						else
						{
							currentNode = currentNode.LeftChild;
						}
					}
					else // value > currentNode.Data
					{
						if (currentNode.RightChild == null)
						{
							Node<T> newNode = new Node<T>(value);
							currentNode.RightChild = newNode;
							nodeAdded = true;
						}
						else
						{
							currentNode = currentNode.RightChild;
						}
					}
				}
			}

			// Increment Count
			Count++;
		}

		public void Clear()
		{
			// Set RootNode to null
			// Set Count to 0


			RootNode = null;
			Count = 0;
		}

		
	}
}

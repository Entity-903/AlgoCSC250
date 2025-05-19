using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_II.BinarySearchTree
{
	public class BinarySearchTree<T>
	{
		public void AddValue(T value)
		{
			// If the root node is null, create a new node with no children to hold our passed-in data, referred to as "value", as the root node
			// otherwise...
			// Repeat this until we find a location to store value, with "currentNode" starting at the root node, and moving through the tree through the curentNode's children, LeftChild and RightChild
			// The location is found when we notice the node we want to repeat our logic with is null
			// {
			// Compare our passed in value with the data stored in the currentNode
			// if value <= the data stored in currentNode, LeftChild
			//		if currentNode.LeftChild == null, set LeftChild to equal a node that contains value and has no children
			//			else currentNode = currentNode.LeftChild
			// else RightChild
			//		if currentNode.RightChild == null, set RightChild to equal a node that contains value and has no children
			//			else currentNode = curentNode.RightChild
			// }
			// Increment Count


			// Increment Count
			Count++;
		}

		public void Clear()
		{
			//
			// Set Count to 0

			Count = 0;
		}

		public int Count { get; private set; }
	}
}

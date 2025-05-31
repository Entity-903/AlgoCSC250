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

		/// <summary>
		/// Adds a value to the tree
		/// </summary>
		/// <param name="value"> Value to add to the BinarySearchTree </param>
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

		/// <summary>
		/// Clears the tree
		/// </summary>
		public void Clear()
		{
			// Set RootNode to null
			// Set Count to 0


			RootNode = null;
			Count = 0;
		}

		/// <summary>
		/// Checks if the tree contains a value
		/// </summary>
		/// <param name="value"> Value we are looking for </param>
		/// <returns></returns>
		public bool Contains(T value)
		{
			Node<T> currentNode = RootNode;
			for (int i = 0; i < Height(); i++)
			{
				if (value.CompareTo(currentNode.Data) == 0)
				{
					return true;
				}

				if (value.CompareTo(currentNode.Data) > 0)
				{
					if (currentNode.RightChild == null)
					{
						return false;
					}
					else
					{
						currentNode = currentNode.RightChild;
					}
				}
				else // value < currentNode.Data
				{
					if (currentNode.LeftChild == null)
					{
						return false;
					}
					else
					{
						currentNode = currentNode.LeftChild;
					}
				}
			}

			// Shouldn't get to this line, but will return return false if we get here
			return false;
		}

		/// <summary>
		/// Removes the specified value from the tree if present.
		/// Does nothing if not present.
		/// </summary>
		/// <param name="value"> Value to remove </param>
		public void Remove(T value)
		{
			Node<T> currentNode = RootNode;
			for (int i = 0; i < Height(); i++)
			{
					// remove() logic

				// ensure logic is impleneted when two children are present

				// check for left child
				// if present, current node now points to left child
				// otherwise check for right child
				// if present, current node now points to right child
				// otherwise current node points to null
				if (currentNode.LeftChild != null && value.CompareTo(currentNode.LeftChild.Data) == 0)
				{
					bool hasLeftChild  = (currentNode.LeftChild.LeftChild != null);
					bool hasRightChild = (currentNode.LeftChild.RightChild != null);

					if (!hasLeftChild && !hasRightChild)
					{
						currentNode.LeftChild = null;
					}
					else if (hasLeftChild && hasRightChild)
					{
						// Have left child of to-be-removed node point to to-be-removed node's right child
						currentNode.LeftChild.LeftChild.RightChild = currentNode.LeftChild.RightChild;
						// Have currentNode point to to-be-removed node's LeftChild
						currentNode.LeftChild = currentNode.LeftChild.LeftChild;
					}
					else if (hasLeftChild)
					{
						currentNode.LeftChild = currentNode.LeftChild.LeftChild;
					}
					else // hasRightChild
					{
						currentNode.LeftChild = currentNode.LeftChild.RightChild;
					}

					return;
				}
				else if (currentNode.RightChild != null && value.CompareTo(currentNode.RightChild.Data) == 0)
				{
					bool hasLeftChild = (currentNode.RightChild.LeftChild != null);
					bool hasRightChild = (currentNode.RightChild.RightChild != null);

					if (!hasLeftChild && !hasRightChild)
					{
						currentNode.RightChild = null;
					}
					else if (hasLeftChild && hasRightChild)
					{
						// Have left child of to-be-removed node point to to-be-removed node's right child
						currentNode.RightChild.LeftChild.RightChild = currentNode.RightChild.RightChild;
						// Have currentNode point to to-be-removed node's LeftChild
						currentNode.RightChild = currentNode.RightChild.LeftChild;
					}
					else if (hasLeftChild)
					{
						currentNode.RightChild = currentNode.RightChild.LeftChild;
					}
					else // hasRightChild
					{
						currentNode.RightChild = currentNode.RightChild.RightChild;
					}

					return;
				}

				// Search further
				if (value.CompareTo(currentNode.Data) > 0)
				{
					if (currentNode.RightChild != null)
					{
						currentNode = currentNode.RightChild;
					}
				}
				else // value < currentNode.Data
				{
					if (currentNode.LeftChild != null)
					{
						currentNode = currentNode.LeftChild;
					}
				}
			}
		}

		/// <summary>
		/// Calculates the height of the tree
		/// </summary>
		/// <returns></returns>
		public int Height()
		{
			if (RootNode == null)
			{
				return -1;
			}

			int currentLevel = 1;
			int deepestLevel = 1;
			Node<T> currentNode = RootNode;

			if (currentNode.LeftChild != null)
			{
				GoDeeper(currentNode.LeftChild, ref currentLevel, ref deepestLevel);
			}

			if (currentNode.RightChild != null)
			{
				GoDeeper(currentNode.RightChild, ref currentLevel, ref deepestLevel);
			}

			return deepestLevel;
		}

		/// <summary>
		/// Helps Height() to calculate the height of the tree
		/// </summary>
		/// <param name="currentNode"> Where we are in the tree </param>
		/// <param name="currentLevel"> How deep we are currently </param>
		/// <param name="deepestLevel"> The deepest we have ever gone </param>
		public void GoDeeper(Node<T> currentNode, ref int currentLevel, ref int deepestLevel)
		{
			currentLevel++;
			if (currentLevel > deepestLevel)
			{
				deepestLevel = currentLevel;
			}

			if (currentNode.LeftChild != null)
			{
				GoDeeper(currentNode.LeftChild, ref currentLevel, ref deepestLevel);
			}

			if (currentNode.RightChild != null)
			{
				GoDeeper(currentNode.RightChild, ref currentLevel, ref deepestLevel);
			}

			currentLevel--;
		}

		/// <summary>
		/// Returns the array representation of the values using in-order traversal
		/// 0, 1, 2, 3, 4, 5, 6
		/// </summary>
		/// <returns></returns>
		public T[] ToArray()
		{
			if (RootNode == null)
			{
				T[] empty = new T[0];
				return empty;
			}
			T[] result = new T[Count];
			int arrayPosition = 0;
			Node<T> currentNode = RootNode;

			GoLeft(currentNode, ref result, ref arrayPosition);
			result[arrayPosition++] = currentNode.Data;
			GoRight(currentNode, ref result, ref arrayPosition);

			return result;
		}

		public void GoLeft(Node<T> currentNode, ref T[] result, ref int arrayPosition)
		{
			currentNode = currentNode.LeftChild;

			if (currentNode.LeftChild != null)
			{
				GoLeft(currentNode, ref result, ref arrayPosition);
			}

			result[arrayPosition++] = currentNode.Data;

			if (currentNode.RightChild != null)
			{
				GoRight(currentNode, ref result, ref arrayPosition);
			}
		}

		public void GoRight(Node<T> currentNode, ref T[] result, ref int arrayPosition)
		{
			currentNode = currentNode.RightChild;

			if (currentNode.LeftChild != null)
			{
				GoLeft(currentNode, ref result, ref arrayPosition);
			}

			result[arrayPosition++] = currentNode.Data;

			if (currentNode.RightChild != null)
			{
				GoRight(currentNode, ref result, ref arrayPosition);
			}
		}

		/// <summary>
		/// Returns an in-order string representation of all the values in the BST(Left, Root, Right)
		/// 0, 1, 2, 3, 4, 5, 6
		/// </summary>
		/// <returns></returns>
		public string InOrder()
		{
			T[] values = ToArray();
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < Count; i++)
			{
				if (i != Count - 1)
				{
					result.Append(values[i] + ", ");
				}
				else
				{
					result.Append(values[i]);
				}
			}
			return result.ToString();
		}

		/// <summary>
		/// Returns a pre-order string representation of all the values in the BST(Left, Root, Right)
		/// 3, 1, 0, 2, 5, 4, 6
		/// </summary>
		/// <returns></returns>
		public string PreOrder()
		{
			// Start at the root node, referred to as 'currentNode'
			// Save the data in currentNode to the stringbuilder, 'result'
			// While currentNode has children, preform this backtracking recursive logic
			// {
			// If there is a left child node, currentNode = left child node
			// Save data in currentNode to result
			// repeat while logic (check for children)

			// If there is a right child node, if so, currentNode = right child node
			// Save data in currentNode to result
			// repeat while logic (check for children)
			// }

			if (RootNode == null)
			{
				return "";
			}

			Node<T> currentNode = RootNode;
			StringBuilder result = new StringBuilder();

			PreOrder_CheckChildren(currentNode, ref result);

			// Removes the extra ', ' at the end of the StringBuilder
			result.Length -= 2;

			return result.ToString();
		}

		public void PreOrder_CheckChildren(Node<T> currentNode, ref StringBuilder result)
		{
			result.Append(currentNode.Data + ", ");

			PreOrder_CheckLeftChild(currentNode, ref result);
			PreOrder_CheckRightChild(currentNode, ref result);
		}

		public void PreOrder_CheckLeftChild(Node<T> currentNode, ref StringBuilder result)
		{
			if (currentNode.LeftChild != null)
			{
				PreOrder_CheckChildren(currentNode.LeftChild, ref result);
			}
		}

		public void PreOrder_CheckRightChild(Node<T> currentNode, ref StringBuilder result)
		{
			if (currentNode.RightChild != null)
			{
				PreOrder_CheckChildren(currentNode.RightChild, ref result);
			}
		}

		/// <summary>
		/// Returns a post-order string representation of all the values in the BST(Left, Right, Root)
		/// 0, 2, 1, 4, 6, 5, 3
		/// </summary>
		/// <returns></returns>
		public string PostOrder()
		{
			if (RootNode == null)
			{
				return "";
			}

			Node<T> currentNode = RootNode;
			StringBuilder result = new StringBuilder();

			PostOrder_CheckChildren(currentNode, ref result);

			// Removes the extra ', ' at the end of the StringBuilder
			result.Length -= 2;

			return result.ToString();
		}

		public void PostOrder_CheckChildren(Node<T> currentNode, ref StringBuilder result)
		{
			PostOrder_CheckLeftChild(currentNode, ref result);
			PostOrder_CheckRightChild(currentNode, ref result);

			result.Append(currentNode.Data + ", ");
		}

		public void PostOrder_CheckLeftChild(Node<T> currentNode, ref StringBuilder result)
		{
			if (currentNode.LeftChild != null)
			{
				PostOrder_CheckChildren(currentNode.LeftChild, ref result);
			}
		}

		public void PostOrder_CheckRightChild(Node<T> currentNode, ref StringBuilder result)
		{
			if (currentNode.RightChild != null)
			{
				PostOrder_CheckChildren(currentNode.RightChild, ref result);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_II.Stack
{
	[TestClass]
	public class StackTests
	{
		[TestMethod]
		public void Stack_GetHappyPath()
		{
			int[] arr = { 5, 4, 3, 2, 1 };
			Stack<int> input = new Stack<int>(arr);

			int actual = input.Get(2);
			int expected = 3;

			Assert.AreEqual(actual, expected);
		}
	}
}

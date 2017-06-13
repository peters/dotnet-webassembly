﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebAssembly.Instructions
{
	/// <summary>
	/// Tests the <see cref="Int64NotEqual"/> instruction.
	/// </summary>
	[TestClass]
	public class Int64NotEqualTests
	{
		/// <summary>
		/// Tests compilation and execution of the <see cref="Int64NotEqual"/> instruction.
		/// </summary>
		[TestMethod]
		public void Int64NotEqual_Compiled()
		{
			var exports = ComparisonTestBase<long>.CreateInstance(
				new GetLocal(0),
				new GetLocal(1),
				new Int64NotEqual(),
				new End());

			var values = Samples.Int64;

			foreach (var comparand in values)
			{
				foreach (var value in values)
					Assert.AreEqual(comparand != value, exports.Test(comparand, value) != 0);

				foreach (var value in values)
					Assert.AreEqual(value != comparand, exports.Test(value, comparand) != 0);
			}
		}
	}
}
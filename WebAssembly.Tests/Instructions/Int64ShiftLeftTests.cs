﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebAssembly.Instructions
{
    /// <summary>
    /// Tests the <see cref="Int64ShiftLeft"/> instruction.
    /// </summary>
    [TestClass]
    public class Int64ShiftLeftTests
    {
        /// <summary>
        /// Tests compilation and execution of the <see cref="Int64ShiftLeft"/> instruction.
        /// </summary>
        [TestMethod]
        public void Int64ShiftLeft_Compiled()
        {
            if (!System.Environment.Is64BitProcess)
                Assert.Inconclusive("32-bit .NET doesn't support 64-bit bit shift amounts.");

            const int amount = 0xF;

            var exports = CompilerTestBase<long>.CreateInstance(
                new LocalGet(0),
                new Int64Constant(amount),
                new Int64ShiftLeft(),
                new End());

            foreach (var value in new long[] { 0x00, 0x01, 0x02, 0x0F, 0xF0, 0xFF, })
                Assert.AreEqual(value << amount, exports.Test(value));
        }
    }
}
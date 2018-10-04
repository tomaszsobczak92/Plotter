using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plotter.Infrastructures;
using System;
using System.Drawing;

namespace Plotter.Tests
{
    [TestClass]
    public class ColorManagerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Color index is out of array")]
        public void GetColor21ShuldThrowException()
        {
            ColorManager.GetColor(21);
        }

        [TestMethod]
        public void GetColor0ShuldReturnColorBlack()
        {
            var result = ColorManager.GetColor(0);
            Assert.AreEqual(Color.Black, result);
        }

    }
}

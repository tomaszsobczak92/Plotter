using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plotter.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotter.Tests
{
    [TestClass]
    public class PixelTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Pixel properties X have to be between 0 and 1")]
        public void CreatingPixelWithXGreaterThan1ShuldThrowException()
        {
            Pixel pixel = new Pixel((decimal)1.1, 1, Color.Black); 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Pixel properties Y have to be between 0 and 1")]
        public void CreatingPixelWithYGreaterThan1ShuldThrowException()
        {
            Pixel pixel = new Pixel(1, (decimal)1.1, Color.Black);
        }

    }
}

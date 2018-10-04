using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plotter.Infrastructures;
using Plotter.Controls;

namespace Plotter.Tests
{
    [TestClass]
    public class DrawingAreaTests
    {
        [TestMethod]
        public void SetDrawingSpeedAt5ShouldReturnAs200msDelay()

        {
            Requests requests = new Requests();
            DrawingAreaControl dac = new DrawingAreaControl(requests);

            dac.SetDrawingDelay(5);

            int result = dac.Delay;

            Assert.AreEqual(200, result);

        }
    }
}

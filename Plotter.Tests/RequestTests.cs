using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plotter.Infrastructures;
using Plotter.Models;
using System.Drawing;

namespace Plotter.Tests
{
    [TestClass]
    public class RequestTests
    {
        [TestMethod]
        public void AddingPixelToRequestShouldAddPixelToRequest()
        {
            Pixel pixel = new Pixel(1, 1, Color.Black); 
            Requests requests = new Requests();

            int before = requests.GetCapacity();
            requests.Add(pixel);
            int after = requests.GetCapacity();

            var result = after - before;

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TakingPixelFromRequestShouldRemovePixelFromRequest()
        {
            Pixel pixel = new Pixel(1, 1, Color.Black);
            Requests requests = new Requests();
            requests.Add(pixel);

            int before = requests.GetCapacity();
            var pixelTake = requests.Take();
            int after = requests.GetCapacity();

            var result = after - before;

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void EmptyRequestListShouldReturnFalseForIsReadyForTake()
        {
            Requests requests = new Requests();
            var result = requests.IsReadyToTake();
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ClearMethodShouldDeleteAllRecordsInRequests()
        {
            Pixel pixel = new Pixel(1, 1, Color.Black);
            Requests requests = new Requests();
  
            for(int i = 0; i < 5; i++)
            {
                requests.Add(pixel);
            }
            
            requests.Clear();
            int result = requests.GetCapacity();

            Assert.AreEqual(0, result);
        }
    }
}

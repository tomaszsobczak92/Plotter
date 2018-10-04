using Plotter.Interfaces;
using Plotter.Models;
using System.Collections.Concurrent;

namespace Plotter.Infrastructures
{
    public class Requests : IRequests
    {
        public ConcurrentQueue<Pixel> RequestList;

        public bool IsReadyToTake()
        {
            return !RequestList.IsEmpty;
        }

        public int GetCapacity()
        {
            return RequestList.Count;
        }

        public Requests()
        {
            RequestList = new ConcurrentQueue<Pixel>();
        }

        public void Add(Pixel pixel)
        {
            RequestList.Enqueue(pixel);
        }

        public Pixel Take()
        {
            RequestList.TryDequeue(out Pixel pixel);
            return pixel;
        }

        public void Clear()
        {
            while (RequestList.TryDequeue(out Pixel pixel))
            {
                // do nothing
            }
        }
    }
}

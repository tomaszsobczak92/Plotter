using Plotter.Models;

namespace Plotter.Interfaces
{
    public interface IRequests
    {
        bool IsReadyToTake();
        int GetCapacity();
        void Add(Pixel pixel);
        Pixel Take();
        void Clear();
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Plotter.Interfaces
{
    public interface IThreadManager
    {
        Color GetThreadColor(Thread thread);
        void CreateThread(Action action);
        void StartAll();
        void StopAll();
    }
}

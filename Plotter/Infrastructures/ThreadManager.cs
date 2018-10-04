using Plotter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace Plotter.Infrastructures
{
    public class ThreadManager : IThreadManager
    {
        private Dictionary<Thread, Color> threadList = new Dictionary<Thread, Color>();

        public void CreateThread(Action action)
        {
            Thread thread = new Thread(new ThreadStart(action));
            Color color = ColorManager.GetColor(threadList.Count());
            thread.IsBackground = true;
            threadList.Add(thread, color);
        }

        public void StartAll()
        {
            foreach(var thread in threadList.Keys)
            {
                if(!thread.IsAlive)
                    thread.Start();
            }
        }

        public void StopAll()
        {
            foreach (var thread in threadList.Keys)
            {
                thread.Abort();
            }
            threadList.Clear();
        }

        public Color GetThreadColor(Thread thread)
        {
            return threadList[thread];
        }
    }
}

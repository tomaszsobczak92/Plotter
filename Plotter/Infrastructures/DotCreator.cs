using Ninject;
using Plotter.Infrastructures;
using Plotter.Interfaces;
using Plotter.Models;
using System;
using System.Drawing;
using System.Reflection;
using System.Threading;

namespace Plotter.Infrastructures
{
    public class DotCreator
    {
        private IThreadManager _threadManager;
        private IRequests _requests;
        private Random _random;

        public DotCreator(IRequests requests)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var threadManager = kernel.Get<IThreadManager>();

            _threadManager = threadManager;
            _requests = requests;
            _random = new Random();
        }

        public void StartCreator(int threads)
        {
            _threadManager.StopAll();

            for(int i = 0; i < threads; i++)
            {
                _threadManager.CreateThread(CreateDot);
            }

            _threadManager.StartAll();
        }

        public void StopCreator()
        {
            _threadManager.StopAll(); 
        }
        
        private void CreateDot()
        {
            Color color = _threadManager.GetThreadColor(Thread.CurrentThread);

            while (true)
            {
                if (_requests.GetCapacity() >= 500)
                {
                    Thread.Sleep(100);
                    continue;
                }

                var random = new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));
                var data = random.Value.NextDouble();

                decimal x = (decimal)random.Value.NextDouble(); ;
                decimal y = (decimal)random.Value.NextDouble();
                Pixel pixel = new Pixel(x, y, color);
                _requests.Add(pixel);
                Thread.Sleep(100);
            }
        }
    }
}

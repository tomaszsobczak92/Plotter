using Ninject;
using Plotter.Infrastructures;
using Plotter.Interfaces;
using Plotter.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Plotter.Controls
{
    public partial class DrawingAreaControl : UserControl
    {
        IRequests _requests;
        private int _windowX;
        private int _windowY;
        private Bitmap _bitmap;
        private List<Pixel> _listPixel = new List<Pixel>();
        private IThreadManager _threadManager;
        public int Delay;

        public DrawingAreaControl(IRequests requests)
        {
            InitializeComponent();
            _requests = requests;
            _windowX = drawingArea.Width;
            _windowY = drawingArea.Height;
            _bitmap = new Bitmap(_windowX, _windowY);

            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var threadManager = kernel.Get<IThreadManager>();
            _threadManager = threadManager;
        }

        public void SetDrawingDelay(int delay)
        {
            var drawingDelay = 1000 / delay;
            this.Delay = drawingDelay;
        }

        public void StartDrawing()
        {
            _threadManager.CreateThread(DoWorker);
            _threadManager.StartAll();
        }

        public void PauseDrawing()
        {
            _threadManager.StopAll();
        }

        public void DoWorker()
        {
            while(true)
            {
                if (!_requests.IsReadyToTake())
                    continue;

                Pixel newPixel = _requests.Take();
                PaintPixel(newPixel);
                _listPixel.Add(newPixel);
                Thread.Sleep(Delay);
           }
        }

        public void Restart()
        {
            ClearArea();
            _listPixel.Clear();
        }

        private void PaintPixel(Pixel pixel)
        {
            try
            {
                int x = RoundTwoNumbersToInt(pixel.X, _windowX);
                int y = RoundTwoNumbersToInt(pixel.Y, _windowY);
                
                Brush brush = new SolidBrush(pixel.Color);
                Graphics graphics = Graphics.FromImage(_bitmap);
                graphics.FillRectangle(brush, x, y, 5, 5);
                             
                drawingArea.Image = _bitmap;
            }
            catch(Exception ex)
            {
                Debugger.Log(1, "PaintPixel", ex.Message);
            }
        }

        private int RoundTwoNumbersToInt(decimal d1, int i)
        {
            return (int)Math.Round(d1 * (decimal)i, 0);
        }

       private void ForResizeChangedEvent(object sender, EventArgs e)
        {
            _windowX = drawingArea.Width;
            _windowY = drawingArea.Height;

            ClearArea();
            RedrawArea();
        }

        private void ClearArea()
        {
            if (_windowX == 0 || _windowY == 0)
                return;
            _bitmap = new Bitmap(_windowX, _windowY);
            drawingArea.Image = _bitmap;
        }

        private void RedrawArea()
        {
            PauseDrawing();

            foreach (Pixel pixel in _listPixel)
            {
                PaintPixel(pixel);
            }

            StartDrawing();
        }
    }
}

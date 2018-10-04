using Plotter.Infrastructures;
using Plotter.Interfaces;
using System;
using System.Windows.Forms;

namespace Plotter.Forms
{
    public partial class MainForm : Form
    {
        private IRequests _request;
        private DotCreator _dotCreator;

        public MainForm(IRequests requests)
        {
            _request = requests;
            _dotCreator = new DotCreator(_request);

            InitializeComponent(_request);
            CenterToScreen();
            SetStyle(ControlStyles.ResizeRedraw, true);
            BeforeStartHit();
        }

        private void BeforeStartHit()
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnReset.Enabled = false;
            numDrawingSpeed.Enabled = true;
            numNumberOfThreads.Enabled = true;
        }

        private void AfterStartHit()
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnReset.Enabled = true;
            numDrawingSpeed.Enabled = false;
            numNumberOfThreads.Enabled = false;
        }

        private void AfterStopHit()
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnReset.Enabled = true;
            numDrawingSpeed.Enabled = true;
            numNumberOfThreads.Enabled = false;
        }

        private void BtnStart_Click(object sender, System.EventArgs e)
        {
            var numberOfThreat = (int)numNumberOfThreads.Value;
            var drawingSpeed = (int)numDrawingSpeed.Value;

            AfterStartHit();
            _dotCreator.StartCreator(numberOfThreat);
            drawingAreaControl1.SetDrawingDelay(drawingSpeed);
            drawingAreaControl1.StartDrawing();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            drawingAreaControl1.PauseDrawing();
            AfterStopHit();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            drawingAreaControl1.PauseDrawing();
            drawingAreaControl1.Restart();
            _dotCreator.StopCreator();
            _request.Clear();
            BeforeStartHit();
            numNumberOfThreads.Value = 1;
            numDrawingSpeed.Value = 1;
        }
    }
}

using Ninject;
using Plotter.Forms;
using Plotter.Interfaces;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Plotter
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var requests = kernel.Get<IRequests>();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new MainForm(requests));
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred. We are sorry! Details: " + ex.Message);
            }
        }
    }
}

using Ninject.Modules;
using Plotter.Infrastructures;
using Plotter.Interfaces;

public class Bindings : NinjectModule
{
    public override void Load()
    {
        Bind<IRequests>().To<Requests>();
        Bind<IThreadManager>().To<ThreadManager>();
    }
}
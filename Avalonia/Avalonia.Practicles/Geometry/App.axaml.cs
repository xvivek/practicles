using Avalonia;
using Geometry.ViewModels;
using Geometry.Views;
using ModuleA;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;

namespace Geometry;

public partial class App : PrismApplication
{
    //public override void Initialize()
    //{
    //    AvaloniaXamlLoader.Load(this);
    //}

    //public override void OnFrameworkInitializationCompleted()
    //{
    //    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    //    {
    //        desktop.MainWindow = new MainWindow
    //        {
    //            DataContext = new MainViewModel()
    //        };
    //    }
    //    else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
    //    {
    //        singleViewPlatform.MainView = new MainView
    //        {
    //            DataContext = new MainViewModel()
    //        };
    //    }

    //    base.OnFrameworkInitializationCompleted();
    //}

    protected override AvaloniaObject CreateShell()
    {
        var w = Container.Resolve<Shell>();

        return w;
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<Services.ICustomerStore, Services.DbCustomerStore>();

        containerRegistry.RegisterForNavigation<MainView, MainViewModel>();       
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        moduleCatalog.AddModule<ModuleAModule>();
    }
}

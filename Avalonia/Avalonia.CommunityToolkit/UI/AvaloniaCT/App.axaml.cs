using Avalonia;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;

using AvaloniaCT.ViewModels;
using Microsoft.Extensions.Logging;
using Splat;

using CTDialog.ViewModels;
using ReactiveUI;
using System.ComponentModel;
using Avalonia.Controls.ApplicationLifetimes;
using AvaloniaCT.Views;
using AvaloniaWebView;

namespace AvaloniaCT;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);


        var build = Locator.CurrentMutable;
        var loggerFactory = LoggerFactory.Create(builder => builder.AddFilter(logLevel => true).AddDebug());
    }
    public override void RegisterServices()
    {
        base.RegisterServices();

        AvaloniaWebViewBuilder.Initialize(default);
    }
    public override void OnFrameworkInitializationCompleted()
    {
        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindowView
            {
                DataContext = new MainWindowViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new  MainViewModel()
            };
        }

        //DialogService.Show(null, MainWindow);
        base.OnFrameworkInitializationCompleted();
        
        //Locator.CurrentMutable.InitializeSplat();
        //Locator.CurrentMutable.InitializeReactiveUI();
    }    
}

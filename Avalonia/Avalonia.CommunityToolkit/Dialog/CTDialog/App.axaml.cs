using System;
using Avalonia;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Logging;
using Splat;
using CTDialog.ViewModels;
using CTDialog.Views;
using Avalonia.Controls.ApplicationLifetimes;
using AvaloniaCT.ViewModels;

namespace CTDialog;
public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);       
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new WCView
            {
                DataContext = new WCViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new UCView
            {
                DataContext = new UCViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }   
}

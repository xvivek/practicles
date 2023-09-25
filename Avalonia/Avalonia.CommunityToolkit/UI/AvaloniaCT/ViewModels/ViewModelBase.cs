using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System;

namespace AvaloniaCT.ViewModels;

public class ViewModelBase : ReactiveObject
{
}

public class ViewModelBase2 : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected string GetAssemblyResource(string name)
    {
        using (var stream = AssetLoader.Open(new Uri(name)))
        using (StreamReader reader = new StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }

    protected bool RaiseAndSetIfChanged<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
    {
        if (!EqualityComparer<T>.Default.Equals(field, value))
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
        return false;
    }

    protected void RaisePropertyChanged(string propName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}

public class MainPageViewModelBase : ViewModelBase2
{
    public string NavHeader { get; set; }

    public string IconKey { get; set; }

    public bool ShowsInFooter { get; set; }
}
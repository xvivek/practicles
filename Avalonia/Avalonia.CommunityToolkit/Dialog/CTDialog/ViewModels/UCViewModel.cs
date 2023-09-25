using ReactiveUI;
using Splat;
using System;
using System.Windows.Input;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Logging;
using Avalonia.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using AvaloniaCT.ViewModels;
using System.ComponentModel;
using System.Reactive.Linq;
using Avalonia.Controls;

namespace CTDialog.ViewModels;

public partial class UCViewModel : ViewModelBase
{
    private Window _parentWindow;

    public Window ParentWindow
    {
        get => _parentWindow;
        set => this.RaiseAndSetIfChanged(ref _parentWindow, value);
    }


    public UCViewModel()
    {
        ShowDialog = new Interaction<DialogWindowViewModel, UCViewModel?>();

        OkCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var store = new DialogWindowViewModel();

            var result = await ShowDialog.Handle(store);
        });       
    }

    public ICommand OkCommand { get; }

    public Interaction<DialogWindowViewModel, UCViewModel?> ShowDialog { get; }

}

﻿using System;
using System.Windows.Input;
using Avalonia.Threading;
using HanumanInstitute.MvvmDialogs;
using ReactiveUI;

namespace Demo.Avalonia.ModalDialog;

public class AddTextDialogViewModel : ViewModelBase, IModalDialogViewModel, ICloseable
{
    private string _text = string.Empty;
    private bool? _dialogResult;
    public ICommand OkCommand { get; private set; }
    public event EventHandler? RequestClose;

    public AddTextDialogViewModel()
    {
      //  Dispatcher.UIThread.Invoke(() => { OkCommand = ReactiveCommand.Create(Ok); });        
    }

    public string Text
    {
        get => _text;
        set => this.RaiseAndSetIfChanged(ref _text, value, nameof(Text));
    }

    public bool? DialogResult
    {
        get => _dialogResult;
        set => this.RaiseAndSetIfChanged(ref _dialogResult, value, nameof(DialogResult));
    }

    private void Ok()
    {
        //if (!string.IsNullOrEmpty(Text))
        //{
        //    DialogResult = true;
        //    RequestClose?.Invoke(this, EventArgs.Empty);
        //}
    }

    public void Cancel()
    {
        //DialogResult = false;
        //RequestClose?.Invoke(this, EventArgs.Empty);
    }
}

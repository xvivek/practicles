using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using CTDialog.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace CTDialog.Views;

public partial class UCView : ReactiveUserControl<UCViewModel>
{
    public UCView()
    {
        InitializeComponent();

        this.WhenActivated(d => {
            if (ViewModel == null)
            {
                var ViewModel = this.DataContext as UCViewModel;
                if(ViewModel == null)
                {
                    ViewModel = new UCViewModel();
                    this.DataContext = ViewModel;
                }
            }              
            d(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync));
        });
    }

    private async Task DoShowDialogAsync(InteractionContext<DialogWindowViewModel, UCViewModel?> interaction)
    {
        var dialog = new DialogWindowView();
        dialog.DataContext = interaction.Input;
        Window Parent = null;

        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            Parent = desktop.MainWindow;
        }
      
        var result = await dialog.ShowDialog<UCViewModel?>(Parent);

        interaction.SetOutput(result);
    }
}

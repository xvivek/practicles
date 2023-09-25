using Avalonia.Controls;
using Avalonia.ReactiveUI;
using AvaloniaCT.ViewModels;
using CTDialog.ViewModels;
using CTDialog.Views;
using ReactiveUI;
using System.Threading.Tasks;

namespace AvaloniaCT.Views;

public partial class MainWindowView : Window // ReactiveWindow<MainWindowViewModel>
{
    public MainWindowView()
    {
        InitializeComponent();

        //this.WhenActivated(d => d(ViewModel.ShowDialog.RegisterHandler(DoShowDialogAsync)));
    }

    //private async Task DoShowDialogAsync(InteractionContext<DialogWindowViewModel, UCViewModel?> interaction)
    //{
    //    var dialog = new DialogWindowView();
    //    dialog.DataContext = interaction.Input;

    //    var result = await dialog.ShowDialog<UCViewModel?>(this);
    //    interaction.SetOutput(result);
    //}
}

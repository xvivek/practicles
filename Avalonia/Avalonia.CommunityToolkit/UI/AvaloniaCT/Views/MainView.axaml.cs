using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using AvaloniaCT.ViewModels;
using CTDialog.ViewModels;
using CTDialog.Views;
using ReactiveUI;
using System.Threading.Tasks;

namespace AvaloniaCT.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();        
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        if (ucView.DataContext == null)
        {
            ucView.ViewModel = new UCViewModel();
            ucView.DataContext = ucView.ViewModel;
        }

       // ((UCViewModel)ucView.DataContext).ParentWindow = this.Parent as MainWindowView;
    }
}

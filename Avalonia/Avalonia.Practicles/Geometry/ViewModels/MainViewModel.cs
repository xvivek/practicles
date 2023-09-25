using Geometry.Services;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Geometry.ViewModels;

public class MainViewModel : BindableBase
{
    private Services.ICustomerStore _customerStore = null;

    public ObservableCollection<string> Customers { get; private set; } = new ObservableCollection<string>();

    public MainViewModel(ICustomerStore customerStore)
    {
        _customerStore = customerStore;
    }

    private string _selectedCustomer = null;
    public string SelectedCustomer
    {
        get => _selectedCustomer;
        set
        {
            if (SetProperty<string>(ref _selectedCustomer, value))
            {
                Debug.WriteLine(_selectedCustomer ?? "no customer selected");
            }
        }
    }

    private DelegateCommand _commandLoad = null;
    public DelegateCommand CommandLoad => _commandLoad ?? (_commandLoad = new DelegateCommand(CommandLoadExecute));

    private void CommandLoadExecute()
    {
        Customers.Clear();
        List<string> list = _customerStore.GetAll();
        foreach (string item in list)
            Customers.Add(item);
    }
}

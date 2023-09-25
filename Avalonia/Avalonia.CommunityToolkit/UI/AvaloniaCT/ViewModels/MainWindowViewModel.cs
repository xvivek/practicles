using CTDialog.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.Serialization.DataContracts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvaloniaCT.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {      
        public MainWindowViewModel()
        {
            //ShowDialog = new Interaction<DialogWindowViewModel, UCViewModel?>();

            //BuyMusicCommand = ReactiveCommand.CreateFromTask(async () =>
            //{
            //    var store = new DialogWindowViewModel();

            //    var result = await ShowDialog.Handle(store);               
            //});
        }


        //public ICommand BuyMusicCommand { get; }

        //public Interaction<DialogWindowViewModel, UCViewModel?> ShowDialog { get; }
    }
}

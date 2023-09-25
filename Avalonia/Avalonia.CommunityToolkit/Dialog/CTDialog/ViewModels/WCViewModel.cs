using CTDialog.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.DataContracts;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaCT.ViewModels
{
    public class WCViewModel : ViewModelBase
    {      
        UCViewModel mainVM;
        public UCViewModel MainVM
        {
            get => mainVM;
            set => this.RaiseAndSetIfChanged(ref mainVM, value, nameof(mainVM));
        }

        public WCViewModel()
        {
            MainVM = new UCViewModel();
        }
    }
}

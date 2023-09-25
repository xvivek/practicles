using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvaloniaCT.ViewModels
{
    public class PageBaseViewModel : ViewModelBase
    {
        public PageBaseViewModel()
        {
          //  InvokeCommand = new Command(PageInvoked);
        }

        public MainPageViewModelBase Parent { get; set; }

        public string Header { get; init; }

        public string Description { get; init; }

        public string IconResourceKey { get; init; }

        public string PageKey { get; init; }

        public string[] SearchKeywords { get; init; }

        public ICommand InvokeCommand { get; }

        private void PageInvoked(object param)
        {
           // NavigationService.Instance.NavigateFromContext(this);
        }
    }
}

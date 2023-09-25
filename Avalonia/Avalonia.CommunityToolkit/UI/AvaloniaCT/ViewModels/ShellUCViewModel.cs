using Avalonia.Collections;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaCT.ViewModels
{
    public class ShellUCViewModel: ViewModelBase2
    {

        public AvaloniaList<MainAppSearchItem> SearchTerms { get; } = new AvaloniaList<MainAppSearchItem>();

    }

    public class MainAppSearchItem
    {
        public MainAppSearchItem() { }

        public MainAppSearchItem(string pageHeader, Type pageType)
        {
            Header = pageHeader;
            PageType = pageType;
        }

        public string Header { get; set; }

        public PageBaseViewModel ViewModel { get; set; }

        public string Namespace { get; set; }

        public Type PageType { get; set; }
    }
}

using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class ShellModel : BindableBase
    {
        private string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                SetProperty(ref _Message, value);
            }
        }
    }
}

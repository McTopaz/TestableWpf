using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PropertyChanged;

using WpfApp.Misc;

namespace WpfApp.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class DialogWindowViewModel
    {
        string OrignalValue { get; set; }
        public string Value { get; set; }
        public RelayCommand OK { get; private set; }
        public RelayCommand Cancel { get; private set; }

        public DialogWindowViewModel(string value)
        {
            Value = value;
            OrignalValue = string.Copy(value);
            OK = new RelayCommand(OkCallback);
            Cancel = new RelayCommand(CancelCallback);
        }

        void OkCallback()
        {
        }

        void CancelCallback()
        {
            Value = OrignalValue;
        }
    }
}

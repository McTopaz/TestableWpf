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
    public class Window1ViewModel
    {
        public string Input { get; set; }
        public string Output { get; set; }
        public RelayCommand ButtonCommand { get; private set; }

        public Window1ViewModel()
        {
            ButtonCommand = new RelayCommand(TransferInputToOutput);
        }

        void TransferInputToOutput()
        {
            Output = Input;
        }
    }
}

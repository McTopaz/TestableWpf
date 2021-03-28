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
    public class MainWindowViewModel
    {
        public string Input { get; set; }
        public string Output { get; set; }
        public RelayCommand ButtonCommand { get; private set; }

        public MainWindowViewModel()
        {
            ButtonCommand = new RelayCommand(TransferInputToOutput);
        }

        void TransferInputToOutput()
        {
            Output = Input;
        }
    }
}

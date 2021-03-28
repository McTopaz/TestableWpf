using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PropertyChanged;

namespace WpfApp.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ComboBoxViewModel
    {
        public List<string> Fruits { get; set; } = new List<string>();
        public string Fruit { get; set; }
    }
}

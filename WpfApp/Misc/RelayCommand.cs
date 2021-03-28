using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp.Misc
{
    public class RelayCommand : ICommand
    {
        public Action MethodToExecute { get; private set; }
        Func<bool> CanExecuteEvaluator { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public RelayCommand(Action methodToExecute) : this(methodToExecute, null)
        {
        }

        public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
        {
            this.MethodToExecute = methodToExecute;
            this.CanExecuteEvaluator = canExecuteEvaluator;
        }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteEvaluator is null)
            {
                return true;
            }
            else
            {
                return CanExecuteEvaluator.Invoke();
            }
        }

        public void Execute(object parameter)
        {
            MethodToExecute.Invoke();
        }
    }
}

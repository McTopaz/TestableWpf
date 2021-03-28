using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TestableWpf.Extensions
{
    public static class ButtonExtension
    {
        public static void ClickWithEvent(this Button button)
        {
            var clickEvent = System.Windows.Controls.Primitives.ButtonBase.ClickEvent;
            var routedEventArgs = new RoutedEventArgs(clickEvent);
            button.RaiseEvent(routedEventArgs);
        }

        public static void ClickWithCommand(this Button button, object parameter = null)
        {
            parameter = parameter is null ? button.CommandParameter : parameter;
            button.Command.Execute(parameter);
        }
    }
}

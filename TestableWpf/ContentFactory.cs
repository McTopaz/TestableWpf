using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TestableWpf
{
    public class ContentFactory
    {
        static T CreateContent<T>() where T : DependencyObject
        {
            var type = typeof(T);
            var content = Activator.CreateInstance(type);
            return content as T;
        }

        public static T CreateWindow<T>() where T : Window
        {
            return CreateContent<T>();
        }

        public static Window CreateUserControl<T>() where T : UserControl
        {
            var uc = CreateContent<T>();
            var host = new Window();
            host.Content = uc;
            return host;
        }
    }
}

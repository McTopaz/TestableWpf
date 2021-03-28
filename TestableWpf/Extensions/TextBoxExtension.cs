using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestableWpf.Extensions
{
    public static class TextBoxExtension
    {
        public static void SendKeys(this TextBox textBox, string text)
        {
            var manager = InputManager.Current;
            var composition = new TextComposition(manager, textBox, text);
            TextCompositionManager.StartComposition(composition);
        }
    }
}

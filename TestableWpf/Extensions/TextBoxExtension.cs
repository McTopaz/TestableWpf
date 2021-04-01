using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestableWpf.Extensions
{
    /// <summary>
    /// Not used. Don't work as expected. If it worked as expected, it would waste time in tests.
    /// </summary>
    internal static class TextBoxExtension
    {
        public static void SendKeys(this TextBox textBox, string text)
        {
            var manager = InputManager.Current;
            var composition = new TextComposition(manager, textBox, text);
            TextCompositionManager.StartComposition(composition);
        }
    }
}

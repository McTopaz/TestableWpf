using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using System.Windows.Controls;

using TestableWpf;
using TestableWpf.Extensions;

using WpfApp.Views;

namespace TestProject
{
    [TestClass]
    public class Window1Tests
    {
        [TestMethod]
        public void Window1_Input_Equal_Output()
        {
            var host = ContentFactory.CreateWindow<Window1>();
            host.Show();

            var box = ControlFinder.FindByAutomationName<TextBox>(host, "aa");
            var button = ControlFinder.FindByName<Button>(host, "B");
            var block = ControlFinder.FindByAutomationId<TextBlock>(host, "dd");

            var input = "asdf";
            var expected = $"Output: {input}";

            box.SendKeys(input);
            button.ClickWithEvent();
            var result = block.Text;

            Assert.AreEqual(expected, result);
        }
    }
}

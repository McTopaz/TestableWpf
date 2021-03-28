using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Controls;

using TestableWpf;
using TestableWpf.Extensions;

using WpfApp;

namespace TestProject
{
    [TestClass]
    public class MainWindowTests
    {
        [TestMethod]
        public void MainWindow_Input_Equal_Output()
        {
            var window = ContentFactory.CreateWindow<MainWindow>();
            window.Show();

            var box = ControlFinder.FindByAutomationName<TextBox>(window, "aa");
            var button = ControlFinder.FindByName<Button>(window, "B");
            var block = ControlFinder.FindByAutomationId<TextBlock>(window, "dd");

            var input = "asdf";
            var expected = $"Output: {input}";

            box.Text = input;
            button.ClickWithEvent();
            var result = block.Text;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MainWindow_Input_NotEqual_Output()
        {
            var window = ContentFactory.CreateWindow<MainWindow>();
            window.Show();

            var box = ControlFinder.FindByAutomationName<TextBox>(window, "aa");
            var button = ControlFinder.FindByName<Button>(window, "C");
            var block = ControlFinder.FindByAutomationId<TextBlock>(window, "dd");

            var input = "asdf";
            var expected = "wasd";

            box.SendKeys(input);
            button.ClickWithCommand();
            var result = block.Text;

            Assert.AreNotEqual(expected, result);
        }
    }
}

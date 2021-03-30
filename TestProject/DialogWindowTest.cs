using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Windows.Controls;

using TestableWpf;
using TestableWpf.Extensions;

using WpfApp.Views;
using WpfApp.ViewModels;

namespace TestProject
{
    [TestClass]
    public class DialogWindowTest
    {
        [TestMethod]
        public void DialogWindow_EnterReverseValuePressOk_ReadReverseValue()
        {
            var def = "default";
            var reverse = string.Join("", def.Reverse());
            var vm = new DialogWindowViewModel("default");
            var window = ContentFactory.CreateWindow<DialogWindow>();

            window.DataContext = vm;
            window.Show();

            var value = ControlFinder.FindByAutomationId<TextBox>(window, "Value");
            var ok = ControlFinder.FindByAutomationId<Button>(window, "OK");

            value.Text = reverse;
            ok.ClickWithCommand();

            Assert.AreEqual(reverse, vm.Value);
        }

        [TestMethod]
        public void DialogWindow_EnterReverseValuePressCancel_ReadDefaultValue()
        {
            var def = "default";
            var reverse = string.Join("", def.Reverse());
            var vm = new DialogWindowViewModel("default");
            var window = ContentFactory.CreateWindow<DialogWindow>();

            window.DataContext = vm;
            window.Show();

            var value = ControlFinder.FindByAutomationId<TextBox>(window, "Value");
            var cancel = ControlFinder.FindByAutomationId<Button>(window, "Cancel");

            value.Text = reverse;
            cancel.ClickWithCommand();

            Assert.AreEqual(def, vm.Value);
        }
    }
}

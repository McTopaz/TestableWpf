using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

using TestableWpf;

using WpfApp.Views;
using WpfApp.ViewModels;

namespace TestProject
{
    [TestClass]
    public class ComboBoxTests
    {
        [TestMethod]
        public void ComboBoxWindow_SetFruitByIndex_ReadFruitInTextBlock()
        {
            var window = ContentFactory.CreateWindow<ComboBoxWindow>();
            var vm = new ComboBoxViewModel();

            vm.Fruits = new List<string> { "Banana", "Pear", "Lemon", "Apple" };
            window.DataContext = vm;
            window.Show();

            var cmbFruits = ControlFinder.FindByAutomationId<ComboBox>(window, "Fruits");
            var txtFruit = ControlFinder.FindByAutomationId<TextBlock>(window, "Fruit");

            var index = 1;
            cmbFruits.SelectedIndex = index;
            var expected = vm.Fruits[index];
            var result = txtFruit.Text;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ComboBoxWindow_SetRandomFruitInViewModel_ReadFromSelectedItemAndTextBlock()
        {
            var window = ContentFactory.CreateWindow<ComboBoxWindow>();
            var vm = new ComboBoxViewModel();

            vm.Fruits = new List<string> { "Banana", "Pear", "Lemon", "Apple" };
            window.DataContext = vm;
            window.Show();

            var cmbFruits = ControlFinder.FindByAutomationId<ComboBox>(window, "Fruits");
            var txtFruit = ControlFinder.FindByAutomationId<TextBlock>(window, "Fruit");

            var index = new Random().Next(0, vm.Fruits.Count);
            var fruit = vm.Fruits[index];
            vm.Fruit = fruit;
            var result1 = cmbFruits.SelectedItem as string;
            var result2 = txtFruit.Text;

            Assert.AreEqual(fruit, result1);
            Assert.AreEqual(fruit, result2);
        }
    }
}

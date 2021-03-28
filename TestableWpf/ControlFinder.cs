using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Automation;

namespace TestableWpf
{
    public static class ControlFinder
    {
        public static T FindByAutomationId<T>(DependencyObject parent, string id) where T : DependencyObject
        {
            VerifyArguments(parent, id);
            var control = RecursivelyFindControlByAutomationMethod<T>(parent, id, AutomationProperties.GetAutomationId);

            if (control is null)
            {
                var msg = $"Unable to find control with AutomationId = '{id}'";
                throw new NullReferenceException(msg);
            }

            return control;
        }

        public static T FindByAutomationName<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            VerifyArguments(parent, name);
            var control = RecursivelyFindControlByAutomationMethod<T>(parent, name, AutomationProperties.GetName);

            if (control is null)
            {
                var msg = $"Unable to find control with AutomationName = '{name}'";
                throw new NullReferenceException(msg);
            }

            return control;
        }

        public static T FindByName<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            VerifyArguments(parent, name);
            var control = RecursivelyFindControlByName<T>(parent, name);

            if (control is null)
            {
                var msg = $"Unable to find control with control's name = '{name}'";
                throw new NullReferenceException(msg);
            }

            return control;
        }

        static void VerifyArguments(DependencyObject parent, string pattern)
        {
            if (parent is null)
            {
                var msg = $"Parent of control cannot be null";
                throw new ArgumentNullException(msg);
            }

            if (string.IsNullOrWhiteSpace(pattern))
            {
                var msg = $"There must be a pattern specified to find the control";
                throw new ArgumentException(msg);
            }
        }

        static T RecursivelyFindControlByAutomationMethod<T>(DependencyObject parent, string pattern, Func<DependencyObject, string> method) where T : DependencyObject
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);
            T found = null;

            for (var i = 0; i < count; i++)
            {
                var control = VisualTreeHelper.GetChild(parent, i);
                var isOfTypeT = control as T is T;

                if (isOfTypeT)
                {
                    var id = method(control);
                    var hasId = !string.IsNullOrWhiteSpace(id);

                    if (hasId && id == pattern)
                    {
                        found = control as T;
                    }
                }
                else
                {
                    control = RecursivelyFindControlByAutomationMethod<T>(control, pattern, method);

                    if (control != null)
                    {
                        found = control as T;
                    }
                }
            }

            return found;
        }

        static T RecursivelyFindControlByName<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);
            T found = null;

            for (int i = 0; i < count; i++)
            {
                var control = VisualTreeHelper.GetChild(parent, i);
                var isOfTypeT = control as T is T;

                if (isOfTypeT && control is FrameworkElement element && element.Name == name)
                {
                    found = element as T;
                }
                else
                {
                    control = RecursivelyFindControlByName<T>(control, name);

                    if (control != null)
                    {
                        found = control as T;
                    }
                }
            }

            return found;
        }
    }
}

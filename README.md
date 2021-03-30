# TestableWpf

**Test WPF-code without need of any third party software.
Load your WPF-application's Windows and UserControls directly into your test project.
Implement and perform unit tests on the controls.
Read and write data by the use of the viewmodel or directely on the controls.**

### Goals
* Independent from third party solutions to handle all communication between the WPF-application and the tests. (e.g. WinAppDriver).
* Only one DLL to add into your test project.
* Your WPF-application can be started and debugged in Visual Studio.

### Usage
1) In your WPF-application.
 * Add necessary AutomationProperties reference. (see how-to beelow)
 * Make sure your WPF-application is compiled.

4) Acquire the TestableWpf DLL-file.
5) Add a Unit test project to your solution.

6) In your test project:
 * Add a reference to your WPF-application's project file.
 * Add a reference to the TestableWpf DLL-file.
 * Add references to necessary NET-Framework DLL files. (see list bellow)
 
7) Create as many unit test files you need.
   It's recommended one test file per control (Windows or UserControls) in your WPf.

8) In each unit test file:
 * Add necessary using statements. (see list bellow)

9) Implement the test you need for your WPF-application.

### Include AutomationProperties in your WPF-application
TestableWPF uses AutomationProperties to access your controls in your code.
You can use AutomationId or Name attributes from the AutomationProperties.
It's also possible to use the FrameworkElement.Name property to access the control.

```xaml
<Textbox AutomationProperties.AutomationId="textbox" />
<Button AutomationProperties.Name="button" />
<Label x:Name="Label" />
```

### Add NET-Framework DLL-files in your test project
As your test project will use controls common in a WPF-application, it's necessary to include these NET-Framework DLL-files.

 * PresentationCore
 * PresentationFramework
 * WindowsBase
 
### Add necessary using statement in your unit test files
Add these using statements.

```csharp
using System.Windows;
using System.Windows.Controls;

using TestableWpf;
using TestableWpf.Extensions;
```

Add any using statements to your WPF-application as you need for the test you require.
You might have different specific folders for View and ViewModels.

```csharp
using <YourWpfApplication>;
using <YourWpfApplication>.Views;
using <YourWpfApplication>.ViewModels;
```

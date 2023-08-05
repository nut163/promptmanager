```csharp
using System;
using System.Windows;

namespace PromptInstructionManagement
{
    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            MainWindow mainWindow = new MainWindow();
            app.Run(mainWindow);
        }
    }
}
```
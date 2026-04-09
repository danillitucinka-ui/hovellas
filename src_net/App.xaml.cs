using System.Windows;

namespace HovellasUI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Запуск C++ движка через P/Invoke или процесс
            // var mainWindow = new MainWindow();
            // mainWindow.Show();
        }
    }
}
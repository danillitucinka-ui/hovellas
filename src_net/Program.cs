using System;

namespace HovellasUI
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            var app = new System.Windows.Application();
            var window = new MainWindow();
            app.Run(window);
        }
    }
}
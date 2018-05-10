using System;
using Gtk;

namespace Interfaz
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            MainWindow win = new MainWindow();
            Controller controlador = new Controller(win);

            Application.Run();
        }
    }
}

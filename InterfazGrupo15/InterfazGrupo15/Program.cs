using System;
using Gtk;

namespace InterfazGrupo15
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            Main menu = new Main();
            Window2 win = new Window2(menu);
            win.Show();
            Application.Run();
        }
    }
}

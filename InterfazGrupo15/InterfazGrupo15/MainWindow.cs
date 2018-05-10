using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    Main menu = new Main();
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnButton5Clicked(object sender, EventArgs e)
    {
        
    }

}

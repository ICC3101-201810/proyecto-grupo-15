using System;
using Gtk;
using ProyectoGrupo15;
namespace Interfaz
{
    public partial class Window2 : Gtk.Window
    {
        // crear usuario
        String nombre, mail, telefono, clave, apodo;
        public Window2() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        protected void OnEntry1TextInserted(object o, Gtk.TextInsertedArgs args)
        {
            args = nombre;
        }

        protected void OnEntry11TextInserted(object o, Gtk.TextInsertedArgs args)
        {
            if (main.revisarapodo(args))
            {
                args = apodo;
            }
            else 
            {
                this.lblWindow2Text.Text = "el apodo ingresado ya existe no se puede crear el usuario";

            }

        }
    }
}

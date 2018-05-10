using System;
namespace InterfazGrupo15
{
    public partial class Window3 : Gtk.Window
    {
        Main metodos = new Main();
        public Window3() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        protected void OnButton11Clicked(object sender, EventArgs e)
        {
            String apodo = entry36.Text;
            String contraseña = entry37.Text;
            String tipo = combobox5.ActiveText;
            if (metodos.RevisarApodo(apodo))
            {
                Usuario usuario = metodos.GetAlumno(apodo);
                if (contraseña == usuario.Getcontraseña())
                {
                    if (tipo == "administrador")
                    {
                        // menu de adm
                    }
                    else
                    {
                        //menu de usuario
                    }
                }
                else
                {
                    String var = "Contraseña mal ingresada";
                    label41.Text = var;
                }

            }
            else
            {
                String var = "el apodo ingresado no existe por favor, ingrese uno nuevo";
                label41.Text = var;
            }
        }
    }
}

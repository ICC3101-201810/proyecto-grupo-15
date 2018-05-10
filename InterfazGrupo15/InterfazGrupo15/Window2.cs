using System;
using Gtk;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InterfazGrupo15
{
    public partial class Window2 : Gtk.Window
    {
        Main metodos; 
        public Window2(Main main) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            metodos = main;
        }

        protected void OnButton7Clicked(object sender, EventArgs e) //crear usuario
        {
            String nombre = entry21.Text;
            String apodo = entry23.Text;
            String telefono = entry25.Text;
            String Contraseña = entry28.Text;
            String mail = entry30.Text;
            String tipo = combobox3.ActiveText;
            String cc = entry32.Text;
            if (metodos.RevisarApodo(apodo))
            {
                if(metodos.RevisarMail(mail))
                {
                    if (metodos.CrearUsuario(nombre, apodo, telefono, mail, Contraseña, tipo, cc))
                    {
                        // escribir que se ha creado con exito
                        String var = "Usuario creado con exito";
                        label29.Text = var;
                    }
                    else
                    {
                        // escribir que se ha ingresado mal el tipo
                        String var = "tipo de usuario mal ingresado";
                        label29.Text = var;
                    }
                }
                else
                {
                    String var = "ya existe el mail, por favor ingrese uno nuevo";
                    label29.Text = var;
                }
            }
            else
            {
                String var = "ya existe el apodo, por favor ingrese uno nuevo";
                label29.Text = var;
            }



        }
    }
}

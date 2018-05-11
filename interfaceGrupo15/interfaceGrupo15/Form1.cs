using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaceGrupo15
{
	public partial class Form1 : Form
	{
		Main metodos = new Main();
		public Form1()
		{
		
			InitializeComponent();
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.BringToFront();
			//this.Refresh();

		}
		private void button1_Click(object sender, EventArgs e)
		{
			panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			panel3.BringToFront();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			panel2.BringToFront();

		}

		private void button3_Click(object sender, EventArgs e) //salir
		{
			Application.Exit();
		}

		private void button4_Click(object sender, EventArgs e) //crear usuario
		{
			String nombre = textBox1.Text;
			String apodo = textBox2.Text;
			String telefono = textBox3.Text;
			String Contraseña = textBox4.Text;
			String mail = textBox5.Text;
			String tipo = comboBox1.Text;
			String cc = textBox6.Text;
			if (metodos.RevisarApodo(apodo))
			{
				if (metodos.RevisarMail(mail))
				{
					if (metodos.CrearUsuario(nombre, apodo, telefono, mail, Contraseña, tipo, cc))
					{
						// escribir que se ha creado con exito
						String var = "Usuario creado con exito";
						label9.Text = var;
					}
					else
					{
						// escribir que se ha ingresado mal el tipo
						String var = "tipo de usuario mal ingresado";
						label9.Text = var;
					}
				}
				else
				{
					String var = "ya existe el mail, por favor ingrese uno nuevo";
					label9.Text = var;
				}
			}
			else
			{
				String var = "ya existe el apodo, por favor ingrese uno nuevo";
				label9.Text = var;
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			textBox1.Clear();
			textBox2.Clear();
			textBox3.Clear();
			textBox4.Clear();
			textBox5.Clear();
			textBox6.Clear();
            label9.Text = "";
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.BringToFront();
		}

		private void button6_Click(object sender, EventArgs e) //ingresar
		{
			String apodo = textBox7.Text;
			String contraseña = textBox8.Text;
			String tipo = comboBox2.Text;
			if ((apodo == null) | (contraseña == null))
			{
				String var = "Apodo o Contraseña sin texto";
				label14.Text = var;
				label14.Text = var;
			}
			else if (metodos.RevisarApodo(apodo) == false)
			{
				if (metodos.EntregarUsuario(apodo) == null)
				{
					String var = "El usuario no existe";
					label14.Text = var;
				}
				else
				{
					Usuario usuario = metodos.EntregarUsuario(apodo);
					if (contraseña == usuario.Getcontraseña())
					{
						if (tipo == "administrador")
						{
							// menu de adm
							panel10.Dock = System.Windows.Forms.DockStyle.Fill;
							panel10.BringToFront();
						}
						else
						{
							//menu de usuario
							panel4.Dock = System.Windows.Forms.DockStyle.Fill;
							panel4.BringToFront();
						}
					}
					else
					{
						String var = "Contraseña mal ingresada";
						label14.Text = var;
					}
				}

				

			}
			else
			{
				String var = "el apodo ingresado no existe por favor, ingrese uno nuevo";
				label14.Text = var;
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
            textBox7.Clear();
            textBox8.Clear();
            label14.Text = "";
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.BringToFront();
		}

		private void button8_Click(object sender, EventArgs e) //Ver Perfil
		{
			String apodo = textBox7.Text;
			label17.Text = apodo;
			Usuario usuario = metodos.EntregarUsuario(apodo);
			label19.Text = usuario.CalcularPuntos().ToString();
			panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			panel5.BringToFront();
		}

		private void button9_Click(object sender, EventArgs e) //Crear Publicacion 
		{
			panel6.Dock = System.Windows.Forms.DockStyle.Fill;
			panel6.BringToFront();
		}

		private void button10_Click(object sender, EventArgs e) //ver Publicaciones
		{
			panel15.Dock = System.Windows.Forms.DockStyle.Fill;
			panel15.BringToFront();
		}

		private void button12_Click(object sender, EventArgs e) //salir de un perfil
		{
            textBox7.Clear();
            textBox8.Clear();
            label14.Text = "";
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.BringToFront();
		}

		private void button17_Click(object sender, EventArgs e)
		{
			panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			panel4.BringToFront();
		}

	

		private void button13_Click(object sender, EventArgs e) //enviar notificacion a un usuario en perfil
		{
			panel7.Dock = System.Windows.Forms.DockStyle.Fill;
			panel7.BringToFront();
		}

		private void button14_Click(object sender, EventArgs e) //calificar a otros usuario en perfil
		{
			panel8.Dock = System.Windows.Forms.DockStyle.Fill;
			panel8.BringToFront();
		}

		private void button15_Click(object sender, EventArgs e) // ver mis publicaciones en perfil
		{
			String apodo = textBox7.Text;
			Usuario usuario = metodos.EntregarUsuario(apodo);
			foreach (Publicacion p in usuario.GetListaPublicaciones())
			{
				this.comboBox7.Items.Add(p.GetEncabezado());
			}
			textBox18.Text = "";
			panel14.Dock = System.Windows.Forms.DockStyle.Fill;
			panel14.BringToFront();
		}

		private void button16_Click(object sender, EventArgs e) //eliminar una publicacion en perfil
		{
			String apodo = textBox7.Text;
			Usuario usuario = metodos.EntregarUsuario(apodo);
			foreach (Publicacion p in usuario.GetListaPublicaciones())
			{
				this.comboBox10.Items.Add(p.GetEncabezado());
			}
			panel9.Dock = System.Windows.Forms.DockStyle.Fill;
			panel9.BringToFront();
		}

		private void button19_Click(object sender, EventArgs e) // guardar publicacion
		{
			String apodo = textBox7.Text;
			String encabezado = textBox9.Text;
			String descripcion = textBox10.Text;
			String tipo = comboBox3.Text;
			String categoria = comboBox4.Text;
			if (metodos.CrearPublicacion(apodo, encabezado, descripcion, tipo, categoria))
			{
				label25.Text = "publicacion creada con exito";
			}
			
		}

		private void button18_Click(object sender, EventArgs e)
		{
            textBox9.Clear();
            textBox10.Clear();
            label25.Text = "";
            panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			panel4.BringToFront();
		}

		private void button21_Click(object sender, EventArgs e) // enviar notificacion
		{
			String apodoquiennotifica= textBox7.Text;
			Usuario usuarioManda = metodos.EntregarUsuario(apodoquiennotifica);
			String apodonotificado = textBox11.Text;
			String notificacion = textBox12.Text;
			if (metodos.RevisarApodo(apodonotificado))
			{
				label29.Text = "Apodo mal ingresado o no existe";
			}
			else
			{
				Usuario usuarionotificado = metodos.EntregarUsuario(apodonotificado);
				if (usuarionotificado.AgregarNotificacion(usuarioManda, notificacion) == "bien")
				{
					label29.Text = "Notificacion enviada";
				}
				else
				{
					label29.Text = "no se ha podido crear la notificacion";
				}
			}
		}

		private void button20_Click(object sender, EventArgs e)
		{
            textBox11.Clear();
            textBox12.Clear();
            label29.Text = "";
            panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			panel5.BringToFront();
		}

		private void button22_Click(object sender, EventArgs e) //asignar calificacion
		{
			String apodonotificado = textBox13.Text;
			String calificacion = comboBox5.Text;
			if (metodos.RevisarApodo(apodonotificado) == false)
			{
				Usuario usuariocalificar = metodos.EntregarUsuario(apodonotificado);
				if (metodos.AgregarCalificacion(usuariocalificar, calificacion))
				{
					label33.Text = "usuario calificado";
				}
				else
				{
					label33.Text = "no se ha podido calificar al usuario";
				}
			}
			else
			{
				label33.Text = "el usuario esta mal ingresado o no existe";
			}

		}

		private void button23_Click(object sender, EventArgs e)
		{
            textBox13.Clear();
            label33.Text = "";
            panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			panel5.BringToFront();
		}

		private void button24_Click(object sender, EventArgs e) //eliminando publicacion
		{
			String id_public = null;
			String encabezado = comboBox10.Text;
			String apodo = textBox7.Text;
			Usuario usuarioingresado = metodos.EntregarUsuario(apodo);
			foreach (Publicacion p in usuarioingresado.GetListaPublicaciones())
			{
				if (p.GetEncabezado() == encabezado)
				{
					id_public = p.GetId().ToString();
					break;
				}
				else
				{
					id_public = null;
				}
			}
			if (metodos.EliminarPublicacionUsuario(usuarioingresado, id_public))
			{
				label36.Text = "publicacion eliminada con exito";
			}
			else
			{
				label36.Text = "ID mal ingresado, no se ha podido eliminar la publicacion";
			}


		}

		private void button25_Click(object sender, EventArgs e)
		{
            label36.Text = "";
            panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			panel5.BringToFront();
		}

        private void button30_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.BringToFront();
        }

        private void button27_Click(object sender, EventArgs e) //eliminar publicacion administrador
        {
            panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            panel11.BringToFront();
        }

        private void button26_Click(object sender, EventArgs e) // ver publicaciones administrador
        {
			panel15.Dock = System.Windows.Forms.DockStyle.Fill;
			panel15.BringToFront();
		}

        private void button28_Click(object sender, EventArgs e) //eliminr usuario administrador
        {
            panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            panel12.BringToFront();
        }

        private void button29_Click(object sender, EventArgs e) // ver usuarios administrador 
        {
			panel16.Dock = System.Windows.Forms.DockStyle.Fill;
			panel16.BringToFront();
			foreach (Alumno a in metodos.GetListaAlumnos())
			{
				listBox3.Items.Add("Usuario: " + a.Getapodo());
				listBox3.Items.Add("Nombre: " + a.Getnombre());
				listBox3.Items.Add("Mail: " + a.Getmail());
				listBox3.Items.Add("Telefono: " + a.Gettelefono());
				listBox3.Items.Add("Calificacion: " + a.CalcularPuntos());
				listBox3.Items.Add("------------------------------------------");
			}
			foreach (Personal p in metodos.GetListaPersonal())
			{
				listBox3.Items.Add("Usuario: " + p.Getapodo());
				listBox3.Items.Add("Nombre: " + p.Getnombre());
				listBox3.Items.Add("Mail: " + p.Getmail());
				listBox3.Items.Add("Telefono: " + p.Gettelefono());
				listBox3.Items.Add("Calificacion: " + p.CalcularPuntos());
				listBox3.Items.Add("------------------------------------------");
			}
		}

        private void button31_Click(object sender, EventArgs e) //eliminado public
        {
            String id_public = textBox15.Text;
            if (metodos.EliminarCualquierPublicacion(id_public))
            {
                label40.Text = "publicacion eliminada con exito";
            }
            else
            {
                label40.Text = "ID de publicacion mal ingresado o no existe";
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            textBox15.Clear();
            label40.Text = "";
            panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            panel10.BringToFront();

        }

        private void button33_Click(object sender, EventArgs e) //elimino usuario
        {
            String apodoborrar = textBox16.Text;
            if (metodos.eliminarUsuario(apodoborrar))
            {
                label43.Text = "Usuario eliminado con exito";
            }
            else
            {
                label43.Text = "se ha ingresado mal el apodo del usuario o este no existe";
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            textBox16.Clear();
            label43.Text = "";
            panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            panel10.BringToFront();

        }


		private void button35_Click_1(object sender, EventArgs e) //ver notif
		{
			String apodousuario = textBox7.Text;
			String apodo = comboBox6.Text;
			Usuario usuario = metodos.EntregarUsuario(apodousuario);
			Usuario usuario1 = metodos.EntregarUsuario(apodo);

			listBox2.Items.Add("Mail del remitente: " + usuario1.Getmail());
			foreach (List<String> m in usuario.GetListaNotificaciones())
			{
				if (m[1] == apodo)
				{
					listBox2.Items.Add("Mensaje: " + m[0]);
				}
				else
				{
					continue;
				}

			}
		}

		private void button11_Click_1(object sender, EventArgs e) //ver mis notificaciones
		{
			String apodo = textBox7.Text;
			Usuario usuario = metodos.EntregarUsuario(apodo);
			foreach (List<String> p in usuario.GetListaNotificaciones())
			{
				if (comboBox6.Items.Contains(p[1]))
				{
					continue;
				}
				else
				{
					this.comboBox6.Items.Add(p[1]);
				}

			}
			panel13.Dock = System.Windows.Forms.DockStyle.Fill;
			panel13.BringToFront();
		}

		private void button36_Click(object sender, EventArgs e)
		{
			listBox2.Items.Clear();
			panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			panel5.BringToFront();
		}

		private void button37_Click(object sender, EventArgs e)
		{
			String encabezado = comboBox7.Text;
			String apodo = textBox7.Text;
			Usuario usuario = metodos.EntregarUsuario(apodo);
			foreach (Publicacion p in usuario.GetListaPublicaciones())
			{
				if (encabezado == p.GetEncabezado())
				{
					textBox18.Text = p.Getdescripcion();
				}
			}

		}

		private void button38_Click(object sender, EventArgs e)
		{
			textBox18.Text = "";
			listBox2.Items.Clear();
			panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			panel5.BringToFront();
		}

		private void button40_Click(object sender, EventArgs e)
		{
			listbox1.Items.Clear();
			panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			panel4.BringToFront();
		}

		private void button39_Click(object sender, EventArgs e) //mostrar publicaciones
		{
			if (comboBox8.Text == "encontrado")
			{
				foreach (Encontrado enc in metodos.Getlistaencontrado())
				{
					if (enc.GetCategoria() == comboBox9.Text)
					{
						listbox1.Items.Add("ID: " + enc.GetId());
						listbox1.Items.Add("Encabezado: " + enc.GetEncabezado());
						listbox1.Items.Add("Descripcion: " + enc.Getdescripcion());
						listbox1.Items.Add("Usuario: " + enc.GetApodo());
						listbox1.Items.Add("------------------------------------------------");
					}
				}
			}
			else if (comboBox8.Text == "perdido")
			{
				foreach (Perdido p in metodos.Getlistaperdido())
				{
					if (p.GetCategoria() == comboBox9.Text)
					{
						listbox1.Items.Add("ID: " + p.GetId());
						listbox1.Items.Add("Encabezado: " + p.GetEncabezado());
						listbox1.Items.Add("Descripcion: " + p.Getdescripcion());
						listbox1.Items.Add("Usuario: " + p.GetApodo());
						listbox1.Items.Add("------------------------------------------------");
					}
				}
			}
		}

		private void button41_Click(object sender, EventArgs e)
		{
			listBox3.Items.Clear();
			panel16.Dock = System.Windows.Forms.DockStyle.Fill;
			panel16.BringToFront();
		}
	}
}

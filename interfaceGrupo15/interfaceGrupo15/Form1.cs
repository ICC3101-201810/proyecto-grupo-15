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
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.BringToFront();
		}

		private void button6_Click(object sender, EventArgs e) //ingresar
		{
			String apodo = textBox7.Text;
			String contraseña = textBox8.Text;
			String tipo = comboBox2.Text;
			if (metodos.RevisarApodo(apodo))
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
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.BringToFront();
		}

		private void button8_Click(object sender, EventArgs e) //Ver Perfil
		{
			String apodo = textBox7.Text;
			label17.Text = apodo;
			Usuario usuario = metodos.EntregarUsuario(apodo);
			label18.Text = usuario.CalcularPuntos().ToString();
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
			
		}

		private void button12_Click(object sender, EventArgs e) //salir de un perfil
		{
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.BringToFront();
		}

		private void button17_Click(object sender, EventArgs e)
		{
			panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			panel4.BringToFront();
		}

		private void button11_Click(object sender, EventArgs e) //ver notificaciones en perfil
		{

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

		}

		private void button16_Click(object sender, EventArgs e) //eliminar una publicacion en perfil
		{
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
			panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			panel4.BringToFront();
		}

		private void button21_Click(object sender, EventArgs e) // enviar notificacion
		{
			String apodoquiennotifica= textBox7.Text;
			Usuario usuarioManda = metodos.EntregarUsuario(apodoquiennotifica);
			String apodonotificado = textBox11.Text;
			String notificacion = textBox12.Text;
			if (metodos.RevisarApodo(apodonotificado) == false)
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
			panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			panel5.BringToFront();
		}

		private void button22_Click(object sender, EventArgs e) //asignar calificacion
		{
			String apodonotificado = textBox13.Text;
			String calificacion = comboBox5.Text;
			if (metodos.RevisarApodo(apodonotificado))
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
			panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			panel5.BringToFront();
		}

		private void button24_Click(object sender, EventArgs e) //eliminando publicacion
		{
			String id_public = textBox14.Text;
			String apodo = textBox7.Text;
			Usuario usuarioingresado = metodos.EntregarUsuario(apodo);
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
			panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			panel5.BringToFront();
		}

		
	}
}

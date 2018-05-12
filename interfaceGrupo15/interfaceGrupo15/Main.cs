using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace interfaceGrupo15
{
	[Serializable]
	public class Main
	{
		List<Alumno> alumnos = new List<Alumno>();
		List<Personal> personals = new List<Personal>();
		List<Administrador> administradores = new List<Administrador>();
		List<Encontrado> encontradas = new List<Encontrado>();
		List<Perdido> perdidos = new List<Perdido>();
		int cuentaPublicaciones = 10;
		public Main()
		{
		}

		
		public void GenerarTXT()
		{
			String rutacompleta = @" D:\RegistroApp.txt";
			String texto = "APP objetos perdidos";
			using (StreamWriter mylogs = File.AppendText(rutacompleta))
			{
				DateTime datetime = new DateTime();
				datetime = DateTime.Now;
				String strDate = Convert.ToDateTime(datetime).ToString("yyMMdd");
				mylogs.WriteLine(texto + strDate);
				mylogs.Close();
			}
		}

		// revisar datos unicos
		public bool RevisarApodo(String apodo)
		{
			if (apodo == null)
			{
				return false;
			}
			foreach (Alumno alumno1 in alumnos)
			{
				if (alumno1.Getapodo() == apodo)
				{
					return false;
				}
			}
			foreach (Administrador administrador1 in administradores)
			{
				if (administrador1.Getapodo() == apodo)
				{
					return false;
				}
			}
			foreach (Personal personal1 in personals)
			{
				if (personal1.Getapodo() == apodo)
				{
					return false;
				}
			}
			return true;
		}

		public bool RevisarMail(String mail)
		{
			foreach (Alumno alumno1 in alumnos)
			{
				if (alumno1.Getmail() == mail)
				{
					return false;
				}
			}
			foreach (Administrador administrador1 in administradores)
			{
				if (administrador1.Getmail() == mail)
				{
					return false;
				}
			}
			foreach (Personal personal1 in personals)
			{
				if (personal1.Getmail() == mail)
				{
					return false;
				}
			}
			return true;
		}
		// guardar usuarios en listas
		public void guardarAlumno(Alumno alumno)
		{
			alumnos.Add(alumno);
		}
		public void guardarPersonal(Personal personal)
		{
			personals.Add(personal);
		}
		public void guardarAdministrador(Administrador administrador)
		{
			administradores.Add(administrador);
		}
		// guardar publicaciones
		public void guardarEncontrado(Encontrado encontrado, Usuario usuario)
		{
			encontradas.Add(encontrado);
			usuario.AgregarPublicacion(encontrado);

		}
		public void guardarPerdido(Perdido perdido, Usuario usuario)
		{
			perdidos.Add(perdido);
			usuario.AgregarPublicacion(perdido);

		}
		// get usuarios por apodo

		public Alumno GetAlumno(String apodo)
		{
			foreach (Alumno alumno1 in alumnos)
			{
				if (alumno1.Getapodo() == apodo)
				{
					return alumno1;
				}
			}
			return null;

		}
		public Personal GetPersonal(String apodo)
		{
			foreach (Personal personal1 in personals)
			{
				if (personal1.Getapodo() == apodo)
				{
					return personal1;
				}
			}
			return null;
		}
		public Administrador GetAdministrador(String apodo)
		{
			foreach (Administrador admin1 in administradores)
			{
				if (admin1.Getapodo() == apodo)
				{
					return admin1;
				}
			}
			return null;
		}
		// crear publicacion
		public bool CrearPublicacion(String apodo, String encabezado, String Comentario, String tipo, String categoria)
		{
			if (tipo == "perdido")
			{
				cuentaPublicaciones++;
				Perdido perdido = new Perdido(encabezado, Comentario, categoria, cuentaPublicaciones, apodo);
				//Publicacion publicacion1 = new Publicacion(encabezado, Comentario, cuentaPublicaciones, apodo);
				perdidos.Add(perdido);
				foreach (Alumno alumno in alumnos)
				{
					if (alumno.Getapodo() == apodo)
					{
						alumno.AgregarPublicacion(perdido);
					}
				}
				foreach (Personal personal in personals)
				{
					if (personal.Getapodo() == apodo)
					{
						personal.AgregarPublicacion(perdido);
					}
				}
				foreach (Administrador admin in administradores)
				{
					if (admin.Getapodo() == apodo)
					{
						admin.AgregarPublicacion(perdido);
					}
				}
				return true;
			}
			if (tipo == "encontrado")
			{
				cuentaPublicaciones++;
				Encontrado encontrado = new Encontrado(encabezado, Comentario, categoria, cuentaPublicaciones, apodo);
				//Publicacion publicacion1 = new Publicacion(encabezado, Comentario, cuentaPublicaciones);
				encontradas.Add(encontrado);
				foreach (Alumno alumno in alumnos)
				{
					if (alumno.Getapodo() == apodo)
					{
						alumno.AgregarPublicacion(encontrado); // preguntar ayudante si se puede poner encontrado y funciona solo con los atib de publicacion
					}
				}
				foreach (Personal personal in personals)
				{
					if (personal.Getapodo() == apodo)
					{
						personal.AgregarPublicacion(encontrado);
					}
				}
				foreach (Administrador admin in administradores)
				{
					if (admin.Getapodo() == apodo)
					{
						admin.AgregarPublicacion(encontrado);
					}
				}
				return true;
			}
			else
			{
				return false; // tipo mal ingresado
			}

		}
		// get de lista de objetos perdidos
		public List<Encontrado> Getlistaencontrado()
		{
			return encontradas;
		}
		public List<Perdido> Getlistaperdido()
		{
			return perdidos;
		}
		
		// mostrar informacion de un usuario creador de una publicacion
		
		//entrega el usuario a partir del apodo
		public Usuario EntregarUsuario(String apodo)
		{
			foreach (Alumno alumno in alumnos)
			{
				if (alumno.Getapodo() == apodo)
				{
					return alumno;
				}
			}
			foreach (Personal personal in personals)
			{
				if (personal.Getapodo() == apodo)
				{
					return personal;
				}
			}
			foreach (Administrador admin in administradores)
			{
				if (admin.Getapodo() == apodo)
				{
					return admin;
				}
			}
			return null;
		}
		//eliminar publicacion por usuario
		public bool EliminarPublicacionUsuario(Usuario usuario, string id)
		{
			try
			{
				int id1 = Convert.ToInt32(id);
				if (usuario.EntregarPublicacion(id1) == null)
				{
					return false;//a publicacion ingresada no existe

				}
				else
				{
					foreach (Encontrado encontrado in encontradas)
					{
						if (encontrado.GetId() == id1)
						{
							encontradas.Remove(encontrado);
							usuario.EliminarPublicacion(id1);
							break;
						}
						else
						{
							continue;
						}
					}
					foreach (Perdido perdido in perdidos)
					{
						if (perdido.GetId() == id1)
						{
							perdidos.Remove(perdido);
							usuario.EliminarPublicacion(id1);
							break;
						}
						else
						{ continue; }
					}
					return true; //Publicacion eliminada con exito
				}
			}
			catch
			{
				return false; //Id mal ingresado, ingrese solo un numero");

			}

		}
		// calificar a un usuario
		public bool AgregarCalificacion(Usuario usuario, String calificacion2)
		{
			try
			{
				int calificacion = Convert.ToInt32(calificacion2);
				if ((calificacion < 6) & (calificacion > 0))
				{
					usuario.AgregarCalificaion(calificacion);
					return true;//Calificado con exito
				}
				else
				{
					return false; //calificacion no valida, ingrese un numero entre el 1 y el 5"

				}

			}
			catch
			{
				return false;//Error, numero mal ingresado
			}
		}
		//eliminar cualquier publicacion
		public bool EliminarCualquierPublicacion(string id)
		{
			try
			{
				int i = 0;
				int id1 = Convert.ToInt32(id);
				foreach (Encontrado encontrado in encontradas)
				{
					if (encontrado.GetId() == id1)
					{
						foreach (Alumno alumno in alumnos)
						{
							if (alumno.Getapodo() == encontrado.GetApodo())
							{
								encontradas.Remove(encontrado);
								alumno.EliminarPublicacion(id1);
								//Se ha borrado la publicacion con exito
								i++;
								break;
							}
						}
						if (i > 0)
						{
							break;
						}
						foreach (Personal personal in personals)
						{
							if (personal.Getapodo() == encontrado.GetApodo())
							{
								encontradas.Remove(encontrado);
								personal.EliminarPublicacion(id1);
								//Se ha borrado la publicacion con exito");
								i++;
								break;
							}
						}
						if (i > 0)
						{
							break;
						}
						foreach (Administrador admin in administradores)
						{
							if (admin.Getapodo() == encontrado.GetApodo())
							{
								encontradas.Remove(encontrado);
								admin.EliminarPublicacion(id1);
								//Se ha borrado la publicacion con exito");
								i++;
								break;
							}
						}
						if (i > 0)
						{
							break;
						}
					}
				}
				foreach (Perdido perdido in perdidos)
				{
					if (perdido.GetId() == id1)
					{
						foreach (Alumno alumno in alumnos)
						{
							if (alumno.Getapodo() == perdido.GetApodo())
							{
								perdidos.Remove(perdido);
								alumno.EliminarPublicacion(id1);
								//Se ha borrado la publicacion con exito");
								i++;
								break;
							}
						}
						if (i > 0)
						{
							break;
						}
						foreach (Personal personal in personals)
						{
							if (personal.Getapodo() == perdido.GetApodo())
							{
								perdidos.Remove(perdido);
								personal.EliminarPublicacion(id1);
								//Se ha borrado la publicacion con exito");
								i++;
								break;
							}
						}
						if (i > 0)
						{
							break;
						}
						foreach (Administrador admin in administradores)
						{
							if (admin.Getapodo() == perdido.GetApodo())
							{
								perdidos.Remove(perdido);
								admin.EliminarPublicacion(id1);
								//Se ha borrado la publicacion con exito");
								i++;
								break;
							}
						}
						if (i > 0)
						{
							break;
						}
					}
				}
				return true; // Se ha borrado la publicacion con exito
			}
			catch
			{
				return false; //Error, Id mal ingresado
			}
		}
		//eliminar a un usuario
		public bool eliminarUsuario(string apodo)
		{
			if (RevisarApodo(apodo))
			{
				return false; //No exite el apodo
			}

			else
			{
				foreach (Alumno alumno in alumnos)
				{
					if (alumno.Getapodo() == apodo)
					{
						foreach (Encontrado enc in encontradas)
						{
							if (enc.GetApodo() == apodo)
							{
								encontradas.Remove(enc);
								break;
							}
						}
						foreach (Perdido per in perdidos)
						{
							if (per.GetApodo() == apodo)
							{
								perdidos.Remove(per);
								break;
							}
						}
						alumnos.Remove(alumno);
						//"Usuario eliminado con exito
						break;
					}
				}
				foreach (Personal personal in personals)
				{
					if (personal.Getapodo() == apodo)
					{
						foreach (Encontrado enc in encontradas)
						{
							if (enc.GetApodo() == apodo)
							{
								encontradas.Remove(enc);
								break;
							}
						}
						foreach (Perdido per in perdidos)
						{
							if (per.GetApodo() == apodo)
							{
								perdidos.Remove(per);
								break;
							}
						}
						personals.Remove(personal);
						// Usuario eliminado con exito
						break;
					}
				}
				return true; // Usuario eliminado con exito
			}
		}
		
		public bool CrearUsuario(String nombre, String apodo, String telefono, String mail, String contraseña, String tipo, String cc)
		{
			if (tipo == "alumno")
			{
				Alumno alumno = new Alumno(nombre, mail, apodo, telefono, contraseña, cc);
				guardarAlumno(alumno);
				return true;
			}

			else if (tipo == "personal")
			{
				Personal personal = new Personal(nombre, mail, apodo, telefono, contraseña, cc);
				guardarPersonal(personal);
				return true;

			}
			else
			{
				return false; //Tipo de usuario no existente
			}
		}
		public List<Alumno> GetListaAlumnos()
		{
			return alumnos;
		}
		public List<Personal> GetListaPersonal()
		{
			return personals;
		}
	}

}

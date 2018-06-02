using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaceGrupo15
{
	[Serializable]
	public class Usuario
	{

		String nombre, mail, apodo, telefono, clave;
		List<int> puntos = new List<int>();
		List<Publicacion> publicaciones = new List<Publicacion>();
		List<List<String>> notificaciones = new List<List<String>>();

		public Usuario(String minombre, String mimail, String miapodo, String mitelefono, String miclave)
		{
			nombre = minombre;
			mail = mimail;
			apodo = miapodo;
			telefono = mitelefono;
			clave = miclave;
		}

		public String Getapodo()
		{
			return apodo;
		}
		public String Getmail()
		{
			return mail;
		}
		public String Getcontraseña()
		{
			return clave;
		}
		public String Getnombre()
		{
			return nombre;
		}
		public String Gettelefono()
		{
			return telefono;
		}

		public int CalcularPuntos()
		{
			int i = 0;
			for (int j = 0; j < puntos.Count(); j++)
			{
				int calculo = puntos[j];
				i = i + calculo;
			}
			if (puntos.Count() == 0)
			{
				int calculofinal = 0;
				return calculofinal;
			}
			else
			{
				int calculofinal = i / puntos.Count();
				return calculofinal;
			}
		}
		public void AgregarPublicacion(Publicacion publicacion1)
		{
			publicaciones.Add(publicacion1);
		}
		
		
		public String AgregarNotificacion(Usuario usuario, String notificacion)
		{
			List<String> usuarioquelacrea = new List<string>();
			usuarioquelacrea.Add(notificacion);
			usuarioquelacrea.Add(usuario.Getapodo());
			usuarioquelacrea.Add(usuario.Getmail());
			notificaciones.Add(usuarioquelacrea);
			return "bien"; //Notificacion creada con exito
		}
		

		public bool EliminarNotificaciones(Usuario usuarionotifica)
		{
			if (notificaciones.Count() == 0)
			{
                return false;//No tiene notificaciones
			}
			else
			{
                int i = 0;
                foreach (List<string> p in notificaciones)
                {
                    if (p[1] == usuarionotifica.Getapodo())
                    {
                        break;
                    }
                    
                    i++;
                }
                notificaciones.RemoveAt(i);
                return true;
			}

		}

		public Publicacion EntregarPublicacion(int id)
		{
			foreach (Publicacion publicacion2 in publicaciones)
			{
				if (publicacion2.GetId() == id)
				{
					return publicacion2;
				}
			}
			return null;
		}
		public void EliminarPublicacion(int id)
		{
			foreach (Publicacion publicacion2 in publicaciones)
			{
				if (publicacion2.GetId() == id)
				{
					publicaciones.Remove(publicacion2);
					break;
				}

			}
		}


		public void AgregarCalificaion(int calificacion)
		{
			puntos.Add(calificacion);
		}

        public List<List<String>> GetListaNotificaciones()
        {
            return notificaciones;
        }
		public List<Publicacion> GetListaPublicaciones()
		{
			return publicaciones;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaceGrupo15
{
	public class Publicacion
	{
		String encabezado, comentario, apodo;
		int id;
		public Publicacion(String miEncabezado, String miComentario, int miId, String miapodo)
		{
			encabezado = miEncabezado;
			comentario = miComentario;
			apodo = miapodo;
			id = miId;
		}
		//REVISAR
		public virtual void MostrarPublicacion()
		{
			Console.WriteLine("ID: " + id);
			Console.WriteLine("Encabezado: " + encabezado);
			Console.WriteLine("Cometario: " + comentario);
		}
		public int GetId()
		{
			return id;
		}
		public String GetApodo()
		{
			return apodo;
		}





	}
}

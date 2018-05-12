using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaceGrupo15
{
	[Serializable]
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
		
		public int GetId()
		{
			return id;
		}
		public String GetApodo()
		{
			return apodo;
		}

		public String GetEncabezado()
		{
			return encabezado;
		}
		public String Getdescripcion()
		{
			return comentario;
		}




	}
}

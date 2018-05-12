﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaceGrupo15
{
	[Serializable]
	public class Perdido : Publicacion
	{
		String categoria;
		public Perdido(String encabezado, String comentario, String miCategoria, int id, String apodo)
			: base(encabezado, comentario, id, apodo)
		{
			categoria = miCategoria;
		}
		

		public String GetCategoria()
		{
			return categoria;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaceGrupo15
{
	public class Administrador : Usuario
	{
		public Administrador(String nombre, String mail, String apodo, String telefono, String clave)
			: base(nombre, mail, apodo, telefono, clave)
		{

		}
	}
}

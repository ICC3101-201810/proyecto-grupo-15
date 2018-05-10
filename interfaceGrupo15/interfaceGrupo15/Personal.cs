using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaceGrupo15
{
	public class Personal : Usuario
	{
		String cargo;
		public Personal(String nombre, String mail, String apodo, String telefono, String clave, String miCargo)
			: base(nombre, mail, apodo, telefono, clave)
		{
			cargo = miCargo;
		}
	}
}

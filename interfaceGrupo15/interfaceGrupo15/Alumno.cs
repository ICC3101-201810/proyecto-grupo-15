using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaceGrupo15
{
	public class Alumno : Usuario
	{
		String carrera;
		public Alumno(String nombre, String mail, String apodo, String telefono, String clave, String miCarrera)
			: base(nombre, mail, apodo, telefono, clave)
		{
			carrera = miCarrera;
		}
	}
}

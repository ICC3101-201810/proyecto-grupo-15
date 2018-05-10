using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazGrupo15
{
    public class Encontrado : Publicacion
    {
        String categoria;
        public Encontrado(String encabezado, String comentario, String miCategoria, int id, String apodo)
            : base(encabezado, comentario, id, apodo)
        {
            categoria = miCategoria;
        }
//REVISAR
        public override void MostrarPublicacion()
        {
            Console.WriteLine("Categoria: " + categoria);
            base.MostrarPublicacion();
        }

        public String GetCategoria()
        {
            return categoria;
        }
    }
}

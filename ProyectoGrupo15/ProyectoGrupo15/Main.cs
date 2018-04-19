using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoGrupo15
{
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

// para generar un archivo de texto se utilizaran los siguientes metodos
        public void GenerarTXT()
        {
            String rutacompleta = @" D:\registroapp.txt";
            String texto = "APP objetos perdidos";
            using (StreamWriter mylogs = File.AppendText(rutacompleta))
            {
                DateTime datetime = new DateTime();
                datetime = DateTime.Now;
                string strDate = Convert.ToDateTime(datetime).ToString("yyMMdd");
                mylogs.WriteLine(texto + strDate);
                mylogs.Close();
            }
        }

        public void AdicionarInfo(String texto)
        {
            string rutaCompleta = @" D:\registroapp.txt";
            using (StreamWriter file = new StreamWriter(rutaCompleta, true))
            {
                file.WriteLine(texto);
                file.Close();
            }
        }

// fin de metodos para TXT
// revisar datos unicos
        public bool RevisarApodo(String apodo)
        {
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
// gets
        public Alumno GetAlumno(String apodo)
        {
            foreach(Alumno alumno1 in alumnos)
            {
                if(alumno1.Getapodo()==apodo)
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
        public bool CrearPublicacion( List<String> categorias, String apodo)
        {
            Console.WriteLine("Ingrese el encabezado de la publicacion: ");
            String encabezado = Console.ReadLine();
            Console.WriteLine("Ingrese el comentario de la publicacion: ");
            String Comentario = Console.ReadLine();
            Console.WriteLine("Ingrese tipo de publicacion(perdido / encontrado: ");
            String tipo = Console.ReadLine();
            if (tipo == "perdido")
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Categorias: ");
                foreach (String categoria in categorias)
                {
                    Console.WriteLine(categoria);
                }
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Escriba la categoria a la cual pertenece su publicacion: ");
                String categ =  Console.ReadLine();
                cuentaPublicaciones++;
                Perdido perdido = new Perdido(encabezado, Comentario, categ, cuentaPublicaciones, apodo);
                //Publicacion publicacion1 = new Publicacion(encabezado, Comentario, cuentaPublicaciones, apodo);
                perdidos.Add(perdido);
                foreach(Alumno alumno in alumnos)
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
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Categorias: ");
                foreach (String categoria in categorias)
                {
                    Console.WriteLine(categoria);
                }
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Escriba la categoria a la cual pertenece su publicacion: ");
                String categ = Console.ReadLine();
                cuentaPublicaciones++;
                Encontrado encontrado = new Encontrado(encabezado, Comentario, categ, cuentaPublicaciones, apodo);
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
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Tipo mal ingresado");
                Console.ForegroundColor = ConsoleColor.Black;
                return false;
            }

        }
        public void VerPublicacionesEncontradas()
        {
            if (encontradas.Count() == 0)
            {
                Console.WriteLine("No exiten publicaciones de objetos encontrados");
            }
            else
            {
                foreach (Encontrado encontrado in encontradas)
                {
                    encontrado.MostrarPublicacion();
                }
            }

        }
        public void VerPublicacionesPerdidas()
        {
            if(perdidos.Count() == 0)
            {
                Console.WriteLine("No exiten publicaciones de objetos perdidos");
            }
            else
            {
                foreach (Perdido perdido in perdidos)
                {
                    perdido.MostrarPublicacion();
                }
            }

        }
        public void VerPublicacionesCategoriaP(String categoria)
        {
            if (perdidos.Count() == 0)
            {
                Console.WriteLine("No exiten publicaciones de objetos perdidos");
            }
            else
            {
                foreach (Perdido perdido in perdidos)
                {
                    if (perdido.GetCategoria() == categoria)
                    {
                        perdido.MostrarPublicacion();
                    }
                }
            }

        }

        public void VerPublicacionesCategoriaE(String categoria)
        {
            if (encontradas.Count() == 0)
            {
                Console.WriteLine("No exiten publicaciones de objetos encontrados");
            }
            else
            {
                foreach (Encontrado encontrado in encontradas)
                {
                    if (encontrado.GetCategoria() == categoria)
                    {
                        encontrado.MostrarPublicacion();
                    }

                } 
            }

        }
        public void mostrarInformacion(int id)
        {
            foreach(Encontrado pub in encontradas)
            {
                if(pub.GetId()==id)
                {
                    foreach (Alumno alumno in alumnos)
                    {
                        if (alumno.Getapodo() == pub.GetApodo())
                        {
                            alumno.MostrarContacto();
                            break;
                        }
                    }
                    foreach (Personal personal in personals)
                    {
                        if (personal.Getapodo() == pub.GetApodo())
                        {
                            personal.MostrarContacto();
                            break;
                        }
                    }
                    foreach (Administrador admin in administradores)
                    {
                        if (admin.Getapodo() == pub.GetApodo())
                        {
                            admin.MostrarContacto();
                            break;
                        }
                    }
                    break;
                }
            }
        }
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

        public void EliminarPublicacionUsuario(Usuario usuario)
        {
            Console.WriteLine("Ingrese el id de la publicacion que quiere eliminar");
            try
            {
                int id1 = Convert.ToInt32(Console.ReadLine());
                if (usuario.EntregarPublicacion(id1) == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("La publicacion ingresada no existe");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    foreach(Encontrado encontrado in encontradas)
                    {
                        if(encontrado.GetId()==id1)
                        {
                            encontradas.Remove(encontrado);
                            usuario.EliminarPublicacion(id1);
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Publicacion eliminada con exito");
                            Console.ForegroundColor = ConsoleColor.Black;
                            String texto1 = "Se ha eliminado una publicacion";
                            AdicionarInfo(texto1);
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    foreach(Perdido perdido in perdidos)
                    {
                        if (perdido.GetId() == id1)
                        {
                            perdidos.Remove(perdido);
                            usuario.EliminarPublicacion(id1);
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Publicacion eliminada con exito");
                            Console.ForegroundColor = ConsoleColor.Black;
                            String texto1 = "Se ha eliminado una publicacion";
                            AdicionarInfo(texto1);
                            break;
                        }
                        else
                        { continue; }
                    }
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Id mal ingresado, ingrese solo un numero");
                Console.ForegroundColor = ConsoleColor.Black;
            }

        }
// calificar
        public void AgregarCalificacion(Usuario usuario)
        {
            Console.WriteLine("Ingrese la calificacion que le asignara al usuario (1-5): ");
            try 
            {
               
                int calificacion = Convert.ToInt32(Console.ReadLine());
                if ((calificacion < 6) & (calificacion > 0))
                {
                    usuario.AgregarCalificaion(calificacion);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Se ha agregado una calificacion con exito");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("calificacion no valida, ingrese un numero entre el 1 y el 5");
                    Console.ForegroundColor = ConsoleColor.Black;
                }

            }
            catch 
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error, numero mal ingresado");
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }
        public void EliminarCualquierPublicacion()
        {
            Console.WriteLine("Ingrese el id de la publicacion que quiere eliminar");
            try
            {
                int i = 0;
                int id1 = Convert.ToInt32(Console.ReadLine());
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
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Se ha borrado la publicacion con exito");
                                Console.ForegroundColor = ConsoleColor.Black;
                                String texto3 = "Se ha eliminado una publicacion";
                                AdicionarInfo(texto3);
                                i++;
                                break;
                            }
                        }
                        if (i>0)
                        {
                            break;
                        }
                        foreach (Personal personal in personals)
                        {
                            if (personal.Getapodo() == encontrado.GetApodo())
                            {
                                encontradas.Remove(encontrado);
                                personal.EliminarPublicacion(id1);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Se ha borrado la publicacion con exito");
                                Console.ForegroundColor = ConsoleColor.Black;
                                String texto3 = "Se ha eliminado una publicacion";
                                AdicionarInfo(texto3);
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
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Se ha borrado la publicacion con exito");
                                Console.ForegroundColor = ConsoleColor.Black;
                                String texto3 = "Se ha eliminado una publicacion";
                                AdicionarInfo(texto3);
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
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Se ha borrado la publicacion con exito");
                                Console.ForegroundColor = ConsoleColor.Black;
                                String texto3 = "Se ha eliminado una publicacion";
                                AdicionarInfo(texto3);
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
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Se ha borrado la publicacion con exito");
                                Console.ForegroundColor = ConsoleColor.Black;
                                String texto3 = "Se ha eliminado una publicacion";
                                AdicionarInfo(texto3);
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
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Se ha borrado la publicacion con exito");
                                Console.ForegroundColor = ConsoleColor.Black;
                                String texto3 = "Se ha eliminado una publicacion";
                                AdicionarInfo(texto3);
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
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error, Id mal ingresado");
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }
        public void eliminarUsuario()
        {
            Console.WriteLine("Ingrese apodo del usuario que desea eliminar: ");
            String apodo = Console.ReadLine();
            if (RevisarApodo(apodo))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No exite el apodo");
                Console.ForegroundColor = ConsoleColor.Black;
            }

            else
            {
                foreach(Alumno alumno in alumnos)
                {
                    if(alumno.Getapodo()==apodo)
                    {
                        foreach(Encontrado enc in encontradas)
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
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Usuario eliminado con exito");
                        Console.ForegroundColor = ConsoleColor.Black;
                        String texto3 = "Se ha eliminado un usuario";
                        AdicionarInfo(texto3);
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
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Usuario eliminado con exito");
                        Console.ForegroundColor = ConsoleColor.Black;
                        String texto3 = "Se ha eliminado un usuario";
                        AdicionarInfo(texto3);
                        break;
                    }
                }
            }

        }
         
        public void verUsuario()
        {
            if (alumnos.Count() > 0)
            {
                Console.WriteLine("ALumnos:");
                foreach ( Alumno alumno3 in alumnos)
                {
                    alumno3.MostrarContacto();
                }
            }
            if (personals.Count() > 0)
            {
                Console.WriteLine("Personal:");
                foreach (Personal personal in personals)
                {
                    personal.MostrarContacto();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No hay usuarios que mostrar");
                Console.ForegroundColor = ConsoleColor.Black;
            }

        }
    }

}



   
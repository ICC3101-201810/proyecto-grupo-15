using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InterfazGrupo15
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
        public bool CrearPublicacion(List<String> categorias, String apodo, String encabezado, String Comentario, String tipo, String categoria)
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
        // ver publicaciones de objetos encontrados
        public bool VerPublicacionesEncontradas()
        {
            if (encontradas.Count() == 0)
            {
                return false; //No exiten publicaciones de objetos encontrados
            }
            else
            {
                foreach (Encontrado encontrado in encontradas)
                {
                    encontrado.MostrarPublicacion();
                }
                return true;
            }

        }
        // ver publicaciones de objetos perdidos
        public bool VerPublicacionesPerdidas()
        {
            if (perdidos.Count() == 0)
            {
                return false;//No exiten publicaciones de objetos perdidos
            }
            else
            {
                foreach (Perdido perdido in perdidos)
                {
                    perdido.MostrarPublicacion();
                }
                return true;
            }

        }
        // ver publicaciones de objetos perdidos por categoria
        public bool VerPublicacionesCategoriaP(String categoria)
        {
            if (perdidos.Count() == 0)
            {
                return false;//No exiten publicaciones de objetos perdidos
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
                return true;
            }

        }
        // ver publicaciones de objetos encontrados por categoria
        public bool VerPublicacionesCategoriaE(String categoria)
        {
            if (encontradas.Count() == 0)
            {
                return false;//No exiten publicaciones de objetos encontrados
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
                return true;
            }

        }
        // mostrar informacion de un usuario creador de una publicacion
        public void mostrarInformacion(int id)
        {
            foreach (Encontrado pub in encontradas)
            {
                if (pub.GetId() == id)
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
        public bool EliminarPublicacionUsuario(Usuario usuario, String id)
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
                            String texto1 = "Se ha eliminado una publicacion";
                            AdicionarInfo(texto1);
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
                            String texto1 = "Se ha eliminado una publicacion";
                            AdicionarInfo(texto1);
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
                            if (personal.Getapodo() == encontrado.GetApodo())
                            {
                                encontradas.Remove(encontrado);
                                personal.EliminarPublicacion(id1);
                                //Se ha borrado la publicacion con exito");
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
                                //Se ha borrado la publicacion con exito");
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
                                //Se ha borrado la publicacion con exito");
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
                                //Se ha borrado la publicacion con exito");
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
                                //Se ha borrado la publicacion con exito");
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
                        // Usuario eliminado con exito
                        String texto3 = "Se ha eliminado un usuario";
                        AdicionarInfo(texto3);
                        break;
                    }
                }
                return true; // Usuario eliminado con exito
            }
        }
        // ver todos los usuarios         
        public bool verUsuario()
        {
            if (alumnos.Count() > 0)
            {
                foreach (Alumno alumno3 in alumnos)
                {
                    alumno3.MostrarContacto();
                }
                return true;
            }
            if (personals.Count() > 0)
            {
                foreach (Personal personal in personals)
                {
                    personal.MostrarContacto();
                }
                return true;
            }
            else
            {
                return false; //No hay usuarios que mostrar
            }

        }

        public bool CrearUsuario(String nombre, String apodo, String telefono, String mail, String contraseña, String tipo, String cc)
        {
            if (tipo == "alumno")
            {
                Alumno alumno = new Alumno(nombre, mail, apodo, telefono, contraseña, cc);
                guardarAlumno(alumno);
                String texto = "Se ha creado un usuario. Apodo: " + apodo;
                AdicionarInfo(texto);
                return true;
            }

            if(tipo == "personal")
            {
                Personal personal = new Personal(nombre, mail, apodo, telefono, contraseña, cc);
                guardarPersonal(personal);
                String texto = "Se ha creado un usuario. Apodo: " + apodo;
                AdicionarInfo(texto);
                return true;
                     
            }
            else
            {
                return false; //Tipo de usuario no existente
            }
        }
    }

}

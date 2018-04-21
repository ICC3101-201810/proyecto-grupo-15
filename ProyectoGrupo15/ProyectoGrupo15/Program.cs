using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoGrupo15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Bienvenido a objetos perdidos !");
            Console.ForegroundColor = ConsoleColor.Black;
            Main main = new Main();
            Administrador admin = new Administrador("ernesto", "ejrios@miuandes.cl", "ejrios","9876543","1234");
            Administrador admin1 = new Administrador("nicolas", "naulloa@miuandes.cl", "nico", "9876234", "hola");
            Administrador admin2 = new Administrador("catalina", "cbsanchez@miuandes.cl", "cbsanchez", "9386543", "cata");
            main.guardarAdministrador(admin);
            main.guardarAdministrador(admin1);
            main.guardarAdministrador(admin2);
            Alumno alumno5 = new Alumno("matias", "matias@miuandes.cl", "mati", "9967399", "mati123", "ing");
            Alumno alumno6 = new Alumno("paulina", "paulina@miuandes.cl", "palu", "9529099", "paulina1", "ing");
            main.guardarAlumno(alumno5);
            main.guardarAlumno(alumno6);
            Personal personal1 = new Personal("rodrigo", "rodrigo@uandes.cl", "rodri", "234567", "0123456789", "director");
            Personal personal2 = new Personal("carla", "carla@uandes.cl", "carla23", "778899", "juan", "secretaria");
            main.guardarPersonal(personal1);
            main.guardarPersonal(personal2);
            Encontrado encontrado3 = new Encontrado("iphone4", "Encontre en el reloj un iphone4 con un fondo de pantalla con un perro", "Electronico",1, "mati");
            main.guardarEncontrado(encontrado3, alumno5);
            Encontrado encontrado5 = new Encontrado("botella de agua", "Encontre una botella de agua en la sala B24, la deje en porteria del edificio de biblioteca", "Otros", 3, "palu");
            main.guardarEncontrado(encontrado5, alumno6);
            Perdido perdido6 = new Perdido("cuaderno", "Se me perdio un cuaderno rosado, la ultima vez que lo vi fue en los ciruelos", "Utiles", 2, "carla23");
            main.guardarPerdido(perdido6, personal2);
            Perdido perdido7 = new Perdido("chaleco verde", "Se me perdio un chaleco vere, lo deje en el cafe de biblioteca", "Ropa", 4, "carla23");
            main.guardarPerdido(perdido7, personal2);
            List<String> categorias = new List<String>();
            categorias.Add("Electronica");
            categorias.Add("Ropa");
            categorias.Add("Documentos");
            categorias.Add("Utiles");
            categorias.Add("Otros");
            main.GenerarTXT();

            for (; ; )
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Ingrese una opcion:");
                Console.WriteLine("1. Crear un Usuario ");
                Console.WriteLine("2. Ingresar");
                Console.WriteLine("3. Cerrar programa");
                Console.ForegroundColor = ConsoleColor.Black;
                String desicion = Console.ReadLine();
// crear usuario
                if (desicion == "1")
                {
                    Console.WriteLine("Ingrese tipo de usuario que es (alumno o personal) ");
                    String tipo = Console.ReadLine();
// crear un alumno
                    if ( tipo == "alumno")
                    {
                        Console.WriteLine("Ingrese su nombre: ");
                        String nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese su telefono: ");
                        String telefono = Console.ReadLine();
                        Console.WriteLine("Ingrese su clave: ");
                        String clave = Console.ReadLine();
                        Console.WriteLine("Ingrese su carrera: ");
                        String carrera = Console.ReadLine();
                        while (true)
                        {
                            Console.WriteLine("Ingrese su mail: ");
                            String mail = Console.ReadLine();
                            if (main.RevisarMail(mail))
                            {
                                Console.WriteLine("Mail correcto ");
                                Console.WriteLine("Ingrese su apodo: ");
                                String apodo = Console.ReadLine();
                                if (main.RevisarApodo(apodo))
                                {
                                    Console.WriteLine("Apodo correcto ");
                                    Alumno alumno = new Alumno(nombre, mail, apodo, telefono, clave, carrera);
                                    main.guardarAlumno(alumno);
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("Usuario creado con exito.");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    String texto = "Se ha creado un usuario. Apodo: " + apodo ;
                                    main.AdicionarInfo(texto);
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("El apodo ingresado ya existe, ingrese uno nuevo.");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    continue;
                                }

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("El mail ingresado ya existe, ingrese uno nuevo.");
                                Console.ForegroundColor = ConsoleColor.Black;
                                continue;
                            }
                        }
                        continue;
                    }
// crear un personal
                    if(tipo == "personal")
                    {
                        Console.WriteLine("Ingrese su nombre: ");
                        String nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese su telefono: ");
                        String telefono = Console.ReadLine();
                        Console.WriteLine("Ingrese su clave: ");
                        String clave = Console.ReadLine();
                        Console.WriteLine("Ingrese su cargo: ");
                        String cargo = Console.ReadLine();
                        while (true)
                        {
                            Console.WriteLine("Ingrese su mail: ");
                            String mail = Console.ReadLine();
                            if (main.RevisarMail(mail))
                            {
                                Console.WriteLine("Mail correcto ");
                                Console.WriteLine("Ingrese su apodo: ");
                                String apodo = Console.ReadLine();
                                if (main.RevisarApodo(apodo))
                                {
                                    Console.WriteLine("Apodo correcto ");
                                    Personal personal = new Personal(nombre, mail, apodo, telefono, clave, cargo);
                                    main.guardarPersonal(personal);
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("Usuario creado con exito.");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    String texto = "Se ha creado un usuario. Apodo: " + apodo;
                                    main.AdicionarInfo(texto);
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("El apodo ingresado ya existe, ingrese uno nuevo.");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    continue;
                                }

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("El mail ingresado ya existe, ingrese uno nuevo.");
                                Console.ForegroundColor = ConsoleColor.Black;
                                continue;
                            }
                        }
                        continue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Tipo de usuario no existente");
                        Console.ForegroundColor = ConsoleColor.Black;
                        continue;
                    }


                }
//ingreso
                if ( desicion == "2")
                {
                    Console.WriteLine("Ingrese tipo de usuario (alumno, personal o admin): ");
                    String tipo = Console.ReadLine();
                    Console.WriteLine("Ingrese el apodo: ");
                    String apodo = Console.ReadLine();
// cuando es un alumno
                    if (tipo == "alumno")
                    {
                        if (main.RevisarApodo(apodo))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("No exite el apodo");
                            Console.ForegroundColor = ConsoleColor.Black;
                            continue;
                        }

                        else
                        {
                            if (main.GetAlumno(apodo)==null)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Nombre de usuario de tipo incorrecto");
                                Console.ForegroundColor = ConsoleColor.Black;
                                continue;
                            }
                            Alumno alumno = main.GetAlumno(apodo);
                            Console.WriteLine("ingrese la clave: ");
                            String clave = Console.ReadLine();
                            if (clave == alumno.Getcontraseña())
                            {
                                String texto = "Se ha ingresado a la aplicacion con el usuario, Apodo: " + apodo;
                                main.AdicionarInfo(texto);
//menu principal alumno
                                while (true)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.WriteLine("Menu:");
                                    Console.WriteLine("1. Ver mi perfil");
                                    Console.WriteLine("2. Crear publicacion");
                                    Console.WriteLine("3. Ver publicaciones");
                                    Console.WriteLine("4. Salir");
                                    Console.WriteLine("Ingrese una opcion: ");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    String opcion = Console.ReadLine();
//perfil alumno
                                    if (opcion == "1")
                                    {
                                        Console.WriteLine("Apodo: " + alumno.Getapodo());
                                        Console.WriteLine("Calificacion: " + alumno.CalcularPuntos());
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine("1. Ver mis notificaciones");
                                        Console.WriteLine("2. Enviar notificacion a un usuario");
                                        Console.WriteLine("3. Calificar a otro usuario");
                                        Console.WriteLine("4. Ver mis publicaciones");
                                        Console.WriteLine("5. Eliminar una publicacion"); // el usuario solo puede eliminar una publicacion de el.
                                        Console.WriteLine("6. Volver");
                                        Console.WriteLine("Ingrese una opcion");
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        String a = Console.ReadLine();
                                        if (a == "1")
                                        {
                                            alumno.verNotificaciones();
                                            Console.WriteLine("¿Quiere borra todas las notificiaciones existentes (si /no)?");
                                            String g = Console.ReadLine();
                                            if (g == "si")
                                            {
                                                alumno.EliminarNotificaciones();
                                                continue;
                                            }
                                            if (g == "no")
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("Opcion mal Ingresada");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                continue;
                                            }
                                        }
                                        if (a == "2") 
                                        {
                                            Console.WriteLine("Ingrese el apodo del usuario a quien quiere enviarle una notificacion");
                                            String apodonuevo = Console.ReadLine();
                                            Usuario usuario3 = main.EntregarUsuario(apodonuevo); 
                                            if (usuario3 == null)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("Usuario no encontrado");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                continue;
                                            }
                                            else
                                            {
                                                alumno.AgregarNotificacion(usuario3);
                                                String texto1 = "Se ha enviado una notificacion a un usuario";
                                                main.AdicionarInfo(texto1);
                                                continue;
                                            }

                                        }
                                        if (a == "3")
                                        {
                                            Console.WriteLine("Ingrese el apodo del usuario que quiere calificar");
                                            String apodonuevo = Console.ReadLine();
                                            Usuario usuario3 = main.EntregarUsuario(apodonuevo);
                                            if (usuario3 == null)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("Usuario no encontrado");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                continue;
                                            }
                                            else
                                            {
                                                main.AgregarCalificacion(usuario3);
                                                String texto1 = "Se ha calificado a un usuario";
                                                main.AdicionarInfo(texto1);
                                                continue;
                                            }

                                        }
                                        if (a == "4")
                                        {
                                            alumno.VerMisPublicaciones();
                                            continue;
                                        }
                                        if (a == "5")
                                        {
                                            Console.WriteLine("Solo puede eliminar publicaciones que usted haya creado");
                                            main.EliminarPublicacionUsuario(alumno);
                                            continue;
                                        }
                                        if (a == "6")
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine("Opcion no valida.");
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            continue;
                                        }
                                    }
//crear publicacion alumno
                                    if (opcion == "2")
                                    {
                                        if (main.CrearPublicacion(categorias, alumno.Getapodo()))
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine("La publicacion se ha creado con exito");
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            String texto3 = "Se ha creado una publicacion";
                                            main.AdicionarInfo(texto3);
                                            continue;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine("La publicacion no se ha podido crear");
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            continue; 
                                        }

                                    }
//ver publicaciones alumno
                                    if (opcion == "3")
                                    {
                                        while (true)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            Console.WriteLine("Ingrese una opcion (1, 2 o 3)");
                                            Console.WriteLine("1. Publicaciones de objetos encontrados");
                                            Console.WriteLine("2. Publicaciones de objetos perdidos");
                                            Console.WriteLine("3. Volver");
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            String b = Console.ReadLine();
                                            if (b == "1")
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.WriteLine("Ingrese una opcion (1, 2 o 3)");
                                                Console.WriteLine("1. Ver todas las publicaciones");
                                                Console.WriteLine("2. Ver por categoria");
                                                Console.WriteLine("3. Mostrar contacto de una publicacion");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                String c = Console.ReadLine();
                                                if (c == "1")
                                                {
                                                    main.VerPublicacionesEncontradas();
                                                    continue;
                                                }
                                                if (c == "2")
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.WriteLine("Categorias:");
                                                    foreach (String categoria in categorias)
                                                    {
                                                        Console.WriteLine(categoria);
                                                    }
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("Escriba la categoria que quiere ver");
                                                    String cate = Console.ReadLine();
                                                    if(categorias.Contains(cate))
                                                    {
                                                        main.VerPublicacionesCategoriaE(cate);
                                                        continue;

                                                    }
                                                    else
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("No existe categoria");
                                                        Console.ForegroundColor = ConsoleColor.Black;
                                                        continue;
                                                    }

                                                }
                                                if (c == "3")
                                                {
                                                    Console.WriteLine("Ingrese el id de la publicacion para mostrar contacto");
                                                    try
                                                    {
                                                        int id = Convert.ToInt32(Console.ReadLine());
                                                        main.mostrarInformacion(id);
                                                        continue;
                                                    }
                                                    catch
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("Error, numero mal ingresado");
                                                        Console.ForegroundColor = ConsoleColor.Black;
                                                    }
                                                    continue;

                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                                    Console.WriteLine("Opcion no valida");
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    continue;
                                                }
                                            }
                                            if (b == "2")
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.WriteLine("Ingrese una opcion (1 o 2)");
                                                Console.WriteLine("1. Ver todas las publicaciones");
                                                Console.WriteLine("2. Ver por categoria:");
                                                Console.WriteLine("3. Mostrar contacto de una publicacion");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                String c = Console.ReadLine();
                                                if (c == "1")
                                                {
                                                    main.VerPublicacionesPerdidas();
                                                    continue;
                                                }
                                                if (c == "2")
                                                {
                                                    foreach (String categoria in categorias)
                                                    {
                                                        Console.WriteLine(categoria);
                                                    }
                                                    Console.WriteLine("Escriba la categoria que quiere ver");
                                                    String cate = Console.ReadLine();
                                                    main.VerPublicacionesCategoriaP(cate);
                                                    continue;
                                                }
                                                if (c == "3")
                                                {
                                                    Console.WriteLine("Ingrese el id de la publicacion para mostrar contacto");
                                                    try
                                                    {
                                                        int id = Convert.ToInt32(Console.ReadLine());
                                                        main.mostrarInformacion(id);
                                                        continue;
                                                    }
                                                    catch
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("Error, numero mal ingresado");
                                                        Console.ForegroundColor = ConsoleColor.Black;
                                                    }
                                                    continue;

                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                                    Console.WriteLine("Opcion no valida");
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    continue;
                                                }
                                            }
                                            if(b == "3")
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("Opcion no valida");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                continue;
                                            }
                                        }
                                        continue;

                                    }
//volver menu principal
                                    if (opcion == "4")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Opcion no valida");
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        continue;
                                    }
                                }
                                continue;

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Contraseña Incorrecta");
                                Console.ForegroundColor = ConsoleColor.Black;
                                continue;
                            }
                        }
                    } 

// cuando es un personal
                    if (tipo == "personal")
                    {
                        if (main.RevisarApodo(apodo))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("No exite el apodo");
                            Console.ForegroundColor = ConsoleColor.Black;
                            continue;
                        }

                        else
                        {
                            if(main.GetPersonal(apodo)==null)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Nombre de usuario de tipo incorrecto");
                                Console.ForegroundColor = ConsoleColor.Black;
                                continue;
                            }
                            Personal personal = main.GetPersonal(apodo);
                            Console.WriteLine("ingrese la clave: ");
                            String clave = Console.ReadLine();
                            if (clave == personal.Getcontraseña())
                            {
                                String texto = "Se ha ingresado a la aplicacion con el usuario, Apodo: " + apodo;
                                main.AdicionarInfo(texto);
//menu principal
                                while (true)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.WriteLine("Menu:");
                                    Console.WriteLine("1. Ver mi perfil");
                                    Console.WriteLine("2. Crear publicacion");
                                    Console.WriteLine("3. Ver publicaciones");
                                    Console.WriteLine("4. Salir");
                                    Console.WriteLine("Ingrese una opcion: ");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    String opcion = Console.ReadLine();
//Perfil personal 
                                    if (opcion == "1")
                                    {
                                        Console.WriteLine("Apodo: " + personal.Getapodo());
                                        Console.WriteLine("Calificacion: " + personal.CalcularPuntos());
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine("1. Ver mis notificaciones");
                                        Console.WriteLine("2. Enviar notificacion a un usuario");
                                        Console.WriteLine("3. Calificar a otro usuario");
                                        Console.WriteLine("4. Ver mis publicaciones");
                                        Console.WriteLine("5. Eliminar una publicacion"); // el usuario solo puede eliminar una publicacion de el.
                                        Console.WriteLine("6. Volver");
                                        Console.WriteLine("Ingrese una opcion");
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        String a = Console.ReadLine();
                                        if (a == "1")
                                        {
                                            personal.verNotificaciones();
                                            Console.WriteLine("¿Quiere borra todas las notificiaciones existentes (si/no)?");
                                            String g = Console.ReadLine();
                                            if (g == "si")
                                            {
                                                personal.EliminarNotificaciones();
                                                continue;
                                            }
                                            if (g == "no")
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("Opcion mal Ingresada");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                continue;
                                            }
                                        }
                                        if (a == "2") // nuevoooo (revisar)
                                        {
                                            Console.WriteLine("Ingrese el apodo del usuario a quien quiere enviarle una notificacion");
                                            String apodonuevo = Console.ReadLine();
                                            Usuario usuario3 = main.EntregarUsuario(apodonuevo);
                                            if (usuario3 == null)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("Usuario no encontrado");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                continue;
                                            }
                                            else
                                            {
                                                personal.AgregarNotificacion(usuario3);
                                                String texto1 = "Se ha enviado una notificacion a un usuario";
                                                main.AdicionarInfo(texto1);
                                                continue;
                                            }

                                        }
                                        if (a == "3")
                                        {
                                            Console.WriteLine("Ingrese el apodo del usuario que quiere calificar");
                                            String apodonuevo = Console.ReadLine();
                                            Usuario usuario3 = main.EntregarUsuario(apodonuevo);
                                            if (usuario3 == null)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("Usuario no encontrado");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                continue;
                                            }
                                            else
                                            {
                                                main.AgregarCalificacion(usuario3);
                                                String texto1 = "Se ha calificado a un usuario";
                                                main.AdicionarInfo(texto1);
                                                continue;
                                            }

                                        }
                                        if (a == "4")
                                        {
                                            personal.VerMisPublicaciones();
                                            continue;
                                        }
                                        if (a == "5")
                                        {
                                            Console.WriteLine("Solo puede eliminar publicaciones que usted haya creado");
                                            main.EliminarPublicacionUsuario(personal);
                                            continue;
                                        }
                                        if (a == "6")
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine("Opcion no valida.");
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            continue;
                                        }
                                    }
//crear publicacion personal
                                    if (opcion == "2")
                                    {
                                        if (main.CrearPublicacion(categorias, personal.Getapodo()))
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine("La publicacion se ha creado con exito");
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            String texto3 = "Se ha creado una publicacion";
                                            main.AdicionarInfo(texto3);
                                            continue;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine("La publicacion no se ha podido crear");
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            continue;
                                        }

                                    }
// ver publicaciones
                                    if (opcion == "3")
                                    {
                                        while (true)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            Console.WriteLine("Ingrese una opcion (1, 2 o 3)");
                                            Console.WriteLine("1. Publicaciones de objetos encontrados");
                                            Console.WriteLine("2. Publicaciones de objetos perdidos");
                                            Console.WriteLine("3. Volver");
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            String b = Console.ReadLine();
                                            if (b == "1")
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.WriteLine("Ingrese una opcion (1, 2 o 3)");
                                                Console.WriteLine("1. Ver todas las publicaciones");
                                                Console.WriteLine("2. Ver por categoria");
                                                Console.WriteLine("3. Mostrar contacto de una publicacion");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                String c = Console.ReadLine();
                                                if (c == "1")
                                                {
                                                    main.VerPublicacionesEncontradas();
                                                    continue;
                                                }
                                                if (c == "2")
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.WriteLine("Categorias:");
                                                    foreach (String categoria in categorias)
                                                    {
                                                        Console.WriteLine(categoria);
                                                    }
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("Escriba la categoria que quiere ver");
                                                    String cate = Console.ReadLine();
                                                    if (categorias.Contains(cate))
                                                    {
                                                        main.VerPublicacionesCategoriaE(cate);
                                                        continue;

                                                    }
                                                    else
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("No existe categoria");
                                                        Console.ForegroundColor = ConsoleColor.Black;
                                                        continue;
                                                    }

                                                }
                                                if (c == "3")
                                                {
                                                    Console.WriteLine("Ingrese el id de la publicacion para mostrar contacto");
                                                    try
                                                    {
                                                        int id = Convert.ToInt32(Console.ReadLine());
                                                        main.mostrarInformacion(id);
                                                        continue;
                                                    }
                                                    catch
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("Error, numero mal ingresado");
                                                        Console.ForegroundColor = ConsoleColor.Black;
                                                    }
                                                    continue;

                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                                    Console.WriteLine("Opcion no valida");
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    continue;
                                                }
                                            }
                                            if (b == "2")
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.WriteLine("Ingrese una opcion (1 o 2)");
                                                Console.WriteLine("1. Ver todas las publicaciones");
                                                Console.WriteLine("2. Ver por categoria:");
                                                Console.WriteLine("3. Mostrar contacto de una publicacion");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                String c = Console.ReadLine();
                                                if (c == "1")
                                                {
                                                    main.VerPublicacionesPerdidas();
                                                    continue;
                                                }
                                                if (c == "2")
                                                {
                                                    foreach (String categoria in categorias)
                                                    {
                                                        Console.WriteLine(categoria);
                                                    }
                                                    Console.WriteLine("Escriba la categoria que quiere ver");
                                                    String cate = Console.ReadLine();
                                                    main.VerPublicacionesCategoriaP(cate);
                                                    continue;
                                                }
                                                if (c == "3")
                                                {
                                                    Console.WriteLine("Ingrese el id de la publicacion para mostrar contacto");
                                                    try
                                                    {
                                                        int id = Convert.ToInt32(Console.ReadLine());
                                                        main.mostrarInformacion(id);
                                                        continue;
                                                    }
                                                    catch
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("Error, numero mal ingresado");
                                                        Console.ForegroundColor = ConsoleColor.Black;
                                                    }
                                                    continue;

                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                                    Console.WriteLine("Opcion no valida");
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    continue;
                                                }
                                            }
                                            if (b == "3")
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("Opcion no valida");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                continue;
                                            }
                                        }
                                        continue;

                                    }
// volver menu principal
                                    if (opcion == "4")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Opcion no valida");
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        continue;
                                    }
                                }
                                continue;

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Contraseña Incorrecta");
                                Console.ForegroundColor = ConsoleColor.Black;
                                continue;
                            }
                        }

                    }
// administrador
                    if (tipo == "admin")
                    {
                        if (main.RevisarApodo(apodo))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("No exite el apodo");
                            Console.ForegroundColor = ConsoleColor.Black;
                            continue;
                        }

                        else
                        {
                            if (main.GetAdministrador(apodo) == null)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Nombre de usuario de tipo incorrecto");
                                Console.ForegroundColor = ConsoleColor.Black;
                                continue;
                            }
                            Administrador administrador1 = main.GetAdministrador(apodo);
                            Console.WriteLine("ingrese la clave: ");
                            String clave = Console.ReadLine();
                            if (clave == administrador1.Getcontraseña())
                            {
                                String texto = "Se ha ingresado a la aplicacion como administrador, Apodo: " + apodo;
                                main.AdicionarInfo(texto);
//menu principal administrador
                                while (true)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.WriteLine("Menu:");
                                    Console.WriteLine("1. Ver publicaciones");
                                    Console.WriteLine("2. Eliminar publicaciones");
                                    Console.WriteLine("3. Eliminar usuario");
                                    Console.WriteLine("4. Ver usuarios");
                                    Console.WriteLine("5. Salir");
                                    Console.WriteLine("Ingrese una opcion: ");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    String opcion1 = Console.ReadLine();
//ver publicaciones
                                    if (opcion1 == "1")
                                    {
                                        while (true)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            Console.WriteLine("Ingrese una opcion (1, 2 o 3)");
                                            Console.WriteLine("1. Publicaciones de objetos encontrados");
                                            Console.WriteLine("2. Publicaciones de objetos perdidos");
                                            Console.WriteLine("3. Volver");
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            String b = Console.ReadLine();
                                            if (b == "1")
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.WriteLine("Ingrese una opcion (1, 2 o 3)");
                                                Console.WriteLine("1. Ver todas las publicaciones");
                                                Console.WriteLine("2. Ver por categoria");
                                                Console.WriteLine("3. Mostrar informacion de usuario");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                String c = Console.ReadLine();
                                                if (c == "1")
                                                {
                                                    main.VerPublicacionesEncontradas();
                                                    continue;
                                                }
                                                if (c == "2")
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.WriteLine("Categorias:");
                                                    foreach (String categoria in categorias)
                                                    {
                                                        Console.WriteLine(categoria);
                                                    }
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("Escriba la categoria que quiere ver");
                                                    String cate = Console.ReadLine();
                                                    if (categorias.Contains(cate))
                                                    {
                                                        main.VerPublicacionesCategoriaE(cate);
                                                        continue;

                                                    }
                                                    else
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("No existe categoria");
                                                        Console.ForegroundColor = ConsoleColor.Black;
                                                        continue;
                                                    }

                                                }
                                                if (c == "3")
                                                {
                                                    Console.WriteLine("Ingrese el id de la publicacion para mostrar contacto");
                                                    try
                                                    {
                                                        int id = Convert.ToInt32(Console.ReadLine());
                                                        main.mostrarInformacion(id);
                                                        continue;
                                                    }
                                                    catch
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("Error, numero mal ingresado");
                                                        Console.ForegroundColor = ConsoleColor.Black;
                                                    }
                                                    continue;

                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                                    Console.WriteLine("Opcion no valida");
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    continue;
                                                }
                                            }
                                            if (b == "2")
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.WriteLine("Ingrese una opcion (1 o 2)");
                                                Console.WriteLine("1. Ver todas las publicaciones");
                                                Console.WriteLine("2. Ver por categoria:");
                                                Console.WriteLine("3. Mostrar informacion de usuario");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                String c = Console.ReadLine();
                                                if (c == "1")
                                                {
                                                    main.VerPublicacionesPerdidas();
                                                    continue;
                                                }
                                                if (c == "2")
                                                {
                                                    foreach (String categoria in categorias)
                                                    {
                                                        Console.WriteLine(categoria);
                                                    }
                                                    Console.WriteLine("Escriba la categoria que quiere ver");
                                                    String cate = Console.ReadLine();
                                                    main.VerPublicacionesCategoriaP(cate);
                                                    continue;
                                                }
                                                if (c == "3")
                                                {
                                                    Console.WriteLine("Ingrese el id de la publicacion para mostrar contacto");
                                                    try
                                                    {
                                                        int id = Convert.ToInt32(Console.ReadLine());
                                                        main.mostrarInformacion(id);
                                                        continue;
                                                    }
                                                    catch
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine("Error, numero mal ingresado");
                                                        Console.ForegroundColor = ConsoleColor.Black;
                                                    }
                                                    continue;

                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                                    Console.WriteLine("Opcion no valida");
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    continue;
                                                }
                                            }
                                            if (b == "3")
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("Opcion no valida");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                continue;
                                            }
                                        }
                                        continue;
                                    }
// eliminar publicaciones
                                    if (opcion1 == "2")
                                    {
                                        main.EliminarCualquierPublicacion();
                                        continue;
                                    }
// eliminar usuario
                                    if (opcion1 == "3")
                                    {
                                        main.eliminarUsuario();
                                        continue;
                                    }
// ver usuarios
                                    if (opcion1 == "4")
                                    {
                                        main.verUsuario();
                                        continue;
                                    }
//volver
                                    if (opcion1 == "5")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Opcion no valida");
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Contraseña Incorrecta");
                                Console.ForegroundColor = ConsoleColor.Black;
                                continue; 
                            }
                        }
                        continue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Tipo de usuario no existente");
                        Console.ForegroundColor = ConsoleColor.Black;
                        continue;
                    }
                    
                }
                if (desicion == "3")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Gracias por usar la aplicacion");
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                }

                else 
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Opcion no valida, intentelo nuevamente");
                    Console.ForegroundColor = ConsoleColor.Black;
                    continue;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGrupo15
{
    public class Usuario
    {

        String nombre, mail, apodo, telefono, clave;
        List<int> puntos = new List<int>();
        List<Publicacion> publicaciones = new List<Publicacion>();
        List<List<String>> notificaciones = new List<List<String>>();

        public Usuario(String minombre, String mimail, String miapodo, String mitelefono, String miclave)
        {
            nombre = minombre;
            mail = mimail;
            apodo = miapodo;
            telefono = mitelefono;
            clave = miclave;
        }

        public String Getapodo()
        {
            return apodo;
        }
        public String Getmail()
        {
            return mail;
        }
        public String Getcontraseña()
        {
            return clave;
        }

        public int CalcularPuntos()
        {
            int i = 0;
            for (int j = 0; j < puntos.Count(); j++)
            {
                int calculo = puntos[j];
                i = i + calculo;
            }
            if (puntos.Count() == 0)
            {
                Console.WriteLine("No tiene calificacion");
                int calculofinal = 0;
                return calculofinal;
            }
            else
            {
                int calculofinal = i / puntos.Count();
                return calculofinal;
            }
        }
        public void AgregarPublicacion(Publicacion publicacion1)
        {
            publicaciones.Add(publicacion1);
        }
        public virtual void VerMisPublicaciones()
        {
            if (publicaciones.Count() == 0)
            {
                Console.WriteLine("No tiene publicaciones");
            }
            else
            {
                foreach (Publicacion publicacion in publicaciones)
                {
                    publicacion.MostrarPublicacion();
                }
            }

        }
        public void MostrarContacto()
        {
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Apodo: " + apodo);
            Console.WriteLine("Mail: " + mail);
            Console.WriteLine("Telefono: " + telefono);
            Console.WriteLine("Calificacion: " + CalcularPuntos());

        }
        public void AgregarNotificacion(Usuario usuario)
        {
            List<String> usuarioquelacrea = new List<string>();
            Console.WriteLine("Ingrese texto de la notificacion:");
            String notificacion = Console.ReadLine();
            usuarioquelacrea.Add(notificacion);
            usuarioquelacrea.Add(apodo);
            usuarioquelacrea.Add(mail);
            usuario.notificaciones.Add(usuarioquelacrea);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Notificacion creada con exito");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public void verNotificaciones()
        {
            if (notificaciones.Count() == 0)
            {
                Console.WriteLine("No tiene notificaciones");
            }
            else
            {
                foreach (List<string> notificacion1 in notificaciones)
                {
                    Console.WriteLine("Remitente: " + notificacion1[1]);
                    Console.WriteLine("Mail remitente: " + notificacion1[2]);
                    Console.WriteLine("Mensaje: " + notificacion1[0]);
                }
            }

        }

        public void EliminarNotificaciones()
        {
            if (notificaciones.Count() == 0)
            {
                Console.WriteLine("No tiene notificaciones");
            }
            else
            {
                notificaciones.Clear();
            }

        }

        public Publicacion EntregarPublicacion(int id)
        {
            foreach (Publicacion publicacion2 in publicaciones)
            {
                if (publicacion2.GetId() == id)
                {
                    return publicacion2;
                }
            }
            return null;
        }
        public void EliminarPublicacion(int id)
        {
            foreach (Publicacion publicacion2 in publicaciones)
            {
                if (publicacion2.GetId() == id)
                {
                    publicaciones.Remove(publicacion2);
                    break;
                }

            }
        }


        public void AgregarCalificaion(int calificacion)
        {
            puntos.Add(calificacion); 
        }
    
    }
}

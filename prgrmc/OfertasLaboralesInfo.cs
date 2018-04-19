using System;
using System.Collections.Generic;
namespace prgrmc
{
    public class OfertasLaboralesInfo
    {

        List<Postulacion> Postulaciones = new List<Postulacion>();
        List<Postulacion> PostulacionesAceptadas = new List<Postulacion>();
        List<Oferta> Ofertas = new List<Oferta>();
        public List<Usuario> Usuarios = new List<Usuario>();


        public Usuario GetUsuario(int rut)
        {

            foreach (Usuario us in Usuarios)
            {

                if (us.Rut == rut)
                {

                    return us;
                }
            }
            return null;

        }

        public void ListaUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }



        public void ListaOferta(Oferta oferta)
        {
            Ofertas.Add(oferta);
        }



        public void ListaPostulacion(Postulacion postulacion)
        {
            Postulaciones.Add(postulacion);
        }



        public Oferta GetOferta(int codigo)
        {
            foreach (Oferta of in Ofertas)
            {
                if (of.Codigo == codigo)
                {
                    return of;
                }
            }
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("El codigo ingresado no existe");
            Console.Beep();
            Console.Beep();
            Console.BackgroundColor = ConsoleColor.White;
            return null;

        }



        public Postulacion GetPostulacion(int codigo)
        {
            foreach (Postulacion po in Postulaciones)
            {
                if (po.Codigo == codigo)
                {
                    return po;
                }
            }

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("El codigo ingresado no existe");
            Console.Beep();
            Console.Beep();
            Console.BackgroundColor = ConsoleColor.White;
            return null;

        }



        public void MostrarOfertas()
        {
            foreach (Oferta of in Ofertas)
            {
                if (of.Estado == true)
                {

                    {
                        Console.WriteLine(of.Titulo + "\nCodigo: " + of.Codigo +
                                        "\nRemuneracion: " + of.Remuneracion +
                                        "\nVacantes: " + of.Vacantes +
                                      "\nDescripcion: " + of.Descripcion +
                                      "\nLugar: " + of.Evento.Lugar +
                                      "\nDesde " + of.Evento.FechaInicio + "\nHasta " + of.Evento.FechaTermino +
                                      "\nRemitente de la oferta:" + of.Remitente.Nombre + " " + of.Remitente.Apellido);
                    }

                    if (of.GetType() == typeof(Investigacion)) 
                    { 
                        Console.WriteLine("Es una investigacion"); 
                    }
                }
            }
        }

        public void MostrarRankeables()
        {
            foreach (Oferta of in Ofertas)
            {
                if (of.Estado == false)
                {

                    {
                        Console.WriteLine(of.Titulo + "\nCodigo: " + of.Codigo +
                                        "\nRemuneracion: " + of.Remuneracion +
                                        "\nVacantes: " + of.Vacantes +
                                      "\nDescripcion: " + of.Descripcion +
                                      "\nLugar: " + of.Evento.Lugar +
                                      "\nDesde " + of.Evento.FechaInicio + "\nHasta " + of.Evento.FechaTermino +
                                      "\nRemitente de la oferta:" + of.Remitente.Nombre + " " + of.Remitente.Apellido);
                    }

                    if (of.GetType() == typeof(Investigacion))
                    {
                        Console.WriteLine("Es una investigacion");
                    }
                }
            }
            
        }


        public Oferta OfertaRemitente(int rut)
        {
            foreach (Oferta of in Ofertas)
            {
                if (of.Remitente.Rut == rut)
                {
                    Console.WriteLine("Oferta Nº " + of.Codigo +
                                      "y titulo: " + of.Titulo +
                                      "\n De esta oferta quiere ver los postulantes? " +
                                      "\n1.Si " +
                                      "\n2.No");

                    string n = Console.ReadLine();
                    if (n == "1")
                    {
                        return of;
                    }
                }
            }
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("No hay se encuentran mas ofertas bajo su rut");
            Console.Beep();
            Console.Beep();
            Console.BackgroundColor = ConsoleColor.White;
            return null;
        }



        public Usuario AceptarPostulacionOferta(int CodOf)
        {
            List<Postulacion> p = new List<Postulacion>();

            Console.WriteLine("Estos son los usuarios que postularon a su oferta:");
            foreach (Postulacion po in Postulaciones)
            {

                if (po.Oferta1.Codigo == CodOf)
                {
                    Console.WriteLine("Nombre: " + po.Usuario1.Nombre + " " + po.Usuario1.Apellido +
                                     "Rut: " + po.Usuario1.Rut +
                                     "Ranking: " + po.Usuario1.RankingProm +
                                     "Edad: " + po.Usuario1.Edad);

                    if (po.Usuario1.GetType() == typeof(Profesor)) { Console.WriteLine("Es un profesor"); }

                    else if (po.Usuario1.GetType() == typeof(Alumno)) { Console.WriteLine("Es un alumno"); }

                    p.Add(po);
                }
            }

            if (p.Count == 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("No se encuentran ofertas bajo su rut");
                Console.Beep();
                Console.Beep();
                Console.BackgroundColor = ConsoleColor.White;
                return null;
                
            }

            Console.WriteLine("Ingrese el rut del postulante que desea aceptar");
            int r = Convert.ToInt32(Console.ReadLine());

            foreach (Postulacion i in p)
            {
                if (i.Usuario1.Rut == r)
                {
                    i.Oferta1.Vacantes = i.Oferta1.Vacantes - 1;
                    i.Oferta1.Contratado = i.Usuario1;

                    PostulacionesAceptadas.Add(i);
                    return i.Usuario1;
                }
            }
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("El rut del postulante no es valido");
            Console.Beep();
            Console.Beep();
            Console.BackgroundColor = ConsoleColor.White;
            return null;
        }
    }
}

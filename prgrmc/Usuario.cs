using System;
using System.Collections.Generic;
using System.IO;

namespace prgrmc
{
    public class Usuario
    {


        public List<Usuario> Usuarios = new List<Usuario>();
        public int Rut;
        public string Nombre;
        public string Apellido;
        public int Edad;
        public int RankingProm;
        public List<int> Ranking = new List<int>();
        public List<string> Comentario = new List<string>();
        string Descripcion;
        OfertasLaboralesInfo OLI;

        public Usuario(int rut, string nombre, string apellido, int edad, int rankingprom1, List<int>ranking, List<string> comentario, string descripcion, OfertasLaboralesInfo oli)

        {
            OLI = oli;
            Rut = rut;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            RankingProm = rankingprom1;
            Ranking = ranking;
            Comentario = comentario;
            Descripcion = descripcion;
        }





        public int IngresarUsuario(OfertasLaboralesInfo OLI)
        {
            int termino = 0;
            Console.WriteLine("Ingrese su rut");
            int rut = Convert.ToInt32(Console.ReadLine());
            if (OLI.GetUsuario(rut) == null)
            {
                while (termino == 0)
                {
                    Console.WriteLine("Usted es:\n1.Alumno \n2.Profesor");
                    string respuesta = Console.ReadLine();
                    if (respuesta == "1")
                    {
                        Console.WriteLine("Ingrese:\n1.Nombre \n2.Apellido \n3.Edad \n4.Una descripcion sobre usted \n5.Carrera \n6.Ano");
                        string nombre = Console.ReadLine();
                        string apellido = Console.ReadLine();

                        int edad = Convert.ToInt32(Console.ReadLine());
                        string descripcion = Console.ReadLine();
                        string carrera = Console.ReadLine();
                        int ano = Convert.ToInt32(Console.ReadLine());
                        List<string> comentario = new List<string>();
                        List<int> ranking = new List<int>();
                        ranking.Add(5);

                        Usuario usuario = new Alumno(rut, nombre, apellido, edad, 5, ranking, comentario, descripcion, carrera, ano, OLI);
                        OLI.ListaUsuario(usuario);

                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine("El usuario ingresada exitosamente! Su Nº de credencial es: " + rut);
                        Console.Beep();
                        Console.BackgroundColor = ConsoleColor.White;
                        return rut;
                       

                    }

                    if (respuesta == "2")
                    {
                        Console.WriteLine("Ingrese:\n1.Nombre \n2.Apellido \n3.Edad \n4.Una descripcion sobre usted \n5.Especialidad");
                        string nombre = Console.ReadLine();
                        string apellido = Console.ReadLine();
                        int edad = Convert.ToInt32(Console.ReadLine());
                        string descripcion = Console.ReadLine();
                        string especialidad = Console.ReadLine();
                        List<string> comentario = new List<string>();
                        List<int> ranking = new List<int>();

                        ranking.Add(5);

                        Usuario usuario = new Profesor(rut, nombre, apellido, edad, 5, ranking, comentario, descripcion, especialidad, OLI);
                        OLI.ListaUsuario(usuario);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine("El usuario ingresada exitosamente! Su Nº de credencial es: " + rut);
                        Console.Beep();
                        Console.BackgroundColor = ConsoleColor.White;
                        return rut;
                       

                    }

                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("La opcion ingresada no es correcta");
                        Console.Beep();
                        Console.Beep();
                        Console.BackgroundColor = ConsoleColor.White;
                    }  
                }
                return 0;

                                          
            }

            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Usted ya se enceuntra registrado");
                Console.Beep();
                Console.Beep();
                Console.BackgroundColor = ConsoleColor.White;
                return rut;

                
            }
                   
        }

        public Usuario rankear(int CodOf, int estrellas, OfertasLaboralesInfo OLI)
        {

            Oferta of = OLI.GetOferta(CodOf);

            if (of != null)
            {
                if (of.Estado == false && of.Remitente.Rut == this.Rut)
                {
                    of.Contratado.Ranking.Add(estrellas);
                    int x = 0;
                    int cant = 0;
                    foreach (int y in of.Contratado.Ranking)
                    {
                        x += y;
                        cant += 1;
                    }

                    of.Contratado.RankingProm = x / cant;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("El usuario Nº " + of.Contratado +  " fue rankeado exitosamente");
                    Console.Beep();
                    Console.BackgroundColor = ConsoleColor.White;

                    Console.WriteLine("Desea ingresar un comentario sobre este usuario? " +
                                      "\n1.Si " +
                                      "\n2.No");
                    
                    string respuesta = Console.ReadLine();

                    if (respuesta == "1")
                    {
                        Console.WriteLine("Ingrese el comentario");
                        string com = Console.ReadLine();
                        of.Contratado.Comentario.Add(com);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine("Comentario ingresado correctamente");
                        Console.Beep();
                        Console.BackgroundColor = ConsoleColor.White;

                    }

                    else if( respuesta == "2")
                    {
                        return of.Contratado;

                    }

                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("La opcion ingresada no es correcta");
                        Console.Beep();
                        Console.Beep();
                        Console.BackgroundColor = ConsoleColor.White;

                    }
                    return of.Contratado;


                }

                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("No puede rankear a un usuario mientras el evento no finalice");
                    Console.Beep();
                    Console.Beep();
                    Console.BackgroundColor = ConsoleColor.White;
                    return null;
                }

            }

            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("La oferta ingresada no existe");
                Console.Beep();
                Console.Beep();
                Console.BackgroundColor = ConsoleColor.White;
                return null;
            }



        }

        public int OfertaFinalizada(OfertasLaboralesInfo OLI)
        {
            Console.WriteLine("Su rut es: " + this.Rut);
            OLI.MostrarOfertas();
            Console.WriteLine("Ingrese el codigo de la oferta que desea eliminar (debe haber sido ingresada por usted)");
            int cod = Convert.ToInt32(Console.ReadLine());
            Oferta o = OLI.GetOferta(cod);
            if (o.Remitente.Rut == this.Rut)
            {
                o.Estado = false;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Oferta dada de baja exitosamente!");
                Console.Beep();
                Console.BackgroundColor = ConsoleColor.White;
                return cod;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("El codigo ingresado no corresponde a alguna oferta o esta no fue ingrasada por usted");
                Console.Beep();
                Console.Beep();
                Console.BackgroundColor = ConsoleColor.White;
                return 0;
            }


        }



        public void IngresarOferta(int codigo, OfertasLaboralesInfo OLI)
        {
            

            Console.WriteLine("Su rut es:" + this.Rut);
            Console.WriteLine("Para ingresar la oferta debe ingresar: \n1.Titulo \n2.Remuneracion \n3.Vacantes \n4.Descripcion");
            string titulo = Console.ReadLine();


            int renumeracion = Convert.ToInt32(Console.ReadLine());
            int vacantes = Convert.ToInt32(Console.ReadLine());
            string descripcion = Console.ReadLine();

            Console.WriteLine("Además, debe ingresar para el evento: \n1.Lugar \n2.Fecha inicio (DD/MM/AAAA HH:MM:SS (AM o PM)) \n3.Fecha termino (DD/MM/AAAA HH:MM:SS (AM o PM)");
            string lugar = Console.ReadLine();
            string fechai = Console.ReadLine();
            string fechaf = Console.ReadLine();

            Evento evento = new Evento(fechai, fechaf, lugar);
            Console.WriteLine("Desea ingresar: " +
                  "\n1.Oferta " +
                  "\n2.Investigacion");
            string respuesta = Console.ReadLine();

            if (respuesta == "1")
            {
                Oferta oferta = new Oferta(codigo, titulo, renumeracion, vacantes, descripcion, evento, this, true);
                OLI.ListaOferta(oferta);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Oferta ingresada exitosamente! El codigo de esta es: " + codigo);
                Console.Beep();
                Console.BackgroundColor = ConsoleColor.White;

            }

            else if (respuesta == "2")
            {
                Console.WriteLine("Para la investigacion ingrese: \n1.Su area \n2.Especialidad");
                string area = Console.ReadLine();
                string especialidad = Console.ReadLine();
                Oferta oferta = new Investigacion(codigo, titulo, renumeracion, vacantes, descripcion, evento, this, area, especialidad, true);

                OLI.ListaOferta(oferta);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Oferta ingresada exitosamente! El codigo de esta es: " + codigo);
                Console.Beep();
                Console.BackgroundColor = ConsoleColor.White;
            }
        }



        public Oferta PostularOferta(int codigo, OfertasLaboralesInfo OLI)
        {
            Console.WriteLine("Su rut es: " + this.Rut);
            OLI.MostrarOfertas();
            Console.WriteLine("Ingrese el codigo de la oferta a la que desea postular");
            int cod = Convert.ToInt32(Console.ReadLine());
            Oferta o = OLI.GetOferta(cod);
            if (o == null)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("El codigo ingresado no corresponde a alguna oferta");
                Console.Beep();
                Console.Beep();
                Console.BackgroundColor = ConsoleColor.White;
                return null;
            }

            else
            {
                Postulacion postulacion = new Postulacion(codigo, this, o);
                OLI.ListaPostulacion(postulacion); 
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Postulacion ingresada exitosamente! El codigo de esta es: " + codigo);
                Console.Beep();
                Console.BackgroundColor = ConsoleColor.White;
                return o;
            }



        }



        public Oferta AceptarOferta(OfertasLaboralesInfo OLI)
        {

            Console.WriteLine("SU rut es: " + this.Rut);
            Oferta of = OLI.OfertaRemitente(this.Rut);
            if (of == null)
            {
                return null;
            }

            else
            {
                if (OLI.AceptarPostulacionOferta(of.Codigo) != null)
                {
                    Usuario usu = OLI.AceptarPostulacionOferta(of.Codigo);
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Postulacion aceptada exitosamente! El usuario aceptado es: " + usu);
                    Console.Beep();
                    Console.BackgroundColor = ConsoleColor.White;
                    return of;
                }

                else
                {
                    return null;
                }
            }

        }
    }



    public class Profesor : Usuario
    {
        public string Especialidad;

        public Profesor(int rut, string nombre, string apellido, int edad, int rankingprom, List<int> ranking, List<string> comentario, string descripcion, string especialidad, OfertasLaboralesInfo oli) : base(rut, nombre, apellido, edad, rankingprom, ranking, comentario, descripcion, oli)
        {
            Especialidad = especialidad;
        }


    }



    public class Alumno : Usuario
    {
        public string Carrera;
        public int Ano;

        public Alumno(int rut, string nombre, string apellido, int edad, int rankingprom, List<int> ranking, List<string> comentario, string descripcion, string carrera, int ano, OfertasLaboralesInfo oli) : base(rut, nombre, apellido, edad, rankingprom, ranking, comentario, descripcion, oli)
        {
            Carrera = carrera;
            Ano = ano;
        }
    }
}
using System;
using System.IO;
using System.Collections.Generic;

namespace prgrmc
{
    public class Menu
    {


        public void GenerarMenu(Usuario Adm, OfertasLaboralesInfo OLI)
        {
            StreamWriter sw = new StreamWriter("C:\\Logging.txt");
            int CodOferta = 1;
            int CodPost = 1;
            int termino0 = 0;
            Usuario usuario = Adm;

            while (termino0 == 0)
            {
                Console.WriteLine("Bienvenidos a Ofertas Laborales!");
                int termino1 = 0;
                int termino2 = 0;

                while (termino1 == 0)
                {
                    Console.WriteLine("Usuario nuevo? " +
                      "\n1.Si " +
                      "\n2.No");
                    string r1 = Console.ReadLine();

                    if (r1 == "1")
                    {
                        int rut = Adm.IngresarUsuario(OLI);
                        sw.WriteLine("El usuario Nº " + rut + " fue registrado");

                        termino1 = 1;
                    }

                    if (r1 == "2" || r1 == "1")
                    {

                        Console.WriteLine("Ingrese su rut/Nº de credencial");
                        int rut = Convert.ToInt32(Console.ReadLine());
                        Usuario usuario1 = OLI.GetUsuario(rut);
                        usuario = usuario1;

                        if (usuario1 == null)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("El rut ingresado no existe");
                            Console.Beep();
                            Console.Beep();
                            Console.BackgroundColor = ConsoleColor.White;
                            termino1 = 0;
                        }

                        else
                        {
                            sw.WriteLine("El usuario Nº " + rut + " inicio sesion");
                            termino1 = 1;
                        }
                    }

                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("La opcion ingresada no existe");
                        Console.Beep();
                        Console.Beep();
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    
                }


                while (termino2 == 0)
                {
                    Console.WriteLine("Desea: \n1.Ingresar oferta laboral " +
                                      "\n2. Postular a una oferta laboral" +
                                      "\n3. Aceptar postulantes de una oferta" +
                                      "\n4. Cerrar sesion" +
                                      "\n5. Rankear a un usuario" +
                                     "\n6. Dar de baja una oferta");

                    string r2 = Console.ReadLine();

                    if (r2 == "1")
                    {

                        usuario.IngresarOferta(CodOferta, OLI);
                        CodOferta += 1;
                        sw.WriteLine("El usuario Nº " + usuario.Rut + " ingreso la oferta laboral Nº " + CodOferta);
                    }

                    else if (r2 == "2")
                    {
                        Oferta oferta = usuario.PostularOferta(CodPost, OLI);
                        if (oferta == null)
                        {

                        }

                        else
                        {
                            sw.WriteLine("El usuario Nº " + usuario.Rut + " postulo oferta laboral Nº " + oferta.Codigo + " y el Nº de la postulacion es " + CodPost);

                        }


                        CodPost += 1;
                    }

                    else if (r2 == "3")
                    {
                        Oferta oferta = usuario.AceptarOferta(OLI);

                        if (oferta == null)
                        {

                        }

                        else
                        {
                            sw.WriteLine("El usuario Nº " + oferta.Remitente.Rut + " acepto al usuario Nº " + oferta.Contratado.Rut + " en la oferta Nº " + oferta.Codigo);

                        }
                    }

                    else if (r2 == "4")
                    {
                        sw.WriteLine("El usuario Nº " + usuario.Rut + " cerro sesion");

                        termino2 = 1;
                        Console.WriteLine("Desea cerrar el programa?" +
                                          "\n1. Si" +
                                          "\n2. No");
                        
                        string r3 = Console.ReadLine();
                        if (r3 == "1")
                        {
                            sw.WriteLine("El usuario Nº " + usuario.Rut + " cerro el programa");

                            Console.WriteLine("Hasta Luego!");
                            termino0 = 1;
                            sw.Close();
                            
                        }
                    }

                    else if (r2 == "5")
                    {
                        OLI.MostrarRankeables();
                        Console.WriteLine("Ingrese: \n1.El codigo de la oferta \n2. Un numero entre el 1-5 con el que desea evaluar al contrado ");
                        int cod = Convert.ToInt32(Console.ReadLine());
                        int estrellas = Convert.ToInt32(Console.ReadLine());

                        while (estrellas < 1 || estrellas > 5)
                        {
                            Console.WriteLine("Debe ingresar un valor entre 0-5");
                            estrellas = Convert.ToInt32(Console.ReadLine());

                        }

                        Usuario contratado = usuario.rankear(cod, estrellas, OLI);
                        if (usuario == null)
                        {

                        }

                        else
                        {
                            sw.WriteLine("El usuario Nº " + usuario.Rut + " rankeo con " + estrellas + " al usuario Nº " + contratado.Rut);
                        }
                    }

                    else if (r2 == "6")
                    {

                        int r4 = usuario.OfertaFinalizada(OLI);
                        if (r4 != 0)
                        {
                            sw.WriteLine("El usuario Nº " + usuario.Rut + " dio de baja la oferta Nº  " + r4);

                        }


                    }
                }
            }
        }
    }
}
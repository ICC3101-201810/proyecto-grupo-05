using System;
using System.IO;
using System.Collections.Generic;
using Gtk;

namespace gtk
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            OfertasLaboralesInfo OLI = new OfertasLaboralesInfo();

            Console.BackgroundColor = ConsoleColor.White;

            StreamWriter sw = File.AppendText("Logging.txt");

            int CodOferta = OLI.DeserealizarCodOf();
            int CodPost = OLI.DeserealizarCodPost();
            OLI.Deserealizar();


            //int CodPost = 1;
            //int CodOf = 1;


            //List<string> comentario = new List<string>();
            //List<string> comentario1 = new List<string>();

            //List<int> ranking = new List<int>();
            //List<int> ranking1 = new List<int>();
            //Usuario Adm = new Alumno(0000, "Adm", "Administrador", 20, 5, ranking, comentario, "", "Ingenieria", 2, OLI);
            //Usuario Josefina = new Alumno(196868119, "Josefina", "Valenzuela", 20, 5,ranking1, comentario1, "", "Ingeniera", 3, OLI);
            //OLI.Usuarios.Add(Adm);
            //OLI.Usuarios.Add(Josefina);

            //Evento ev = new Evento("1", "1", "1");
            //Oferta Of = new Oferta(CodOf, "1", 1, 1, "1", ev, Adm, true);
            //OLI.Ofertas.Add(Of);
            //CodOf += 1;

            //Postulacion post = new Postulacion(CodPost, Josefina, Of);
            //OLI.Postulaciones.Add(post);
            //CodPost += 1;

            //post.Oferta1.Contratado = Josefina;
            //post.Oferta1.Vacantes -= 1;

            //OLI.PostulacionesAceptadas.Add(post);

            //OLI.SerializableOferta(OLI.Ofertas);
            //OLI.SerializableUsuario(OLI.Usuarios);
            //OLI.SerializablePostulacion(OLI.Postulaciones);
            //OLI.SerializablePostulacionAceptadas(OLI.PostulacionesAceptadas);
            //OLI.SerializableCodOf(CodOf);
            //OLI.SerializableCodPost(CodPost);

            Application.Init();
            MainWindow w = new MainWindow(OLI, CodOferta, CodPost, sw);
            Application.Run();
            w.Show();

        }
    }
}

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

            StreamWriter sw = new StreamWriter("Logging.txt");
            int CodOferta = 1;
            int CodPost = 1;

            List<string> comentario = new List<string>();
            List<int> ranking = new List<int>();

            Usuario Adm = new Alumno(0000, "Adm", "Administrador", 20, 5, ranking, comentario, "", "Ingenieria", 2, OLI);

            Application.Init();
            MainWindow w = new MainWindow(OLI, CodOferta, CodPost);
            Application.Run();
            w.Show();

        }
    }
}

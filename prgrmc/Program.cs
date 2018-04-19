using System;
using System.IO;
using System.Collections.Generic;

namespace prgrmc
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            OfertasLaboralesInfo OLI = new OfertasLaboralesInfo();

            Console.BackgroundColor = ConsoleColor.White;

            StreamWriter Logging = new StreamWriter("Logging.txt");

            Menu menu = new Menu();
            List<string> comentario = new List<string>();
            List<int> ranking = new List<int>();

            Usuario Adm = new Alumno(0000, "Adm", "Administrador", 20, 5, ranking, comentario, "", "Ingenieria", 2, OLI);

            menu.GenerarMenu(Adm, OLI);



        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace gtk
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

        public Usuario(int rut, string nombre, string apellido, int edad, int rankingprom1, List<int> ranking, List<string> comentario, string descripcion, OfertasLaboralesInfo oli)

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




        //Sin Console.WriteLine();
        public bool IngresarUsuario(OfertasLaboralesInfo OLI)
        {
            if (OLI.GetUsuario(this.Rut) == null)
            {
                OLI.ListaUsuario(this);
                return true;
            }

            return false;
                

        }

        //Sin Console.WriteLine
        public bool rankear(Oferta of, int estrellas, OfertasLaboralesInfo OLI)
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
                return true;
            }
            return false;
        }

        //Sin Console.WriteLine
        public bool OfertaFinalizada(OfertasLaboralesInfo OLI, Oferta o)
        {

            if (o.Remitente.Rut == this.Rut)
            {
                o.Estado = false;

                return true;
            }
            else
            {
                return false;
            }


        }


        //Sin Console.WriteLine
        public void IngresarOferta(OfertasLaboralesInfo OLI, Oferta oferta)
        {
            OLI.ListaOferta(oferta);

        }


        //Sin Console.WriteLine
        public Oferta PostularOferta(int codigopost, OfertasLaboralesInfo OLI, int cod)
        {
            Oferta o = OLI.GetOferta(cod);

            if (o == null) { return null; }


            Postulacion postulacion = new Postulacion(codigopost, this, o);
            OLI.ListaPostulacion(postulacion);
            return o;

        }


        // Sin Console.WriteLine
        public Oferta AceptarOferta(OfertasLaboralesInfo OLI, Oferta ofer, List<Postulacion> p, Usuario contratado)
        {

            if (OLI.AceptarPostulacionOferta(ofer, p, contratado) != null)
            {
                Usuario usu = OLI.AceptarPostulacionOferta(ofer, p, contratado);
                return ofer;
            }

            else
            {
                return null;
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
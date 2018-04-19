using System;
namespace prgrmc
{
    public class Evento
    {
        public String Lugar;
        public string FechaInicio;
        public string FechaTermino;

        public Evento(string miFechaInicio, string miFechaTermino, string miLugar)
        {
            FechaTermino = miFechaTermino;
            Lugar = miLugar;
            FechaInicio = miFechaInicio;
        }
    }



    public class Investigacion : Oferta
    {
        public string Area;
        public string Especialidad;

        public Investigacion(int codigo, string titulo, int miRemuneracion, int miVacante, string miDescricion, Evento evento, Usuario remitente, string area, string especialidad, bool estado) : base(codigo, titulo, miRemuneracion, miVacante, miDescricion, evento, remitente, estado)
        {
            Area = area;
            Especialidad = especialidad;
        }
    }



    public class Oferta
    {
        public string Titulo;
        public int Codigo;
        public int Remuneracion;
        public int Vacantes;
        public string Descripcion;
        public Evento Evento;
        public Usuario Remitente;
        public Usuario Contratado;
        public bool Estado;


        public Oferta(int codigo, string titulo, int miRemuneracion, int miVacante, string miDescricion, Evento evento, Usuario remitente, bool estado)
        {
            Codigo = codigo;
            Titulo = titulo;
            Remuneracion = miRemuneracion;
            Vacantes = miVacante;
            Descripcion = miDescricion;
            Evento = evento;
            Remitente = remitente;
            Estado = estado;
            Contratado = null;
        }
    }
}


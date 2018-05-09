using System;
namespace gtk
{
    public class Postulacion
    {
        public int Codigo;
        public Usuario Usuario1;
        public Oferta Oferta1;

        public Postulacion(int codigo, Usuario usuario, Oferta oferta)
        {
            Codigo = codigo;
            Usuario1 = usuario;
            Oferta1 = oferta;
        }

    }
}

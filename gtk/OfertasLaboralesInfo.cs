using System;
using System.Collections.Generic;
using System.IO;
namespace gtk
{
    public class OfertasLaboralesInfo
    {

        public List<Postulacion> Postulaciones = new List<Postulacion>();
        public List<Postulacion> PostulacionesAceptadas = new List<Postulacion>();
        public List<Oferta> Ofertas = new List<Oferta>();
        public List<Usuario> Usuarios = new List<Usuario>();

        //Sin Console.WriteLine
        public Usuario GetUsuario(int rut)
        {

            foreach (Usuario us in Usuarios)
            {

                if (us.Rut == rut)
                {
                    Console.WriteLine(us.Rut);
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


        // Sin Console.WriteLine
        public Oferta GetOferta(int codigo)
        {
            foreach (Oferta of in Ofertas)
            {
                if (of.Codigo == codigo)
                {
                    return of;
                }
            }
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
            return null;

        }

        //Sin Console.WriteLine
        public Usuario AceptarPostulacionOferta(Oferta ofer, List<Postulacion> p, Usuario contratado)
        {

            foreach (Postulacion i in p)
            {
                if (i.Usuario1.Rut == contratado.Rut)
                {
                    i.Oferta1.Vacantes = i.Oferta1.Vacantes - 1;
                    i.Oferta1.Contratado = i.Usuario1;

                    PostulacionesAceptadas.Add(i);
                    return i.Usuario1;
                }
            }
            return null;
        }
    }
}


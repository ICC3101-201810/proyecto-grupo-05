using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace gtk

{
    [Serializable]
    public class OfertasLaboralesInfo
    {

        public List<Postulacion> Postulaciones = new List<Postulacion>();
        public List<Postulacion> PostulacionesAceptadas = new List<Postulacion>();
        public List<Oferta> Ofertas = new List<Oferta>();
        public List<Usuario> Usuarios = new List<Usuario>();

        public void ArchivoUsuarios(List<Usuario> archivo)
        {
            Usuarios = archivo;
        }

        public void ArchivoOfertas(List<Oferta> archivo)
        {
            Ofertas = archivo;
        }

        public void ArchivoPostulacion(List<Postulacion> archivo)
        {
            Postulaciones = archivo;
        }

        public void ArchivoPostulacionAceptada(List<Postulacion> archivo)
        {
            PostulacionesAceptadas = archivo;
        }

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
            SerializableUsuario(Usuarios);

        }



        public void ListaOferta(Oferta oferta)
        {
            Ofertas.Add(oferta);
            SerializableOferta(Ofertas);
        }



        public void ListaPostulacion(Postulacion postulacion)
        {
            Postulaciones.Add(postulacion);
            SerializablePostulacion(Postulaciones);
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
                    SerializableUsuario(Usuarios);
                    return i.Usuario1;
                }
            }
            return null;
        }

        public void SerializableCodOf(int CodOf)
        {
            try
            {
                using (Stream st = File.Open("CodOf.bin", FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(st, CodOf);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
            }
        }

        public void SerializableCodPost(int CodPost)
        {
            try
            {
                using (Stream st = File.Open("CodPost.bin", FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(st, CodPost);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
            }
        }

        public int DeserealizarCodOf()
        {
            int CodOf;
            try
            {
                using (Stream st = File.Open("CodOf.bin", FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    CodOf = (int)bf.Deserialize(st);
                }
                return CodOf;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int DeserealizarCodPost()
        {
            int CodPost;
            try
            {
                using (Stream st = File.Open("CodPost.bin", FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    CodPost = (int)bf.Deserialize(st);
                }
                return CodPost;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void SerializableUsuario(List<Usuario> usuarios)
        {
            try
            {
                using (Stream st = File.Open("usuarios.bin", FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(st, usuarios);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
            }
        }

        public void SerializableOferta(List<Oferta> ofertas)
        {
            try
            {
                using (Stream st = File.Open("ofertas.bin", FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(st, ofertas);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error");

            }
        }

        public void SerializablePostulacion(List<Postulacion> postulaciones)
        {
            try
            {
                using (Stream st = File.Open("postulaciones.bin", FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(st, postulaciones);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error");

            }
        }

        public void SerializablePostulacionAceptadas(List<Postulacion> postulaciones)
        {
            try
            {
                using (Stream st = File.Open("postulacionesaceptasas.bin", FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(st, postulaciones);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error" + ex.Message);

            }
        }

        public List<Postulacion> DeserealizarPostulacionAceptada()
        {
            List<Postulacion> postulaciones;
            try
            {
                using (Stream st = File.Open("postulacionesaceptadas.bin", FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    postulaciones = (List<Postulacion>)bf.Deserialize(st);
                }
                return postulaciones;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Usuario> DeserealizarUsuario()
        {
            List<Usuario> usuarios;
            try
            {
                using (Stream st = File.Open("usuarios.bin", FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    usuarios = (List<Usuario>)bf.Deserialize(st);
                }
                return usuarios;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Oferta> DeserealizarOferta()
        {
            List<Oferta> ofertas;
            try
            {
                using (Stream st = File.Open("ofertas.bin", FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    ofertas = (List<Oferta>)bf.Deserialize(st);
                }
                return ofertas;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Postulacion> DeserealizarPostulacion()
        {
            List<Postulacion> postulaciones;
            try
            {
                using (Stream st = File.Open("postulaciones.bin", FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    postulaciones = (List<Postulacion>)bf.Deserialize(st);
                }
                return postulaciones;

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public void Deserealizar()
        {
            Ofertas = DeserealizarOferta();
            Usuarios = DeserealizarUsuario();
            Postulaciones = DeserealizarPostulacion();
            PostulacionesAceptadas = DeserealizarPostulacionAceptada();
        }
    }
}


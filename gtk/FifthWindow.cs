using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;


namespace gtk
{
    public partial class FifthWindow : Gtk.Window
    {
        int CodOf;
        int CodPost;

        //La variable Invest, se encarga identificar si el usuario marco la casilla de Investigación o no
        bool Invest;
        OfertasLaboralesInfo OLI;
        Usuario Usuario;
        StreamWriter ST;


        //En esta ventana se muestran todas las opciones disponibles para el usuario, una en cada pestaña
        public FifthWindow(OfertasLaboralesInfo oli, int codOf, int codPost, Usuario usuario, bool invest, StreamWriter st) :
                base(Gtk.WindowType.Toplevel)
        {
            CodPost = codPost;
            CodOf = codOf;
            Usuario = usuario;
            OLI = oli;
            Invest = invest;
            ST = st;
            this.Build();
        }

        //Investigación marcado
        protected void OnInvestigacion1Toggled(object sender, EventArgs e)
        {
            this.Invest = true;

        }

        //Ingresar Oferta
        protected void OnIngresarOfertaClicked(object sender, EventArgs e)
        {
            if (Titulo1.Text != "" &&
                Remuneracion1.Text != "" &&
                Vacantes1.Text != "" &&
                Descripcion1.Text != "" &&
                Lugar1.Text != "" &&
                Inicio1.Text != "" &&
                Termino1.Text != "")
            {
                string titulo = Titulo1.Text;
                int remuneracion = Convert.ToInt32(Remuneracion1.Text);
                int vacantes = Convert.ToInt32(Vacantes1.Text);
                string descripcion = Descripcion1.Text;
                string lugar = Lugar1.Text;
                string inicio = Inicio1.Text;
                string termino = Termino1.Text;
                Evento evento = new Evento(inicio, termino, lugar);
                Oferta oferta = new Oferta(CodOf, titulo, remuneracion, vacantes, descripcion, evento, Usuario, true);
                Usuario.IngresarOferta(OLI, oferta);
                System.Windows.Forms.MessageBox.Show("Usuario Nº " + Usuario.Rut + " ingresó la oferta Nº " + CodOf);
                ST.WriteLine("Usuario Nº " + Usuario.Rut + " ingresó la oferta Nº " + CodOf);

                CodOf += 1;
                OLI.SerializableCodOf(CodOf);
            }

            else
            {
                System.Windows.Forms.MessageBox.Show("No ha ingresado todos los datos");

            }


        }

        //Ingresar Investigación
        protected void OnButton36Clicked(object sender, EventArgs e)
        {
            if (Titulo1.Text != "" && 
                Remuneracion1.Text != "" && 
                Vacantes1.Text != "" &&
                Descripcion1.Text != "" &&
                Lugar1.Text != ""&&
                Inicio1.Text != "" &&
                Termino1.Text != "" &&
                Area1.Text != "" &&
                Especialidad1.Text != "")
            {
                string titulo = Titulo1.Text;
                int remuneracion = Convert.ToInt32(Remuneracion1.Text);
                int vacantes = Convert.ToInt32(Vacantes1.Text);
                string descripcion = Descripcion1.Text;
                string lugar = Lugar1.Text;
                string inicio = Inicio1.Text;
                string termino = Termino1.Text;
                Evento evento = new Evento(inicio, termino, lugar);
                string area = Area1.Text;
                string especialidad = Especialidad1.Text;


                if (Invest)
                {
                    Oferta oferta = new Investigacion(CodOf, titulo, remuneracion, vacantes, descripcion, evento, Usuario, area, especialidad, true);
                    Usuario.IngresarOferta(OLI, oferta);
                    System.Windows.Forms.MessageBox.Show("Usuario Nº " + Usuario.Rut + " ingresó la investigación Nº " + CodOf);
                    ST.WriteLine("Usuario Nº " + Usuario.Rut + " ingresó la investigación Nº " + CodOf);
                    CodOf += 1;
                    OLI.SerializableCodOf(CodOf);

                }

                else
                {
                    System.Windows.Forms.MessageBox.Show("No ha marcado la casilla de Investigación");
                }
            }

            else
            {
                System.Windows.Forms.MessageBox.Show("No ha ingresado todo lo datos");

            }

               

            
        }




        protected void OnVerOfertasClicked(object sender, EventArgs e)
        {
            
            foreach (Oferta of in OLI.Ofertas)
            {
                if (of.Estado == true)
                {
                    if (of.GetType() == typeof(Investigacion))
                    {
                        System.Windows.Forms.MessageBox.Show(of.Titulo + "\nCodigo: " + of.Codigo +
                                                        "\nRemuneracion: " + of.Remuneracion +
                                                        "\nVacantes: " + of.Vacantes +
                                                        "\nDescripcion: " + of.Descripcion +
                                                        "\nLugar: " + of.Evento.Lugar +
                                                        "\nDesde " + of.Evento.FechaInicio +
                                                        "\nHasta " + of.Evento.FechaTermino +
                                                        "\nRemitente de la oferta:" + of.Remitente.Nombre + " " + of.Remitente.Apellido +
                                                        "\n Es una Investigación");
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(of.Titulo + "\nCodigo: " + of.Codigo +
                                                        "\nRemuneracion: " + of.Remuneracion +
                                                        "\nVacantes: " + of.Vacantes +
                                                        "\nDescripcion: " + of.Descripcion +
                                                        "\nLugar: " + of.Evento.Lugar +
                                                        "\nDesde " + of.Evento.FechaInicio +
                                                        "\nHasta " + of.Evento.FechaTermino +
                                                        "\nRemitente de la oferta:" + of.Remitente.Nombre + " " + of.Remitente.Apellido);
                    }

                }
            }
                
        }

        //Ingresar Postulación
        protected void OnButton40Clicked(object sender, EventArgs e)
        {
            if (CodigoPostulacion2.Text != "")
            {
                int codigopostulacion = Convert.ToInt32(CodigoPostulacion2.Text);
                Oferta oferta = Usuario.PostularOferta(CodPost, OLI, codigopostulacion);

                if (oferta == null)
                {
                    System.Windows.Forms.MessageBox.Show("El codigo ingresado no corresponde a alguna oferta");

                }

                else
                {
                    System.Windows.Forms.MessageBox.Show("Postulacion ingresada exitosamente! El codigo de esta es: " + oferta.Codigo);
                    ST.WriteLine("Usuario Nº " + Usuario.Rut + " Postuló a la oferta " + oferta.Codigo + ". Código postulación: " + (CodPost));
                    CodPost += 1;
                    OLI.SerializableCodPost(CodPost);

                }
            }

        }

        //Mostrar Ofertas que se pueden dar de baja
        protected void OnVerBajablesClicked(object sender, EventArgs e)
        {
            OnVerOfertasClicked(sender, e);
        }

        //Dar de baja Oferta
        protected void OnDarDeBajaClicked(object sender, EventArgs e)
        {
            if (CodigoOferta4.Text != "")
            {
                int cod = Convert.ToInt32(CodigoOferta4.Text);
                Oferta o = OLI.GetOferta(cod);
                if (o != null)
                {
                    bool bb = Usuario.OfertaFinalizada(OLI, o);
                    if (bb)
                    {

                        System.Windows.Forms.MessageBox.Show("Oferta dada de baja exitosamente!");

                        ST.WriteLine("El usuario Nº " + Usuario.Rut + " dio de baja la oferta Nº  " + o.Codigo);
                    }

                    else
                    {
                        System.Windows.Forms.MessageBox.Show("El codigo ingresado no corresponde a alguna oferta o esta no fue ingrasada por usted");
                    }
                }

                else
                {
                    System.Windows.Forms.MessageBox.Show("El codigo ingresado no existe");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No ha ingresado un código");

            }

        }

        protected void OnVerRankeablesClicked(object sender, EventArgs e)
        {
            foreach (Oferta of in OLI.Ofertas)
            {
                if (of.Estado == false && of.Remitente.Rut == Usuario.Rut)
                {

                    System.Windows.Forms.MessageBox.Show(of.Titulo + "\nCodigo: " + of.Codigo +
                                                        "\nRemuneracion: " + of.Remuneracion +
                                                        "\nVacantes: " + of.Vacantes +
                                                        "\nDescripcion: " + of.Descripcion +
                                                        "\nLugar: " + of.Evento.Lugar +
                                                        "\nDesde " + of.Evento.FechaInicio +
                                                        "\nHasta " + of.Evento.FechaTermino +
                                                        "\nRemitente de la oferta:" + of.Remitente.Nombre + " " + of.Remitente.Apellido);
                }
            }
        }

        protected void OnRankearClicked(object sender, EventArgs e)
        {
            if(CodigoOferta5.Text != "" && Estrellas5.Text != "")
            {
                int cod = Convert.ToInt32(CodigoOferta5.Text);
                int estrellas = Convert.ToInt32(Estrellas5.Text);
                int r = 0;
                Oferta of = OLI.GetOferta(cod);

                if (of == null)
                {
                    System.Windows.Forms.MessageBox.Show("El codigo ingresado no existe");
                }

                else
                {
                    if (estrellas < 1 || estrellas > 5)
                    {
                        System.Windows.Forms.MessageBox.Show("Debe ingresar un valor entre 0-5");
                        r = 1;

                    }

                    else if (of.Contratado == null)
                    {
                        System.Windows.Forms.MessageBox.Show("Esta oferta no tuvo algún contratado");
                        r = 1;
                    }

                    else if (Usuario.rankear(of, estrellas, OLI) == true && r == 0)
                    {
                        bool rank = Usuario.rankear(of, estrellas, OLI);
                        System.Windows.Forms.MessageBox.Show("El usuario Nº " + of.Contratado.Rut + " fue rankeado exitosamente");
                        ST.WriteLine("El usuario Nº " + Usuario.Rut + " rankeo con " + estrellas + " al usuario Nº " + of.Contratado.Rut);


                    }
                }
                    
            }

            else
            {
                System.Windows.Forms.MessageBox.Show("No ha ingresado todos los datos");

            }

        }

        //Ofertas que se pueden comentar
        protected void OnVerComentablesClicked(object sender, EventArgs e)
        {
            OnVerRankeablesClicked(sender, e);


        }

        //Ingresar comentario
        protected void OnIngresarComentarioClicked(object sender, EventArgs e)
        {
            if(CodigoOferta6.Text != "" && Comentario6.Text != "")
            {
                int cod = Convert.ToInt32(CodigoOferta6.Text);
                string com = Comentario6.Text;
                Oferta of = OLI.GetOferta(cod);

                if (of == null)
                {
                    System.Windows.Forms.MessageBox.Show("El codigo ingresado no existe");
                }

                else if (of.Contratado == null)
                {
                    System.Windows.Forms.MessageBox.Show("Esta oferta no tuvo algún contratado");

                }

                else
                {
                    of.Contratado.Comentario.Add(com);
                    System.Windows.Forms.MessageBox.Show("Comentario ingresado correctamente");
                    ST.WriteLine("El usuario Nº " + Usuario.Rut + " ingreso un comentario sobre el usuario Nº " + of.Contratado.Rut);
                }
            }

            else
            {
                System.Windows.Forms.MessageBox.Show("No ha ingresado todos los datos");

            }

        }

        protected void OnApagarProgramaClicked(object sender, EventArgs e)
        {
            ST.WriteLine("Usuario Nº " + Usuario.Rut + " cerró el programa");
            ST.Close();
            System.Windows.Forms.MessageBox.Show("Hasta Luego!");
            this.Destroy();
        }

        protected void OnCerrarSesionClicked(object sender, EventArgs e)
        {
            ST.WriteLine("Usuario Nº " + Usuario.Rut + " cerró sesión");
            FourthWindow w4 = new FourthWindow(this.OLI, CodOf, CodPost, ST);
            this.Destroy();
            w4.Show();
        }


        //Ver Ofertas que publicó el usuario
        protected void OnVerOfertas3Clicked(object sender, EventArgs e)
        {
            foreach (Oferta of in OLI.Ofertas)
            {
                if (of.Estado == true && of.Remitente.Rut == Usuario.Rut)
                {
                    if (of.GetType() == typeof(Investigacion))
                    {
                        System.Windows.Forms.MessageBox.Show(of.Titulo + "\nCodigo: " + of.Codigo +
                                                        "\nRemuneracion: " + of.Remuneracion +
                                                        "\nVacantes: " + of.Vacantes +
                                                        "\nDescripcion: " + of.Descripcion +
                                                        "\nLugar: " + of.Evento.Lugar +
                                                        "\nDesde " + of.Evento.FechaInicio +
                                                        "\nHasta " + of.Evento.FechaTermino +
                                                        "\nRemitente de la oferta:" + of.Remitente.Nombre + " " + of.Remitente.Apellido +
                                                        "\n Es una Investigación");
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(of.Titulo + "\nCodigo: " + of.Codigo +
                                                        "\nRemuneracion: " + of.Remuneracion +
                                                        "\nVacantes: " + of.Vacantes +
                                                        "\nDescripcion: " + of.Descripcion +
                                                        "\nLugar: " + of.Evento.Lugar +
                                                        "\nDesde " + of.Evento.FechaInicio +
                                                        "\nHasta " + of.Evento.FechaTermino +
                                                        "\nRemitente de la oferta:" + of.Remitente.Nombre + " " + of.Remitente.Apellido);
                    }
                }
            }
        }

        //Postulantes de las ofertas del usuario
        protected void OnVerPostulantesClicked(object sender, EventArgs e)
        {
            if (CodigoOferta3.Text != "")
            {
                int ofert = Convert.ToInt32(CodigoOferta3.Text);
                Oferta ofer = OLI.GetOferta(ofert);
                if (ofer != null)
                {
                    List<Postulacion> p = new List<Postulacion>();

                    System.Windows.Forms.MessageBox.Show("Estos son los usuarios que postularon a su oferta:");
                    foreach (Postulacion po in OLI.Postulaciones)
                    {

                        if (po.Oferta1.Codigo == ofer.Codigo)
                        {
                            if (po.Usuario1.GetType() == typeof(Profesor))
                            {
                                System.Windows.Forms.MessageBox.Show("Nombre: " + po.Usuario1.Nombre + " " + po.Usuario1.Apellido +
                                             " \nRut: " + po.Usuario1.Rut +
                                             " \nRanking: " + po.Usuario1.RankingProm +
                                             " \nEdad: " + po.Usuario1.Edad + " " + "\nEs un profesor");
                            }

                            else if (po.Usuario1.GetType() == typeof(Alumno))
                            {
                                System.Windows.Forms.MessageBox.Show("Nombre: " + po.Usuario1.Nombre + " " + po.Usuario1.Apellido +
                                             " \nRut: " + po.Usuario1.Rut +
                                             " \nRanking: " + po.Usuario1.RankingProm +
                                             " \nEdad: " + po.Usuario1.Edad + " " + "\nEs un alumno");
                            }

                            p.Add(po);
                        }
                    }

                    if (p.Count != 0)
                    {
                        this.Destroy();
                        SixthWindow w6 = new SixthWindow(OLI, Usuario, ofer, p, CodOf, CodPost, ST);
                        w6.Show();
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("No se encuentran postulante en esa oferta");
                    }

                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("El codigo ingresado no existe");
                }
            }
                                 
        }

        //Ver rankeables
        protected void OnButton1Clicked(object sender, EventArgs e)
        {
            OnVerRankeablesClicked(sender, e);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
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


        //En esta ventana se muestran todas las opciones disponibles para el usuario, una en cada pestaña
        public FifthWindow(OfertasLaboralesInfo oli, int codOf, int codPost, Usuario usuario, bool invest) :
                base(Gtk.WindowType.Toplevel)
        {
            CodPost = codPost;
            CodOf = codOf;
            Usuario = usuario;
            OLI = oli;
            Invest = invest;
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
            System.Windows.Forms.MessageBox.Show("Usuario Nº " + Usuario.Rut + " ingrese la oferta Nº " + CodOf );
            CodOf += 1;

        }

        //Ingresar Investigación
        protected void OnButton36Clicked(object sender, EventArgs e)
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
                System.Windows.Forms.MessageBox.Show("Usuario Nº " + Usuario.Rut + " ingresó la investigación Nº " + CodOf );
                CodOf += 1;

            }

            else
            {
                System.Windows.Forms.MessageBox.Show("No ha marcado la casilla de Investigación");
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
            int codigopostulacion = Convert.ToInt32(CodigoPostulacion2.Text);
            Oferta oferta = Usuario.PostularOferta(CodPost, OLI, codigopostulacion);

            if (oferta == null)
            {
                System.Windows.Forms.MessageBox.Show("El codigo ingresado no corresponde a alguna oferta");

            }

            else
            {
                System.Windows.Forms.MessageBox.Show("Postulacion ingresada exitosamente! El codigo de esta es: " + oferta.Codigo);
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
            int cod = Convert.ToInt32(CodigoOferta4.Text);
            Oferta o = OLI.GetOferta(cod);
            if (o != null)
            {
                bool bb = Usuario.OfertaFinalizada(OLI, o);
                if (bb)
                {
                    
                    System.Windows.Forms.MessageBox.Show("Oferta dada de baja exitosamente!");

                    //sw.WriteLine("El usuario Nº " + usuario.Rut + " dio de baja la oferta Nº  " + o.Codigo);
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
                    System.Windows.Forms.MessageBox.Show("El usuario Nº " + of.Contratado + " fue rankeado exitosamente");
                    //sw.WriteLine("El usuario Nº " + usuario.Rut + " rankeo con " + estrellas + " al usuario Nº " + of.Contratado);


                }
                    
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
                //sw.WriteLine("El usuario Nº " + usuario.Rut + " ingreso un comentario sobre el usuario Nº " + of.Contratado);
            }
        }

        protected void OnApagarProgramaClicked(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Hasta Luego!");
            this.Destroy();
        }

        protected void OnCerrarSesionClicked(object sender, EventArgs e)
        {
            FourthWindow w4 = new FourthWindow(this.OLI, CodOf, CodPost);
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
                                         "Rut: " + po.Usuario1.Rut +
                                         "Ranking: " + po.Usuario1.RankingProm +
                                         "Edad: " + po.Usuario1.Edad + " " + "Es un profesor"); 
                        }

                        else if (po.Usuario1.GetType() == typeof(Alumno)) 
                        { 
                            System.Windows.Forms.MessageBox.Show("Nombre: " + po.Usuario1.Nombre + " " + po.Usuario1.Apellido +
                                         "Rut: " + po.Usuario1.Rut +
                                         "Ranking: " + po.Usuario1.RankingProm +
                                         "Edad: " + po.Usuario1.Edad + " " + "Es un alumno"); 
                        }

                        p.Add(po);
                    }
                }

                if (p.Count != 0)
                {
                    this.Destroy();
                    SixthWindow w6 = new SixthWindow(OLI, Usuario, ofer, p, CodOf, CodPost);
                    w6.Show();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("No se encuentran ofertas bajo su rut");

                }


            }
            else
            {
                System.Windows.Forms.MessageBox.Show("El codigo ingresado no existe");
            }



           

        }

        //Ver rankeables
        protected void OnButton1Clicked(object sender, EventArgs e)
        {
            OnVerRankeablesClicked(sender, e);

        }
    }
}

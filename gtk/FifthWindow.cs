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

                if (Invest == true && Area1.Text != "" &&
                Especialidad1.Text != "")
                {
                    string area = Area1.Text;
                    string especialidad = Especialidad1.Text;
                    Oferta oferta = new Investigacion(CodOf, titulo, remuneracion, vacantes, descripcion, evento, Usuario, area, especialidad, true);
                    Usuario.IngresarOferta(OLI, oferta);
                    System.Windows.Forms.MessageBox.Show("Usuario Nº " + Usuario.Rut + " ingresó la investigación Nº " + CodOf);
                    ST.WriteLine("Usuario Nº " + Usuario.Rut + " ingresó la investigación Nº " + CodOf);
                    CodOf += 1;
                    OLI.SerializableCodOf(CodOf);

                    Titulo1.Text = "";
                    Remuneracion1.Text = "";
                    Vacantes1.Text = "";
                    Descripcion1.Text = "";
                    Lugar1.Text = "";
                    Inicio1.Text = "DD/MM/AAAA";
                    Termino1.Text = "DD/MM/AAAA";
                    Area1.Text = "";
                    Especialidad1.Text = "";

                }

                else if (Invest == false)
                {
                    //Evento evento = new Evento(inicio, termino, lugar);
                    Oferta oferta = new Oferta(CodOf, titulo, remuneracion, vacantes, descripcion, evento, Usuario, true);
                    Usuario.IngresarOferta(OLI, oferta);
                    System.Windows.Forms.MessageBox.Show("Usuario Nº " + Usuario.Rut + " ingresó la oferta Nº " + CodOf);
                    ST.WriteLine("Usuario Nº " + Usuario.Rut + " ingresó la oferta Nº " + CodOf);

                    CodOf += 1;
                    OLI.SerializableCodOf(CodOf);

                    Titulo1.Text = "";
                    Remuneracion1.Text = "";
                    Vacantes1.Text = "";
                    Descripcion1.Text = "";
                    Lugar1.Text = "";
                    Inicio1.Text = "DD/MM/AAAA";
                    Termino1.Text = "DD/MM/AAAA";
                }
            }

            else
            {
                System.Windows.Forms.MessageBox.Show("No ha ingresado todo lo datos o marcado la casilla de investigacion");

            }




        }

        //Ingresar Investigación
      //  protected void OnButton36Clicked(object sender, EventArgs e)
        //{
          //  if (Titulo1.Text != "" && 
            //    Remuneracion1.Text != "" && 
              //  Vacantes1.Text != "" &&
                //Descripcion1.Text != "" &&
                //Lugar1.Text != ""&&
                //Inicio1.Text != "" &&
                //Termino1.Text != "" &&
                //Area1.Text != "" &&
                //Especialidad1.Text != "")
            //{
              //  string titulo = Titulo1.Text;
                //int remuneracion = Convert.ToInt32(Remuneracion1.Text);
               // int vacantes = Convert.ToInt32(Vacantes1.Text);
                //string descripcion = Descripcion1.Text;
                //string lugar = Lugar1.Text;
                //string inicio = Inicio1.Text;
                //string termino = Termino1.Text;
                //Evento evento = new Evento(inicio, termino, lugar);
                //string area = Area1.Text;
                //string especialidad = Especialidad1.Text;


                //if (Invest)
                //{
                  //  Oferta oferta = new Investigacion(CodOf, titulo, remuneracion, vacantes, descripcion, evento, Usuario, area, especialidad, true);
                    //Usuario.IngresarOferta(OLI, oferta);
                    //System.Windows.Forms.MessageBox.Show("Usuario Nº " + Usuario.Rut + " ingresó la investigación Nº " + CodOf);
                    //ST.WriteLine("Usuario Nº " + Usuario.Rut + " ingresó la investigación Nº " + CodOf);
                    //CodOf += 1;
                    //OLI.SerializableCodOf(CodOf);

                //}

                //else if (Invest == false)
                //{
                //    //Evento evento = new Evento(inicio, termino, lugar);
                  //  Oferta oferta = new Oferta(CodOf, titulo, remuneracion, vacantes, descripcion, evento, Usuario, true);
                    //Usuario.IngresarOferta(OLI, oferta);
                    //System.Windows.Forms.MessageBox.Show("Usuario Nº " + Usuario.Rut + " ingresó la oferta Nº " + CodOf);
                    //ST.WriteLine("Usuario Nº " + Usuario.Rut + " ingresó la oferta Nº " + CodOf);

                   // CodOf += 1;
                    //OLI.SerializableCodOf(CodOf);
                    //System.Windows.Forms.MessageBox.Show("No ha marcado la casilla de Investigación");
                //}
         //   }

           // else
            //{
              //  System.Windows.Forms.MessageBox.Show("No ha ingresado todo lo datos o marcado la casilla de");

//            }

               

            
  //      }




        protected void OnVerOfertasClicked(object sender, EventArgs e)
        {
			string s = "";
			textview10.Buffer.Text = "";
			textview10.Editable = false;

            foreach (Oferta of in OLI.Ofertas)
            {
                if (of.Estado == true)
                {

                    if (of.GetType() == typeof(Investigacion))
                    {
                        s +=  ("\nTitulo: " + of.Titulo + "\nCodigo: " + of.Codigo +
                                                        "\nRemuneracion: " + of.Remuneracion +
                                                        "\nVacantes: " + of.Vacantes +
                                                        "\nDescripcion: " + of.Descripcion +
                                                        "\nLugar: " + of.Evento.Lugar +
                                                        "\nDesde " + of.Evento.FechaInicio +
                                                        "\nHasta " + of.Evento.FechaTermino +
                                                        "\nRemitente de la oferta:" + of.Remitente.Nombre + " " + of.Remitente.Apellido +
                                                        "\n Es una Investigación\n ---------------------------------------\n");

                    }
                    else
                    {
                        s +=  ("\nTitulo: " + of.Titulo + "\nCodigo: " + of.Codigo +
                                                        "\nRemuneracion: " + of.Remuneracion +
                                                        "\nVacantes: " + of.Vacantes +
                                                        "\nDescripcion: " + of.Descripcion +
                                                        "\nLugar: " + of.Evento.Lugar +
                                                        "\nDesde " + of.Evento.FechaInicio +
                                                        "\nHasta " + of.Evento.FechaTermino +
                              "\nRemitente de la oferta:" + of.Remitente.Nombre + " " + of.Remitente.Apellido + "\n ---------------------------------------\n");

					}
                    
                    
                }
				textview10.Buffer.Text = s;
                
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
                    CodigoPostulacion2.Text = "";

                }
            }

        }

        //Mostrar Ofertas que se pueden dar de baja
        protected void OnVerBajablesClicked(object sender, EventArgs e)
        {
			string s = "";
            textview12.Buffer.Text = "";
            textview12.Editable = false;

            foreach (Oferta of in OLI.Ofertas)
            {
                if (of.Estado == true)
                {

                    if (of.GetType() == typeof(Investigacion))
                    {
                        s += ("\nTitulo: " + of.Titulo + "\nCodigo: " + of.Codigo +
                                                        "\nRemuneracion: " + of.Remuneracion +
                                                        "\nVacantes: " + of.Vacantes +
                                                        "\nDescripcion: " + of.Descripcion +
                                                        "\nLugar: " + of.Evento.Lugar +
                                                        "\nDesde " + of.Evento.FechaInicio +
                                                        "\nHasta " + of.Evento.FechaTermino +
                                                        "\nRemitente de la oferta:" + of.Remitente.Nombre + " " + of.Remitente.Apellido +
                                                        "\n Es una Investigación\n ---------------------------------------\n");

                    }
                    else
                    {
                        s += ("\nTitulo: " + of.Titulo + "\nCodigo: " + of.Codigo +
                                                        "\nRemuneracion: " + of.Remuneracion +
                                                        "\nVacantes: " + of.Vacantes +
                                                        "\nDescripcion: " + of.Descripcion +
                                                        "\nLugar: " + of.Evento.Lugar +
                                                        "\nDesde " + of.Evento.FechaInicio +
                                                        "\nHasta " + of.Evento.FechaTermino +
                              "\nRemitente de la oferta:" + of.Remitente.Nombre + " " + of.Remitente.Apellido + "\n ---------------------------------------\n");

                    }


                }
                textview12.Buffer.Text = s;

            }
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
                        CodigoOferta4.Text = "";
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
            string s = "";
            foreach (Oferta of in OLI.Ofertas)
            {
                if (of.Estado == false && of.Remitente.Rut == Usuario.Rut)
                {

                    s+= ("\nTitulo: " + of.Titulo + "\nCodigo: " + of.Codigo +
                                                        "\nRemuneracion: " + of.Remuneracion +
                                                        "\nVacantes: " + of.Vacantes +
                                                        "\nDescripcion: " + of.Descripcion +
                                                        "\nLugar: " + of.Evento.Lugar +
                                                        "\nDesde " + of.Evento.FechaInicio +
                                                        "\nHasta " + of.Evento.FechaTermino +
                                                         "\nRemitente de la oferta:" + of.Remitente.Nombre + " " + of.Remitente.Apellido + "\n ---------------------------------------\n");
                }
            }
            System.Windows.Forms.MessageBox.Show(s);
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
                        System.Windows.Forms.MessageBox.Show("El usuario Nº " + of.Contratado.Rut + " fue rankeado exitosamente en la ofera Nº " + of.Codigo);
                        ST.WriteLine("El usuario Nº " + Usuario.Rut + " rankeo con " + estrellas + " al usuario Nº " + of.Contratado.Rut);
                        CodigoOferta5.Text = "";
                        Estrellas5.Text = "";

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
			string s = "";
			textview15.Editable = false;
			textview15.Buffer.Text = "";
            foreach (Oferta of in OLI.Ofertas)
            {
                if (of.Estado == false)
                {
					if (of.Remitente.Rut == Usuario.Rut)
					{
						if(of.Contratado != null)
						{
							s += ("\nTitulo: " + of.Titulo + "\nCodigo: " + of.Codigo +
                                    "\nRemuneracion: " + of.Remuneracion +
                                    "\nVacantes: " + of.Vacantes +
                                    "\nDescripcion: " + of.Descripcion +
                                    "\nLugar: " + of.Evento.Lugar +
                                    "\nDesde " + of.Evento.FechaInicio +
                                    "\nHasta " + of.Evento.FechaTermino +
                                     "\nRemitente de la oferta:" + of.Remitente.Nombre + " " + of.Remitente.Apellido + "\n ---------------------------------------\n");
						}
					}


                }
            }

			textview15.Buffer.Text = s;


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
                    System.Windows.Forms.MessageBox.Show("Comentario ingresado xitosamente en la ofera Nº " + of.Codigo);
                    ST.WriteLine("El usuario Nº " + Usuario.Rut + " ingreso un comentario sobre el usuario Nº " + of.Contratado.Rut);
                    CodigoOferta6.Text = "";
                    Comentario6.Text = "";
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
            MainWindow w1 = new MainWindow(OLI, CodOf, CodPost, ST);
            w1.OnCerrarProgramaClicked(sender, e);
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
			textview8.Buffer.Text = "";
			textview8.Editable = false;
            string s = "";
            foreach (Oferta of in OLI.Ofertas)
            {
                if (of.Estado == true && of.Remitente.Rut == Usuario.Rut)
                {
                    if (of.GetType() == typeof(Investigacion ))
                    {
                        s += ("\nTitulo: " + of.Titulo + "\nCodigo: " + of.Codigo +
                                                        "\nRemuneracion: " + of.Remuneracion +
                                                        "\nVacantes: " + of.Vacantes +
                                                        "\nDescripcion: " + of.Descripcion +
                                                        "\nLugar: " + of.Evento.Lugar +
                                                        "\nDesde " + of.Evento.FechaInicio +
                                                        "\nHasta " + of.Evento.FechaTermino +
                                                        "\nRemitente de la oferta:" + of.Remitente.Nombre + " " + of.Remitente.Apellido +
                                                             "\n Es una Investigación\n ---------------------------------------\n");
                    }
                    else
                    {
                        s += ("\nTitulo: " + of.Titulo + "\nCodigo: " + of.Codigo +
                                                        "\nRemuneracion: " + of.Remuneracion +
                                                        "\nVacantes: " + of.Vacantes +
                                                        "\nDescripcion: " + of.Descripcion +
                                                        "\nLugar: " + of.Evento.Lugar +
                                                        "\nDesde " + of.Evento.FechaInicio +
                                                        "\nHasta " + of.Evento.FechaTermino +
                                                             "\nRemitente de la oferta:" + of.Remitente.Nombre + " " + of.Remitente.Apellido+ "\n ---------------------------------------\n");
                    }
                }
            }
			textview8.Buffer.Text = s;
        }

        //Postulantes de las ofertas del usuario
        protected void OnVerPostulantesClicked(object sender, EventArgs e)
        {
			textview2.Buffer.Text = "";
			textview2.Editable = false;
			string s = "";
            if (CodigoOferta3.Text != "")
            {
                int ofert = Convert.ToInt32(CodigoOferta3.Text);
                Oferta ofer = OLI.GetOferta(ofert);
                if (ofer != null)
                {
                    List<Postulacion> p = new List<Postulacion>();

					s += ("Estos son los usuarios que postularon a su oferta:" + "\n ---------------------------------------\n");
                    foreach (Postulacion po in OLI.Postulaciones)
                    {

                        if (po.Oferta1.Codigo == ofer.Codigo)
                        {
                            if (po.Usuario1.GetType() == typeof(Profesor))
                            {
                                s += ("Nombre: " + po.Usuario1.Nombre + " " + po.Usuario1.Apellido +
                                             " \nRut: " + po.Usuario1.Rut +
                                             " \nRanking: " + po.Usuario1.RankingProm +
								      " \nEdad: " + po.Usuario1.Edad + " " + "\nEs un profesor");
								
                            }

                            else if (po.Usuario1.GetType() == typeof(Alumno))
                            {
                                s += ("Nombre: " + po.Usuario1.Nombre + " " + po.Usuario1.Apellido +
                                             " \nRut: " + po.Usuario1.Rut +
                                             " \nRanking: " + po.Usuario1.RankingProm +
								      " \nEdad: " + po.Usuario1.Edad + " " + "\nEs un alumno");
                            }

                            p.Add(po);

							if ((po.Usuario1.Comentario.Count) > 0)
							{
								s += "Comentarios:\n";
								foreach(string com in po.Usuario1.Comentario)
								{
									s += com + "\n";
								}
							}
					        
					        s += "\n ---------------------------------------\n";
                        }
                    }

                    if (p.Count != 0)
                    {
						textview2.Buffer.Text = s;

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
			string s = "";
			textview14.Buffer.Text = "";
			textview14.Editable = false;
            foreach (Oferta of in OLI.Ofertas)
            {
				if (of.Estado == false)
				{
					if (of.Remitente.Rut == Usuario.Rut)
                {
						if(of.Contratado != null)
						{
							s += ("\nTitulo: " + of.Titulo + "\nCodigo: " + of.Codigo +
                                    "\nRemuneracion: " + of.Remuneracion +
                                    "\nVacantes: " + of.Vacantes +
                                    "\nDescripcion: " + of.Descripcion +
                                    "\nLugar: " + of.Evento.Lugar +
                                    "\nDesde " + of.Evento.FechaInicio +
                                    "\nHasta " + of.Evento.FechaTermino +
                                     "\nRemitente de la oferta:" + of.Remitente.Nombre + " " + of.Remitente.Apellido + "\n ---------------------------------------\n");
						}


                    }
				}
					
            }
			textview14.Buffer.Text = s;

        }

        protected void OnCombobox3Changed(object sender, EventArgs e)
        {
            
        }

        protected void OnTextview2InsertAtCursor(object o, Gtk.InsertAtCursorArgs args)
        {
            
        }

		protected void OnButton2Clicked(object sender, EventArgs e)
		{
			string s = "";
            textview16.Buffer.Text = "";
            textview16.Editable = false;
            foreach (Oferta of in OLI.Ofertas)
            {
                if (of.Remitente.Rut == Usuario.Rut)
                {

                    s += ("\nTitulo: " + of.Titulo + "\nCodigo: " + of.Codigo +
                                                        "\nRemuneracion: " + of.Remuneracion +
                                                        "\nVacantes: " + of.Vacantes +
                                                        "\nDescripcion: " + of.Descripcion +
                                                        "\nLugar: " + of.Evento.Lugar +
                                                        "\nDesde " + of.Evento.FechaInicio +
                                                        "\nHasta " + of.Evento.FechaTermino +
                                                         "\nRemitente de la oferta:" + of.Remitente.Nombre + " " + of.Remitente.Apellido + "\n ---------------------------------------\n");
                }
            }
            textview16.Buffer.Text = s;
		}

		protected void OnVerOfertasAceptadasClicked(object sender, EventArgs e)
		{
			string s = "";
            textview18.Buffer.Text = "";
            textview18.Editable = false;
            foreach (Oferta of in OLI.Ofertas)
            {
				if(of.Contratado != null)
				{
					if (of.Contratado.Rut == Usuario.Rut)
                    {

                        s += ("\nTitulo: " + of.Titulo + "\nCodigo: " + of.Codigo +
                                                            "\nRemuneracion: " + of.Remuneracion +
                                                            "\nVacantes: " + of.Vacantes +
                                                            "\nDescripcion: " + of.Descripcion +
                                                            "\nLugar: " + of.Evento.Lugar +
                                                            "\nDesde " + of.Evento.FechaInicio +
                                                            "\nHasta " + of.Evento.FechaTermino +
                                                             "\nRemitente de la oferta:" + of.Remitente.Nombre + " " + of.Remitente.Apellido + "\n ---------------------------------------\n");
                    }
				}

            }
            textview18.Buffer.Text = s;
		}

		protected void OnAceptarPostulanteClicked(object sender, EventArgs e)
		{
			if (CodigoOferta3.Text != "" && CodigoOferta3.Text != "")
            {
                int ofert = Convert.ToInt32(CodigoOferta3.Text);
                Oferta ofer = OLI.GetOferta(ofert);
				int rut = Convert.ToInt32(rutcontratado.Text);
                Usuario aceptado = OLI.GetUsuario(rut);
				List<Postulacion> p = new List<Postulacion>();
                if (ofer != null)
				{
					foreach (Postulacion po in OLI.Postulaciones)
                    {
                        if (po.Oferta1.Codigo == ofer.Codigo)
                        {

                            p.Add(po);
                        }
                    }
				}                

				if (ofer != null && aceptado != null)
				{
					if(ofer.Remitente.Rut == Usuario.Rut)
					{
						Oferta ofertaaceptada = Usuario.AceptarOferta(OLI, ofer, p, aceptado);

                        if (ofertaaceptada != null)
                        {
                            System.Windows.Forms.MessageBox.Show("La oferta Nº: " + ofertaaceptada.Codigo.ToString() + " fue aceptada exitosamente!");
                            ST.WriteLine("La oferta Nº " + ofertaaceptada.Codigo.ToString() + "fue aceptada");
                        }

                        else
                        {
                            System.Windows.Forms.MessageBox.Show("El rut ingresado no corresponde al de un postulante");

                        }
					}
					else
					{
						System.Windows.Forms.MessageBox.Show("Usted no es el remitente de esa oferta");

					}


				}
                				
                else
                {
                    System.Windows.Forms.MessageBox.Show("El rut ingresado o el codigo de la oferta no corresponde");

                }

                
				
			}
		}
	}
    


}

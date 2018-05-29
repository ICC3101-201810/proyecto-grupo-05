using System;
using System.IO;

namespace gtk
{
    //Iniciar Sesión
    public partial class FourthWindow : Gtk.Window
    {
        public OfertasLaboralesInfo oli;
        int CodOf;
        int CodPost;
        StreamWriter ST;

        public FourthWindow(OfertasLaboralesInfo OLI, int codOf, int codPost, StreamWriter st) :
                base(Gtk.WindowType.Toplevel)
        {
            oli = OLI;
            CodOf = codOf;
            CodPost = codPost;
            ST = st;
            Build();
        }

        protected void OnIniciarSesionClicked(object sender, EventArgs e)
        {
            if(Rut.Text != "")
            {
                int rut = Convert.ToInt32(Rut.Text);

                if (oli.GetUsuario(rut) != null)
                {
                    Usuario usuario = oli.GetUsuario(rut);
                    System.Windows.Forms.MessageBox.Show("Usuario Nº " + rut + " inició sesión correctamente");
                    ST.WriteLine("El usuario Nº " + rut + " inicio sesion");
                    this.Destroy();
                    FifthWindow w5 = new FifthWindow(this.oli, CodOf, CodPost, usuario, false, ST);
                    w5.Show();
                }

                else
                {
                    System.Windows.Forms.MessageBox.Show("La credencial/rut ingresado no existe");
                    this.Destroy();
                    MainWindow w = new MainWindow(this.oli, CodOf, CodPost, ST);
                    w.Show();
                }
            }

            else
            {
                System.Windows.Forms.MessageBox.Show("No ha ingresado una credencial/rut");

            }


        }

        protected void OnVolverClicked(object sender, EventArgs e)
        {
            this.Destroy();
            ThirdWindow w3 = new ThirdWindow(this.oli, CodOf, CodPost, ST);
            w3.Show();
            
        }

        protected void OnCerrarProgramaClicked(object sender, EventArgs e)
        {
            ST.Close();
            this.Destroy();
			MainWindow w1 = new MainWindow(this.oli, CodOf, CodPost, ST);
			w1.OnCerrarProgramaClicked(sender, e);

        }
    }
}

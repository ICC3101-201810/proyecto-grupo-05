using System;
namespace gtk
{
    //Iniciar Sesión
    public partial class FourthWindow : Gtk.Window
    {
        public OfertasLaboralesInfo oli;
        int CodOf;
        int CodPost;

        public FourthWindow(OfertasLaboralesInfo OLI, int codOf, int codPost) :
                base(Gtk.WindowType.Toplevel)
        {
            oli = OLI;
            CodOf = codOf;
            CodPost = codPost;
            Build();
        }

        protected void OnIniciarSesionClicked(object sender, EventArgs e)
        {
            int rut = Convert.ToInt32(Rut.Text);

            if (oli.GetUsuario(rut) != null)
            {
                Usuario usuario = oli.GetUsuario(rut);
                System.Windows.Forms.MessageBox.Show("Usuario Nº " + rut +  " inició sesión correctamente");
                this.Destroy();
                FifthWindow w5 = new FifthWindow(this.oli, CodOf, CodPost, usuario, false);
                w5.Show();
            }

            else
            {
                System.Windows.Forms.MessageBox.Show("La credencial/rut ingresado no existe");
                this.Destroy();
                MainWindow w = new MainWindow(this.oli, CodOf, CodPost);
                w.Show();
            }

        }

        protected void OnVolverClicked(object sender, EventArgs e)
        {
            this.Destroy();
            ThirdWindow w3 = new ThirdWindow(this.oli, CodOf, CodPost);
            w3.Show();
            
        }

        protected void OnCerrarProgramaClicked(object sender, EventArgs e)
        {
            this.Destroy();
        }
    }
}

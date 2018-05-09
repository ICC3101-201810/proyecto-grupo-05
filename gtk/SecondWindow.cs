using System;

namespace gtk
{
    //En esta interfaz se le pregunta al usuario si está ingresado o no
    public partial class SecondWindow : Gtk.Window
    {
        OfertasLaboralesInfo OLI;
        int CodOf;
        int CodPost;

        public SecondWindow(OfertasLaboralesInfo oli, int codOf, int codPost) :
                base(Gtk.WindowType.Toplevel)
        {
            CodOf = codOf;
            CodPost = codPost;
            OLI = oli;
            Build();
        }

        //Usuario Nuevo
        protected void OnSiClicked(object sender, EventArgs e)
        {
            
            this.Destroy();
            ThirdWindow w3 = new ThirdWindow(OLI, CodOf, CodPost);
            w3.Show();
        }

        //Usuario Existente
        protected void OnNoClicked(object sender, EventArgs e)
        {
            FourthWindow w4 = new FourthWindow(OLI, CodOf, CodPost);
            this.Destroy();
            w4.Show();
        }
    }
}

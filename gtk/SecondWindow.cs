using System;
using System.IO;


namespace gtk
{
    //En esta interfaz se le pregunta al usuario si está ingresado o no
    public partial class SecondWindow : Gtk.Window
    {
        OfertasLaboralesInfo OLI;
        int CodOf;
        int CodPost;
        StreamWriter ST;

        public SecondWindow(OfertasLaboralesInfo oli, int codOf, int codPost, StreamWriter st) :
                base(Gtk.WindowType.Toplevel)
        {
            CodOf = codOf;
            CodPost = codPost;
            OLI = oli;
            ST = st;
            Build();
        }

        //Usuario Nuevo
        protected void OnSiClicked(object sender, EventArgs e)
        {
            
            this.Destroy();
            ThirdWindow w3 = new ThirdWindow(OLI, CodOf, CodPost, ST);
            w3.Show();
        }

        //Usuario Existente
        protected void OnNoClicked(object sender, EventArgs e)
        {
            ST.WriteLine("Usuario no registrado cerró el programa");
            FourthWindow w4 = new FourthWindow(OLI, CodOf, CodPost, ST);
            this.Destroy();
            w4.Show();
        }
    }
}

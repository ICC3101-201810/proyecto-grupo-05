using System;
using System.IO;
using System.Collections.Generic;
namespace gtk
{
    public partial class SixthWindow : Gtk.Window
    {
        OfertasLaboralesInfo OLI;
        Usuario Usuario;
        Oferta Oferta;
        int CodOf;
        int CodPost;
        StreamWriter ST;

        List<Postulacion> P;
        public SixthWindow(OfertasLaboralesInfo oli, Usuario usuario, Oferta oferta, List<Postulacion> p, int codOf, int codPost, StreamWriter st) :
                base(Gtk.WindowType.Toplevel)
        {
            OLI = oli;
            Usuario = usuario;
            Oferta = oferta;
            P = p;
            CodOf = codOf;
            CodPost = codPost;
            ST = st;
            Build();
        }

        protected void OnAceptarPostulanteClicked(object sender, EventArgs e)
        {
            if (RutUsuario.Text != "")
            {
                int rut = Convert.ToInt32(RutUsuario.Text);
                Usuario aceptado = OLI.GetUsuario(rut);
                if (aceptado != null)
                {

                    Oferta ofertaaceptada = Usuario.AceptarOferta(OLI, Oferta, P, aceptado);

                    if (ofertaaceptada != null)
                    {
                        System.Windows.Forms.MessageBox.Show("La oferta Nº: " + ofertaaceptada.Codigo.ToString() + " fue aceptada exitosamente!");
                        ST.WriteLine("La oferta Nº " + ofertaaceptada.Codigo.ToString() + "fue aceptada");

                        FifthWindow w5 = new FifthWindow(OLI, CodOf, CodPost, Usuario, false, ST);
                        this.Destroy();
                        w5.Show();

                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("El rut ingresado no corresponde al de un postulante");

                    }

                } 
            }

            else
            {
                System.Windows.Forms.MessageBox.Show("No ha ingresado algún rut");

            }

        }

        protected void OnVolverClicked(object sender, EventArgs e)
        {
            this.Destroy();
            FifthWindow w5 = new FifthWindow(OLI, CodOf, CodPost, Usuario, false, ST);
            w5.Show();
        }
    }
}

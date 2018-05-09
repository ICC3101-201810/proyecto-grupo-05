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

        List<Postulacion> P;
        public SixthWindow(OfertasLaboralesInfo oli, Usuario usuario, Oferta oferta, List<Postulacion> p, int codOf, int codPost) :
                base(Gtk.WindowType.Toplevel)
        {
            OLI = oli;
            Usuario = usuario;
            Oferta = oferta;
            P = p;
            CodOf = codOf;
            CodPost = codPost;
            Build();
        }

        protected void OnAceptarPostulanteClicked(object sender, EventArgs e)
        {
            int rut = Convert.ToInt32(RutUsuario.Text);
            Usuario aceptado = OLI.GetUsuario(rut);
            if (aceptado != null)
            {
                Oferta ofertaaceptada = Usuario.AceptarOferta(OLI, Oferta, P, aceptado);
                if (ofertaaceptada != null)
                {
                    System.Windows.Forms.MessageBox.Show("La oferta Nº: " + ofertaaceptada.Codigo.ToString() + " fue aceptada exitosamente!");
                    //sw.WriteLine("El usuario Nº " + ofertaaceptada.Remitente.Rut + " acepto al usuario Nº " ofertaaceptada.Contratado.Rut + " en la oferta Nº " + ofertaaceptada.Codigo);

                    this.Destroy();
                    FifthWindow w5 = new FifthWindow(OLI, CodOf, CodPost, Usuario, false);
                    w5.Show();

                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("El rut ingresado no corresponde al de un postulante");

                }

            } 
        }

        protected void OnVolverClicked(object sender, EventArgs e)
        {
            this.Destroy();
            FifthWindow w5 = new FifthWindow(OLI, CodOf, CodPost, Usuario, false);
            w5.Show();
        }
    }
}

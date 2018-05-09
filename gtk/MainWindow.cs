using System;
using System.Windows;
using Gtk;
using gtk;

//En esta interfaz se le da la bienvenida al usuario
public partial class MainWindow : Gtk.Window
{
    OfertasLaboralesInfo OLI;
    int CodOf;
    int CodPost;


    public MainWindow(OfertasLaboralesInfo oli, int codOf, int CodPost) : base(Gtk.WindowType.Toplevel)
    {
        OLI = oli;
        CodPost = codOf;
        CodOf = codOf;
        Build();
    }


    protected void OnEnterClicked(object sender, EventArgs e)
    {
        SecondWindow w2 = new SecondWindow(OLI, CodOf, CodPost);
        this.Destroy();
        w2.Show();


    }

    protected void OnCerrarProgramaClicked(object sender, EventArgs e)
    {
        this.Destroy();
    }
}


                                     
                                      

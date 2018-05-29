using System;
using System.Windows;
using Gtk;
using gtk;
using System.IO;

using System.Collections.Generic;

//En esta interfaz se le da la bienvenida al usuario
public partial class MainWindow : Gtk.Window
{
    OfertasLaboralesInfo OLI;
    int CodOf;
    int CodPost;
    StreamWriter ST;


    public MainWindow(OfertasLaboralesInfo oli, int codOf, int CodPost, StreamWriter st) : base(Gtk.WindowType.Toplevel)
    {
        OLI = oli;
        CodPost = codOf;
        CodOf = codOf;
        ST = st;
        Build();

    }


    protected void OnEnterClicked(object sender, EventArgs e)
    {
        SecondWindow w2 = new SecondWindow(OLI, CodOf, CodPost, ST);
        this.Destroy();
        w2.Show();


    }

    public void OnCerrarProgramaClicked(object sender, EventArgs e)
    {
        this.Destroy();
		Application.Quit();
    }
}


                                     
                                      

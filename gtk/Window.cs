using System;
using Gtk;
namespace gtk
{
    
    public partial class Window : Gtk.Window
    {
        public Window(Gtk.WindowType windowType) :
        base(windowType)
        {
            this.Build();
        }


        protected void OnIngresarClicked(object sender, EventArgs e)
        {
           
            System.Windows.Forms.MessageBox.Show("hola");
           
        }
    }
}

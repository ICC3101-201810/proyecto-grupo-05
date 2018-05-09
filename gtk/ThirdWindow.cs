using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace gtk
{
    //Se ingresan usuario nuevos
    public partial class ThirdWindow : Gtk.Window
    {
        public OfertasLaboralesInfo OLI;
        int CodOf;
        int CodPost;

        public ThirdWindow(OfertasLaboralesInfo oli, int codOf, int codPost) :
                base(Gtk.WindowType.Toplevel)
        {
            CodPost = codPost;
            CodOf = codOf;
            OLI = oli;
            Build();
        }

        //Ingresar profesor
        protected void OnIngresarClicked(object sender, EventArgs e)
        {
            int rut = Convert.ToInt32(RutProfesor.Text);
            string nombre = NombreProfesor.Text;
            string apellido = ApellidoProfesor.Text;
            string especialidad = EspecialidadProfesor.Text;
            string descripcion = DescripcionProfesor.Text;
            int edad = Convert.ToInt32(EdadProfesor.Text);
            List<string> comentario = new List<string>();
            List<int> ranking = new List<int>();
            ranking.Add(5);

            Usuario usuario = new Profesor(rut, nombre, apellido, edad, 5, ranking, comentario, descripcion, especialidad, OLI);
            if (usuario.IngresarUsuario(OLI))
            {
                usuario.IngresarUsuario(OLI);
                System.Windows.Forms.MessageBox.Show("Usuario Ingresado correctamente, su Nº de credencial " + usuario.Rut);

                FourthWindow w4 = new FourthWindow(OLI, CodOf, CodPost);
                this.Destroy();
                w4.Show();
            }

            else
            {
                System.Windows.Forms.MessageBox.Show("Este usuario ya se encuentra ingresado");
                this.Destroy();
                this.Destroy();
                SecondWindow w2 = new SecondWindow(OLI, CodOf, CodPost);
                w2.Show();
            }
        }

        //Ingresar alumno
        protected void OnButton21Clicked(object sender, EventArgs e)
        {
            int rut = Convert.ToInt32(RutAlumno.Text);
            string nombre = NombreAlumno.Text;
            string apellido = ApellidoAlumno.Text;
            string carrera = CarreraAlumno.Text;
            string descripcion = DescripcionAlumno.Text;
            int ano = Convert.ToInt32(AnoAlumno.Text);
            int edad = Convert.ToInt32(EdadAlumno.Text);
            List<string> comentario = new List<string>();
            List<int> ranking = new List<int>();
            ranking.Add(5);

            Usuario usuario = new Alumno(rut, nombre, apellido, edad, 5, ranking, comentario, descripcion, carrera, ano, OLI);
            if (usuario.IngresarUsuario(OLI))
            {
                usuario.IngresarUsuario(OLI);
                System.Windows.Forms.MessageBox.Show("Usuario Ingresado correctamente, su Nº de credencial " + usuario.Rut);

                FourthWindow w4 = new FourthWindow(this.OLI, CodOf, CodPost);
                this.Destroy();
                w4.Show();
            }

            else
            {
                System.Windows.Forms.MessageBox.Show("Este usuario ya se encuentra ingresado");
                this.Destroy();
                SecondWindow w2 = new SecondWindow(this.OLI, CodOf, CodPost);
                w2.Show();
            }

        }

        protected void OnVolverProfesorClicked(object sender, EventArgs e)
        {
            this.Destroy();
            SecondWindow w2 = new SecondWindow(this.OLI, CodOf, CodPost);
            w2.Show();

        }

        protected void OnVolverAlumnoClicked(object sender, EventArgs e)
        {
            this.Destroy();
            SecondWindow w2 = new SecondWindow(this.OLI, CodOf, CodPost);
            w2.Show();
        }

        protected void OnRegistradoAlumnoClicked(object sender, EventArgs e)
        {
            FourthWindow w4 = new FourthWindow(this.OLI, CodOf, CodPost);
            this.Destroy();
            w4.Show();
        }

        protected void OnRegistradoProfesorClicked(object sender, EventArgs e)
        {
            FourthWindow w4 = new FourthWindow(this.OLI, CodOf, CodPost);
            this.Destroy();
            w4.Show();
        }
    }


}

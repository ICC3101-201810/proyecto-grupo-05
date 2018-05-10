using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;


namespace gtk
{
    //Se ingresan usuario nuevos
    public partial class ThirdWindow : Gtk.Window
    {
        public OfertasLaboralesInfo OLI;
        int CodOf;
        int CodPost;
        StreamWriter ST;

        public ThirdWindow(OfertasLaboralesInfo oli, int codOf, int codPost, StreamWriter st) :
                base(Gtk.WindowType.Toplevel)
        {
            CodPost = codPost;
            CodOf = codOf;
            OLI = oli;
            ST = st;
            Build();
        }

        //Ingresar profesor
        protected void OnIngresarClicked(object sender, EventArgs e)
        {
            if (RutProfesor.Text != "" &&
                NombreProfesor.Text != "" &&
                ApellidoProfesor.Text != "" &&
                EspecialidadProfesor.Text != "" &&
                DescripcionProfesor.Text != "" &&
                EdadProfesor.Text != "")
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
                    ST.WriteLine("El usuario Nº " + rut + " fue registrado");

                    FourthWindow w4 = new FourthWindow(OLI, CodOf, CodPost, ST);
                    this.Destroy();
                    w4.Show();
                }

                else
                {
                    System.Windows.Forms.MessageBox.Show("Este usuario ya se encuentra ingresado");
                    this.Destroy();
                    this.Destroy();
                    SecondWindow w2 = new SecondWindow(OLI, CodOf, CodPost, ST);
                    w2.Show();
                }
            }

            else
            {
                System.Windows.Forms.MessageBox.Show("No ha ingresado todo los datos");

            }
               

        }

        //Ingresar alumno
        protected void OnButton21Clicked(object sender, EventArgs e)
        {
            if( RutAlumno.Text != "" &&
               NombreAlumno.Text != "" &&
               ApellidoAlumno.Text != "" &&
               CarreraAlumno.Text != "" &&
               DescripcionAlumno.Text != "")
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
                    ST.WriteLine("El usuario Nº " + rut + " fue registrado");


                    FourthWindow w4 = new FourthWindow(this.OLI, CodOf, CodPost, ST);
                    this.Destroy();
                    w4.Show();
                }

                else
                {
                    System.Windows.Forms.MessageBox.Show("Este usuario ya se encuentra ingresado");
                    this.Destroy();
                    SecondWindow w2 = new SecondWindow(this.OLI, CodOf, CodPost, ST);
                    w2.Show();
                }
            }

            else
            {
                System.Windows.Forms.MessageBox.Show("No ha ingresado todo los datos");

            }



        }

        protected void OnVolverProfesorClicked(object sender, EventArgs e)
        {
            this.Destroy();
            SecondWindow w2 = new SecondWindow(this.OLI, CodOf, CodPost, ST);
            w2.Show();

        }

        protected void OnVolverAlumnoClicked(object sender, EventArgs e)
        {
            this.Destroy();
            SecondWindow w2 = new SecondWindow(this.OLI, CodOf, CodPost, ST);
            w2.Show();
        }

        protected void OnRegistradoAlumnoClicked(object sender, EventArgs e)
        {
            FourthWindow w4 = new FourthWindow(this.OLI, CodOf, CodPost, ST);
            this.Destroy();
            w4.Show();
        }

        protected void OnRegistradoProfesorClicked(object sender, EventArgs e)
        {
            FourthWindow w4 = new FourthWindow(this.OLI, CodOf, CodPost, ST);
            this.Destroy();
            w4.Show();
        }
    }


}


// This file has been generated by the GUI designer. Do not modify.
namespace gtk
{
	public partial class SixthWindow
	{
		private global::Gtk.Table table39;

		private global::Gtk.Button AceptarPostulante;

		private global::Gtk.Label label195;

		private global::Gtk.Entry RutUsuario;

		private global::Gtk.Button Volver;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget gtk.SixthWindow
			this.Name = "gtk.SixthWindow";
			this.Title = global::Mono.Unix.Catalog.GetString("SixthWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child gtk.SixthWindow.Gtk.Container+ContainerChild
			this.table39 = new global::Gtk.Table(((uint)(3)), ((uint)(3)), false);
			this.table39.Name = "table39";
			this.table39.RowSpacing = ((uint)(6));
			this.table39.ColumnSpacing = ((uint)(6));
			// Container child table39.Gtk.Table+TableChild
			this.AceptarPostulante = new global::Gtk.Button();
			this.AceptarPostulante.CanFocus = true;
			this.AceptarPostulante.Name = "AceptarPostulante";
			this.AceptarPostulante.UseUnderline = true;
			this.AceptarPostulante.Label = global::Mono.Unix.Catalog.GetString("Aceptar Postulante");
			this.table39.Add(this.AceptarPostulante);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table39[this.AceptarPostulante]));
			w1.TopAttach = ((uint)(2));
			w1.BottomAttach = ((uint)(3));
			w1.LeftAttach = ((uint)(1));
			w1.RightAttach = ((uint)(2));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table39.Gtk.Table+TableChild
			this.label195 = new global::Gtk.Label();
			this.label195.Name = "label195";
			this.label195.LabelProp = global::Mono.Unix.Catalog.GetString("Ingrese el rut del Usuario que desea aceptar");
			this.table39.Add(this.label195);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table39[this.label195]));
			w2.TopAttach = ((uint)(1));
			w2.BottomAttach = ((uint)(2));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table39.Gtk.Table+TableChild
			this.RutUsuario = new global::Gtk.Entry();
			this.RutUsuario.CanFocus = true;
			this.RutUsuario.Name = "RutUsuario";
			this.RutUsuario.IsEditable = true;
			this.RutUsuario.InvisibleChar = '●';
			this.table39.Add(this.RutUsuario);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table39[this.RutUsuario]));
			w3.TopAttach = ((uint)(1));
			w3.BottomAttach = ((uint)(2));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table39.Gtk.Table+TableChild
			this.Volver = new global::Gtk.Button();
			this.Volver.CanFocus = true;
			this.Volver.Name = "Volver";
			this.Volver.UseUnderline = true;
			this.Volver.Label = global::Mono.Unix.Catalog.GetString("Volver");
			this.table39.Add(this.Volver);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table39[this.Volver]));
			w4.TopAttach = ((uint)(2));
			w4.BottomAttach = ((uint)(3));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.table39);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 435;
			this.DefaultHeight = 300;
			this.Show();
			this.Volver.Clicked += new global::System.EventHandler(this.OnVolverClicked);
			this.AceptarPostulante.Clicked += new global::System.EventHandler(this.OnAceptarPostulanteClicked);
		}
	}
}

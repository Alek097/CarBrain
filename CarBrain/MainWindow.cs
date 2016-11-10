using System;
using Gtk;
using Gdk;
using CarBrain.System;
using CBglobal = CarBrain.System.Global;

public partial class MainWindow: Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		Pixbuf buf = new Pixbuf (CBglobal.SystemInformation.Screen.Background);

		buf = buf.ScaleSimple (
			CBglobal.SystemInformation.Screen.Width,
			CBglobal.SystemInformation.Screen.Height,
			InterpType.Bilinear);

		Pixmap map, mask;

		buf.RenderPixmapAndMask(out map, out mask, 255);

		Style style = this.Style;

		style.SetBgPixmap (StateType.Normal, map);

		this.Style = style;
	
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Startup.KillAll ();

		Application.Quit ();
		a.RetVal = true;
	}
}

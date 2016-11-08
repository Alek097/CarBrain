using System;
using Gtk;
using CarBrain.System;

public partial class MainWindow: Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Startup.KillAll ();

		Application.Quit ();
		a.RetVal = true;
	}
}

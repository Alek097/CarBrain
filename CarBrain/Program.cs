using System;
using Gtk;

namespace CarBrain
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Fullscreen ();
			Application.Run ();
		}
	}
}

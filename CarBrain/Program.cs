using System;
using Gtk;

namespace CarBrain
{
	class Program
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Fullscreen ();
			Application.Run ();
		}

		private static void RegisterServicesAndSettings()
		{
			Startup.RegisterSetting (

			);

			Startup.RegisterServices (

			);
		}
	}
}

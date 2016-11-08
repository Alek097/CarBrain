using System;
using CarBrain.System.Settings;
using Gtk;
using CarBrain.System;

namespace CarBrain
{
	class Program
	{
		public static void Main (string[] args)
		{
			Application.Init ();

			RegisterServicesAndSettings ();

			MainWindow win = new MainWindow ();
			win.Fullscreen ();
			Application.Run ();
		}

		private static void RegisterServicesAndSettings()
		{
			Startup.RegisterSetting (
				new StartMongoDB("111111")
			);

			Startup.RegisterServices (

			);
		}
	}
}

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using CarBrain.System;

namespace CarBrain.System
{
	public static class Startup
	{
		private static List<ISetting> _settings;
		private static List<Service> _services;

		public static void RegisterSetting(params ISetting[] settings)
		{
			_settings = new List<ISetting> (settings);
			
			foreach (ISetting setting in settings)
			{
				setting.Start ();
			}
		}

		public static void RegisterServices(params IService[] services)
		{
			_services = new List<Service> ();

			foreach (IService item in services) 
			{
				_services.Add (new Service (item));
			}
		}

		public static void KillAll()
		{
			_settings.ForEach (setting => setting.Kill ());
			_services.ForEach (service => service.Kill ());
		}
	}
}


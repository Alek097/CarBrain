using System;
using System.Threading.Tasks;
using CarBrain.System;
using System.Collections.Generic;
using System.Linq;

namespace CarBrain
{
	public static class Startup
	{
		private static List<ISetting> _settings;
		private static List<IService> _services;

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
			_services = new List<IService> (services);

			foreach (IService service in services)
			{
				Task.Run (() => {
					bool isNext = true;

					while(isNext)
					{
						isNext = service.Loop();
					}
				});
			}
		}

		public static void KillAll()
		{
			_settings.ForEach (setting => setting.Kill ());
			_services.ForEach (service => service.Kill ());
		}
	}
}


using System;
using System.Threading.Tasks;
using CarBrain.System;

namespace CarBrain
{
	public static class Startup
	{
		public static void RegisterSetting(params ISetting[] settings)
		{
			foreach (ISetting setting in settings)
			{
				setting.Start ();
			}
		}

		public static void RegisterServices(params IService[] services)
		{
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
	}
}


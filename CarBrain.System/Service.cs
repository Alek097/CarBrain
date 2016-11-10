using System;
using System.Threading.Tasks;

namespace CarBrain.System
{
	internal class Service
	{
		internal bool IsKill { get; private set; }
		private Task service;

		internal Service (IService service)
		{
			this.IsKill = false;

			this.service = Task.Run (() => {
				bool isNext;

				do
				{
					isNext = service.Loop(this.IsKill);

					if(this.IsKill)
					{
						break;
					}

				} while(isNext);
			});
		}

		internal void Kill()
		{
			this.IsKill = true;
			this.service.Wait ();
		}
	}
}


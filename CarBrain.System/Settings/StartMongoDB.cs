using System;
using System.Diagnostics;

namespace CarBrain.System.Settings
{
	public class StartMongoDB : ISetting
	{
		private readonly string password;
		public StartMongoDB (string password)
		{
			this.password = password;
		}

		public void Start()
		{
			Process.Start (new ProcessStartInfo () {
				FileName = "/bin/bash",
				UseShellExecute = false,
				RedirectStandardOutput = true,
				Arguments = string.Format("-c \"echo {0} | sudo -S service mongod start\"", this.password)
			});
		}
		public void Kill ()
		{
			Process.Start (new ProcessStartInfo () {
				FileName = "/bin/bash",
				UseShellExecute = false,
				RedirectStandardOutput = true,
				Arguments = string.Format("-c \"echo {0} | sudo -S service mongod stop\"", this.password)
			});
		}	
	}
}


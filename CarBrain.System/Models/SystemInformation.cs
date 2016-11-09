using System;
using System.Diagnostics;
using System.Reflection;

namespace CarBrain.System.Models
{
	public class SystemInformation
	{
		public Screen Screen { get; internal set; }

		public string OS { get; private set; }

		public string Version { get; private set; }

		internal SystemInformation() 
		{
			this.OS = Environment.OSVersion.ToString ();

			Assembly assembly = Assembly.GetExecutingAssembly();
			this.Version = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
		}
	}
}


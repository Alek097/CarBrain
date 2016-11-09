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

		internal SystemInformation(Assembly assembly) 
		{
			this.OS = Environment.OSVersion.ToString ();

			this.Version = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
		}
	}
}


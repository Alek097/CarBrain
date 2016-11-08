using System;
using System.Collections.Generic;

namespace CarBrain.System.Models
{
	public class Screen
	{
		public int Width { get; internal set; }
		public int Height { get; internal set; }
		public byte[] Background { get; set; }
		public List<Icon> Icons { get; set; }

		internal Screen() {}
	}
}


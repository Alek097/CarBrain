using System;
using System.Collections.Generic;
using descktop = System.Windows.Forms.Screen;
using System.Drawing;

namespace CarBrain.System.Models
{
	public class Screen
	{
		public int Width { get; private set; }
		public int Height { get; private set; }
		public byte[] Background { get; set; }
		public List<Icon> Icons { get; set; }

		internal Screen() 
		{
			Rectangle descktopSize = descktop.PrimaryScreen.Bounds;

			this.Width = descktopSize.Width;
			this.Height = descktopSize.Height;
		}
	}
}


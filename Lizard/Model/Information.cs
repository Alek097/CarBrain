using System;
using System.Collections.Generic;

namespace Lizard
{
	public class Information
	{
		public string Text { get; set; }
		public List<Information> InnerINformation { get; set; } = new List<Information>();
	}
}


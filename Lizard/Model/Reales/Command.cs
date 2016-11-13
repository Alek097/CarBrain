using System;

namespace Lizard.Model.Reales
{
	public class Command
	{
		public CommandType CommandType { get; set; }

		public Command (CommandType type)
		{
			this.CommandType = type;
		}

		public Command () { }
	}
}


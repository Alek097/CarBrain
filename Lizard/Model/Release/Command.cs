﻿using System;

namespace Lizard.Model.Release
{
	public class Command
	{
		public CommandType CommandType { get; set; }
		public string Type { get; set; }

		internal Command (CommandType commandType)
		{
			this.CommandType = commandType;
		}

		public Command () { }
	}
}


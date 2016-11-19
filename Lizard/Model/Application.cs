using System;
using System.Collections.Generic;
using Lizard.Interpreter;
using Lizard.Model.Release;

namespace Lizard.Model
{
	public class Application
	{
		public InterpreterVersion InterpreterVersion { get; set; }
		public string AppType { get; set; }
		public string Version { get; set; }
		public string Author { get; set; }
		public IEnumerable<Command> Main { get; set; }
	}
}


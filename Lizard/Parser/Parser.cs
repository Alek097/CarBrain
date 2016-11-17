using System;
using Lizard.Interpreter;

namespace Lizard.Parser
{
	public sealed class Parser
	{
		private readonly string[] bannedSymbol = new string[] {
			"var",
			"goto"
		};
		
		private Parser () { }

		public IInterpreter Interpreter { get; set; }

		public static Parser FromText(string text, IInterpreter interpreter)
		{



			string code = text
				.Replace ("\n", string.Empty)
				.Replace("\t", string.Empty);

			return new Parser ();
		}
	}
}


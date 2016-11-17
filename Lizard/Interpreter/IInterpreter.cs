using System;
using System.Collections.Generic;
using Lizard.Debug;

namespace Lizard.Interpreter
{
	public interface IInterpreter
	{
		void StartReleas();
		IEnumerable<CommandDebug> Debug ();
	}
}


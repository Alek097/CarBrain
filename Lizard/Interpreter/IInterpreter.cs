using System;
using System.Collections.Generic;
using Lizard.Model.Debug;

namespace Lizard.Interpreter
{
	public interface IInterpreter
	{
		void StartReleas();
		IEnumerable<CommandDebug> Debug ();
	}
}


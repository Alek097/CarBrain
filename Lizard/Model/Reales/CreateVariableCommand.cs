using System;
using System.Numerics;

namespace Lizard.Model.Reales
{
	public class CreateVariableCommand<TValue> : Command
	{
		public string Name { get; set; }
		public TValue Value { get; set; }
		public LizardType Type { get; set; }

		public CreateVariableCommand (string Name, TValue value)
			:base(CommandType.CreateVariable)
		{
			this.Name = Name;
			this.Value = value;

			Type valueType = typeof(TValue);

			if (valueType == typeof(BigInteger)) 
			{
				this.Type = LizardType.Numeric;
			} 
			else if (valueType == typeof(string)) 
			{
				this.Type = LizardType.String;
			} 
			else if (valueType == typeof(bool)) 
			{
				this.Type = LizardType.Boolean;
			} 
			else 
			{
				this.Type = LizardType.Custom;
			}
		}

		public CreateVariableCommand ()
		{
			
		}
	}
}


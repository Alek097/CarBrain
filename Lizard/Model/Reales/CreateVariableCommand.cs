using System;
using System.Numerics;

namespace Lizard.Model.Reales
{
	public class CreateVariableCommand<TValue> : Command
	{
		public string Name { get; set; }
		public TValue Value { get; set; }
		public LizardType ValueType { get; set; }

		internal CreateVariableCommand (string Name, TValue value)
			:base(CommandType.CreateVariable)
		{
			this.Name = Name;
			this.Value = value;
			base.Type = this.GetType ().ToString ();

			Type valueType = typeof(TValue);

			if (valueType == typeof(BigInteger)) 
			{
				this.ValueType = LizardType.Numeric;
			} 
			else if (valueType == typeof(string)) 
			{
				this.ValueType = LizardType.String;
			} 
			else if (valueType == typeof(bool)) 
			{
				this.ValueType = LizardType.Boolean;
			} 
			else 
			{
				this.ValueType = LizardType.Custom;
			}
		}

		public CreateVariableCommand ()
		{
			
		}
	}
}


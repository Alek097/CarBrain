using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Lizard.Interpreter;
using Lizard.Model.Release;

namespace Lizard.Parser
{
	public sealed class Parser
	{
		private static readonly List<string> BannedWords = new List<string>() {
			"var",
			"goto",
			"method",
			"class",
			"enum",
			"if",
			"else",
			"interface",
			"public",
			"private",
			"internal",
			"protected"
		};

		private static readonly List<char> BannedSymbols = new List<char>(){
			',',
			'+',
			'~',
			'^',
			'<',
			'>',
			'|',
			'/',
			'\\',
			'.',
			'[',
			']',
			'{',
			'}',
			'`',
			'!',
			'@',
			'"',
			'#',
			'№',
			'$',
			';',
			':',
			'%',
			'&',
			'?',
			'*',
			'(',
			')',
			'-',
			'=',
			'\'',
			' ',
			'0',
			'1',
			'2',
			'3',
			'4',
			'5',
			'6',
			'7',
			'8',
			'9'
		};
		
		private Parser () { }

		public IInterpreter Interpreter { get; set; }

		public static Parser FromText(string text, IInterpreter interpreter)
		{
			List<Command> commands = new List<Command> ();

			string code = text
				.Replace ("\n", string.Empty)
				.Replace("\t", string.Empty);

			foreach (string unknownCommand in code.Split(';'))
			{
				if (unknownCommand == string.Empty)
				{
					continue;
				}

				if(Regex.IsMatch(unknownCommand, @"var\s*\w+\b\s*:\s*\w+\s*(=\s*.+?)?(,\s*\w+\b\s*:\s*\w+\s*(=\s*.+?))?"))
				{
					commands.AddRange(
						ParseCreateVariable(unknownCommand));
				}
			}
			return new Parser ();
		}

		private static IEnumerable<Command> ParseCreateVariable(string text)
		{
			List<Command> commands = new List<Command> ();

			text = text.Replace ("var", string.Empty);

			foreach (string newVar in text.Split(','))
			{
				string[] varSplit = newVar.Split (':');

				if (varSplit.Length < 2) 
				{
					//TODO: THROW EXCEPTION
					return null;
				} 


				string varName = RemoveSpaceAroundWord (varSplit [0]);

				char firstSymbol = varName [0];

				if(string.IsNullOrWhiteSpace(varName))
				{
					//TODO: THROW EXCEPTION
					return null;
				}
				else if (BannedWords.Contains (varName)) 
				{
					//TODO: THROW EXCEPTION
					return null;
				} 
				else if (BannedSymbols.Contains (firstSymbol)) 
				{
					//TODO: THROW EXCEPTION
					return null;
				} 
				else 
				{
					foreach (char symbol in varName) 
					{
						if(BannedSymbols.Contains(symbol))
						{
							//TODO: THROW EXCEPTION
							return null;
						}
					}
				}

				string varVal = null;
				string varType = null;

				if (varSplit [1].Contains ("="))
				{
					varSplit = varSplit [1].Split ('=');

					if (varSplit.Length < 2) 
					{
						//TODO: THROW EXCEPTION
						return null;
					}

					varType = RemoveSpaceAroundWord(varSplit [0]);

					varVal = varSplit [1];

					if (string.IsNullOrWhiteSpace (varVal)) 
					{
						//TODO: THROW EXCEPTION
						return null;
					}
				}
				else 
				{
					varType = RemoveSpaceAroundWord(varSplit [1]);
					varVal = null;
				}

				switch (varType) 
				{
				case "numeric":

					BigInteger value;

					try
					{
						value = varVal == null ? 0 : BigInteger.Parse(varVal);
					}
					catch
					{
						//TODO: THROW EXCEPTION
						throw;
					}


					commands.Add (new CreateVariableCommand<BigInteger> () 
						{
							Name = varName,
							Value = value,
							ValueType = LizardType.Numeric
						});
					break;

				case "string":
					if (varVal == null)
					{
						varVal = "null";
					}
					else if (Regex.IsMatch (varVal, "\"" + @"(.|\s)+" + "\"")) 
					{
						varVal = Regex.Replace (varVal, @"\s*" + "\"", string.Empty);
						varVal = Regex.Replace (varVal, "\"" + @"\s*", string.Empty);
					}
					else if (Regex.IsMatch (varVal, "'" + @"(.|\s)+" + "'"))
					{
						varVal = Regex.Replace (varVal, @"\s*'", string.Empty);
						varVal = Regex.Replace (varVal, @"'\s*", string.Empty);
					} 
					else 
					{
						//TODO: THROW EXCEPTION
						return null;
					}

					commands.Add (new CreateVariableCommand<string> () {
						Name = varName,
						Value = varVal,
						ValueType = LizardType.String
					});

					break;

				case "boolean":
					bool value_bool;

					try
					{
						value_bool = varVal == null ? false : bool.Parse (varVal);
					}
					catch
					{
						//TODO: THROW EXCEPTION
						throw;
					}

					commands.Add (new CreateVariableCommand<bool> ()
						{
							Name = varName,
							Value = value_bool,
							ValueType = LizardType.Boolean
						});
					
					break;

				default:

					//TODO: No idea

					break;
				}

			}

			return commands;
		}
		private static string RemoveSpaceAroundWord(string word)
		{
			word = Regex.Replace (word, @"\s*\b", string.Empty);
			word = Regex.Replace (word, @"\b\s*", string.Empty);

			return word;
		}

	}
}


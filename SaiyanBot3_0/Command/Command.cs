using System;
using System.Linq;
using System.Collections.Generic;

namespace SaiyanBot3_0.Command
{
	public class Command
	{
		public bool IsDiscord { get; protected set; }
		public bool IsTwitch { get; protected set; }

		protected string script;

		public Command()
		{

		}

		public abstract void Execute();
	}
}
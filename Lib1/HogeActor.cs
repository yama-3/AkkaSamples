using System;

using Akka.Actor;

namespace Lib1
{
	public class HogeActor : UntypedActor
	{
		public HogeActor ()
		{
		}
	
		protected override void OnReceive(object message)
		{
			Console.WriteLine (message);
		}
	}
}


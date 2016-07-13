using System;
using Akka.Actor;
using System.Threading;

namespace Lib1
{
	public class GreetingActor : ReceiveActor /*TypedActor , IHandle<Greet>*/
	{
		public GreetingActor()
		{
			Receive<Greet>(greet => {
				Thread.Sleep(5000);
				Console.WriteLine("Hello {0}, ({1})", greet.Who, greet.CreatedAt);
			});
		}
		/*
		public void Handle(Greet greet)
		{
			Console.WriteLine("Hello {0}!", greet.Who);
		}
		*/
	}

}


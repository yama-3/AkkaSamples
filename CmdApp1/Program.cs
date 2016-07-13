using System;
using System.Threading;

using Akka;
using Akka.Actor;

using Lib1;

namespace CmdApp1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// Create a new actor system (a container for your actors)
			var system = ActorSystem.Create("MySystem");

			// Create your actor and get a reference to it.
			// This will be an "ActorRef", which is not a
			// reference to the actual actor instance
			// but rather a client or proxy to it.
			var greeter = system.ActorOf<GreetingActor>("greeter");

			// Send a message to the actor
			greeter.Tell(new Greet("1"));
			greeter.Tell(new Greet("2"));
			greeter.Tell(new Greet("3"));
			greeter.Tell(new Greet("4"));
			greeter.Tell(new Greet("5"));



			// This prevents the app from exiting
			// before the async work is done
			Console.ReadLine();
		}
	}
}

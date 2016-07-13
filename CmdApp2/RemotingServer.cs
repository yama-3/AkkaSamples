using System;

using Akka;
using Akka.Actor;
using Akka.Configuration;
using Akka.Remote;
using Lib1;

namespace CmdApp2
{
	class MainClass
	{
		static void Main(string[] args)
		{
			var config = ConfigurationFactory.ParseString(@"
			akka {
			    actor {
			        provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
			    }
			    remote {
			        helios.tcp {
			            port = 8080
			            hostname = localhost
			        }
			    }
			}");

			using (var sys1 = ActorSystem.Create("MyServer1", config))
			using (var sys2 = ActorSystem.Create("MyServer2", config))
			{
				sys1.ActorOf<GreetingActor>("greeter");
				sys2.ActorOf<HogeActor> ("hoger");
				Console.ReadKey();
			}
		}
	}
}

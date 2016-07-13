using System;
using System.Threading;

using Akka;
using Akka.Configuration;
using Akka.Actor;

using Lib1;

namespace CmdApp3
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var config = ConfigurationFactory.ParseString(@"akka {
				actor {
					provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
				}
				remote {
					helios.tcp {
						port = 8090
						hostname = localhost
					}
				}
			}");

			using(var system = ActorSystem.Create("MyClient", config))
			{
				var greeter = system.ActorSelection("akka.tcp://MyServer@localhost:8080/user/greeter");
				for (int idx = 0; idx < 10; idx++) {
					greeter.Tell (new Greet ("Roger" + idx.ToString()));
					Thread.Sleep(100);
				}

				var hoger = system.ActorSelection("akka.tcp://MyServer@localhost:8080/user/hoger");
				for (int idx = 0; idx < 10; idx++) {
					hoger.Tell (new Hoge("yama3"));
					Thread.Sleep(100);
				}
			}
		}
	}
}

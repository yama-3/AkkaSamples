using System;

using Akka;
using Akka.Actor;
using Akka.Configuration;

namespace TestApp1
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
			
			using (var system = ActorSystem.Create ("MyClient", config)) {
				var target = system.ActorOf (Props.Empty);
				var inbox = Inbox.Create (system);
				inbox.Send (target, "hello");
				try {
					var result = inbox.Receive (TimeSpan.FromSeconds (1)).Equals ("world");
					Console.WriteLine(result);
				} catch (TimeoutException) {
					Console.WriteLine ("timeout");
				}
			}
		}
	}
}

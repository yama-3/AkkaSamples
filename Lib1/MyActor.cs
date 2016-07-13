using Akka;
using Akka.Actor;
using Akka.Event;
using Akka.Logger.NLog;

public class MyActor: ReceiveActor
{
	ILoggingAdapter _log = Logging.GetLogger(Context);

	public MyActor()
	{
		Receive<string>(message => {
			_log.Info("Received String message: {0}", message);
			Sender.Tell(message);
		});
		//Receive<SomeMessage(message => {...});
	}
}
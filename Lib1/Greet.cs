using System;

namespace Lib1
{
	public class Greet
	{
		public Greet(string who)
		{
			Who = who;
			CreatedAt = DateTime.Now;
		}
		public string Who { get;private set; }
		public DateTime CreatedAt { get; private set; }
	}
}


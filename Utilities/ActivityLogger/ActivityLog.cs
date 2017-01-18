using System;
namespace Utilities.ActivityLogger
{
	public class ActivityMessage : Message
	{
		private string _UserName;
		public ActivityMessage(string message): base(message)
		{
			//figure out how to get the current user

		}

	}
}

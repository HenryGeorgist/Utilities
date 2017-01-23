using System;
namespace Utilities
{
	public static class MessageHub
	{
		public static void ReportMessage(Message message)
		{
			switch (message.GetType().Name)
			{
				case nameof(Logger.ErrorMessage):
					Logger.Log.Instance.LogMessage((Logger.ErrorMessage)message);
					break;
				default:

					break;
			}
		}
	}
}

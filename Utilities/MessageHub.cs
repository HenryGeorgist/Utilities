using System;
namespace Utilities
{
	public static class MessageHub
	{
		public static void ReportMessage(AbstractMessage message)
		{
			switch (message.GetType().Name)
			{
				case nameof(Logger.ErrorMessage):
					Logger.Log.Instance.LogMessage((Logger.ErrorMessage)message);
					break;
				default:
					MessageEnum newenum = message.MessageEnum;
					newenum &= ~MessageEnum.DoNotWriteToLog;//ensure it can be written to the log file.
					Logger.Log.Instance.LogMessage(new Logger.ErrorMessage(message.Message, newenum));
					break;
			}
		}
	}
}

using System;
namespace Utilities
{
	public abstract class AbstractMessage
	{
		private readonly MessageEnum _MessageEnum;
		private readonly string _Message;
		private readonly System.DateTime _DateTime;
		public MessageEnum MessageEnum
		{
			get
			{
				return _MessageEnum;
			}
		}
		public string Message
		{
			get
			{
				return _Message;
			}
		}
		protected AbstractMessage(string message, MessageEnum state)
		{
			_Message = message;
			_MessageEnum = state;
			_DateTime = System.DateTime.Now;
		}
	}
}

using System;
namespace Utilities
{
	public class Message
	{
		private readonly string _Message;
		private readonly System.DateTime _DateTime;
		public string message
		{
			get
			{
				return _Message;
			}
		}
		protected Message(string theMessage)
		{
			_Message = theMessage;
			_DateTime = System.DateTime.Now;
		}
	}
}

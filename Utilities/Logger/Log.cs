namespace Utilities.Logger
{
    public sealed class Log
    {
        #region Fields
        private string _LogFile;
        private static Log _Instance = new Log();
		private static System.Collections.Concurrent.ConcurrentStack<ErrorMessage> _Stack;
        #endregion
        #region Properties
        public static Log Instance
        {
            get{return _Instance;}
        }
        #endregion
        #region Constructors
        private Log(){

        }
		public void LogMessage(ErrorMessage message)
		{
			_Stack.Push(message);
			if (_Stack.Count > 100) Flush();
		}
		public void Flush()
		{
		}
        #endregion
    }
}
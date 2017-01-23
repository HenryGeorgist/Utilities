namespace Utilities.Logger
{
	public sealed class Log
	{
		#region Fields
		private string _LogFile;//store a sqliteconnection instead?
		private static ErrorEnum _LogLevel = ErrorEnum.Fine;
		private static Log _Instance = new Log();
		private static object _SyncLock = new object();
		private static System.Collections.Concurrent.ConcurrentQueue<ErrorMessage> _Queue;
		#endregion
		#region Properties
		public static Log Instance
		{
			get { return _Instance; }
		}
		public string LogFile
		{
			get
			{
				return _LogFile;
			}
		}
		#endregion
		#region Constructors
		private Log()
		{
			if (_LogFile == null || _LogFile == "")
			{
				CreateTempFilePath();
			}
			_Queue = new System.Collections.Concurrent.ConcurrentQueue<ErrorMessage>();
		}
		#endregion
		#region Methods
		public void LogMessage(ErrorMessage message)
		{
			_Queue.Enqueue(message);
			if (_Queue.Count > 100) Flush();
		}
		public void Flush()
		{
			if (_Queue.Count == 0) return;
			lock (_SyncLock)
			{
				System.Collections.Generic.List<ErrorMessage> messages = new System.Collections.Generic.List<ErrorMessage>();
				//SQLite.SQLiteAsyncConnection sql = new SQLite.SQLiteAsyncConnection(_LogFile, SQLite.SQLiteOpenFlags.Create);
				SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(_LogFile, SQLite.SQLiteOpenFlags.Create);
				//sql.CreateTableAsync<ErrorMessage>();
				sql.CreateTable<ErrorMessage>();
				ErrorMessage e = null;
				//dequeue all messages at this time, just in case additional messages get added while writing.
				do
				{
					if (_Queue.TryDequeue(out e))
					{
						messages.Add(e);
					}
				} while (_Queue.Count > 0);
				//write to sql using orm.
				using (sql)
				{
					foreach (ErrorMessage error in messages)
					{
						if (e.ErrorEnum <= _LogLevel)//not 100% sure this works.
						{
							//sql.InsertAsync(error);
							sql.Insert(error);
						}
					}
				}

			}

		}
		private async void CreateTempFilePath()
		{
			PCLStorage.IFolder folder = PCLStorage.FileSystem.Current.LocalStorage;
			PCLStorage.IFolder projectdir = await folder.CreateFolderAsync("Logger", PCLStorage.CreationCollisionOption.OpenIfExists);
			PCLStorage.IFile tmp = await projectdir.CreateFileAsync("Log", PCLStorage.CreationCollisionOption.ReplaceExisting);
			_LogFile = tmp.Name;	
		}
		#endregion
	}
}
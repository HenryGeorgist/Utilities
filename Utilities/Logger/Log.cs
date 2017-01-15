namespace Logger
{
    public sealed class Log
    {
        #region Fields
        private string _LogFile;
        private static Log _Instance = new Log();
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
        #endregion
    }
}
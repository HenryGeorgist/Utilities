namespace Logger
{
    public class ErrorMessage
    {
        private readonly ErrorEnum _ErrorState;
        private readonly string _ErrorMessage;
        private readonly string _CallingMethod;//would rather calling assembly
        private readonly string _CallingFile;
        private readonly int _CallingLine;
        public string CallingMethod{
            get{return _CallingMethod;}
        }
        public string CallingFile{
            get{return _CallingFile;}
        }
        public int CallingLine{
            get{return _CallingLine;}
        }
        public ErrorMessage(string message, ErrorEnum state, [System.Runtime.CompilerServices.CallerMemberNameAttribute] string memberName = "", [System.Runtime.CompilerServices.CallerFilePathAttribute] string filePath = "", [System.Runtime.CompilerServices.CallerLineNumberAttribute] int lineNo = 0 ){
            _ErrorMessage = message;
            _ErrorState = state;
            _CallingMethod = memberName;
            _CallingFile = filePath;
            _CallingLine = lineNo;
            //get calling assembly...
        }
    }
}
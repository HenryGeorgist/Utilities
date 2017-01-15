namespace Utilities.Logger
{
    public class ErrorMessage : AbstractMessage
	{
        private readonly string _CallingMethod;//would rather calling assembly
        private readonly string _CallingFile;
		private readonly int _CallingLine;


		public ErrorMessage(string message, MessageEnum state, [System.Runtime.CompilerServices.CallerMemberNameAttribute] string memberName = "", [System.Runtime.CompilerServices.CallerFilePathAttribute] string filePath = "", [System.Runtime.CompilerServices.CallerLineNumberAttribute] int lineNo = 0 ) : base(message, state){
            _CallingMethod = memberName;
            _CallingFile = filePath;
            _CallingLine = lineNo;

            //get calling assembly...
        }
		public override string ToString()
		{
			return string.Format("MessageEnum={0} Error={1}" + "/n" + "Calling Method: " + _CallingMethod + "/n" + "File Path: " + _CallingFile + "/n" + "Error Line: " + _CallingLine + "/n" + "Calling Time: " + _DateTime.ToString(), MessageEnum, Message);
		}
    }
}
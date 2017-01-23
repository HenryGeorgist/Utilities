namespace Utilities.Logger
{
	[System.Flags]
    public enum ErrorEnum : byte
    {
        Unassigned = 0x00,
        //log severities.
		Minor = 0x01,
        Major = 0x02,
        Fatal = 0x04,
        //reserved for later expansion = 0x08,
		//Log levels.
        //reserved for later expansion = 0x10,
		/// <summary>
		/// A log level reserved for things that are fairly essential to report to the users
		/// </summary>
        Coarse = 0x20,//if loglevel is not set, it is assumed to be coarse.
		/// <summary>
		/// A log level reserved for things a user should know about.
		/// </summary>
        Medium = 0x40,
		/// <summary>
		/// For those chatty Cathys...
		/// </summary>
        Fine = 0x80
    }
}
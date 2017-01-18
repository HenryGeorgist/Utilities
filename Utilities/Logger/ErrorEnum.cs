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
        Fine = 0x10,
        Medium = 0x20,
        Coarse = 0x40,
        //reserved for later expansion = 0x80
    }
}
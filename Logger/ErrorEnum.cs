namespace Logger
{
    public enum ErrorEnum : byte
    {
        Unassigned = 0x00,
        Report = 0x01,
        Minor = 0x02,
        Major = 0x04,
        Fatal = 0x08,
        WriteToLog = 0x10,
        MessageUser = 0x20,
        RequestYesNo = 0x40,
        RequestYesNoCancel = 0x80
    }
}
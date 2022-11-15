using Colored_Logger;
using System.Diagnostics;

TestCodes testCode = TestCodes.Write;


if (testCode == TestCodes.Write)
{
    Logger.Write("{blue}Hello{end} The {green}World{end}");
}
else if (testCode == TestCodes.WriteLine)
{
    Logger.WriteLine("{red}Write {cyan}Line");
}
else if (testCode == TestCodes.Log)
{
    Logger.Log($"{{red}}This {{yellow}}Is {{cyan}}Log");
}
else if (testCode == TestCodes.Error)
{
    Logger.Error("The Custom Error Message");
}
else if (testCode == TestCodes.ExceptionError)
{
    try
    {
        int.Parse("MrYusuf");
    }
    catch (Exception ex)
    {
        Logger.Error(ex);
    }
}
else if (testCode == TestCodes.FatalError)
{
    Logger.FatalError("The Custom Fatal Error");
}
else if (testCode == TestCodes.ExceptionFatalError)
{
    try
    {
        int.Parse("MrYusuf");
    }
    catch (Exception ex)
    {
        Logger.FatalError(ex);
    }
}
else if (testCode == TestCodes.Clear)
{
    Logger.WriteLine("If you hit the enter key, this will clear the console screen.");
    Logger.ReadLine();
    Logger.Clear();
}
else if (testCode == TestCodes.ReadLine)
{
    var tempString = Logger.ReadLine(">>>");
    Logger.Log("{blue}You typed :{end}" + tempString);
}
else if (testCode == TestCodes.ReadInt)
{
    var tempInt = Logger.ReadInt(3, "please enter an int :");
    Logger.Log(tempInt.HasValue ? "{blue}You typed :{end}" + tempInt.Value : "{red}You entered wrong 3 times.");
}
else if (testCode == TestCodes.ReadType)
{
    var tempByte = (byte?)Logger.ReadType(typeof(byte), 3, "please enter an byte :");
    Logger.Log(tempByte.HasValue ? "{blue}You typed :{end}" + tempByte.Value : "{red}You entered wrong 3 times.");
}
else if (testCode == TestCodes.ReadTypeGeneric)
{
    var tempBool = Logger.ReadType<bool>(-1, "please enter an bool :");
    Logger.Log("{blue}You typed :{end}" + tempBool.GetValueOrDefault());
}
else if (testCode == TestCodes.ReadClassType)
{
    var tempCustomClass = Logger.ReadClassType<CustomClass>(3, "please enter an CustomClass :");
    Logger.Log("{blue}You typed :{end} CustomClass.Name = " + tempCustomClass?.Name);
}
else if (testCode == TestCodes.ReadCommand)
{
    var tempCmd = Logger.ReadCommand("Plase enter command:");
    Logger.Log($"Cmd : {tempCmd.cmd} | Args = [{string.Join(", ", tempCmd.args)}]");
}
else if (testCode == TestCodes.StartMenu)
{
    var commands = new Dictionary<string, string>()
    {
        { "hello", "prints hello world to console screen"},
        { "ram", "Shows instant ram usage"},
        { "break", "stops the menu"},
    };
    Logger.StartMenu(commands, StartMenuCallback);
}
else if (testCode == TestCodes.StartMenu2)
{
    var commands = new Dictionary<string, string>()
    {
        { "hello", "prints hello world to console screen"},
        { "ram", "Shows instant ram usage"},
        { "break", "stops the menu"},
    };
    Logger.StartMenu(commands, (Logger.MenuResult result) =>
    {
        if (result.Command == "hello")
        {
            Logger.WriteLine("Hello world");
        }
        else if (result.Command == "ram")
        {
            Logger.WriteLine(((Process.GetCurrentProcess().PrivateMemorySize64) / (float)1024 / (float)1024) + " MB");
        }
        else if (result.Command == "break")
        {
            result.Break = true;
        }
    });
}





void StartMenuCallback(Logger.MenuResult result)
{
    if (result.Command == "hello")
    {
        Logger.WriteLine("Hello world");
    }
    else if (result.Command == "ram")
    {
        Logger.WriteLine(((Process.GetCurrentProcess().PrivateMemorySize64) / (float)1024 / (float)1024) + " MB");
    }
    else if (result.Command == "break")
    {
        result.Break = true;
    }
}




class CustomClass
{
    public string? Name { get; init; }
    public static CustomClass Parse(string value)
    {
        return new CustomClass() { Name = value };
    }
}

enum TestCodes
{
    Write,
    WriteLine,
    Log,
    Error,
    ExceptionError,
    FatalError,
    ExceptionFatalError,
    Clear,
    ReadLine,
    ReadInt,
    ReadType,
    ReadTypeGeneric,
    ReadClassType,
    ReadCommand,
    StartMenu,
    StartMenu2,
}
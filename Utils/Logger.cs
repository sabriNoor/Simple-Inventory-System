namespace SimpleInventorySystem.Utils;

public static class Logger
{
    private const string FileName = "log.txt";
    private static readonly object lockObj = new();
    private static readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(),"Logs", FileName);
    static Logger()
    {
        if (!File.Exists(filePath))
        {
            using (File.Create(filePath)) { }
        }
    }

    public static void LogInfo(string message) => WriteLog("INFO", message);

    public static void LogError(string message) => WriteLog("ERROR", message);

    public static void LogWarning(string message) => WriteLog("WARNING", message);

    public static void LogDebug(string message) => WriteLog("DEBUG", message);



    private static void WriteLog(string level, string message)
    {
        var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
        lock (lockObj)
        {
            File.AppendAllText(filePath, logEntry + Environment.NewLine);
        }
        Console.WriteLine(logEntry);

    }


}
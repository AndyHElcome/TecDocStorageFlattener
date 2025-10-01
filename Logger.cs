using Serilog;
using Serilog.Events;

public static class Logger
{
    public static ILogger Log = SetupLogger("..\\Logs\\Log.txt");
    public static ILogger SetupLogger(string filePath)
    {
#if DEBUG
        filePath = $"..\\Logs\\Log.txt";
#endif

        return new LoggerConfiguration() // TODO put into application settings
            .MinimumLevel.Debug()
            .WriteTo.Console(outputTemplate: "[{Level:u3}] {Message:l}{NewLine}{Exception}")
            .WriteTo.File(filePath,
                            rollOnFileSizeLimit: true,
                            fileSizeLimitBytes: 1048576,
                            shared: true,
                            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:l}{NewLine}{Exception}",
                            restrictedToMinimumLevel: LogEventLevel.Information)
            .CreateLogger();
    }
}

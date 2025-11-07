using Serilog;
using Serilog.Events;
using System;
using System.IO;

namespace CoreLayer.Logging
{
    public static class Log
    {
        public static ILogger Logger { get; private set; }

        public static void Initialize()
        {
            string logDir = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            Directory.CreateDirectory(logDir);

            string logFile = Path.Combine(logDir, $"test_log_{DateTime.Now:yyyyMMdd_HHmmss}.txt");

            Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.WithThreadId()
                .Enrich.WithProcessId()
                .Enrich.FromLogContext()
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
                .WriteTo.File(
                    logFile,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 7,
                    outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level:u3}] (Thread:{ThreadId}) {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            Logger.Information("Logger initialized.");
        }

        public static void Info(string message) => Logger?.Information(message);
        public static void Warn(string message) => Logger?.Warning(message);
        public static void Error(string message, Exception ex = null) =>
            Logger?.Error(ex, message);
        public static void Debug(string message) => Logger?.Debug(message);
    }
}

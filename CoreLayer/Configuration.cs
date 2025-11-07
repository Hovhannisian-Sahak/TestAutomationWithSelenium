using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace CoreLayer.Config
{
    public static class Configuration
    {
        public static BrowserType BrowserType { get; private set; }
        public static string AppUrl { get; private set; }
        public static string TestDataPath { get; private set; }

        static Configuration() => Init();

        public static void Init()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var browserTypeValue = config["BrowserType"] ?? "Firefox";
            if (!Enum.TryParse(browserTypeValue, true, out BrowserType browserType))
                browserType = BrowserType.Firefox;

            BrowserType = browserType;
            AppUrl = config["ApplicationUrl"] ?? string.Empty;
            TestDataPath = config["TestDataPath"] ?? string.Empty;

            var b = config["BrowserType"];
            var appUrl = config["ApplicationUrl"];
            var testDataPath = config["TestDataPath"];

            Console.WriteLine($"BrowserType: {b}");
            Console.WriteLine($"AppUrl: {appUrl}");
            Console.WriteLine($"TestDataPath: {testDataPath}");
        }
    }
}

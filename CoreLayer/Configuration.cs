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
        }
    }
}

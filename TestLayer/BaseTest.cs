using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLayer.Drivers;
using CoreLayer.Config;
using CoreLayer.Logging;
namespace TestLayer.Base
{
    [TestClass]
    public class BaseTest
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Log.Initialize();
            Log.Info("===== Test Suite Started =====");
        }
        [TestInitialize]
        public void Setup()
        {
            Configuration.Init();
            var url = Configuration.AppUrl;
            if (string.IsNullOrWhiteSpace(url))
                throw new InvalidOperationException(
                    "ApplicationUrl is not configured in appsettings.json or is empty.");
            WebDriverSingleton.InitDriver(Configuration.BrowserType);
            WebDriverSingleton.Driver.Navigate().GoToUrl(url);
            WebDriverSingleton.Driver.Manage().Window.Maximize();
            WebDriverSingleton.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TestCleanup]
        public void Teardown()
        {
            WebDriverSingleton.QuitDriver();
        }
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Log.Info("===== Test Suite Completed =====");
            WebDriverSingleton.QuitDriver();
        }

        public TestContext TestContext { get; set; }
    }
}

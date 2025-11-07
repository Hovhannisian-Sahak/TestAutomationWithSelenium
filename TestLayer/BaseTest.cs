using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLayer.Drivers;
using CoreLayer.Config;

namespace TestLayer.Base
{
    [TestClass]
    public class BaseTest
    {
        [TestInitialize]
        public void Setup()
        {
            Configuration.Init();
            var url = Configuration.AppUrl;
            if (string.IsNullOrWhiteSpace(url))
                throw new InvalidOperationException(
                    "ApplicationUrl is not configured in appsettings.json or is empty.");
            WebDriverSingleton.Driver.Navigate().GoToUrl(url);
            WebDriverSingleton.Driver.Manage().Window.Maximize();
            WebDriverSingleton.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TestCleanup]
        public void Teardown()
        {
            WebDriverSingleton.QuitDriver();
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using Core.Config;
using System;

namespace Core.Drivers
{
    public sealed class WebDriverSingleton
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        private WebDriverSingleton() { }

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                    _driver = CreateDriver(Configuration.Browser);
                return _driver;
            }
        }

        public static IWebDriver CreateWebDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Edge:
                    return new EdgeDriver();
                case BrowserType.Firefox:
                    return new FirefoxDriver();
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }
        }
        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
                _driver = null;
            }
        }
    }
}

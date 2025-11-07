using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using CoreLayer.Config;
using System;
using System.Threading;

namespace CoreLayer.Drivers
{
    public sealed class WebDriverSingleton
    {
        // Each thread gets its own driver instance
        private static ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();

        private WebDriverSingleton() { }

        public static void InitDriver(BrowserType browserType)
        {
            if (!_driver.IsValueCreated || _driver.Value == null)
            {
                _driver.Value = browserType switch
                {
                    BrowserType.Edge => new EdgeDriver(),
                    BrowserType.Firefox => new FirefoxDriver(),
                    _ => throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null)
                };

                _driver.Value.Manage().Window.Maximize();
            }
        }

        public static IWebDriver Driver => _driver.Value;

        public static void QuitDriver()
        {
            if (_driver.IsValueCreated && _driver.Value != null)
            {
                try
                {
                    _driver.Value.Quit();
                    _driver.Value.Dispose();
                }
                catch { /* ignore exceptions */ }
                finally
                {
                    _driver.Value = null;
                }
            }
        }
    }
}

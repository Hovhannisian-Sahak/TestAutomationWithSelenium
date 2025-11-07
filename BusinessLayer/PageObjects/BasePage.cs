using OpenQA.Selenium;
using Core.Drivers;

namespace Core.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver => WebDriverSingleton.Driver;

        public void NavigateToApp()
        {
            Driver.Navigate().GoToUrl(Configuration.AppUrl);
        }

        public void CloseDriver()
        {
            WebDriverSingleton.QuitDriver();
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }

        public string GetCurrentUrl()
        {
            return Driver.Url;
        }

        public void MaximizeWindow()
        {
            Driver.Manage().Window.Maximize();
        }

        public void Click(By by)
        {
            WaitForElementToBePresent(_driver, by, _timeout)?.Click();
        }
        public void EnterText(By by, string text)
        {
            var element = WaitForElementToBePresent(_driver, by, _timeout);
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
            element.Clear();
            element.SendKeys(text);
        }

        public IReadOnlyCollection<IWebElement> FindElements(By by)
        {
            var elementPresent = WaitForElementToBePresent(_driver, by, _timeout);
            return elementPresent.FindElements(by);
        }

        public IWebElement FindElement(By by)
        {
            var elementPresent = WaitForElementToBePresent(_driver, by, _timeout);
            return elementPresent.FindElement(by);
        }

        public IWebElement WaitForElementToBePresent(IWebDriver Driver, By by, TimeSpan _timeout)
        {
            var wait = new WebDriverWait(Driver, _timeout);
            return wait.Until(drv =>
            {
                try
                {
                    var element = drv.FindElement(by);
                    if (element != null && element.Displayed)
                        return element;
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("WaitForElementToBePresent method: 'NoSuchElementException' is found.");
                }

                return null;
            });
        }
    }
}
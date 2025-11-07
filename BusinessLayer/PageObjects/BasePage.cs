using OpenQA.Selenium;
using CoreLayer.Drivers;
using OpenQA.Selenium.Support.UI;
namespace BusinessLayer.BasePage
{
    public class Base
    {
        protected IWebDriver Driver => WebDriverSingleton.Driver;

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
            WaitForElementToBePresent(Driver, by)?.Click();
        }
        public void EnterText(By by, string text)
        {
            var element = WaitForElementToBePresent(Driver, by);
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
            element.Clear();
            element.SendKeys(text);
        }

        public IReadOnlyCollection<IWebElement> FindElements(By by)
        {
            var elementPresent = WaitForElementToBePresent(Driver, by);
            return elementPresent.FindElements(by);
        }

        public IWebElement FindElement(By by)
        {
            var elementPresent = WaitForElementToBePresent(Driver, by);
            return elementPresent.FindElement(by);
        }

        public IWebElement WaitForElementToBePresent(IWebDriver Driver, By by)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
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
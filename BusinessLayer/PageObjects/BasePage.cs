using OpenQA.Selenium;
using CoreLayer.Drivers;
using OpenQA.Selenium.Support.UI;
namespace BusinessLayer.Base
{
    public class BasePage
    {
        protected IWebDriver Driver;

        public BasePage()
        {
            // Each test thread gets its own driver instance (ThreadLocal)
            Driver = WebDriverSingleton.Driver;
        }

        public void Click(By by) => WaitForElementToBePresent(by)?.Click();

        public void ClearField(By by)
        {
            var element = WaitForElementToBePresent(by);
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
            element.Clear();
        }
        public void EnterText(By by, string text)
        {
            var element = WaitForElementToBePresent(by);
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
            element.Clear();
            element.SendKeys(text);
        }

        public IWebElement FindElement(By by) => WaitForElementToBePresent(by);

        public IWebElement WaitForElementToBePresent(By by)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            return wait.Until(drv =>
            {
                try
                {
                    var element = drv.FindElement(by);
                    if (element.Displayed) return element;
                }
                catch (NoSuchElementException) { }
                return null;
            });
        }
    }
}

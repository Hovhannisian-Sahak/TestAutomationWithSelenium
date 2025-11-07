using OpenQA.Selenium;
using BusinessLayer.Base;
namespace BusinessLayer.PageObjects
{
    public class MainPage : BasePage
    {
        private By welcomeMessage = By.CssSelector("div.app_logo");

        public string GetWelcomeMessage() => FindElement(welcomeMessage).Text;
    }
}
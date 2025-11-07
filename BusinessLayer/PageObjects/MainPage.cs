using OpenQA.Selenium;
using Core.Pages;

namespace BusinessLayer.PageObjects
{
    public class MainPage : BasePage
    {
        private By welcomeMessage = By.CssSelector(".app_logo");

        public string GetWelcomeMessage()
        {
            return FindElement(welcomeMessage).Text;
        }
    }
}
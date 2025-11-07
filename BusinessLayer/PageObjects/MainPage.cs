using OpenQA.Selenium;
using BusinessLayer.BasePage;
namespace BusinessLayer.PageObjects
{
    public class MainPage : Base
    {
        private By welcomeMessage = By.CssSelector("div.app_logo");

        public string GetWelcomeMessage()
        {
            return FindElement(welcomeMessage).Text;
        }
    }
}
using OpenQA.Selenium;
using BusinessLayer.Base;
namespace BusinessLayer.PageObjects
{
    public class LoginPage : BasePage
    {
        private By usernameField = By.CssSelector("#user-name");
        private By passwordField = By.CssSelector("#password");
        private By loginButton = By.CssSelector("#login-button");
        private By errorMessage = By.CssSelector("div.error-message-container.error > h3");

        public MainPage Login(string username, string password)
        {
            EnterText(usernameField, username);
            EnterText(passwordField, password);
            Click(loginButton);
            return new MainPage();
        }

        public string GetErrorMessage() => FindElement(errorMessage).Text;
    }
}
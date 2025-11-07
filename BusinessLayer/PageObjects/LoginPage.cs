using OpenQA.Selenium;
using Core.Pages;

namespace BusinessLayer.PageObjects
{
    public class LoginPage : BasePage
    {
        private By usernameField = By.CssSelector("#user-name");
        private By passwordField = By.CssSelector("#password");
        private By loginButton = By.CssSelector("#login-button");

        private By errorMessage = By.CssSelector("h3[data-test='error']");


        public MainPage Login(string username, string password)
        {
            EnterText(usernameField, username);
            EnterText(passwordField, password);
            Click(loginButton);
            return new MainPage();
        }

        public string LoginWithoutPassword(string username)
        {
            EnterText(usernameField, username);
            Click(loginButton);
            return FindElement(errorMessage).Text;
        }

        public string LoginWithoutCredentials()
        {
            Click(loginButton);
            return FindElement(errorMessage).Text;
        }
    }
}
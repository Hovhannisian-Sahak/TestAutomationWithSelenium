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


        public void FillUsername(string text)
        {
            EnterText(usernameField, text);
        }

        public void FillPassword(string text)
        {
            EnterText(passwordField, text);
        }

        public void ClearUsername()
        {
            ClearField(usernameField);
        }

        public void ClearPassword()
        {
            ClearField(passwordField);
        }

        public void ClickLogin()
        {
            Click(loginButton);
        }
        public MainPage Login(string username, string password)
        {
            FillUsername(username);
            FillPassword(password);
            ClickLogin();
            return new MainPage();
        }

        public string GetErrorMessage() => FindElement(errorMessage).Text;
    }
}
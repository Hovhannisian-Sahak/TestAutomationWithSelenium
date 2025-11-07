using TestLayer.Base;
using BusinessLayer.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLayer.Logging;
[assembly: Parallelize(Workers = 2, Scope = ExecutionScope.MethodLevel)]
namespace TestLayer;

[TestClass]
public class Tests : BaseTest
{
    [TestMethod]
    [DataRow("", "", "Epic sadface: Username is required")]
    [DataRow("standard_user", "", "Epic sadface: Password is required")]
    public void Login_without_username_or_password_should_fail(string username, string password, string errorMessage)
    {
        Log.Info($"Starting test: Login_without_username_or_password_should_fail with username='{username}'");

        var loginPage = new LoginPage();
        Log.Info("Attempting login...");
        loginPage.Login(username, password);

        var actualMessage = loginPage.GetErrorMessage();
        Log.Info($"Captured error message: '{actualMessage}'");

        Assert.AreEqual(errorMessage, actualMessage,
            $"Expected message '{errorMessage}' but got '{actualMessage}'.");

        Log.Info("Test passed: Validation message was correct.");
    }

    [TestMethod]
    [DataRow("standard_user", "secret_sauce")]
    public void Login_should_succeed(string username, string password)
    {
        Log.Info($"Starting test: Login_should_succeed with username='{username}'");

        var loginPage = new LoginPage();
        Log.Info("Logging in with valid credentials...");
        loginPage.Login(username, password);

        var mainPage = new MainPage();
        Log.Info("Navigated to Main Page. Checking welcome message...");

        var welcomeMessage = mainPage.GetWelcomeMessage();
        Log.Info($"Welcome message: '{welcomeMessage}'");

        Assert.AreEqual("Swag Labs", welcomeMessage,
            $"Expected welcome message to be 'Swag Labs' but got '{welcomeMessage}'.");

        Log.Info("Test passed: Login successful and welcome message verified.");
    }
}
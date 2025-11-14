using TestLayer.Base;
using BusinessLayer.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLayer.Logging;

[assembly: Parallelize(Workers = 3, Scope = ExecutionScope.MethodLevel)]

namespace TestLayer;

[TestClass]
public class Tests : BaseTest
{
    [TestMethod]
    [DataRow("username", "password", "Epic sadface: Username is required")]
    public void Login_without_username_and_password_should_fail(string username, string password, string errorMessage)
    {
        Log.Info($"=== Test Start: Login_without_username_and_password_should_fail ===");
        Log.Info($"Input parameters → username: '{username}', password: '{password}'");

        var loginPage = new LoginPage();

        // Steps
        Log.Info("Step 1: Filling username and password fields...");
        loginPage.FillUsername(username);
        loginPage.FillPassword(password);

        Log.Info("Step 2: Clearing username and password fields...");
        loginPage.ClearUsername();
        loginPage.ClearPassword();

        Log.Info("Step 3: Clicking Login button...");
        loginPage.ClickLogin();

        // Validation
        var actualMessage = loginPage.GetErrorMessage();
        Log.Info($"Captured error message: '{actualMessage}'");

        Assert.AreEqual(errorMessage, actualMessage,
            $"Expected '{errorMessage}', but got '{actualMessage}'.");

        Log.Info("=== Test Passed: Validation message was correct ===");
    }


    [TestMethod]
    [DataRow("standard_user", "password", "Epic sadface: Password is required")]
    public void Login_without_password_should_fail(string username, string password, string errorMessage)
    {
        Log.Info($"=== Test Start: Login_without_password_should_fail ===");
        Log.Info($"Input → username: '{username}', password: '{password}'");

        var loginPage = new LoginPage();

        Log.Info("Step 1: Filling username and password...");
        loginPage.FillUsername(username);
        loginPage.FillPassword(password);

        Log.Info("Step 2: Clearing password field...");
        loginPage.ClearPassword();

        Log.Info("Step 3: Clicking Login button...");
        loginPage.ClickLogin();

        var actualMessage = loginPage.GetErrorMessage();
        Log.Info($"Captured error message: '{actualMessage}'");

        Assert.AreEqual(errorMessage, actualMessage,
            $"Expected '{errorMessage}', but got '{actualMessage}'.");

        Log.Info("=== Test Passed: Correct validation for missing password ===");
    }


    [TestMethod]
    [DataRow("standard_user", "secret_sauce")]
    public void Login_should_succeed(string username, string password)
    {
        Log.Info($"=== Test Start: Login_should_succeed ===");
        Log.Info($"Logging in with → username: '{username}', password: '{password}'");

        var loginPage = new LoginPage();

        Log.Info("Step 1: Performing login...");
        loginPage.Login(username, password);

        var mainPage = new MainPage();
        Log.Info("Step 2: Checking welcome message on main page...");

        var welcomeMessage = mainPage.GetWelcomeMessage();
        Log.Info($"Captured welcome message: '{welcomeMessage}'");

        Assert.AreEqual("Swag Labs", welcomeMessage,
            $"Expected 'Swag Labs', but got '{welcomeMessage}'.");

        Log.Info("=== Test Passed: Successful login verified ===");
    }
}

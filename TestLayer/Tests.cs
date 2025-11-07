using TestLayer.Base;
using BusinessLayer.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLayer;

[TestClass]
public class Tests : BaseTest
{
    [TestMethod]
    [DataRow("", "", "Epic sadface: Username is required")]
    [DataRow("standard_user", "", "Epic sadface: Password is required")]
    public void Login_without_username_or_password_should_fail(string username, string password, string errorMessage)
    {
        var loginPage = new LoginPage();
        loginPage.Login(username, password);
        Assert.AreEqual(errorMessage, loginPage.GetErrorMessage());
    }
    [TestMethod]
    [DataRow("standard_user", "secret_sauce")]
    public void Login_should_succeed(string username, string password)
    {
        var loginPage = new LoginPage();
        loginPage.Login(username, password);
        var mainPage = new MainPage();
        var welcomeMessage = mainPage.GetWelcomeMessage();
        Assert.AreEqual("Swag Labs", welcomeMessage);
    }
}
# Saucedemo Login Automation (MSTest + Selenium + POM)

This project automates the login functionality of **saucedemo.com**, using:

- MSTest Framework  
- Selenium WebDriver  
- Page Object Model (POM)  
- WebDriver Singleton  
- Data-driven testing with `[DataRow]`

The goal is to validate both **positive** and **negative** login scenarios following *exact Use Case steps*.

---

## 📌 Functional Requirements

### **Use Case: Successful Login**

**Preconditions:**  
- User has valid credentials  
- Application is available  

**Steps:**  
1. Open login page  
2. Enter valid username  
3. Enter valid password  
4. Click **Login** button  
5. Verify user is redirected to Main page  
6. Verify application header displays: **Swag Labs**

**Expected Result:**  
User successfully logs in and the header “Swag Labs” is displayed.

---

## 📌 Negative Use Case: Login Without Username and Password

**Steps:**  
1. Open login page  
2. Enter valid username  
3. Enter valid password  
4. Clear Username
5. Clear Password
6. Attempt login with missing both fields  
7. System displays specific validation error:“Epic sadface: Username is required”


## 📌 Negative Use Case: Login Without Password

**Steps:**  
1. Open login page  
2. Enter valid username  
3. Enter valid password  
4. Clear Password
5. Attempt login with missing field
6. System displays specific validation error:“Epic sadface: Password is required”

---

## 🚀 Running The Tests

1. Clone the repository  
2. Restore NuGet packages  
3. Set your browser in `appsettings.json` (Edge, Chrome, Firefox)  
4. Run tests from:  
   - Visual Studio Test Explorer  
   - `dotnet test` via terminal  

---

## 📂 Project Structure

TestAutomationSelenium/
│
├── BusinessLayer/
│   ├── PageObjects/
│   │   ├── BasePage.cs
│   │   ├── LoginPage.cs
│   │   └── MainPage.cs
│   └── BusinessLayer.csproj
│
├── CoreLayer/
│   ├── WebDriver/
│   │   ├── WebDriverWrapper/
│   │   └── WebDriverSingleton.cs
│   ├── appsettings.json
│   ├── BrowserType.cs
│   ├── Configuration.cs
│   ├── Logging.cs
│   └── CoreLayer.csproj
│
├── TestLayer/
│   ├── BaseTest.cs
│   ├── Tests.cs
│   ├── test.runsettings
│   └── TestLayer.csproj
│
└── TestAutomationSelenium.sln

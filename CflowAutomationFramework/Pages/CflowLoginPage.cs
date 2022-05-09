using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace CflowAutomationFramework.Pages
{
    internal class CflowLoginPage : BaseCflowApplicationPage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public CflowLoginPage(IWebDriver driver) : base(driver) { }

        public bool IsVisible
        {
            get
            {
                Reporter.LogTestStepForBugLogger(Status.Info,
                        "Validate that Login page is visible.");
                return Driver.Title.Contains(PageTitle);
            }
            internal set { }
        }

        private string PageTitle => "Cflow Login";

        private IWebElement ClientIdField => Driver.FindElement(By.Id("txtClientID"));

        private IWebElement UserNameField => Driver.FindElement(By.Id("txtUserName"));

        private IWebElement PasswordField => Driver.FindElement(By.Id("txtPassword"));

        private IWebElement LoginButton => Driver.FindElement(By.XPath("//*[@id='lblLoginError']/preceding-sibling::a"));

        public IWebElement ErrorMessage
        {
            get
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
                    return wait.Until(ExpectedConditions.ElementIsVisible(By.Id("lblLoginError")));
                }
                catch (NoSuchElementException)
                {
                    return null;
                }

            }
            set { }
        }

        internal void GoTo()
        {
            _logger.Trace("Attempting to navigate to the login page");
            var url = "https://cflow.cavintek.com/cflownew/login";
            Driver.Navigate().GoToUrl(url);
            Reporter.LogPassingTestStepToBugLogger($"Open url=>{url} for Login page.");
            Assert.IsTrue(IsVisible,
                $"Cflow application page was not visible. Expected=>{PageTitle}." +
                $"Actual=>{Driver.Title}");
            Reporter.LogPassingTestStepToBugLogger("Check Login page is loaded.");
        }

        internal CflowDashboardPage FillOutLoginFormAndSubmit(TestUser user)
        {
            _logger.Trace("Attempting to fill out and submit the login form");
            ClientIdField.SendKeys(user.clientId);
            Reporter.LogPassingTestStepToBugLogger($"Enter the client id=>{user.clientId}");
            UserNameField.SendKeys(user.userName);
            Reporter.LogPassingTestStepToBugLogger($"Enter the username=>{user.userName}");
            PasswordField.SendKeys(user.password);
            Reporter.LogPassingTestStepToBugLogger($"Enter the password=>{user.password}");
            LoginButton.Click();                      
            return new CflowDashboardPage(Driver);
        }
    }
}
using AventStack.ExtentReports;
using CflowAutomationFramework.Pages.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace CflowAutomationFramework.Pages
{
    internal class CflowDashboardPage : BaseCflowApplicationPage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public CflowDashboardPage(IWebDriver driver) : base(driver) 
        {
            NavigationMenu = new NavigationMenu(driver);
        }

        public NavigationMenu NavigationMenu { get; internal set; }

        public bool IsVisible
        {
            get
            {
                try
                {
                    Reporter.LogTestStepForBugLogger(Status.Info,
                        "Validate that Dashboard page is visible.");
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
                    IWebElement MyWorkflowsText = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='cf_sectiontitle'][contains(text(), 'Workflows')]")));
                    return MyWorkflowsText.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
            set { }
        }

        public void IsLoaded()
        {
            _logger.Trace("Attempting to check if the dashboard page is loaded");
            Assert.IsTrue(IsVisible, "Cflow dashboard page was not visible.");
            Reporter.LogPassingTestStepToBugLogger("Check if the dashboard page is loaded");
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System;
using NLog;
using AventStack.ExtentReports;

namespace CflowAutomationFramework.Pages.AddWorkflow
{
    internal class AddWorkflowPage : BaseCflowApplicationPage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public AddWorkflowPage(IWebDriver driver) : base(driver)
        {
            Header = new Header(driver);
        }

        public Header Header { get; internal set; }

        private IWebElement UseThisWorkflowButton => Driver
            .FindElement(By.XPath("//*[@class='bottom-initate'][contains(text(), 'Workflow')]"));

        public bool IsVisible
        {
            get
            {
                try
                {
                    Reporter.LogTestStepForBugLogger(Status.Info,
                        "Validate that Add Workflow page is visible.");
                    return Driver.FindElement(By.XPath("//*[@class='bottom-initate'][contains(text(), 'Workflow')]")).Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }

            }
            set { }
        }

        public IWebElement SuccessMessage
        {
            get
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
                    return wait.Until(ExpectedConditions
                        .ElementIsVisible(By.XPath("//*[@id='h2ImgDesc']/following-sibling::div[@class='successmsg']")));
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
            _logger.Trace("Attempting to navigate to the add workflow page");
            var url = "https://cflow.cavintek.com/cflownew/add-workflow";
            Driver.Navigate().GoToUrl(url);
            Reporter.LogPassingTestStepToBugLogger($"Open url=>{url} for Add Workflow page.");
            _logger.Trace("Attempting to check if the add workflow page is loaded");
            Assert.IsTrue(IsVisible, "The add workflow page did not open successfully.");
            Reporter.LogPassingTestStepToBugLogger("Check Add Workflow page is loaded.");
        }

        internal void NavigateToSupportProcessWorkflow()
        {
            _logger.Trace("Attempting to navigate to the 'Support Process' pre-built workflow");
            Header.Operations.Tab.Click();
            Header.Operations.SupportProcess.Option.Click();
            Reporter.LogPassingTestStepToBugLogger("Navigate to 'Support Process' workflow");
        }

        internal void NavigateToMeetingNotesActionItemsWorkflow()
        {
            _logger.Trace("Attempting to navigate to the 'Meeting Notes Action Items' pre-built workflow");
            Header.Operations.Tab.Click();
            Header.Operations.MeetingNotesActionItems.Option.Click();
            Reporter.LogPassingTestStepToBugLogger("Navigate to 'Meeting Notes Action Items' workflow");
        }

        internal void NavigateToWorkOrderWorkflow()
        {
            _logger.Trace("Attempting to navigate to the 'Work Order' pre-built workflow");
            Header.Operations.Tab.Click();
            Header.Operations.WorkOrder.Option.Click();
            Reporter.LogPassingTestStepToBugLogger("Navigate to 'Work Order' workflow");
        }

        internal void NavigateToTaskAssignmentProcessWorkflow()
        {
            _logger.Trace("Attempting to navigate to the 'Task Assignment Process' pre-built workflow");
            Header.Operations.Tab.Click();
            Header.Operations.TaskAssignmentProcess.Option.Click();
            Reporter.LogPassingTestStepToBugLogger("Navigate to 'Task Assignment Process' workflow");
        }

        internal void NavigateToProjectManagementWorkflow()
        {
            _logger.Trace("Attempting to navigate to the 'Project Management' pre-built workflow");
            Header.Operations.Tab.Click();
            Header.Operations.ProjectManagement.Option.Click();
            Reporter.LogPassingTestStepToBugLogger("Navigate to 'Project Management' workflow");
        }

        internal void NavigateToBugTrackerWorkflow()
        {
            _logger.Trace("Attempting to navigate to the 'Bug Tracker' pre-built workflow");
            Header.Operations.Tab.Click();
            Header.Operations.BugTracker.Option.Click();
            Reporter.LogPassingTestStepToBugLogger("Navigate to 'Bug Tracker' workflow");
        }

        internal void UseThisWorkflow()
        {
            _logger.Trace("Attempting to use the selected pre-built workflow");
            UseThisWorkflowButton.Click();
            Reporter.LogPassingTestStepToBugLogger("Use this workflow");
        }       
    }
}
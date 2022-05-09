using AutomationResources;
using CflowAutomationFramework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using System;

namespace CflowAutomationFramework.Tests
{
    public class BaseTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public IWebDriver Driver { get; private set; }
        public TestContext TestContext { get; set; }
        internal CflowLoginPage CflowLoginPage { get; private set; }
        internal TestUser TheTestUser { get; private set; }
        private ScreenshotTaker ScreenshotTaker { get; set; }

        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            _logger.Debug("************************************* TEST STARTED");
            _logger.Debug("************************************* TEST STARTED");
            Reporter.AddTestCaseMetadataToHtmlReport(TestContext);
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
            CflowLoginPage = new CflowLoginPage(Driver);
            ScreenshotTaker = new ScreenshotTaker(Driver, TestContext);
            TheTestUser = new TestUser();
            TheTestUser.clientId = "";
            TheTestUser.userName = "";
            TheTestUser.password = "";
        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            _logger.Debug(GetType().FullName + " started a method tear down");
            try
            {
                TakeScreenshotForTestFailure();
            }
            catch (Exception e)
            {
                _logger.Error(e.Source);
                _logger.Error(e.StackTrace);
                _logger.Error(e.InnerException);
                _logger.Error(e.Message);
            }
            finally
            {
                StopBrowser();
                _logger.Debug(TestContext.TestName);
                _logger.Debug("*************************************** TEST STOPPED");
                _logger.Debug("*************************************** TEST STOPPED");
            }
        }

        private void TakeScreenshotForTestFailure()
        {
            if (ScreenshotTaker != null)
            {
                ScreenshotTaker.CreateScreenshotIfTestFailed();
                Reporter.ReportTestOutcome(ScreenshotTaker.ScreenshotFilePath);
            }
            else
            {
                Reporter.ReportTestOutcome("");
            }
        }

        private void StopBrowser()
        {
            if (Driver == null)
                return;
            Driver.Quit();
            Driver = null;
            _logger.Trace("Browser stopped successfully.");
        }
    }
}
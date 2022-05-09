using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace CflowAutomationFramework.Pages.AddWorkflow
{
    internal class Operations : BaseCflowApplicationPage
    {
        public Operations(IWebDriver driver) : base(driver)
        {
            SupportProcess = new SupportProcess(driver);
            MeetingNotesActionItems = new MeetingNotesActionItems(driver);
            WorkOrder = new WorkOrder(driver);
            TaskAssignmentProcess = new TaskAssignmentProcess(driver);
            ProjectManagement = new ProjectManagement(driver);
            BugTracker = new BugTracker(driver);
        }

        public SupportProcess SupportProcess { get; internal set; }
        public IWebElement Tab
        {
            get
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
                    return wait.Until(ExpectedConditions
                        .ElementIsVisible(By.XPath("//*[@class='pbw_tab_list']//a[contains(text(), 'Operations')]")));
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            }
            set { }
        }

        public MeetingNotesActionItems MeetingNotesActionItems { get; internal set; }
        public WorkOrder WorkOrder { get; internal set; }
        public TaskAssignmentProcess TaskAssignmentProcess { get; internal set; }
        public ProjectManagement ProjectManagement { get; internal set; }
        public BugTracker BugTracker { get; internal set; }
    }
}
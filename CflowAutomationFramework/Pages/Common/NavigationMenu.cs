using CflowAutomationFramework.Pages.AddWorkflow;
using OpenQA.Selenium;

namespace CflowAutomationFramework.Pages.Common
{
    internal class NavigationMenu : BaseCflowApplicationPage
    {
        public NavigationMenu(IWebDriver driver) : base(driver) { }

        internal AddWorkflowPage addWorkflow()
        {
            return new AddWorkflowPage(Driver);
        }
    }
}
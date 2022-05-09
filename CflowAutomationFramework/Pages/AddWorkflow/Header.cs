using OpenQA.Selenium;

namespace CflowAutomationFramework.Pages.AddWorkflow
{
    internal class Header : BaseCflowApplicationPage
    {
        public Header(IWebDriver driver) : base(driver)
        {
            Operations = new Operations(driver);
        }

        public Operations Operations { get; internal set; }
    }
}
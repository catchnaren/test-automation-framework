using OpenQA.Selenium;

namespace CflowAutomationFramework.Pages
{
    internal class BaseCflowApplicationPage
    {
        protected IWebDriver Driver { get; set; }

        public BaseCflowApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace CflowAutomationFramework.Pages.AddWorkflow
{
    internal class WorkOrder : BaseCflowApplicationPage
    {


        public WorkOrder(IWebDriver driver) : base(driver) { }

        public IWebElement Option
        {
            get
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
                    return wait.Until(ExpectedConditions
                        .ElementIsVisible(By.XPath("//*[@id='tblDefaultWorkFlows']/li[@categ='Operations']/span[contains(text(), 'Work Order')]")));
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            }
            set { }
        }
    }
}
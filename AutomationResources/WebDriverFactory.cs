using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace AutomationResources
{
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                default:
                    throw new ArgumentOutOfRangeException("No such browser exists");
            }
        }

        private IWebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("headless");
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDirectory, options);
        }
    }
}
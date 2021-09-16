using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SampleFramework1
{
    internal class WebsiteBasePage
    {
        internal IWebDriver Driver { get; set; }
        internal WebDriverWait Wait { get; set; }

        internal WebsiteBasePage(IWebDriver driver, WebDriverWait wait)
        {
            Driver = driver;
            Wait = wait;
        }
    }
}
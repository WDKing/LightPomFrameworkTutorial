using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SampleFramework1.Self_Dev
{
    internal class UltimateQAPage : WebsiteBasePage
    {
        public UltimateQAPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        public bool IsLoaded
        {
            get
            {
                try
                {

                    Wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@type='text'][@name='s']")));
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public string GetUrl()
        {
            return Driver.Url;
        }
    }
}

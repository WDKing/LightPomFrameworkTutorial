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


    class UltimateQAPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public UltimateQAPage(IWebDriver driver, WebDriverWait wait) {
            this.driver = driver;
            this.wait = wait;
        }

        public bool IsLoaded()
        {
            wait.Until(ExpectedConditions.ElementExists(By.Id("main-content"))); 
            return true;
        }

        public string GetUrl()
        {
            return driver.Url;
        }
    }
}

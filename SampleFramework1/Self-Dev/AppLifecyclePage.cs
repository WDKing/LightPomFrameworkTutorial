using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SampleFramework1.Self_Dev;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SampleFramework1
{
    internal class AppLifecyclePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private string URL = "https://ultimateqa.com/sample-application-lifecycle-sprint-1/";

        public AppLifecyclePage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        internal void Open()
        {
            driver.Navigate().GoToUrl(URL);
        }

        internal bool IsNameFieldLoaded()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='firstname']")));
            return true;
        }

        internal void FillOutForm(string name)
        {
            driver.FindElement(By.XPath("//input[@name='firstname']")).SendKeys(name);
        }

        internal UltimateQAPage ClickSubmit()
        {
            driver.FindElement(By.Id("submitForm")).Click();
            return new UltimateQAPage(driver, wait);
        }
    }
}
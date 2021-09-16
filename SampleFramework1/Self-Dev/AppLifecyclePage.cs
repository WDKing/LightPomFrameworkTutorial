using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SampleFramework1.Self_Dev;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SampleFramework1
{
    internal class AppLifecyclePage : WebsiteBasePage
    {
        private string URL => "https://ultimateqa.com/sample-application-lifecycle-sprint-1/";
        public IWebElement FirstNameField => Driver.FindElement(By.XPath("//input[@name='firstname']"));
        public IWebElement SubmitFormButton => Driver.FindElement(By.Id("submitForm"));

        public AppLifecyclePage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        internal void Open()
        {
            Driver.Navigate().GoToUrl(URL);
        }

        /*
        public bool IsVisible
        {
            get
            {
                return driver.Title.Equals("Sample Application Lifecycle - Sprint 1 - Ultimate QA");
            }
            internal set { }
        }
        */ 

        internal bool IsNameFieldLoaded()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='firstname']")));
            return true;
        }

        internal void FillOutForm(string name)
        {
            FirstNameField.SendKeys(name);
        }

        internal UltimateQAPage ClickSubmit()
        {
            SubmitFormButton.Click();
            return new UltimateQAPage(Driver, Wait);
        }
    }
}
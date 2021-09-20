using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SampleFramework1.Self_Dev;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SampleFramework1
{
    internal class AppLifecyclePage : WebsiteBasePage
    {
        private string URL => "https://ultimateqa.com/sample-application-lifecycle-sprint-3/";
        public IWebElement FirstNameField => Driver.FindElement(By.XPath("//input[@name='firstname']"));
        public IWebElement LastNameField => Driver.FindElement(By.XPath("//input[@name='lastname']"));
        public IWebElement GenderField;
        public IWebElement SubmitFormButton => Driver.FindElement(By.XPath("//input[@type='submit']"));

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

        internal bool IsFirstNameFieldLoaded()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='firstname']")));
            return true;
        }

        internal void FillOutUserFields(User user)
        {
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);

            GenderField = Driver.FindElement(By.XPath($"//input[@name='gender'][@value='{user.Gender}']"));
            GenderField.Click();
        }

        internal UltimateQAPage ClickSubmit()
        {
            SubmitFormButton.Click();
            return new UltimateQAPage(Driver, Wait);
        }
    }
}
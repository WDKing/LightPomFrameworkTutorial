using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SampleFramework1.Self_Dev;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SampleFramework1
{
    internal class AppLifecyclePage : WebsiteBasePage
    {
        // Page Values
        public AppLifecyclePage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }
        private string URL => "https://ultimateqa.com/sample-application-lifecycle-sprint-4/";
        public string Title => "Sample Application Lifecycle - Sprint 4 - Ultimate QA";
        // User Form Fields
        public IWebElement UserFirstNameField => Driver.FindElement(By.XPath("//input[@id='f1'][@name='firstname']"));
        public IWebElement UserLastNameField => Driver.FindElement(By.XPath("//input[@id='l1'][@name='lastname']"));
        public IWebElement UserSubmitFormButton => Driver.FindElement(By.Id("submit1"));
        // Emergency Contact Form Fields
        public IWebElement EmergencyFirstNameField => Driver.FindElement(By.XPath("//input[@id='f2'][@name='firstname']"));
        public IWebElement EmergencyLastNameField => Driver.FindElement(By.XPath("//input[@id='l2'][@name='lastname']"));
        public IWebElement EmergencySubmitFormButton => Driver.FindElement(By.Id("submit2"));
        // Adjustable Fields
        public IWebElement GenderField;


        public bool IsVisible
        {
            get => Driver.Title.Equals(Title);
            internal set { }
        }
        internal void GoToPage()
        {
            Driver.Navigate().GoToUrl(URL);
            Assert.IsTrue(IsVisible, $"The expected page is not visible. Title observed: {Driver.Title}, Expected Title: {Title}");
        }

        internal void SubmitUser()
        {
            UserSubmitFormButton.Click();
            
            Assert.IsTrue((new UltimateQAPage(Driver, Wait)).IsLoaded, "UltimateQA Page is not Loaded. Title observed: {Driver.Title}, Expected Title: {Title}");
        }
        internal void SubmitEmergency()
        {
            EmergencySubmitFormButton.Click();

            Assert.IsTrue((new UltimateQAPage(Driver, Wait)).IsLoaded, "UltimateQA Page is not Loaded. Title observed: {Driver.Title}, Expected Title: {Title}");
        }

        internal void FillOutUserFields(User user)
        {
            UserFirstNameField.SendKeys(user.FirstName);
            UserLastNameField.SendKeys(user.LastName);
            GenderField = AcquireGenderField(user.Gender, "1");
            GenderField.Click();
        }
        internal void FillOutEmergencyFields(User user)
        {
            EmergencyFirstNameField.SendKeys(user.FirstName);
            EmergencyLastNameField.SendKeys(user.LastName);
            GenderField = AcquireGenderField(user.Gender, "2");
            GenderField.Click();
        }

        private IWebElement AcquireGenderField(User.GenderTypes gender, string formNumber)
        {
            string id;
            switch (gender)
            {
                case User.GenderTypes.Male:
                    id = "radio" + formNumber + "-m";
                    break;
                case User.GenderTypes.Female:
                    id = "radio" + formNumber + "-f";
                    break;
                case User.GenderTypes.Other:
                    id = "radio" + formNumber + "-0";
                    break;
                default:
                    id = "";
                    break;
            }
            return Driver.FindElement(By.XPath($"//input[@id='{id}'][@name='gender']"));
        }
    }
}
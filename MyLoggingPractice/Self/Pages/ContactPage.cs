using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace MyLoggingPractice
{
    internal class ContactPage
    {
        public IWebDriver Driver { get; private set; }
        public bool IsVisible => Driver.FindElement(By.XPath("//form[@class='contact-form-box']")).Displayed;
        public string Title => "Contact us - My Store";
        public string URL => "http://automationpractice.com/index.php?controller=contact";

        public ContactPage(IWebDriver driver)
        {
            Driver = driver;
        }

        internal void Open()
        {
            Driver.Navigate().GoToUrl(URL);
            Assert.IsTrue(IsVisible, $"The expected page is not visible. Title observed: {Driver.Title}, Expected Title: {Title}");
        }
    }
}
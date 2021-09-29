using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreatingReports.Self.Tests
{
    public class BaseTests
    {
        public IWebDriver Driver { get; private set; }
        public Actions Actions { get; set; }
        public WebDriverWait Wait { get; set; }

        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
            Actions = new Actions(Driver);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(6));
        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}

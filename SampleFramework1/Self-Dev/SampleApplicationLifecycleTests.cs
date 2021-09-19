using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFramework1
{
    [TestClass]
    [TestCategory("SampleApplicationLifecycleTests")]
    public class SampleApplicationLifecycleTests
    {
        private IWebDriver driver;
        private Actions actions;
        private WebDriverWait wait;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            actions = new Actions(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(6));
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }

        [TestMethod]
        public void SAL_Test()
        {
            var appLifecyclePage = new AppLifecyclePage(driver, wait);
            appLifecyclePage.Open();

            Assert.IsTrue(appLifecyclePage.IsFirstNameFieldLoaded(), "First Name Field is Not Loaded");

            var user = new User("Zeus", "God of Greece");

            appLifecyclePage.FillOutNameFields(user);
            var ultimateQAPage = appLifecyclePage.ClickSubmit();

            Assert.IsTrue(ultimateQAPage.IsLoaded(), "UltimateQA Page is not Loaded");
        }
    }
}

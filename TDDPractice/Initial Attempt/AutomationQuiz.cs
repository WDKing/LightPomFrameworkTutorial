using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TDDPractice
{
    [TestClass]
    [TestCategory("TDDAutomationQuiz")]
    class AutomationQuiz
    {
        IWebDriver driver;
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
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }

        [TestMethod]
        public void Test_SearchForAndOpenComplicatedPage()
        {
            AutomationQuizComplicatedPage complicatedPage = new AutomationQuizPage(driver)
                .Open()
                .SearchForComplicatedPage()
                .LocateComplicatedPage();
            Assert.AreEqual("Complicated Page - Ultimate QA", complicatedPage.AcquirePageTitle());
            Assert.AreEqual("https://ultimateqa.com/complicated-page/", complicatedPage.AcquirePageURL());
        }

        [TestMethod]
        public void TestMethodNew()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            var complicatedPage = new ComplicatedPage(driver);
            complicatedPage.Open();
            complicatedPage.SearchArticles("automation testing");
            Assert.IsTrue(complicatedPage.AreResultsReturned());
        }


    }
}

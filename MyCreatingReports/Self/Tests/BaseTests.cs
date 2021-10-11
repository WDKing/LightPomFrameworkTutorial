using System;
using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCreatingReports.Instructor;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace MyCreatingReports.Self.Tests
{
    public class BaseTests
    {
        // -- From Lesson --
        // private static TestContext _testContext; 
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public TestContext TestContext { get; set; }
        private ScreenshotTaker ScreenshotTaker { get; set; }

        public IWebDriver Driver { get; private set; }
        public Actions Actions { get; set; }
        public WebDriverWait Wait { get; set; }

        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            Logger.Debug("*************************************** TEST STARTED");
            Logger.Debug("*************************************** TEST STARTED");
            Reporter.AddTestCaseMetadataToHtmlReport(TestContext);

            var factory = new WebDriverFactory();
			Driver = factory.Create(BrowserType.Chrome);
            Driver.Manage().Window.Maximize();
            Actions = new Actions(Driver);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(6));

            ScreenshotTaker = new ScreenshotTaker(Driver, TestContext);
        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Logger.Debug(GetType().FullName + " started a method tear down");
            try
            {
                TakeScreenshotForTestFailure();
            }
            catch (Exception e)
            {
                Logger.Error(e.Source);
                Logger.Error(e.StackTrace);
                Logger.Error(e.InnerException);
                Logger.Error(e.Message);
            }
            finally
            {
                StopBrowser();
                Logger.Debug(TestContext.TestName);
                Logger.Debug("*************************************** TEST STOPPED");
                Logger.Debug("*************************************** TEST STOPPED");
            }
        }


        private void TakeScreenshotForTestFailure()
        {
            if (ScreenshotTaker != null)
            {
                ScreenshotTaker.CreateScreenshotIfTestFailed();
                Reporter.ReportTestOutcome(ScreenshotTaker.ScreenshotFilePath);
            }
            else
            {
                Reporter.ReportTestOutcome("");
            }
        }

        private void StopBrowser()
        {
            if (Driver == null)
                return;
            Driver.Close();
            Driver.Quit();
            Driver = null;
            Logger.Trace("Browser stopped successfully.");
        }
    }
}

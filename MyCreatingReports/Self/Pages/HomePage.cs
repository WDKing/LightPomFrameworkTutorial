﻿using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCreatingReports.Instructor;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreatingReports.Self.Pages
{
    class HomePage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        IWebDriver Driver { get; set; }

        public string Title => "My Store";
        public string URL => "http://automationpractice.com/index.php";

        public bool IsVisible => Driver.Title.Equals(Title);

        private IWebElement SearchField => Driver.FindElement(By.Id("search_query_top"));
        private IWebElement SearchButton => Driver.FindElement(By.XPath("//button[@type='submit'][@name='submit_search']"));

        internal HomePageSlider Slider { get; set; }
        private SearchResultsPage SearchResultsPage { get; set; }


        public HomePage(IWebDriver driver) {
            Driver = driver;

            Slider = new HomePageSlider(Driver);
        }

        internal void Open()
        {
            Reporter.LogTestStepForBugLogger(Status.Pass, $"Open the web page '{URL}'");
            //_logger.Trace("Entered Open() method");
            Driver.Navigate().GoToUrl(URL);
            Assert.IsTrue(IsVisible, $"The expected page is not visible. Title observed: {Driver.Title}, Expected Title: {Title}");
            //_logger.Info($"Accessed URL: {URL}");

        }

        internal void SearchFor(string searchString)
        {
            _logger.Trace("Entered SearchFor() method.");
            SearchField.SendKeys(searchString);
            SearchButton.Click();
            SearchResultsPage = new SearchResultsPage(Driver);
            _logger.Info($"Searched for item in search bar: {searchString}");
            Assert.IsTrue(SearchResultsPage.IsVisible, $"The Page does not appear to be loadaed. Title observed: {Driver.Title}, Expected Title: {Title}");
            Assert.IsTrue(SearchResultsPage.ConfirmResultsFound(searchString), $"The results do not appear to display results with the search string: {searchString}.");
        }

        internal SearchResultsPage Search(string searchString)
        {
            _logger.Trace("Entered SearchFor() method.");
            SearchField.SendKeys(searchString);
            SearchButton.Click();
            _logger.Info($"Searched for item in search bar: {searchString}");
            Assert.IsTrue(SearchResultsPage.IsVisible, $"The Page does not appear to be loadaed. Title observed: {Driver.Title}, Expected Title: {Title}");
            Assert.IsTrue(SearchResultsPage.ConfirmResultsFound(searchString), $"The results do not appear to display results with the search string: {searchString}.");

            return new SearchResultsPage(Driver);
        }
    }
}

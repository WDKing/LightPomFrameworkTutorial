using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    [TestClass]
    public class PageObjectsQuiz
    {
        private IWebDriver driver;
        private PageObjectTestPage page;
        private readonly string reactShoppingCart = PageObjectTestPage.URL;


        [TestInitialize]
        public void Setup()
        {
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }

        /// <summary>
        /// Test 1
        /// </summary>
        [TestMethod]
        public void Test1()
        {

            Assert.AreEqual(1, AddItemToCart("http:////localhost:3000//"), "we added only 1 item to the cart");
        }

        private int AddItemToCart(string htmlAddress)
        {
            driver = NewChromeDriver();
            driver.Navigate().GoToUrl(htmlAddress);
            driver.FindElement(By.ClassName("shelf-item__buy-btn")).Click();
            return int.Parse(driver.FindElement(By.ClassName("bag__quantity")).Text);
        }

        private IWebDriver NewChromeDriver()
        {
            return new WebDriverFactory().Create(BrowserType.Chrome);
        }




        ///
        /// Test 2
        /// 
        [TestMethod]
        public void Test2()
        {
            OpenInChrome(reactShoppingCart);
            page.ClickBuyButton();
            Assert.AreEqual(1, page.AcquireBagQuantity());
        }

        private bool OpenInChrome(string html)
        {
            driver = new WebDriverFactory().Create(BrowserType.Chrome);
            page = new PageObjectTestPage(driver);
            driver.Navigate().GoToUrl(html);
            return true;
        }


    }
}

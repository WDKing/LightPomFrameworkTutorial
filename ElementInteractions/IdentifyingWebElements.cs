﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

namespace ElementInteractions
{
    [TestClass]
    [TestCategory("Locating web elements")]
    public class IdentifyingWebElements
    {
        public IWebDriver Driver { get; private set; }
        [TestInitialize]
        public void SetupBeforeEveryTestMethod()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }
        [TestCleanup]
        public void CleanupAfterEveryTestMethod()
        {
            //If driver is not null, then Quit()
            //always check for null driver in the TestCleanup first
            Driver?.Quit();
        }
        [TestMethod]
        public void DifferentTypesOfSeleniumLocationStrategies()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            HighlightElementUsingJavaScript(By.ClassName("buttonClass"));
            Driver.FindElement(By.ClassName("buttonClass")).Click();
            HighlightElementUsingJavaScript(By.Id("idExample"));
            HighlightElementUsingJavaScript(By.LinkText("Click me using this link text!"));
            HighlightElementUsingJavaScript(By.Name("button1"));
            HighlightElementUsingJavaScript(By.PartialLinkText("link text!"));
            HighlightElementUsingJavaScript(By.TagName("div"));
            HighlightElementUsingJavaScript(By.CssSelector("#idExample"));
            HighlightElementUsingJavaScript(By.CssSelector(".buttonClass"));
            HighlightElementUsingJavaScript(By.XPath("//*[@id='idExample']"));
            HighlightElementUsingJavaScript(By.XPath("//*[@class='buttonClass']"));
        }

        /*
         Highlight this link using all of the different location strategies
             */
        [TestMethod]
        public void SeleniumLocationStrategiesQuiz()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            var link = Driver.FindElements(By.ClassName("et_pb_blurb_description"))[4];
            //HighlightElementUsingJavaScript(By.ClassName("et_pb_blurb_description"));
            HighlightElementUsingJavaScript(By.Id("simpleElementsLink"));

            HighlightElementUsingJavaScript(By.LinkText("Click this link"));
            HighlightElementUsingJavaScript(By.Name("clickableLink"));
            HighlightElementUsingJavaScript(By.PartialLinkText("Click this lin"));
            HighlightElementUsingJavaScript(By.TagName("a"));
            HighlightElementUsingJavaScript(By.CssSelector("#simpleElementsLink"));
            HighlightElementUsingJavaScript(By.XPath("//*[@id='simpleElementsLink']"));
        }



        private void HighlightElementUsingJavaScript(By locationStrategy, int duration = 2)
        {
            var element = Driver.FindElement(locationStrategy);
            var originalStyle = element.GetAttribute("style");
            IJavaScriptExecutor JavaScriptExecutor = Driver as IJavaScriptExecutor;
            JavaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
                element,
                "style",
                "border: 7px solid yellow; border-style: dashed;");

            if (duration <= 0) return;
            Thread.Sleep(TimeSpan.FromSeconds(duration));
            JavaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
                element,
                "style",
                originalStyle);
        }


        [TestMethod]
        public void SeleniumElementLocationExam()
        {
 
            /*
             *-Using only XPath!!
             -When debugging and testing, make sure that you scroll the element into view, Selenium
             will not scroll for you. Not yet...
             */
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");        
            //click any radio button, hint:  FindElement().Click();
            Driver.FindElement(By.XPath("//*[@type='radio'][@value='male']")).Click();
            //select one checkbox
            Driver.FindElement(By.XPath("//*[@value='Bike']")).Click();
            //select Audi from the dropdown
            Driver.FindElement(By.TagName("select")).Click();
            Driver.FindElement(By.XPath("//*[@value='audi']")).Click();
            //open Tab2 and assert that it is opened. Hint, use .Text property when you find the element
            Driver.FindElement(By.XPath("//li[@class='et_pb_tab_1']")).Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='et_pb_tab et_pb_tab_1 clearfix']")));
            Assert.AreEqual("Tab 2 content", 
                Driver.FindElement(By.XPath("//*[@class='et_pb_tab et_pb_tab_1 clearfix']")).Text);
            //in the HTML Table with id, highlight one of the salary cells
            HighlightElementUsingJavaScript(By.XPath("//td[contains(text(),'$150,000+')]"));

            //Highlight the center section called "Highlight me", but you can only
            //highlight the highest level div for that element. The top parent div.
            //Hint, this is the class - 
            //et_pb_column et_pb_column_1_3  et_pb_column_10 et_pb_css_mix_blend_mode_passthrough
            HighlightElementUsingJavaScript(By.XPath("//*[@class='et_pb_column et_pb_column_1_3 et_pb_column_10  et_pb_css_mix_blend_mode_passthrough']"));

            
        }

        // //h2[contains(text(),'HTML Table with no id')]/following-sibling::table//td[contains(text(),"$120,000")]
        [TestMethod]
        public void FindSalaryByTextTest()
        {
            Driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation/");
            Assert.IsTrue(Driver.FindElement(By.XPath("//h2[contains(text(),'HTML Table with no id')]/following-sibling::table//td[contains(text(),'$120,000')]")).Displayed);
        }

        [TestMethod]
        public void FindSalaryWithColumnLabelTest()
        {
            Driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation/");
            Assert.IsTrue(Driver.FindElement(By.XPath("//table[@id='htmlTableId']//tr//td[contains(text(),'Automation Testing Architect')]/following-sibling::td[contains(text(),'$120,000+')]")).Displayed);
        }

        [TestMethod]
        public void ConfirmButton1HeaderContentTest()
        {
            Driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation/");
            Assert.IsTrue(Driver.FindElement(By.XPath("//button[@id='button1']/../preceding-sibling::h3[contains(text(),'Feel free to practice your test automation on these elements')]")).Displayed);
            // Assert.IsTrue(_driver.FindElement(By.XPath("//button[text()='Click Me!']/ancestor::form/preceding-sibling::h3")).Text.Contains("Feel free to practice your test automation on these elements"));
        }

        [TestMethod]
        public void ConfirmLastRowQAEngineerTest()
        {
            Driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation/");
            Assert.IsTrue(Driver.FindElement(By.XPath("//table[@id='htmlTableId']//tr[last()]//td[contains(text(),'Quality Assurance Engineer')]")).Displayed);
        }
    }
}

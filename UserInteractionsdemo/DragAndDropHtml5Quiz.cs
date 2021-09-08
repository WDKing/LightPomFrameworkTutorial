using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using Assert = NUnit.Framework.Assert;
using System.IO;

namespace UserInteractionsdemo
{
    class DragAndDropHtml5Quiz
    {
        private IWebDriver driver;
        private Actions actions;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            actions = new Actions(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(6));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void DragDropQuiz()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/drag_and_drop");

            IWebElement sourceElement = driver.FindElement(By.XPath("//div[@id='column-a']"));
            IWebElement targetElement = driver.FindElement(By.XPath("//div[@id='column-b']"));

            wait.Until(ExpectedConditions.ElementToBeClickable(sourceElement));

            var jsFile = File.ReadAllText(@"C:\Source\LightPomFrameworkTutorial\UserInteractionsdemo\drag_and_drop_helper.js");
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript(jsFile + "$('#column-a').simulateDragDrop({dropTarget: '#column-b'});"); 

            Assert.AreEqual("A", targetElement.Text);
        }

    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System;
using Assert = NUnit.Framework.Assert;
using System.Diagnostics;

namespace UserInteractionsdemo
{
    [TestFixture]
    class DrawOnCanvasQuiz
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
        public void WriteOnCanvas()
        {
            driver.Navigate().GoToUrl("https://compendiumdev.co.uk/selenium/gui_user_interactions.html");
            IWebElement canvas = driver.FindElement(By.Id("canvas"));

            /* 
            actions
                .MoveToElement(canvas, 50, 50)
                .ClickAndHold()
                .MoveByOffset(50,50)
                .MoveByOffset(-50,50)
                .Perform(); */

            actions
                .MoveToElement(canvas, 50, 50)
                .ClickAndHold()
                .Perform();

            for (int i = 0; i < 5; i++)
            {
                actions.MoveByOffset(10, 10).Perform();
            }

            for (int j = 0; j < 5; j++)
            {
                actions.MoveByOffset(10, -10).Perform();
            }

            for (int k = 0; k < 5; k++)
            {
                actions.MoveByOffset(10, 10).Perform();
            }

            Assert.IsTrue(driver.FindElement(By.Id("keyeventslist")).Text.Contains("draw"));
        }

        [Test]
        public void WriteOnCanvasAnswer()
        {
            driver.Navigate().GoToUrl("https://compendiumdev.co.uk/selenium/gui_user_interactions.html");
            driver.Manage().Window.Maximize();

            IWebElement canvas = driver.FindElement(By.Id("canvas"));
            Debug.WriteLine($"canvas x:{canvas.Location.X}");
            Debug.WriteLine($"canvas y:{canvas.Location.Y}");

            var eventList = driver.FindElement(By.Id("keyeventslist"));

            var li = eventList.FindElements(By.TagName("li"));
            var eventCount = li.Count;

            for (int i = 0; i < 100; i++)
            {
                Random nd = new Random();
                var rnd2 = new Random(i + 3);

                var x = rnd2.Next(1, 100);
                var y = rnd2.Next(1, 100);
                Debug.WriteLine($"rnd:{canvas.Location.X - x}");
                Debug.WriteLine($"rnd2:{canvas.Location.Y - y}");
                actions
                    .DragAndDropToOffset(canvas, canvas.Location.X - x, canvas.Location.Y - y)
                    .Perform();
            }
        }
    }
}

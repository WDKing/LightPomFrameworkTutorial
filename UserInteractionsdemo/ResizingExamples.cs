using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using Assert = NUnit.Framework.Assert;

namespace UserInteractionsdemo
{
    [TestFixture]
    class ResizingExamples
    {
        private IWebDriver driver;
        private Actions actions;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            /* To open maximized and to open developer tools
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--auto-open-devtools-for-tabs");
            driver = new ChromeDriver(options);
            */

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
        public void ResizeExample1()
        {
            driver.Navigate().GoToUrl("http://jqueryui.com/resizable");
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement resizeHandle = driver.FindElement(By.XPath("//*[@class='ui-resizable-handle ui-resizable-se ui-icon ui-icon-gripsmall-diagonal-se']"));

            actions.ClickAndHold(resizeHandle).MoveByOffset(100, 100).Perform();

            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='resizable' and @style]")).Displayed);
        }
    }
}

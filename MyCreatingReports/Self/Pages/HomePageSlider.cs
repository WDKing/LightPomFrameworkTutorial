using OpenQA.Selenium;
using System;

namespace MyCreatingReports.Self.Pages
{
    internal class HomePageSlider
    {
        private IWebDriver Driver;
        internal IWebElement NextButton => Driver.FindElement(By.ClassName("bx-next"));
        internal IWebElement SliderWindow => Driver.FindElement(By.ClassName("bx-viewport"));

        public HomePageSlider(IWebDriver driver)
        {
            Driver = driver;
        }

        internal void ClickNext()
        {
            NextButton.Click();
        }

        internal string GetPosition() => SliderWindow.FindElement(By.Id("homeslider"))
                               .GetAttribute("style");
    }
}
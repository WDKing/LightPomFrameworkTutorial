using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPractice
{
    class AutomationQuizPage : AutomationQuizBasePage
    {
        internal readonly string URL = "http://www.ultimateqa.com/";

         public AutomationQuizPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal AutomationQuizPage Open()
        {
            driver.Navigate().GoToUrl(URL);
            return this;
        }

        internal AutomationQuizSearchPage SearchForComplicatedPage()
        {
            IWebElement searchBox = driver.FindElement(By.Name("s"));
            searchBox.SendKeys("Complicated Page");
            searchBox.SendKeys(Keys.Enter);
            return new AutomationQuizSearchPage(this.driver);
        }
    }
}

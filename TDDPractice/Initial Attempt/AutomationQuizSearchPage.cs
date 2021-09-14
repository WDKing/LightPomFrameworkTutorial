using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPractice
{
    class AutomationQuizSearchPage : AutomationQuizBasePage
    {

        public AutomationQuizSearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal AutomationQuizComplicatedPage LocateComplicatedPage()
        {
            // TODO
            return new AutomationQuizComplicatedPage(driver);
        }
    }
}

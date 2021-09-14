using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPractice
{
    class AutomationQuizBasePage
    {
        internal IWebDriver driver;

        public string AcquirePageTitle()
        {
            return driver.Title;
        }

        public string AcquirePageURL()
        {
            return driver.Url;
        }
    }
}

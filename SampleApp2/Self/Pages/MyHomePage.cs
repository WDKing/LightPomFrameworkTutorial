using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp2
{
    class MyHomePage
    {
        IWebDriver Driver { get; set; }
        public string Title => "My Store";
        public string URL => "http://automationpractice.com/index.php";

        public bool IsVisible => Driver.Title.Equals(Title);


        public MyHomePage(IWebDriver driver) {
            Driver = driver;
        }

        internal void Open()
        {
            Driver.Navigate().GoToUrl(URL);
            Assert.IsTrue(IsVisible, $"The expected page is not visible. Title observed: {Driver.Title}, Expected Title: {Title}");
        }


    }
}

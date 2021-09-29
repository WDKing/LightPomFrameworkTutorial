using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp2.Self
{
    [TestClass]
    [TestCategory("TestQuizes"), TestCategory("SampleApp2")]
    public class TestQuizes : BaseTests
    {
        internal HomePage HomePage { get; set; }
        internal ContactPage ContactPage { get; private set; }

        [TestMethod]
        [Description("Searching for a Blouse")]
        [TestProperty("Author", "KingWilliam")]
        public void TCID1()
        {
            string searchString = "blouse";
            HomePage = new HomePage(Driver);
            HomePage.Open();
            HomePage.SearchFor(searchString);
        }

        [TestMethod]
        [Description("Confirming contact page is open")]
        [TestProperty("Author", "KingWilliam")]
        public void TCID2()
        {
            ContactPage = new ContactPage(Driver);
            ContactPage.Open();
        }

        [TestMethod]
        [Description("Testing the Slider of the Home Page")]
        [TestProperty("Author", "KingWilliam")]
        public void TCID3()
        {

            HomePage = new HomePage(Driver);
            HomePage.Open();
            var position1 = HomePage.Slider.GetPosition();
            HomePage.Slider.ClickNext();
            var position2 = HomePage.Slider.GetPosition();
            Assert.AreNotEqual(position1, position2);
        }
    }
}

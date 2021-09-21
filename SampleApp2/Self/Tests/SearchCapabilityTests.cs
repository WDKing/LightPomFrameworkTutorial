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

namespace SampleApp2
{
    [TestClass]
    [TestCategory("SearchingFeature"), TestCategory("SampleApp2")]
    public class SearchCapabilityTests : BaseTest
    {
        private MyHomePage MyHomePage;

        [TestMethod]
        [Description("Searching for a Blouse")]
        [TestProperty("Author", "KingWilliam")]
        public void TCID1()
        {
            MyHomePage = new MyHomePage(Driver);
            MyHomePage.Open();
            // TODO SearchForBlouse();
            // TODO ConfirmSearch();
        }
    }
}

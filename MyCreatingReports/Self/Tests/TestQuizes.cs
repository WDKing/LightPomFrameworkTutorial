using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCreatingReports.Self.Pages;

namespace MyCreatingReports.Self.Tests
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

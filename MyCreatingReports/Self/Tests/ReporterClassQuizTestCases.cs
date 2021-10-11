using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCreatingReports;
using MyCreatingReports.Instructor;
using MyCreatingReports.Self.Pages;
using MyCreatingReports.Self.Tests;

namespace MyLoggingPractice.Self.Tests
{
    [TestClass]
    [TestCategory("ReporterClassQuiz")]
    public class ReporterClassQuizTestCases : BaseTests
	{
        [TestMethod]
        [Description("Checks to make sure that if we search for browser, that browser comes back.")]
        [TestProperty("Author", "KingWilliam-via-NikolayAdvolodkin")]
        public void TCID1()
        {
            var stringToSearch = "blouse";

            var homePage = new HomePage(Driver);
            homePage.Open();
            var searchPage = homePage.Search(stringToSearch);
            Assert.IsTrue(searchPage.ConfirmResultsFound(Item.Blouse),
                $"When searching for the string=>{stringToSearch}, " +
                $"we did not find it in the search results.");
        }

        /* TODO
        [TestMethod]
        [Description("Validate that slider changes images")]
        [TestProperty("Author", "NikolayAdvolodkin")]
        public void TCID3()
        {
            var homePage = new HomePage(Driver);
            homePage.GoTo();
            var currentImage = homePage.Slider.CurrentImage;
            homePage.Slider.ClickNextButton();
            var newImage = homePage.Slider.CurrentImage;
            homePage.Slider.AssertThatImageChanged(currentImage, newImage);
        }
        */
    }
}

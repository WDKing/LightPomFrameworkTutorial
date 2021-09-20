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
using static SampleFramework1.User;

namespace SampleFramework1
{
    [TestClass]
    [TestCategory("SampleApplicationLifecycleTests")]
    public class SampleApplicationLifecycleTests
    {
        private IWebDriver driver;
        private Actions actions;
        private WebDriverWait wait;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            actions = new Actions(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(6));
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }

        [TestMethod]
        public void SAL_Sprint3Input_Test1() => FillOutPerson("Zeus", "God of Olympus", User.GenderTypes.male);

        [TestMethod]
        public void SAL_Sprint3Input_Test2() => FillOutPerson("Kali", "God of India", User.GenderTypes.female);

        [TestMethod]
        public void SAL_Sprint3Input_Test3() => FillOutPerson("Loki", "God/dess of the Norse", User.GenderTypes.other);


        private void FillOutPerson(string firstName, string lastName, GenderTypes gender) 
        { 
            var appLifecyclePage = new AppLifecyclePage(driver, wait);
            appLifecyclePage.Open();

            Assert.IsTrue(appLifecyclePage.IsFirstNameFieldLoaded(), "First Name Field is Not Loaded");

            var user = new User(firstName, lastName, gender);

            appLifecyclePage.FillOutUserFields(user);
            var ultimateQAPage = appLifecyclePage.ClickSubmit();

            Assert.IsTrue(ultimateQAPage.IsLoaded, "UltimateQA Page is not Loaded, the desired element was not found.");
        }
    }
}

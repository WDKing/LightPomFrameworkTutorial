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
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        public Actions Actions { get; set; }
        internal AppLifecyclePage AppLifecyclePage { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Actions = new Actions(Driver);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(6));
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Close();
            Driver.Quit();
        }

        [TestMethod]
        public void SAL_Sprint3Input_TestUserSubmit1()
        {
            AppLifecyclePage = new AppLifecyclePage(Driver, Wait);
            AppLifecyclePage.GoToPage();
            AppLifecyclePage.FillOutUserFields(new User("Zeus", "God of Olympus", User.GenderTypes.Male));
            // TODO    AppLifecyclePage.FillOutEmergencyFields(new User("Kali", "God of India", User.GenderTypes.female));
            AppLifecyclePage.SubmitUser();
        }

        [TestMethod]
        public void SAL_Sprint3Input_TestUserSubmit2()
        {
            AppLifecyclePage = new AppLifecyclePage(Driver, Wait);
            AppLifecyclePage.GoToPage();
            AppLifecyclePage.FillOutUserFields(new User("Kali", "God of India", User.GenderTypes.Female));
            AppLifecyclePage.SubmitUser();
        }

        [TestMethod]
        public void SAL_Sprint3Input_TestUserSubmit3()
        {
            AppLifecyclePage = new AppLifecyclePage(Driver, Wait);
            AppLifecyclePage.GoToPage();
            AppLifecyclePage.FillOutUserFields(new User("Loki", "God/dess of the Norse", User.GenderTypes.Other));
            AppLifecyclePage.SubmitUser();
        }
        [TestMethod]
        public void SAL_Sprint3Input_TestEmergencySubmit1()
        {
            AppLifecyclePage = new AppLifecyclePage(Driver, Wait);
            AppLifecyclePage.GoToPage();
            AppLifecyclePage.FillOutEmergencyFields(new User("Zeus", "God of Olympus", User.GenderTypes.Male));
            AppLifecyclePage.SubmitEmergency();
        }
        [TestMethod]
        public void SAL_Sprint3Input_TestEmergencySubmit2()
        {
            AppLifecyclePage = new AppLifecyclePage(Driver, Wait);
            AppLifecyclePage.GoToPage();
            AppLifecyclePage.FillOutEmergencyFields(new User("Kali", "God of India", User.GenderTypes.Female));
            AppLifecyclePage.SubmitEmergency();
        }
        [TestMethod]
        public void SAL_Sprint3Input_TestEmergencySubmit3()
        {
            AppLifecyclePage = new AppLifecyclePage(Driver, Wait);
            AppLifecyclePage.GoToPage();
            AppLifecyclePage.FillOutEmergencyFields(new User("Loki", "God/dess of the Norse", User.GenderTypes.Other));
            AppLifecyclePage.SubmitEmergency();
        }
    }
}

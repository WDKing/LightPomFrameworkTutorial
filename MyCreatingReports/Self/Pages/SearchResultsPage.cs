using MyCreatingReports.Instructor;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreatingReports.Self.Pages
{
    class SearchResultsPage
    {
        private string Title => "Search - My Store";
        private IWebDriver Driver { get; set; }
        public bool IsVisible => Driver.Title.Equals(Title);

        public SearchResultsPage(IWebDriver driver)
        {
            Driver = driver;
        }

        internal bool ConfirmResultsFound(string searchString)
        {
            ReadOnlyCollection<IWebElement> searchResults = Driver.FindElements(By.ClassName("product-name"));

            foreach(IWebElement searchResult in searchResults)
            {
                if(searchResult.Text.ToLower().Contains(searchString.ToLower()))
                {
                    return true;
                }
            }

            return false;
        }

		internal bool ConfirmResultsFound(Item item)
		{
            return ConfirmResultsFound(item.ToString());
		}
	}
}

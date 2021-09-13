using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    class PageObjectTestPage
    {
        IWebElement buyButton;
        IWebElement shoppingBag;

        public static string URL = "https://react-shopping-cart-67954.firebaseapp.com/";

        public PageObjectTestPage(IWebDriver driver)
        {
            buyButton = driver.FindElement(By.ClassName("shelf-item__buy-btn"));
            shoppingBag = driver.FindElement(By.ClassName("bag__quantity"));
            URL = "https://react-shopping-cart-67954.firebaseapp.com/";
        }

        internal void ClickBuyButton()
        {
            buyButton.Click();
        }

        internal int AcquireBagQuantity()
        {
            return int.Parse(shoppingBag.Text);
        }
    }
}

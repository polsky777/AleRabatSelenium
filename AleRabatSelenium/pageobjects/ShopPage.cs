using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AleRabatSelenium.pageobjects
{
    internal class ShopPage : BasePage
    {
        public ShopPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetCashbackHeadlineText()
        {
            return driver.FindElement(By.CssSelector("h1.m-header__headline")).Text;
        }

    }
}

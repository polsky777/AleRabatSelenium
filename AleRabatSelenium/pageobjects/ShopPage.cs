using OpenQA.Selenium;

namespace AleRabatSelenium.Pageobjects
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

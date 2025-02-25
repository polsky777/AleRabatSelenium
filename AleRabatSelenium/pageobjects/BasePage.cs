using OpenQA.Selenium;

namespace AleRabatSelenium.Pageobjects
{
    internal class BasePage
    {
        public IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}

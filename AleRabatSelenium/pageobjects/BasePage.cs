
using AleRabatSelenium.utilities;
using OpenQA.Selenium;

namespace AleRabatSelenium.pageobjects
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

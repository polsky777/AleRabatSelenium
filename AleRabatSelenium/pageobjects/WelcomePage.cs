using AleRabatSelenium.Helpers;
using log4net;
using OpenQA.Selenium;

namespace AleRabatSelenium.Pageobjects
{
    internal class WelcomePage : BasePage
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(WelcomePage));
        public WelcomePage(IWebDriver driver) : base(driver)
        {
        }
        public void ClickMenu()
        {
            IWebElement clickableElement = WaitHelper.WaitForElementClickable(driver, By.XPath("//button[contains(text(),'Menu')]"));
            clickableElement.Click();
        }
        public void ClickLogIn()
        {
            IWebElement clickableElement = WaitHelper.WaitForElementClickable(driver, By.XPath("//button[contains(text(),'Zaloguj')]"));
            clickableElement.Click();
        }

    }
}

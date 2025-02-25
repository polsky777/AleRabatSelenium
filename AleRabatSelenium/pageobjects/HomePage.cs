using AleRabatSelenium.Helpers;
using OpenQA.Selenium;

namespace AleRabatSelenium.Pageobjects
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickAgreement()
        {
            IWebElement clickableElement = WaitHelper.WaitForElementClickable(driver, By.XPath("//button[contains(text(),'Zgadzam się')]"));
           clickableElement.Click();
        }
    }
}

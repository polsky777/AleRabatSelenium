using AleRabatSelenium.Helpers;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AleRabatSelenium.Pageobjects
{
    internal class MainHeader : BasePage
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MainHeader));
        public MainHeader(IWebDriver driver) : base(driver) 
        { 
        }

        private readonly By _locatorSearchInput = By.XPath("//input[@placeholder='np. adidas, Media Markt, CCC']");
        private readonly By _locatorSearchButton = By.XPath("//button[@class='m-form__button']");

        public void TypeSearch(string text)
        {
            try
            {
                var searchInput = WaitHelper.WaitForElementClickable(driver, _locatorSearchInput);

                searchInput.Clear();
                searchInput.SendKeys(text);
                var searchButton = WaitHelper.WaitForElementClickable(driver, _locatorSearchButton);
                searchButton.Click();
                var link = WaitHelper.WaitForElementClickable(driver, By.XPath($"//h3[text()='{text}']"));
                if (link != null && link.Displayed && link.Enabled)
                {
                    var actions = new Actions(driver);
                    actions.MoveToElement(link).Click().Perform();
                }

            }
            catch (NoSuchElementException)
            {
                log.Info("Search field was not found");
            }
            catch (WebDriverTimeoutException)
            {
                log.Info("The search field did not appear within the expected time");
            }
        }
        public bool IsButtonVisibleAndActive(string text)
        {
            try
            {
                var button = driver.FindElement(By.XPath($"//button[@data-open-login-or-register='{text}']"));
                return button.Displayed && button.Enabled;
            }
            catch (NoSuchElementException)
            {

                return false; 
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }
        public bool IsElementVisibleAndEnabled(string text)
        {
            try
            {
                var button = driver.FindElement(By.XPath($"//span[text()='{text}']"));
                return button.Displayed && button.Enabled;
            }
            catch (NoSuchElementException)
            {
                return false; 
            }
            catch (StaleElementReferenceException)
            {
                return false; 
            }
        }

    }
}


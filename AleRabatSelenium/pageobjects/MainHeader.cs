using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AleRabatSelenium.helpers;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AleRabatSelenium.pageobjects
{
    internal class MainHeader :BasePage
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MainHeader));
        public MainHeader(IWebDriver driver) : base(driver) 
        { 
        }
        public void TypeSearch(string text)
        {
            try
            {
                var searchInput = WaitHelper.WaitForElementClickable(driver, By.XPath("//input[@placeholder='np. adidas, Media Markt, CCC']"));
                searchInput.Clear();
                searchInput.SendKeys(text);
                searchInput.Click();
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
    }
}

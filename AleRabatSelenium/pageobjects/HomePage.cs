using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AleRabatSelenium.helpers;
using OpenQA.Selenium;

namespace AleRabatSelenium.pageobjects
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

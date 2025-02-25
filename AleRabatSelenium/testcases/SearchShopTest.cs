using log4net;
using AleRabatSelenium.Basetest;
using AleRabatSelenium.Utilities;
using AleRabatSelenium.Pageobjects;
using FluentAssertions;

namespace AleRabatSelenium.testcases
{

    [TestFixture]
    internal class SearchShopTest : BaseTest
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SearchShopTest));

        [Parallelizable]
        [Test, TestCaseSource(nameof(GetTestData))]
        public void SearchShopViaSearch(string browserType, string executionMode, string shopName, string headline)
        {
            var testName = TestContext.CurrentContext.Test.Name;
            log.Info($"Test is starting: {testName}");

            if (executionMode.Equals("N"))
            {
                log.Info("Ignoring the test as the run mode is NO");
                Assert.Ignore("Ignoring the test as the run mode is NO");
            }

            Setup(browserType);
            HomePage home = new HomePage(driver.Value);
            home.ClickAgreement();
            WelcomePage welcomePage = new WelcomePage(driver.Value);
            welcomePage.ClickMenu();

            MainHeader header = new MainHeader(GetDriver());
            header.TypeSearch(shopName);
            ShopPage shopPage = new ShopPage(driver.Value);
            var headlineText = shopPage.GetCashbackHeadlineText();
            var isHeadlineCorrect = headlineText.Contains(headline);

            isHeadlineCorrect.Should().BeTrue($"Expected headline to contain '{headline}', but it was '{headlineText}'");

        }
        public static IEnumerable<TestCaseData> GetTestData()
        {
            var columns = new List<string> { "browserType", "executionMode", "shopName", "headline" };
            return DataUtilities.GetTestDataFromExcel(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Resources\testdata.xlsx", "FindShop", columns);
        }

    }
}

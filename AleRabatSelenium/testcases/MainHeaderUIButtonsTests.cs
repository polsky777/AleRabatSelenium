using log4net;
using AleRabatSelenium.Basetest;
using AleRabatSelenium.Utilities;
using AleRabatSelenium.Pageobjects;
using FluentAssertions;

namespace AleRabatSelenium.testcases
{
    [TestFixture]
    internal class MainHeaderUIButtonsTests : BaseTest
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MainHeaderUIButtonsTests));

        [Parallelizable]
        [Test, TestCaseSource(nameof(GetTestData))]
        public void ShouldDisplayAndBeClickableForAllButtonsInMainHeader(string browserType, string executionMode)
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

            var buttons = new Dictionary<string, bool>
            {
                { "Login", header.IsButtonVisibleAndActive("login") },
                { "SignUp", header.IsButtonVisibleAndActive("register") },
                { "MainSite", header.IsElementVisibleAndEnabled("Strona główna") },
                { "Categories", header.IsElementVisibleAndEnabled("Kategorie") },
                { "Top100", header.IsElementVisibleAndEnabled("Top100") },
                { "Shops", header.IsElementVisibleAndEnabled("Sklepy") },
                { "GiftCards", header.IsElementVisibleAndEnabled("Karty podarunkowe") }
            };


            foreach (var button in buttons)
            {
                button.Value.Should().BeTrue($"{button.Key} button should be visible and active.");
            }
        }

        public static IEnumerable<TestCaseData> GetTestData()
        {
            var columns = new List<string> { "browserType", "executionMode"};
            return DataUtilities.GetTestDataFromExcel(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Resources\testdata.xlsx", "ButtonsMainHeader", columns);
        }
    }
}

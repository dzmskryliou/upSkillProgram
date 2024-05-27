using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Tests;


namespace Tests
{
    public class TestTwoGlobalSearch : BaseTest
    {

        [Test]

        [TestCase("blockchain")]
        [TestCase("cloud")]
        [TestCase("automation")]
        public void CompareTest(string itemToSearch)
        {
            Log.Info("Hello. This is the beginning of Test CompareTest");

            IWebDriver driver = new EdgeDriver();
            var homePage = new HomePage(driver, Log);
            var navMenu = new NavigationMenu(driver, Log);
            var windowSize = new ManageWindowSize(driver, Log);

            homePage.Open();
            windowSize.MaximizeWindow();
            homePage.AcceptCookies();
            navMenu.Search(itemToSearch);
            homePage.SearchTextInLinkCount($"//a[contains(@href, '{itemToSearch}')]");
        }

        private class HomePage
        {
            private IWebDriver driver;
            private ILog log;

            public HomePage(IWebDriver driver, ILog log)
            {
                this.driver = driver;
                this.log = log;
            }
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Tests;

namespace Tests
{

    public class TestFourSelectSlideCompareTitle : BaseTest
    {
        [Test]
        public void SelectSlideCompareTitle()
        {
            Log.Info("Hello. This is the beginning of Test SelectSlideCompareTitle");

            IWebDriver driver = new EdgeDriver();
            var homePage = new HomePage(driver, Log);
            var navMenu = new NavigationMenu(driver, Log);
            var windowSize = new ManageWindowSize(driver, Log);
            var insightsPage = new InsightsPage(driver, Log);

            homePage.Open();
            windowSize.MaximizeWindow();
            homePage.AcceptCookies();
            navMenu.ClickNavLink("//a[@class = 'top-navigation__item-link js-op'][@href='/insights']");
            insightsPage.ClickNextSlideBtn();
            insightsPage.ClickNextSlideBtn();
            insightsPage.ClickReadMoreOnSlider();
            insightsPage.FindTextInTitle("Three Ways Leaders Impede Their Company’s");
        }
    }
}
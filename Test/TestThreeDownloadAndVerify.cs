using Business;
using Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Tests;

namespace Tests
{

    public class TestThreeDownloadAndVerify : BaseTest
    {
        [Test]
        public void DownloadAndVerify()
        {
            Log.Info("Hello. This is the beginning of Test DownloadAndVerify");

            IWebDriver driver = new EdgeDriver();
            var homePage = new HomePage(driver, Log);
            var navMenu = new NavigationMenu(driver, Log);
            var aboutPage = new AboutPage(driver, Log);
            var localInstance = new LocalInstance(driver, Log);
            var windowSize = new ManageWindowSize(driver, Log);

            homePage.Open();
            windowSize.MaximizeWindow();
            homePage.AcceptCookies();
            navMenu.ClickNavLink("//a[@class = 'top-navigation__item-link js-op'][@href='/about']");
            aboutPage.DownloadTheFile();
            localInstance.OpenLocalInstance("file:///C:/Users/Dzmitry_Skryliou/Downloads/");
            localInstance.FindDownloadedFile("EPAM_Corporate_Overview_Q4_EOY");
        }
    }
}
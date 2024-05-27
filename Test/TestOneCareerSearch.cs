using Business;
using Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Tests;

namespace Tests

{

    public class TestOneCareerSearch : BaseTest
    {

        [Test]
        public void CareerSearchTest()
        {
            Log.Info("Hello. This is the beginning of Test CareerSearchTest");

            IWebDriver driver = new EdgeDriver();
            var homePage = new HomePage(driver, Log);
            var navMenu = new NavigationMenu(driver, Log);
            var careerSearchPage = new CareerSearch(driver, Log);
            var careerSearchForm = new CareerSearchForm(driver, Log);
            var windowSize = new ManageWindowSize(driver, Log);


            homePage.Open();
            windowSize.MaximizeWindow();
            homePage.AcceptCookies();
            navMenu.ClickNavLink("//a[@class = 'top-navigation__item-link js-op'][@href='/careers']");
            careerSearchForm.KeyWordOrLanguage(".net");
            careerSearchForm.SelectLocation();
            careerSearchForm.SelectRemote();
            careerSearchForm.SubmitSearchForm();
            careerSearchPage.SortTheResultsByDate();
            careerSearchPage.SelectLatestOpportunity();
            careerSearchPage.ProgrammingLanguageMentioned();

        }
    }
}


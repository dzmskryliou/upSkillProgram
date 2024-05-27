using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using SpecFlowTask.Core;
using SpecFlowTask.Drivers;
using SpecFlowTask.Pages;

namespace SpecFlowTask.StepDefinitions
{
    [Binding]
    public sealed class MainMenuStepDefinitions
    {


        [Given("I open official SpecFlow web site")]
        public static void OpenTheHomePage()
        {
            var basePage = new BasePage();
            var homePage = new HomePage();

            basePage.Open("https://specflow.org/");
            basePage.MaximizeTheWindow();
            homePage.AcceptCookies();
        }


        [When("I hover the (.*) item from the main menu")]
        public static void HoverMenuItem(string mainMenuItem)
        {


            var mainMenu = new MainMenu();

            mainMenu.HoveringMenu(mainMenuItem);
        }

        [When("I click (.*) option from the main menu")]

        public static void ClickSubmenuItem(string subMenuOption)
        {

            var mainMenu = new MainMenu();

            mainMenu.ClickingSubMenuItem(subMenuOption);
        }

        [When("I click on the 'search docs' field")]

        public static void ClickSearchDocks()
        {

            var searchOption = new Search();

            searchOption.ClickingSearchDocsField();
        }

        [When("I type (.*) in the popup window")]

        public static void EnterSearchParam(string searchItem)
        {

            var searchOption = new Search();

            searchOption.SearchForItem(searchItem);
        }

        [When("I select the (.*) page from the suggestions")]
        public static void OpenThePage(string neededPage)
        {
            var resultPage = new Search();

            resultPage.SelectTheItem(neededPage);
        }

        [Then("Page with (.*) title should be opened")]
        public static void ThenTheResultShouldBe(string searchItem)
        {
            var basePage = new BasePage();

            basePage.PageLoadCheck(searchItem);
        }
    }
}

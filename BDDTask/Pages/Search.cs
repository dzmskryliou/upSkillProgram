using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SpecFlowTask.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowTask.Pages
{
    public class Search
    {
        private readonly EdgeDriver driver = WebDriverManager.Driver;

        public void ClickingSearchDocsField()
        {
            var searchDocksPanel = driver.FindElement(By.XPath("//form[@id = 'rtd-search-form']/input"));
            searchDocksPanel.Click();
        }


        public void SearchForItem(string searchItem)
        {
            driver.FindElement(By.XPath("//input[@class = 'search__outer__input']")).SendKeys(searchItem + Keys.Enter);
        }

        public void SelectTheItem(string neededPage)
        {
            var resultPage = driver.FindElement(By.XPath($"//li/a/span[contains(text(), '{neededPage}')]"));
            resultPage.Click();
            Console.WriteLine("The link is opened");
        }
    }
}

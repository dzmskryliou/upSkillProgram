using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CareerSearch
    {

        private readonly ILog _log;
        private readonly IWebDriver _driver;
        public CareerSearch(IWebDriver driver, ILog log)
        {
            this._driver = driver ?? throw new ArgumentException(nameof(driver));
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void SortTheResultsByDate()
        {
            _log.Info("Click on sort by 'Date' button");
            var sortByDate = _driver.FindElement(By.XPath("//label[@class = 'search-result__sorting-label list']"));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            sortByDate.Click();
            _log.Info("Search results are sorted by Date");
        }

        public void SelectLatestOpportunity()
        {
            _log.Info("Click on the first search result");
            var latestOpportunity = _driver.FindElement(By.XPath("//li[1]/descendant::div[@class = 'search-result__item-controls']/a"));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            latestOpportunity.Click();
            _log.Info("Selected search result page opened");
        }

        public void ProgrammingLanguageMentioned()
        {
            _log.Info("Looking if programming language is mentioned on the page");
            var TextOnThePage = _driver.FindElement(By.XPath($"//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '.net')]"));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            System.Console.WriteLine("The text is on the page");
        }
    }
}

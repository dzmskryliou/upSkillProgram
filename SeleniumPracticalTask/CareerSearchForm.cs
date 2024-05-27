using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CareerSearchForm
    {

        private readonly ILog _log;
        private readonly IWebDriver _driver;
        public CareerSearchForm(IWebDriver driver, ILog log)
        {
            this._driver = driver ?? throw new ArgumentException(nameof(driver));
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void KeyWordOrLanguage(string programmingLanguage)
        {
            _log.Info($"Enter {programmingLanguage} in the jod search keyword field");
            _driver.FindElement(By.Id("new_form_job_search-keyword")).Clear();

            var searchKey = _driver.FindElement(By.Id("new_form_job_search-keyword"));
            var clickAndSendKeysActions = new Actions(_driver);

            clickAndSendKeysActions.Click(searchKey)
                .Pause(TimeSpan.FromSeconds(1))
                .SendKeys(programmingLanguage)
                .Perform();
            _log.Info($"{programmingLanguage} is displayed in the jod search keyword field");
        }
        public void SelectLocation()
        {
            _log.Info("Select 'All Locations' option");
            var expandDropdown = _driver.FindElement(By.XPath("//form/div[@class ='recruiting-search__column']/div[@class = 'recruiting-search__location']"));
            expandDropdown.Click();

            IWebElement AllLocations = _driver.FindElement(By.XPath("//div[@class = 'os-content']//li[@title = 'All Locations']"));
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));

            _driver.FindElement(By.XPath("//div[@class = 'os-content']//li[@title = 'All Locations']"));
            wait.Until(d => AllLocations.Displayed);

            AllLocations.Click();

            _log.Info("'All Locations' option is selected and displayed in the locations field");
        }

        public void SelectRemote()
        {
            _log.Info("Select 'Remote' checkbox");

            var selectRemote = _driver.FindElement(By.XPath("//p[@class = 'job-search__filter-items job-search__filter-items--remote']"));
            selectRemote.Click();

            _log.Info("'Remote' checkbox is marked as selected");
        }

        public void SubmitSearchForm()
        {
            _log.Info("Click submit button");
            var clickFind = _driver.FindElement(By.XPath("//form[@id = 'jobSearchFilterForm']/button"));
            clickFind.Click();
            _log.Info("Search results are displayed as list according to the specified search parameters");
        }
    }
}

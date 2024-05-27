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
    public class NavigationMenu
    {

        public NavigationMenu(IWebDriver driver, ILog log)
        {
            this._driver = driver ?? throw new ArgumentException(nameof(driver));
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        private IWebDriver _driver;
        private readonly ILog _log;

        public void ClickNavLink(string link)
        {
            _log.Info($"Click Navigation Menu link: {link}");
            _driver.FindElement(By.XPath(link)).Click();
            _log.Info($"Navigation Menu link: {link} page is opened");
        }

        public void Search(string phrase)
        {
            _log.Info($"Performing search with phrase: {phrase}");

            var searchIcon = _driver.FindElement(By.ClassName("dark-iconheader-search__search-icon"));
            searchIcon.Click();

            var searchPanelWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2))
            {
                PollingInterval = TimeSpan.FromSeconds(0.25),
                Message = "Search panel has not been found"
            };

            var searchPanel = searchPanelWait.Until(driver => driver.FindElement(By.ClassName("header-search__panel")));
            var searchInput = searchPanel.FindElement(By.Name("q"));

            var clickAndSendKeysActions = new Actions(_driver);

            clickAndSendKeysActions.Click(searchInput)
                .Pause(TimeSpan.FromSeconds(1))
                .SendKeys(phrase)
                .Perform();

            var findButton = searchPanel.FindElement(By.XPath("//div[@class='search-results__input-holder']/following-sibling::button"));
            findButton.Click();

        }
    }
}

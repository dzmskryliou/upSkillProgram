using log4net;
using OpenQA.Selenium;

namespace Business
{
    public class HomePage
    {
        private static string Url { get; } = "https://www.epam.com";

        private readonly ILog _log;
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver, ILog log)
        {
            this._driver = driver ?? throw new ArgumentException(nameof(driver));
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public HomePage Open()
        {
            _log.Info($"Opening URL: {Url}");
            _driver.Url = Url;
            return this;
        }

        public void AcceptCookies()
        {
            _log.Info("Close Accept Cookies banner");
            var acceptButton = _driver.FindElement(By.XPath("//button[@id = 'onetrust-accept-btn-handler']"));
            acceptButton.Click();
            _log.Info("Accept Cookies banner closed");
        }

        public void SearchTextInLinkCount(string partOfLink)
        {
            _log.Info($"Count the links that contain {partOfLink} text");
            var elements = _driver.FindElements(By.XPath(partOfLink));
            System.Console.Write(elements.Count);
        }
    }
}

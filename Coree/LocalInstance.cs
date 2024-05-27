using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class LocalInstance
    {
        private readonly ILog _log;
        private readonly IWebDriver _driver;
        public LocalInstance(IWebDriver driver, ILog log)
        {
            this._driver = driver ?? throw new ArgumentException(nameof(driver));
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void OpenLocalInstance(string url)
        {
            _log.Info($"Open the folder where the file was downloaded: {url}");
            _driver.SwitchTo().NewWindow(WindowType.Tab);
            _driver.Navigate().GoToUrl($"{url}");
        }

        public void FindDownloadedFile(string partOfLinkText)
        {
            _log.Info($"Find the file with the title containing text: {partOfLinkText}");
            _driver.FindElement(By.XPath($"//a[contains(@href, {partOfLinkText})]"));
            Console.WriteLine("Document was downloaded");
        }
    }
}

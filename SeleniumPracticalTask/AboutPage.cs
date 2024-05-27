using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class AboutPage
    {

        private readonly ILog _log;
        private readonly IWebDriver _driver;
        public AboutPage(IWebDriver driver, ILog log)
        {
            this._driver = driver ?? throw new ArgumentException(nameof(driver));
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void DownloadTheFile()
        {
            _log.Info("Click on download button, file download started");

            var downloadButton = _driver.FindElement(By.XPath("//a[@class = 'button-ui-23 btn-focusable'][1]"));
            downloadButton.Click();
        }

    }
}

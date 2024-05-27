using log4net;
using OpenQA.Selenium;

namespace Core
{

    public class ManageWindowSize
    {

        private readonly ILog _log;
        private readonly IWebDriver _driver;
        public ManageWindowSize(IWebDriver driver, ILog log)
        {
            this._driver = driver ?? throw new ArgumentException(nameof(driver));
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }


        public void MaximizeWindow()
        {
            _log.Info("Maximize the window");
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
    }
}

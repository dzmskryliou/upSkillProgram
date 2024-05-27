using log4net;
using NUnit.Framework;
using OpenQA.Selenium;


namespace Tests
{
    public class BaseTest
    {
        protected static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IWebDriver _driver;

        [OneTimeSetUp]
        public void BaseSetUp()
        {
            LogHelper.InitializeLogger();
            _driver = WebDriverManager.GetDriver();
        }

        [OneTimeTearDown]
        public void BaseTearDown()
        {
            _driver.Quit();
        }

        protected IWebDriver Driver => _driver;
    }
}
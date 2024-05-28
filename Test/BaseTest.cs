using Core;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;


namespace Tests
{
    public class BaseTest
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        protected static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        private IWebDriver _driver;

        [OneTimeTearDown]
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

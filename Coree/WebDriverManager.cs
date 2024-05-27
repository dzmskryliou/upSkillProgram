using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Core
{
    public class WebDriverManager
    {
        private static IWebDriver? _driver;

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                _driver = new EdgeDriver();
            }
            return _driver;
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}
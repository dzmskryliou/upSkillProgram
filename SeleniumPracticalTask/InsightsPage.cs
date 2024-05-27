using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class InsightsPage
    {

        private readonly ILog _log;
        private readonly IWebDriver _driver;
        public InsightsPage(IWebDriver driver, ILog log)
        {
            this._driver = driver ?? throw new ArgumentException(nameof(driver));
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }


        public void ClickNextSlideBtn()
        {
            _log.Info("Switch to the next slide of the slider");
            var clickNextBtn = _driver.FindElement(By.XPath("//button[@class = 'slider__right-arrow slider-navigation-arrow']"));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            clickNextBtn.Click();
            _log.Info("Slider moved to the next slide");

        }
        public void ClickReadMoreOnSlider()
        {
            _log.Info("Click Read More on the slider");
            var clickReadMore = _driver.FindElement(By.XPath("//div[@class = 'owl-item active']//a[@class = 'custom-link link-with-bottom-arrow color-link body-text font-900 slider-cta-link']"));
            clickReadMore.Click();
            _log.Info("Page referenced to the slide is opened");
        }

        public void FindTextInTitle(string textToFind)
        {
            _log.Info($"Find {textToFind} in the title");
            var element = _driver.FindElement(By.XPath($"//p/span/span[@class='museo-sans-light' and contains(text(), '{textToFind}')]"));
        }
    }
}

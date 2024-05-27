using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using SpecFlowTask.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowTask.Pages
{
    public class MainMenu
    {
        private readonly EdgeDriver driver = WebDriverManager.Driver;

        public void HoveringMenu(string mainMenuItem)
        {
            var navMenu = driver.FindElement(By.XPath($"//li/a[contains(text(), '{mainMenuItem}')][1]"));
            Actions action = new Actions(driver);
            action.MoveToElement(navMenu).Perform();
        }

        public void ClickingSubMenuItem(string subMenuOption)
        {
            var subMenuItem = driver.FindElement(By.XPath($"//li[@class = 'menu-item menu-item-type-custom menu-item-object-custom']/a[contains(text(), '{subMenuOption}')][1]"));
            subMenuItem.Click();
        }
    }
}

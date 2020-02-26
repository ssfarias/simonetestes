using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using Tests.Usability;

namespace Tests.PageObjective
{
    public class PageNav
    {
        private IWebDriver _driver;
        //private Browser _browser;
        //private IWebDriver _driver;

        public PageNav(IWebDriver browser)
        {
            IWebDriver _browser = browser;
            _browser = browser;
          //  string pathDriver = null;

            //if (browser == Browser.Chrome)
            //{
            //  pathDriver = ConfigurationManager.AppSettings["DriverChrome"];
            //}
            // _driver = WebDriverFactory.GetWebDriver(browser, pathDriver);
            _driver = browser;
        }

        public void LoadPage()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            _driver.Navigate().GoToUrl("https://www.ubs.com/br/en.html");
        }
    }
}

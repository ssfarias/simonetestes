using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Tests.Usability
{
    public static class WebDriverFactory
    {
        public static IWebDriver GetWebDriver(Browser browser, string pathDriver)
        {
            //Method will return the browsers instances. I am working with FireFox and Chrome
            IWebDriver webDriver = null;
            switch(browser)
            { 
                case Browser.Firefox:
                    webDriver = new FirefoxDriver();
                    break;
                case Browser.Chrome:
                    webDriver = new ChromeDriver(@"C:\Selenium\ChromeDriver");
                    break;  
            }
            return webDriver;
        }
       
    }
}

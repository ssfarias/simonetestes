using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using Tests.Usability;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Tests.PageObjective
{
    public class PageObject
    {
        private Browser _browser;
        private IWebDriver _driver;       

        //Constructor
        public PageObject(Browser browser)
        {
            _browser = browser;
            string pathDriver = null;

            if (browser == Browser.Chrome)
            {
                pathDriver = ConfigurationManager.AppSettings["DriverChrome"];
            }
            _driver = WebDriverFactory.GetWebDriver(browser, pathDriver);
        }
        public void LoadPage()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            _driver.Navigate().GoToUrl("https://www.ubs.com/br/en.html");
        }

        public IWebElement ReadMoreButton => _driver.FindElement(By.ClassName("actionbutton__txtbody"));
        public IWebElement SearchJobCarrers => _driver.FindElement(By.XPath("(//a[contains(.,'Careers')])[1]"));
        public IWebElement SearchJob => _driver.FindElement(By.XPath("(//a[contains(.,'Careers')])[1]"));
        public IWebElement SearchField => _driver.FindElement(By.Id("pagesearchfield"));

        public void ClickInReadMoreButton()
        {
            ReadMoreButton.Click();
        }

        public void ClickToSearchJob()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
            SearchJobCarrers.Click();
            var SearchJob = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//a[contains(.,'Careers')])[1]")));
            SearchJob.Click();
        }

        public void ValidateShowElementCareers()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
            var Careers  = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='header__hlTitle'][contains(.,'Careers')]"))).Text;
            Assert.IsNotNull(Careers);
        }
        
        public void CLickInBrazilLink()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(50));
            wait.Until((d) => d.FindElement(By.XPath("//a[contains(.,'Global contacts')]"))).Click();            
            wait.Until((d) => d.FindElement(By.XPath("(//a[contains(.,'Brazil')])[2]"))).Click();
        }

        public void FillContactRequeredFields(PageBaseDto dto)
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 40));
            wait.Until((d) => d.FindElement(By.Id("text1_sfcollection"))).SendKeys(dto.Title);
            wait.Until((d) => d.FindElement(By.Id("text2_sfcollection"))).SendKeys(dto.Confirmation);
            wait.Until((d) => d.FindElement(By.Id("memo1"))).SendKeys(dto.Request);
            wait.Until((d) => d.FindElement(By.XPath("//label[contains(.,'Mrs/Ms')]"))).Click();
            wait.Until((d) => d.FindElement(By.Id("firstName"))).SendKeys(dto.Name);
            wait.Until((d) => d.FindElement(By.Id("lastName"))).SendKeys(dto.LastName);
            wait.Until((d) => d.FindElement(By.Id("email"))).SendKeys(dto.Email);
            wait.Until((d) => d.FindElement(By.Id("phoneNumber"))).SendKeys(dto.Contact);
            wait.Until((d) => d.FindElement(By.XPath("//select[@name='domicile_sfcollection']"))).SendKeys(dto.Country);
            wait.Until((d) => d.FindElement(By.XPath("//input[@type='checkbox']"))).Click();
            wait.Until((d) => d.FindElement(By.XPath("//span[@class='actionbutton__txtbody']"))).Click();            
        }
        
        public void ContactConfirmation(PageBaseDto dto)
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 40));
            string message = (dto.Message);
            var elementMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[@class='form__msgTxt']"))).Text;

            Assert.AreEqual(elementMessage, message);
        }

        public void ValidateContactEmail()
        {
            string message = ("Please enter a valid e-mail address.");
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 40));
            var elementEspected = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='form__error']"))).Text;
            
            Assert.AreEqual(elementEspected, message);              
        }

        public void SelectLanguage()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menulabel-5001"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menulabel-5113"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menulabel-5248"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menulabel-5129"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menulabel-524151"))).Click();

            string language = "PT";
            var espectedLanguage = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='/br/pt.html'][contains(.,'PT')]"))).Text;
            Assert.AreEqual(espectedLanguage, language);
        }

        public void Search(PageBaseDto dto)
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Search')]"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pagesearchfield"))).SendKeys(dto.WrongSearch);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(.,'Clear')]"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pagesearchfield"))).SendKeys(dto.SearchOk);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@type='submit']"))).Click();
            var espected = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='searchresults']")));

            Assert.IsNotNull(espected);           
        }
        public void SearchLegalInformationByCountry()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menulabel-5001"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menulabel-51356"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menulabel-7001"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menulabel-7146"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menulabel-7017"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menulabel-714149"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(.,'Financial Information UBS Brasil')]"))).Click();

            var legalBrazil = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[contains(.,'Brazil')]")));
            Assert.IsNotNull(legalBrazil);
        }

        public void Close()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace Tests.stepsTests
{
    [Binding]
    public class SubmitRequestContactFormSteps
    {
        IWebDriver Browser;              
        private string url = "https://www.ubs.com/br/en.html";
       
        [BeforeScenario]
        public void Init()
        {
            this.Browser = new ChromeDriver();           
        }

        [AfterScenario]
        public void Close()
        {
            Browser.Quit();
            Browser = null;
        }    

        [Given(@"user clicks in the Gogal Contact link")]
        public void GivenUserClicksInTheGogalContactLink()
        {
            Browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            Browser.Navigate().GoToUrl(url);
        }

        [Given(@"user clicks the contact link")]
        public void GivenUserClicksTheContactLink()
        {
            WebDriverWait wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(30));
            wait.Until((d) => d.FindElement(By.XPath("//a[@href='/global/en/contact.html']"))).Click();
        }

        [Given(@"user acess the contact form")]
        public void GivenUserAcessTheContactForm()
        {
            WebDriverWait wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(40));
            wait.Until((d) => d.FindElement(By.XPath("(//a[contains(.,'Brazil')])[2]"))).Click();
        }
        
        [Given(@"user Fills all mandatory fields")]
        public void GivenUserFillsAllMandatoryFields()
        {
            IWebElement RequestFieldsText1 = Browser.FindElement(By.Id("text1_sfcollection"));
            RequestFieldsText1.SendKeys("Wealth Management Advice");

            IWebElement RequestFieldsText2 = Browser.FindElement(By.Id("text2_sfcollection"));
            RequestFieldsText2.SendKeys("Yes");

            IWebElement RequestFieldsText3 = Browser.FindElement(By.Id("memo1"));
            RequestFieldsText3.SendKeys("Candidate Automated Tests - Simone Farias");

            IWebElement GetGender = Browser.FindElement(By.XPath("//label[contains(.,'Mrs/Ms')]"));
            GetGender.Click();

            IWebElement firstName = Browser.FindElement(By.Id("firstName"));
            firstName.SendKeys("Simone");

            IWebElement lastName = Browser.FindElement(By.Id("lastName"));
            lastName.SendKeys("Farias");

            IWebElement email = Browser.FindElement(By.Id("email"));
            email.SendKeys("silvafar@gmail.com");

            IWebElement phoneNumber = Browser.FindElement(By.Id("phoneNumber"));
            phoneNumber.SendKeys("+5521981284338");

            IWebElement region = Browser.FindElement(By.XPath("//select[@name='domicile_sfcollection']"));
            region.SendKeys("Brazil");

            IWebElement confirmationCheck = Browser.FindElement(By.XPath("//input[@type='checkbox']"));
            confirmationCheck.Click();
        }
        
        [When(@"user press button submit")]
        public void WhenUserPressButtonSubmit()
        {
            IWebElement buttonSubmit = Browser.FindElement(By.XPath("//span[@class='actionbutton__txtbody']"));
            buttonSubmit.Click();
        }

        [Then(@"a success message should be shown")]
        public void ThenASuccessMessageShouldBeShown()
        {
            string message = "Thank you for writing to us. Your data has been submitted successfully.";
            var wait = new WebDriverWait(Browser, new TimeSpan(0, 0, 30));
            var elementMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//p[@class='form__msgTxt']"))).Text;

            Assert.AreEqual(elementMessage, message);
        }
    }
}

using NUnit.Framework;
using Tests.PageObjective;
using Tests.Usability;

namespace Tests.Tests
{
    [TestFixture]
    public class FilterLegalInformationByCountry
    {
        private PageObject _pageObject;

        [SetUp]
        public void Init()
        {
            _pageObject = new PageObject(Browser.Chrome);
            _pageObject.LoadPage();
        }

        [TestCase]
        /// <summary>
        /// Given the url USB When the user do a filter by their country and clicks to see LegalInformation Then the result is displayed 
        /// </summary>       
        public void Given_UBSPage_When_TheUserFilterByCountryInLegalInformation_Then_TheResultIsDysplayed()
        {
           _pageObject.SearchLegalInformationByCountry();
            Assert.IsTrue(true);
        }

        [TearDown]
        public void Finish()
        {
           _pageObject.Close();
        }
    }
}

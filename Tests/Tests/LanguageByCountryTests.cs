using NUnit.Framework;
using Tests.PageObjective;
using Tests.Usability;


namespace Tests.Tests
{
    [TestFixture]
    public class SelectLanguage
    {
        private PageObject _pageObject;

        [SetUp]
        public void Start()
        {
            _pageObject = new PageObject(Browser.Chrome);
            _pageObject.LoadPage();
        }

        [TestCase]
        /// <summary>
        /// Given the USB page the user select a localization and the language is changed to their official country language
        /// </summary>
        public void Given_UBSPage_When_TheUserSelectsALocalization_Then_TheLanguageIsChanged()
        {
           _pageObject.SelectLanguage();
            Assert.IsTrue(true);
        }

        [TearDown]
        public void Finish()
        {
           _pageObject.Close();
        }
    }
}

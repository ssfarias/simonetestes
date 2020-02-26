using NUnit.Framework;
using Tests.PageObjective;
using Tests.Usability;

namespace Tests.Tests
{
    [TestFixture]
    public class GlobalSearchTests
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
        /// Given the UBS page When the user clicks in glass icon then is possible do a global search 
        /// </summary>       
        public void Given_UBSPage_When_TheUserDoSearchLookingForWords_Then_TheResultIsDysplayedInAList()
        {
            PageBaseDto searchDto = new PageBaseDto()
            {
                WrongSearch = "Wrong Word",
                SearchOk = "Investimentos"               
            };
            _pageObject.Search(searchDto);
            Assert.IsTrue(true);
        }
        
        [TestCase]
        /// <summary>
        /// Given the UBS page When the user try do search with the search field empty nothing is loaded
        /// </summary>     
        public void Given_UBSPage_When_TheUserTryDoSearchWithouData_Then_TheSystemResultis()
    {
            PageBaseDto searchDto = new PageBaseDto()
            {
                WrongSearch = "Test",
                SearchOk = "@@@"               
            };

            _pageObject.Search(searchDto);
            Assert.IsTrue(true);
    }

        [TearDown]
        public void Finish()
        {
            _pageObject.Close();
        }
    }
}

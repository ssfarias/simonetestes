using NUnit.Framework;
using Tests.PageObjective;
using Tests.Usability;


namespace Tests.Tests
{
    [TestFixture]
    public class ContactSubmitRequestTests
    {
        private PageObject _pageObject;       

        [SetUp]
        public void Init()
        {
            _pageObject = new PageObject(Browser.Chrome);
            _pageObject.LoadPage();
        }

        [TestCase]
        [Description("Contact")]
        /// <summary>
        /// Given a conctact form request the user filled all mandatory fields and submits the form successfully
        /// </summary>
        public void Given_ContactForm_When_UserFillMandatoryFieldsAndSubmit_Then_IsShowenConfirmationMessage()
        {
            PageBaseDto contactDto = new PageBaseDto()
            {
                Title = "Wealth Management Advice",
                Confirmation = "Yes",
                Request = "Candidate Automated Tests - Simone Farias",
                Name = "Simone",
                LastName = "Farias",
                Email = "silvafar@gmail.com",
                Contact = "+5521981284338",
                Country = "Brazil",
                Message = "Thank you for writing to us. Your data has been submitted successfully."
            };

            _pageObject.CLickInBrazilLink();
            _pageObject.FillContactRequeredFields(contactDto);
            _pageObject.ContactConfirmation(contactDto);

            Assert.IsTrue(true);
        }

        [TestCase]
        [Description("Contact")]
        /// <summary>
        /// Given a conctact form request the user filled all mandatory fields but write a invalid email and receives a errior messa
        /// /// </summary>
        public void Given_ContactForm_When_UserFillInvalidEmail_Then_IsShowenErrorMessage()
        {
            PageBaseDto contactDto = new PageBaseDto()
            {
                Title = "Wealth Management Advice",
                Confirmation = "Yes",
                Request = "Candidate Automated Tests - Simone Farias",
                Name = "Simone",
                LastName = "Farias",
                Email = "silvafargmail.com",
                Contact = "+5521981284338",
                Country = "Brazil",
                Message = "Thank you for writing to us. Your data has been submitted successfully."
            };

            _pageObject.CLickInBrazilLink();
            _pageObject.FillContactRequeredFields(contactDto);
            _pageObject.ValidateContactEmail();

            Assert.IsTrue(true);
        }


        [TearDown]
        public void Finish()
        {
            _pageObject.Close();
        }
    }
}

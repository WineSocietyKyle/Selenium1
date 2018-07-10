using Join3.Self_Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Join3
{
    [TestFixture]
    public class SelfJoin : TestTemplate
    {
        [Test]
        [Order(1)]
        public void SelfFullApplication()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.SelectTitle("Mr");
            join_selfDetailsPage.EnterFirstName(forename);
            join_selfDetailsPage.EnterSurname(surname);
            join_selfDetailsPage.EnterEmailAddress("brewerk@thewinesociety.com");
            join_selfDetailsPage.EnterPhoneNumber("07713187347");
            join_selfDetailsPage.EnterDOB(day, month, year);
            join_selfDetailsPage.EnterHouseNumber("48");
            join_selfDetailsPage.EnterPostcode("SG54NE");
            join_selfDetailsPage.ClickFindAddress();
            join_selfDetailsPage.CheckAddressDetails("48 Church Road", "Stotfold", "", "Hitchin", "Bedfordshire", "SG5 4NE");
            join_selfDetailsPage.ClickConfirmCheckBox();
            join_selfDetailsPage.ClickNextButton();

            SelfPayment join_selfPaymentPage = new SelfPayment(base.driver);
            join_selfPaymentPage.EnterCardHoldersName(string.Format("MR {0} {1}", forename.ToCharArray()[0], surname.ToUpper()));
            join_selfPaymentPage.EnterCardNumber("4242424242424242");
            join_selfPaymentPage.SelectExpiryMonth("06");
            join_selfPaymentPage.SelectExpiryYear("2022");
            join_selfPaymentPage.EnterSecurityCode("123");
            join_selfPaymentPage.ProposerSelected(true);
            join_selfPaymentPage.EnterProposerDetails("Kyle Brewer-Allan", "Test Street 101", "SG61EF", "madeUpEmail@Test.Com");
            join_selfPaymentPage.SelectMediaOption("Wine fair/festival");
            Assert.IsTrue(driver.FindElement(By.Id("btnSelfStep2")).Enabled);
            // Click complete here...
        }
    }
}

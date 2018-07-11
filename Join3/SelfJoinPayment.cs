using Join3.Self_Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Join3
{
    [TestFixture]
    public class SelfJoinPayment : TestTemplate
    {
        public override string URL { get { return "https://dev.thewinesociety.com/ApplicationForm2/self/step1"; } }

        [OneTimeSetUp]
        public void completePart1and2()
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
        }

        [Test]
        public void SelfFullApplicationNoProposer()
        {
            SelfPayment join_selfPaymentPage = new SelfPayment(base.driver);
            join_selfPaymentPage.ProposerSelected(false);
            Assert.IsTrue(driver.FindElement(By.Id("btnSelfStep2")).Enabled);
            join_selfPaymentPage.ProposerSelected(true);
            // Click complete here...
        }

        [Test]
        public void SelfFullApplicationNoCardHoldersName()
        {
            SelfPayment join_selfPaymentPage = new SelfPayment(base.driver);
            join_selfPaymentPage.EnterCardHoldersName(string.Empty);
            join_selfPaymentPage.ClickHeader();
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep2")).Enabled);
            join_selfPaymentPage.CheckErrorMessage("Required Field");
            join_selfPaymentPage.EnterCardHoldersName(string.Format("MR {0} {1}", forename.ToCharArray()[0], surname.ToUpper()));
        }

        [Test]
        public void SelfFullApplicationSingleCharacterCardHoldersName()
        {
            SelfPayment join_selfPaymentPage = new SelfPayment(base.driver);
            join_selfPaymentPage.EnterCardHoldersName("A");
            join_selfPaymentPage.ClickHeader();
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep2")).Enabled);
            join_selfPaymentPage.CheckErrorMessage("Must be at least 2 characters long.");
            join_selfPaymentPage.EnterCardHoldersName(string.Format("MR {0} {1}", forename.ToCharArray()[0], surname.ToUpper()));
        }

        [Test]
        public void SelfFullApplicationNoCardNumber()
        {
            SelfPayment join_selfPaymentPage = new SelfPayment(base.driver);
            join_selfPaymentPage.EnterCardNumber(string.Empty);
            join_selfPaymentPage.ClickHeader();
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep2")).Enabled);
            join_selfPaymentPage.CheckErrorMessage("Required Field");
            join_selfPaymentPage.EnterCardNumber("4242424242424242");
            // Click complete here...
        }

        [Test]
        public void SelfFullApplicationInvalidCardNumber()
        {
            SelfPayment join_selfPaymentPage = new SelfPayment(base.driver);
            join_selfPaymentPage.EnterCardNumber("12");
            join_selfPaymentPage.ClickHeader();
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep2")).Enabled);
            join_selfPaymentPage.CheckErrorMessage("Is invalid credit card number");
            join_selfPaymentPage.EnterCardNumber("4242424242424242");
            // Click complete here...
        }

        [Test]
        public void SelfFullApplicationNoExpiryMonth()
        {
            SelfPayment join_selfPaymentPage = new SelfPayment(base.driver);
            join_selfPaymentPage.SelectExpiryMonth("EXPIRY MONTH");
            join_selfPaymentPage.ClickHeader();
            join_selfPaymentPage.CheckErrorMessage("Required Field");
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep2")).Enabled);
            join_selfPaymentPage.SelectExpiryMonth("06");
        }

        [Test]
        public void SelfFullApplicationNoExpiryYear()
        {
            SelfPayment join_selfPaymentPage = new SelfPayment(base.driver);
            join_selfPaymentPage.SelectExpiryYear("EXPIRY YEAR");
            join_selfPaymentPage.ClickHeader();
            join_selfPaymentPage.CheckErrorMessage("Required Field");
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep2")).Enabled);
            join_selfPaymentPage.SelectExpiryYear("2022");
            // Click complete here...
        }

        [Test]
        public void SelfFullApplicationNoSecurityCode()
        {
            SelfPayment join_selfPaymentPage = new SelfPayment(base.driver);
            join_selfPaymentPage.EnterSecurityCode(string.Empty);
            join_selfPaymentPage.ClickHeader();
            join_selfPaymentPage.CheckErrorMessage("Required Field");
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep2")).Enabled);
            join_selfPaymentPage.EnterSecurityCode("123");
            // Click complete here...
        }

        [Test]
        public void SelfFullApplicationSecurityCodeShort()
        {
            SelfPayment join_selfPaymentPage = new SelfPayment(base.driver);
            join_selfPaymentPage.EnterSecurityCode("1");
            join_selfPaymentPage.ClickHeader();
            join_selfPaymentPage.CheckErrorMessage("The CCV number should be 3 digits long.");
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep2")).Enabled);
            join_selfPaymentPage.EnterSecurityCode("123");
            // Click complete here...
        }

        [Test]
        public void SelfFullApplicationSecurityCodeLong()
        {
            SelfPayment join_selfPaymentPage = new SelfPayment(base.driver);
            join_selfPaymentPage.EnterSecurityCode("1234");
            join_selfPaymentPage.ClickHeader();
            join_selfPaymentPage.CheckErrorMessage("The CCV number should be 3 digits long.");
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep2")).Enabled);
            join_selfPaymentPage.EnterSecurityCode("123");
            // Click complete here...
        }

        [Test]
        public void SelfFullApplicationInvalidFullName()
        {
            SelfPayment join_selfPaymentPage = new SelfPayment(base.driver);
            join_selfPaymentPage.EnterProposerDetails("A", "Test Street 101", "SG61EF", "madeUpEmail@Test.Com");
            join_selfPaymentPage.ClickHeader();
            join_selfPaymentPage.CheckErrorMessage("Must be at least 2 characters long.");
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep2")).Enabled);
            join_selfPaymentPage.EnterProposerDetails("Kyle Brewer-Allan", "Test Street 101", "SG61EF", "madeUpEmail@Test.Com");
            // Click complete here...
        }

        [Test]
        public void SelfFullApplicationInvalidStreetName()
        {
            SelfPayment join_selfPaymentPage = new SelfPayment(base.driver);
            join_selfPaymentPage.EnterProposerDetails("Kyle Brewer-Allan", "A", "SG61EF", "madeUpEmail@Test.Com");
            join_selfPaymentPage.ClickHeader();
            join_selfPaymentPage.CheckErrorMessage("Must be at least 4 characters long.");
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep2")).Enabled);
            join_selfPaymentPage.EnterProposerDetails("Kyle Brewer-Allan", "Test Street 101", "SG61EF", "madeUpEmail@Test.Com");
            // Click complete here...
        }

        [Test]
        public void SelfFullApplicationInvalidPostcode()
        {
            SelfPayment join_selfPaymentPage = new SelfPayment(base.driver);
            join_selfPaymentPage.EnterProposerDetails("Kyle Brewer-Allan", "Test Street 101", "A", "madeUpEmail@Test.Com");
            join_selfPaymentPage.ClickHeader();
            join_selfPaymentPage.CheckErrorMessage("Sorry! This doesn`t look like a valid UK postcode. Please enter postcode in uppercase only and for UK postcode supplied in the UK format with a space. Ex: SG1 2BT");
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep2")).Enabled);
            join_selfPaymentPage.EnterProposerDetails("Kyle Brewer-Allan", "Test Street 101", "SG61EF", "madeUpEmail@Test.Com");
            // Click complete here...
        }

        [Test]
        public void SelfFullApplicationInvalidEmailAddress()
        {
            SelfPayment join_selfPaymentPage = new SelfPayment(base.driver);
            join_selfPaymentPage.EnterProposerDetails("Kyle Brewer-Allan", "Test Street 101", "SG61EF", "A");
            join_selfPaymentPage.ClickHeader();
            join_selfPaymentPage.CheckErrorMessage("Sorry! This doesn`t look like a valid email address. Please try again.");
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep2")).Enabled);
            join_selfPaymentPage.EnterProposerDetails("Kyle Brewer-Allan", "Test Street 101", "SG61EF", "madeUpEmail@Test.Com");
            // Click complete here...
        }
    }
}

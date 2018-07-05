using Join3.Self_Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
[assembly: Parallelize(Workers = 1, Scope = ExecutionScope.MethodLevel)]

namespace Join3
{
    [TestClass]
    public class SelfJoin : TestTemplate
    {
        [TestMethod]
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

        [TestMethod]
        public void SelfFullApplicationNoProposer()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.SelectTitle("Mrs");
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
            join_selfPaymentPage.EnterCardHoldersName(string.Format("MRS {0} {1}", forename.ToCharArray()[0], surname.ToUpper()));
            join_selfPaymentPage.EnterCardNumber("4242424242424242");
            join_selfPaymentPage.SelectExpiryMonth("06");
            join_selfPaymentPage.SelectExpiryYear("2022");
            join_selfPaymentPage.EnterSecurityCode("123");
            join_selfPaymentPage.ProposerSelected(false);
            join_selfPaymentPage.SelectMediaOption("Wine fair/festival");
            Assert.IsTrue(driver.FindElement(By.Id("btnSelfStep2")).Enabled);
            // Click complete here...
        }

        [TestMethod]
        public void SelfFullApplicationNoForename()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.SelectTitle("Mr");
            // join_selfDetailsPage.EnterFirstName(forename);
            join_selfDetailsPage.EnterSurname(surname);
            join_selfDetailsPage.EnterEmailAddress("brewerk@thewinesociety.com");
            join_selfDetailsPage.EnterPhoneNumber("07713187347");
            join_selfDetailsPage.EnterDOB(day, month, year);
            join_selfDetailsPage.EnterHouseNumber("48");
            join_selfDetailsPage.EnterPostcode("SG54NE");
            join_selfDetailsPage.ClickFindAddress();
            join_selfDetailsPage.CheckAddressDetails("48 Church Road", "Stotfold", "", "Hitchin", "Bedfordshire", "SG5 4NE");
            join_selfDetailsPage.ClickConfirmCheckBox();
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep1")).Enabled);
        }

        [TestMethod]
        public void SelfFullApplicationNoSurname()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.SelectTitle("Mr");
            join_selfDetailsPage.EnterFirstName(forename);
            // join_selfDetailsPage.EnterSurname(surname);
            join_selfDetailsPage.EnterEmailAddress("brewerk@thewinesociety.com");
            join_selfDetailsPage.EnterPhoneNumber("07713187347");
            join_selfDetailsPage.EnterDOB(day, month, year);
            join_selfDetailsPage.EnterHouseNumber("48");
            join_selfDetailsPage.EnterPostcode("SG54NE");
            join_selfDetailsPage.ClickFindAddress();
            join_selfDetailsPage.CheckAddressDetails("48 Church Road", "Stotfold", "", "Hitchin", "Bedfordshire", "SG5 4NE");
            join_selfDetailsPage.ClickConfirmCheckBox();
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep1")).Enabled);
        }

        [TestMethod]
        public void SelfFullApplicationNoEmailAddress()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.SelectTitle("Mr");
            join_selfDetailsPage.EnterFirstName(forename);
            join_selfDetailsPage.EnterSurname(surname);
            // join_selfDetailsPage.EnterEmailAddress("brewerk@thewinesociety.com");
            join_selfDetailsPage.EnterPhoneNumber("07713187347");
            join_selfDetailsPage.EnterDOB(day, month, year);
            join_selfDetailsPage.EnterHouseNumber("48");
            join_selfDetailsPage.EnterPostcode("SG54NE");
            join_selfDetailsPage.ClickFindAddress();
            join_selfDetailsPage.CheckAddressDetails("48 Church Road", "Stotfold", "", "Hitchin", "Bedfordshire", "SG5 4NE");
            join_selfDetailsPage.ClickConfirmCheckBox();
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep1")).Enabled);
        }

        [TestMethod]
        public void SelfFullApplicationNoPhoneNumber()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.SelectTitle("Mr");
            join_selfDetailsPage.EnterFirstName(forename);
            join_selfDetailsPage.EnterSurname(surname);
            join_selfDetailsPage.EnterEmailAddress("brewerk@thewinesociety.com");
            // join_selfDetailsPage.EnterPhoneNumber("07713187347");
            join_selfDetailsPage.EnterDOB(day, month, year);
            join_selfDetailsPage.EnterHouseNumber("48");
            join_selfDetailsPage.EnterPostcode("SG54NE");
            join_selfDetailsPage.ClickFindAddress();
            join_selfDetailsPage.CheckAddressDetails("48 Church Road", "Stotfold", "", "Hitchin", "Bedfordshire", "SG5 4NE");
            join_selfDetailsPage.ClickConfirmCheckBox();
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep1")).Enabled);
        }

        [TestMethod]
        public void SelfFullApplicationNoDOB()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.SelectTitle("Mr");
            join_selfDetailsPage.EnterFirstName(forename);
            join_selfDetailsPage.EnterSurname(surname);
            join_selfDetailsPage.EnterEmailAddress("brewerk@thewinesociety.com");
            join_selfDetailsPage.EnterPhoneNumber("07713187347");
            // join_selfDetailsPage.EnterDOB(day, month, year);
            join_selfDetailsPage.EnterHouseNumber("48");
            join_selfDetailsPage.EnterPostcode("SG54NE");
            join_selfDetailsPage.ClickFindAddress();
            join_selfDetailsPage.CheckAddressDetails("48 Church Road", "Stotfold", "", "Hitchin", "Bedfordshire", "SG5 4NE");
            join_selfDetailsPage.ClickConfirmCheckBox();
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep1")).Enabled);
        }

        [TestMethod]
        public void SelfFullApplicationNoHouseNumber()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.SelectTitle("Mr");
            join_selfDetailsPage.EnterFirstName(forename);
            join_selfDetailsPage.EnterSurname(surname);
            join_selfDetailsPage.EnterEmailAddress("brewerk@thewinesociety.com");
            join_selfDetailsPage.EnterPhoneNumber("07713187347");
            join_selfDetailsPage.EnterDOB(day, month, year);
            // join_selfDetailsPage.EnterHouseNumber("48");
            join_selfDetailsPage.EnterPostcode("SG54NE");
            Assert.IsFalse(driver.FindElement(By.Id("btnFindAddress")).Enabled);
        }

        [TestMethod]
        public void SelfFullApplicationNoPostcode()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.SelectTitle("Mr");
            join_selfDetailsPage.EnterFirstName(forename);
            join_selfDetailsPage.EnterSurname(surname);
            join_selfDetailsPage.EnterEmailAddress("brewerk@thewinesociety.com");
            join_selfDetailsPage.EnterPhoneNumber("07713187347");
            join_selfDetailsPage.EnterDOB(day, month, year);
            join_selfDetailsPage.EnterHouseNumber("48");
            // join_selfDetailsPage.EnterPostcode("SG54NE");
            Assert.IsFalse(driver.FindElement(By.Id("btnFindAddress")).Enabled);
        }

        [TestMethod]
        public void SelfFullApplicationClearedAddressDetails()
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
            join_selfDetailsPage.ClickClearAddress();
            join_selfDetailsPage.CheckAddressDetails("", "", "", "", "", "");
            join_selfDetailsPage.ClickConfirmCheckBox();
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep1")).Enabled);
        }

        [TestMethod]
        public void SelfFullApplicationNoCheckBox()
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
            join_selfDetailsPage.ClickNextButton();
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep1")).Enabled);
        }
    }
}

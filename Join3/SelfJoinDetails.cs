using Join3.Self_Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Join3
{
    [TestFixture]
    public class SelfJoinDetails : TestTemplate
    {
        [OneTimeSetUp]
        public void CompletePart1()
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
        }

        [Test]
        public void SelfFullApplicationNoForename()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.EnterFirstName(string.Empty);
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep1")).Enabled);
            join_selfDetailsPage.ClickHeader();
            join_selfDetailsPage.CheckErrorMessage("Required Field");
            join_selfDetailsPage.EnterFirstName(forename);
        }

        [Test]
        public void SelfFullApplicationForenameTooShort()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.EnterFirstName("A");
            join_selfDetailsPage.ClickHeader();
            join_selfDetailsPage.CheckErrorMessage("Must be at least 2 characters long.");
            join_selfDetailsPage.EnterFirstName(forename);
        }

        [Test]
        public void SelfFullApplicationNoSurname()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.EnterSurname(string.Empty);
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep1")).Enabled);
            join_selfDetailsPage.ClickHeader();
            join_selfDetailsPage.CheckErrorMessage("Required Field");
            join_selfDetailsPage.EnterSurname(surname);
        }

        [Test]
        public void SelfFullApplicationSurnameTooShort()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.EnterSurname("A");
            join_selfDetailsPage.ClickHeader();
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep1")).Enabled);
            join_selfDetailsPage.CheckErrorMessage("Must be at least 2 characters long.");
            join_selfDetailsPage.EnterSurname(surname);
        }

        [Test]
        public void SelfFullApplicationNoEmailAddress()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.EnterEmailAddress(string.Empty);
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep1")).Enabled);
            join_selfDetailsPage.ClickHeader();
            join_selfDetailsPage.CheckErrorMessage("Required Field");
            join_selfDetailsPage.EnterEmailAddress("brewerk@thewinesociety.com");
        }

        [Test]
        public void SelfFullApplicationInvalidEmailAddress()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.EnterEmailAddress("invlalidEmailAddressExample");
            join_selfDetailsPage.ClickHeader();
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep1")).Enabled);
            join_selfDetailsPage.CheckErrorMessage("Sorry! This doesn`t look like a valid email address. Please try again.");
            join_selfDetailsPage.EnterEmailAddress("brewerk@thewinesociety.com");
        }

        [Test]
        public void SelfFullApplicationNoPhoneNumber()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.EnterPhoneNumber(string.Empty);
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep1")).Enabled);
            join_selfDetailsPage.ClickHeader();
            join_selfDetailsPage.CheckErrorMessage("Required Field");
            join_selfDetailsPage.EnterPhoneNumber("07713187347");
        }

        [Test]
        public void SelfFullApplicationPhoneNumberMessage()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            IWebElement telephoneField = driver.FindElement(By.Id("tbTelephone"));
            telephoneField.Click();
            // Add true Check for value at this position
            Assert.IsTrue(driver.FindElements(By.ClassName("state-msg-info"))[4].Displayed);
            Assert.AreEqual(driver.FindElements(By.ClassName("state-msg-info"))[4].Text, "We will only call you if there's an issue with your account or orders: our team never make any 'cold calls'.");
        }

        [Test]
        public void SelfFullApplicationNoDOB()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.EnterDOB(string.Empty, string.Empty, string.Empty);
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep1")).Enabled);
            join_selfDetailsPage.EnterDOB(day, month, year);
        }

        [Test]
        public void SelfFullApplicationDOBTooOld()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.EnterDOB("01", "01", "1900");
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep1")).Enabled);
            join_selfDetailsPage.CheckErrorMessage("The date of birth entered indicates that you might be 118.");
            join_selfDetailsPage.EnterDOB(day, month, year);
        }

        [Test]
        public void SelfFullApplicationDOBTooYoung()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.EnterDOB("17", "08", "2017");
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep1")).Enabled);
            join_selfDetailsPage.CheckErrorMessage("You must be over the age of 18 to join, you are currently 0.");
            join_selfDetailsPage.EnterDOB(day, month, year);
        }

        [Test]
        public void SelfFullApplicationDOBInvalid()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.EnterDOB("32", "13", "3017");
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep1")).Enabled);
            join_selfDetailsPage.CheckErrorMessage("The date entered is not valid.");
            join_selfDetailsPage.EnterDOB(day, month, year);
        }

        [Test]
        [Order(8)]
        public void SelfFullApplicationNoHouseNumber()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.ClickUseAddressLookup(); // Make more fluid
            join_selfDetailsPage.EnterHouseNumber(string.Empty);
            join_selfDetailsPage.EnterPostcode("SG54NE");
            Assert.IsFalse(driver.FindElement(By.Id("btnFindAddress")).Enabled);
            join_selfDetailsPage.EnterHouseNumber("48");
            join_selfDetailsPage.ClickFindAddress();
        }

        [Test]
        [Order(9)]
        public void SelfFullApplicationNoPostcode()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.ClickUseAddressLookup(); // Make more fluid
            join_selfDetailsPage.EnterHouseNumber("48");
            join_selfDetailsPage.EnterPostcode(string.Empty);
            Assert.IsFalse(driver.FindElement(By.Id("btnFindAddress")).Enabled);
            join_selfDetailsPage.EnterPostcode("SG54NE");
        }

        [Test]
        public void SelfFullApplicationClearedAddressDetails()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.ClickFindAddress();
            join_selfDetailsPage.ClickClearAddress();
            join_selfDetailsPage.CheckAddressDetails("", "", "", "", "", "");
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep1")).Enabled);
            join_selfDetailsPage.ClickUseAddressLookup(); // Make more fluid
            join_selfDetailsPage.ClickFindAddress();
            join_selfDetailsPage.CheckAddressDetails("48 Church Road", "Stotfold", "", "Hitchin", "Bedfordshire", "SG5 4NE");
        }

        [Test]
        [Order(11)]
        public void SelfFullApplicationNoCheckBox()
        {
            SelfDetails join_selfDetailsPage = new SelfDetails(base.driver);
            join_selfDetailsPage.ClickConfirmCheckBox();
            Assert.IsFalse(driver.FindElement(By.Id("btnSelfStep1")).Enabled);
            join_selfDetailsPage.ClickConfirmCheckBox();
        }
    }
}

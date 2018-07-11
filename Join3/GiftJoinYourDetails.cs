namespace Join3
{
    using NUnit.Framework;
    using Join3.Gift_Pages;
    using OpenQA.Selenium;

    [TestFixture]
    public class GiftJoinYourDetails : TestTemplate
    {
        public override string URL { get { return "https://dev.thewinesociety.com/applicationform2/gift/step1"; } }

        [Test]
        public void GiftYourDetailsNoName()
        {
            GiftYourDetails giftYourDetails = new GiftYourDetails(driver);
            giftYourDetails.EnterName(string.Empty);
            giftYourDetails.ClickHeader();
            giftYourDetails.CheckErrorMessage("Required Field");
            giftYourDetails.EnterName(base.forename + "" + base.surname);
        }

        [Test]
        public void GiftYourDetailsShortName()
        {
            GiftYourDetails giftYourDetails = new GiftYourDetails(driver);
            giftYourDetails.EnterName("A");
            giftYourDetails.ClickHeader();
            giftYourDetails.CheckErrorMessage("Must be at least 2 characters long.");
            giftYourDetails.EnterName(base.forename + "" + base.surname);
        }

        [Test]
        public void GiftYourDetailsNoEmailAddress()
        {
            GiftYourDetails giftYourDetails = new GiftYourDetails(driver);
            giftYourDetails.EnterEmailAddress(string.Empty);
            giftYourDetails.ClickHeader();
            giftYourDetails.CheckErrorMessage("Required Field");
            giftYourDetails.EnterEmailAddress("brewerk@thewinesociety.com");
        }

        [Test]
        public void GiftYourDetailsInvalidEmail()
        {
            GiftYourDetails giftYourDetails = new GiftYourDetails(driver);
            giftYourDetails.EnterEmailAddress("A");
            giftYourDetails.ClickHeader();
            giftYourDetails.CheckErrorMessage("Sorry! This doesn`t look like a valid email address. Please try again.");
            giftYourDetails.EnterEmailAddress("brewerk@thewinesociety.com");
        }

        [Test]
        public void GiftYourDetailsNoPhoneNumber()
        {
            GiftYourDetails giftYourDetails = new GiftYourDetails(driver);
            giftYourDetails.EnterPhoneNumber(string.Empty);
            giftYourDetails.ClickHeader();
            giftYourDetails.CheckErrorMessage("Required Field");
            giftYourDetails.EnterPhoneNumber("07713187347");
        }

        [Test]
        public void GiftYourDetailsInvalidPhoneNumber()
        {
            GiftYourDetails giftYourDetails = new GiftYourDetails(driver);
            giftYourDetails.EnterPhoneNumber(".");
            giftYourDetails.ClickHeader();
            giftYourDetails.CheckErrorMessage("Only numbers are allowed.");
            giftYourDetails.EnterPhoneNumber("07713187347");
        }

        [Test]
        public void SelfFullApplicationPhoneNumberMessage()
        {
            GiftYourDetails giftYourDetails = new GiftYourDetails(driver);
            IWebElement telephoneField = driver.FindElement(By.Id("tbYourPhone"));
            telephoneField.Click();
            // Add true Check for value at this position
            var a = driver.FindElements(By.ClassName("state-msg-info"));
            Assert.IsTrue(driver.FindElements(By.ClassName("state-msg-info"))[2].Displayed);
            Assert.AreEqual(driver.FindElements(By.ClassName("state-msg-info"))[2].Text, "We’ll only call you if there’s an issue with your application: our team never make any ‘cold calls’.");
        }
    }
}

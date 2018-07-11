namespace Join3
{
    using System;
    using NUnit.Framework;
    using Join3.Gift_Pages;

    [TestFixture]
    public class GiftJoin : TestTemplate
    {
        public override string URL { get { return "https://dev.thewinesociety.com/applicationform2/gift/step1"; } }

        [Test]
        public void GiftFullApplication()
        {
            GiftYourDetails giftYourDetails = new GiftYourDetails(driver);
            giftYourDetails.EnterName("Kyle Brewer-Allan");
            giftYourDetails.EnterEmailAddress("brewerk@thewinesociety.com");
            giftYourDetails.EnterPhoneNumber("07713187347");
            giftYourDetails.ClickNext();
        }
    }
}

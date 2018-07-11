using NUnit.Framework;
using OpenQA.Selenium;

namespace Join3.Gift_Pages 
{
    public class GiftYourDetails : JoinMethods
    {
        private static IWebDriver driver;

        public GiftYourDetails(IWebDriver exDriver)
        {
            driver = exDriver;
        }

        public void EnterName(string name)
        {
            IWebElement nameField = driver.FindElement(By.Id("tbYourName"));
            EnterValueIntoField(name, nameField);
            CompareElementValue(name, nameField);

            if (name == string.Empty)
            {
                nameField.SendKeys("1");
                nameField.SendKeys(Keys.Backspace);
            }
        }

        public void EnterEmailAddress(string emailAddress)
        {
            IWebElement emailAddressField = driver.FindElement(By.Id("tbYourEmail"));
            EnterValueIntoField(emailAddress, emailAddressField);
            CompareElementValue(emailAddress, emailAddressField);

            if (emailAddress == string.Empty)
            {
                emailAddressField.SendKeys("1");
                emailAddressField.SendKeys(Keys.Backspace);
            }
        }

        public void EnterPhoneNumber(string phoneNumber)
        {
            IWebElement phoneNumberField = driver.FindElement(By.Id("tbYourPhone"));
            EnterValueIntoField(phoneNumber, phoneNumberField);
            CompareElementValue(phoneNumber, phoneNumberField);

            if (phoneNumber == string.Empty)
            {
                phoneNumberField.SendKeys("1");
                phoneNumberField.SendKeys(Keys.Backspace);
            }
        }

       public void ClickNext()
        {
            IWebElement next = driver.FindElement(By.Id("btnGiftStep1"));
            ClickElement(next);
        }

        public void ClickHeader()
        {
            IWebElement header = driver.FindElement(By.ClassName("no-top-margin"));
            ClickElement(header);
        }

        public void CheckErrorMessage(string message)
        {
            Assert.IsTrue(driver.FindElement(By.ClassName("state-msg-error")).Displayed);
            Assert.AreEqual(driver.FindElement(By.ClassName("state-msg-error")).Text, message);
        }
    }
}

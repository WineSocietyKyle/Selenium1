namespace Join3.Self_Pages
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Linq;
    using System.Threading;

    class SelfPayment : JoinMethods
    {
        private static IWebDriver driver;

        public SelfPayment(IWebDriver exDriver)
        {
            driver = exDriver;
        }

        public void EnterCardHoldersName(string cardHoldersName)
        {
            IWebElement cardHoldersNameField = driver.FindElement(By.Id("tbCardHolderName"));
            EnterValueIntoField(cardHoldersName, cardHoldersNameField);
            CompareElementValue(cardHoldersName, cardHoldersNameField);

            if (cardHoldersName == string.Empty)
            {
                cardHoldersNameField.SendKeys("1");
                cardHoldersNameField.SendKeys(Keys.Backspace);
            }
        }

        public void EnterCardNumber(string cardNumber)
        {
            IWebElement cardNumberField = driver.FindElement(By.Id("tbCardNumber"));
            EnterValueIntoField(cardNumber, cardNumberField);
            CompareElementValue(cardNumber, cardNumberField);

            if (cardNumber == string.Empty)
            {
                cardNumberField.SendKeys("1");
                cardNumberField.SendKeys(Keys.Backspace);
            }
        }

        public void SelectExpiryMonth(string expiryMonth)
        {
            IWebElement expiryMonthDrop = driver.FindElement(By.Id("lbCardExpiryMonth"));
            SelectElement expiryMonthSelect = new SelectElement(expiryMonthDrop);
            SelectFromDropdown(expiryMonth, expiryMonthSelect);
            Assert.AreEqual(expiryMonth, expiryMonthSelect.SelectedOption.Text);
        }

        public void SelectExpiryYear(string expiryYear)
        {
            IWebElement expiryYearDrop = driver.FindElement(By.Id("lbCardExpiryYear"));
            SelectElement expiryYearSelect = new SelectElement(expiryYearDrop);
            SelectFromDropdown(expiryYear, expiryYearSelect);
            Assert.AreEqual(expiryYear, expiryYearSelect.SelectedOption.Text);
        }

        public void EnterSecurityCode(string securityCode)
        {
            IWebElement securityCodeField = driver.FindElement(By.Id("tbCardCCV"));
            EnterValueIntoField(securityCode, securityCodeField);
            CompareElementValue(securityCode, securityCodeField);

            if (securityCode == string.Empty)
            {
                securityCodeField.SendKeys("1");
                securityCodeField.SendKeys(Keys.Backspace);
            }
        }

        public void ProposerSelected(bool yesOrNo)
        {
            IWebElement proposerCheckboxYes = driver.FindElements(By.TagName("label")).Single(d => d.GetAttribute("for") == "proposer");
            IWebElement proposerCheckboxNo = driver.FindElements(By.TagName("label")).Single(d => d.GetAttribute("for") == "noProposer");
            if (yesOrNo)
            {
                ClickElement(proposerCheckboxYes);
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            else
            {
                try
                {
                    IWebElement proposerFullName = driver.FindElement(By.Id("tbProposerFullName"));
                    if (proposerFullName.Displayed)
                    {
                        ClickElement(proposerCheckboxNo);
                    }
                }
                catch (Exception)
                {
                    // Log Something here
                }
            }
        }

        public void EnterProposerDetails(string fullName, string streetName, string postcode, string email)
        {
            IWebElement proposerFullName = driver.FindElement(By.Id("tbProposerFullName"));
            IWebElement proposerStreetName = driver.FindElement(By.Id("tbProposerStreetName"));
            IWebElement proposerPostcode = driver.FindElement(By.Id("tbProposerPostcode"));
            IWebElement proposerEmail = driver.FindElement(By.Id("tbProposerEmail"));

            EnterValueIntoField(fullName, proposerFullName);
            EnterValueIntoField(streetName, proposerStreetName);
            EnterValueIntoField(postcode, proposerPostcode);
            EnterValueIntoField(email, proposerEmail);

            CompareElementValue(fullName, proposerFullName);
            CompareElementValue(streetName, proposerStreetName);
            CompareElementValue(postcode, proposerPostcode);
            CompareElementValue(email, proposerEmail);
        }

        public void SelectMediaOption(string option)
        {
            IWebElement whereDidYouHearDropdown = driver.FindElement(By.Id("lbSource"));
            SelectElement whereDidYouHearSelect = new SelectElement(whereDidYouHearDropdown);
            whereDidYouHearSelect.SelectByText(option);
            Assert.AreEqual(option, whereDidYouHearSelect.SelectedOption.Text);
        }

        public void clickCompleteApplication()
        {
            IWebElement completeMyApplication = driver.FindElement(By.Id("btnSelfStep2"));
            ClickElement(completeMyApplication);
        }       
    }
}

namespace Join3.Self_Pages
{
    using System;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class SelfDetails : JoinMethods
    {
        private static IWebDriver driver;

        public SelfDetails(IWebDriver exDriver)
        {
            driver = exDriver;
        }

        public void SelectTitle(string title)
        {
            IWebElement titleDrop = driver.FindElement(By.Id("lbTitle"));
            SelectElement titleSelect = new SelectElement(titleDrop);
            SelectFromDropdown(title, titleSelect);
            Assert.AreEqual(title, titleSelect.SelectedOption.Text);
        }

        public void EnterFirstName(string firstName)
        {
            IWebElement firstNameField = driver.FindElement(By.Id("tbFirstName"));
            EnterValueIntoField(firstName, firstNameField);
            CompareElementValue(firstName, firstNameField);
        }

        public void EnterSurname(string surname)
        {
            IWebElement surnameField = driver.FindElement(By.Id("tbLastName"));
            EnterValueIntoField(surname, surnameField);
            CompareElementValue(surname, surnameField);
        }

        public void EnterEmailAddress(string emailAddress)
        {
            IWebElement emailField = driver.FindElement(By.Id("tbEmail"));
            EnterValueIntoField(emailAddress, emailField);
            CompareElementValue(emailAddress, emailField);
        }

        public void EnterPhoneNumber(string phoneNumber)
        {
            IWebElement telephoneField = driver.FindElement(By.Id("tbTelephone"));
            EnterValueIntoField(phoneNumber, telephoneField);
            CompareElementValue(phoneNumber, telephoneField);
        }

        public void EnterDOB(string day, string month, string year)
        {
            IWebElement DOBDay = driver.FindElement(By.Id("DD"));
            EnterValueIntoField(day, DOBDay);
            CompareElementValue(day, DOBDay);

            IWebElement DOBMonth = driver.FindElement(By.Id("MM"));
            EnterValueIntoField(month, DOBMonth);
            CompareElementValue(month, DOBMonth);

            IWebElement DOBYear = driver.FindElement(By.Id("YYYY"));
            EnterValueIntoField(year, DOBYear);
            CompareElementValue(year, DOBYear);
        }

        public void EnterHouseNumber(string houseNumber)
        {
            IWebElement HouseNumber = driver.FindElement(By.Id("tbLookupNumber"));
            EnterValueIntoField(houseNumber, HouseNumber);
            CompareElementValue(houseNumber, HouseNumber);
        }

        public void EnterPostcode(string postCode)
        {
            IWebElement Postcode = driver.FindElement(By.Id("tbLookupPostcode"));
            EnterValueIntoField(postCode, Postcode);
            CompareElementValue(postCode, Postcode);
        }

        public void ClickFindAddress()
        {
            IWebElement FindAddressButton = driver.FindElement(By.Id("btnFindAddress"));
            ClickElement(FindAddressButton);
            Thread.Sleep(4000);
        }

        public void CheckAddressDetails(string line1, string line2, string line3, string town, string county, string postcode)
        {
            IWebElement addressLine1 = driver.FindElement(By.Id("tbAddressLine1"));
            IWebElement addressLine2 = driver.FindElement(By.Id("tbAddressLine2"));
            IWebElement addressLine3 = driver.FindElement(By.Id("tbAddressLine3"));
            IWebElement addressTown = driver.FindElement(By.Id("tbAddressTown"));
            IWebElement AddressCounty = driver.FindElement(By.Id("tbAddressCounty"));
            IWebElement AddressPostcode = driver.FindElement(By.Id("tbAddressPostcode"));

            CompareElementValue(line1, addressLine1);
            CompareElementValue(line2, addressLine2);
            CompareElementValue(line3, addressLine3);
            CompareElementValue(town, addressTown);
            CompareElementValue(county, AddressCounty);
            CompareElementValue(postcode, AddressPostcode);
        }

        public void ClickClearAddress()
        {
            IWebElement ClearAddressButton = driver.FindElement(By.Id("btn-reset-address"));
            ClickElement(ClearAddressButton);
            Thread.Sleep(2000);
        }

        public void ClickConfirmCheckBox()
        {
            IWebElement confirmCheckbox = driver.FindElements(By.TagName("label")).Single(d => d.GetAttribute("for") == "cbConfirmRules");
            ClickElement(confirmCheckbox);
        }

        public void ClickNextButton()
        {
            IWebElement NextButton = driver.FindElement(By.Id("btnSelfStep1"));
            ClickElement(NextButton);
            Thread.Sleep(4000);
        }
    }       
}

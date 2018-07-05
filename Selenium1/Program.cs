using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Linq;

namespace Selenium1
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://dev.thewinesociety.com/ApplicationForm/self/step1");
            IWebElement titleDrop = driver.FindElement(By.Id("lbTitle"));
            SelectElement title = new SelectElement(titleDrop);
            title.SelectByText("Mr");
            Assert.AreEqual("Mr", title.SelectedOption.Text);

            IWebElement firstName = driver.FindElement(By.Id("tbFirstName"));
            firstName.SendKeys("Kyle");
            Assert.AreEqual("Kyle", firstName.GetAttribute("value"));

            IWebElement surname = driver.FindElement(By.Id("tbLastName"));
            surname.SendKeys("Brewer-Allan");
            Assert.AreEqual("Brewer-Allan", surname.GetAttribute("value"));

            IWebElement email = driver.FindElement(By.Id("tbEmail"));
            email.SendKeys("test@test.com");
            Assert.AreEqual("test@test.com", email.GetAttribute("value"));

            IWebElement telephone = driver.FindElement(By.Id("tbTelephone"));
            telephone.SendKeys("07713187347");
            Assert.AreEqual("07713187347", telephone.GetAttribute("value"));

            IWebElement DOBDay = driver.FindElement(By.Id("DD"));
            DOBDay.SendKeys("17");
            Assert.AreEqual("17", DOBDay.GetAttribute("value"));

            IWebElement DOBMonth = driver.FindElement(By.Id("MM"));
            DOBMonth.SendKeys("08");
            Assert.AreEqual("08", DOBMonth.GetAttribute("value"));

            IWebElement DOBYear = driver.FindElement(By.Id("YYYY"));
            DOBYear.SendKeys("1996");
            Assert.AreEqual("1996", DOBYear.GetAttribute("value"));

            IWebElement HouseNumber = driver.FindElement(By.Id("tbLookupNumber"));
            HouseNumber.SendKeys("48");
            Assert.AreEqual("48", HouseNumber.GetAttribute("value"));

            IWebElement Postcode = driver.FindElement(By.Id("tbLookupPostcode"));
            Postcode.SendKeys("SG54NE");
            Assert.AreEqual("SG54NE", Postcode.GetAttribute("value"));

            IWebElement FindAddressButton = driver.FindElement(By.Id("btnFindAddress"));
            FindAddressButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(2));

            IWebElement addressLine1 = driver.FindElement(By.Id("tbAddressLine1"));
            IWebElement addressLine2 = driver.FindElement(By.Id("tbAddressLine2"));
            IWebElement addressLine3 = driver.FindElement(By.Id("tbAddressLine3"));
            IWebElement addressTown = driver.FindElement(By.Id("tbAddressTown"));
            IWebElement AddressCounty = driver.FindElement(By.Id("tbAddressCounty"));
            IWebElement AddressPostcode = driver.FindElement(By.Id("tbAddressPostcode"));

            Assert.AreEqual("48 Church Road", addressLine1.GetAttribute("value"));
            Assert.AreEqual("Stotfold", addressLine2.GetAttribute("value"));
            Assert.AreEqual("", addressLine3.GetAttribute("value"));
            Assert.AreEqual("Hitchin", addressTown.GetAttribute("value"));
            Assert.AreEqual("Bedfordshire", AddressCounty.GetAttribute("value"));
            Assert.AreEqual("SG5 4NE", AddressPostcode.GetAttribute("value"));

            IWebElement confirmCheckbox = driver.FindElements(By.TagName("label")).Single(d => d.GetAttribute("for") == "cbConfirmRules");
            confirmCheckbox.Click();

            IWebElement NextButton = driver.FindElement(By.Id("btnSelfStep1"));
            NextButton.Click();

            IWebElement cardHolderName = driver.FindElement(By.Id("tbCardHolderName"));
            IWebElement cardNumber = driver.FindElement(By.Id("tbCardNumber"));
            IWebElement cardExpiryMonth = driver.FindElement(By.Id("lbCardExpiryMonth"));
            IWebElement cardExpiryYear = driver.FindElement(By.Id("lbCardExpiryYear"));
            IWebElement cardSecurityCode = driver.FindElement(By.Id("tbCardCCV"));

            cardHolderName.SendKeys("MR K A BREWER-ALLAN");
            Assert.AreEqual("MR K A BREWER-ALLAN", cardHolderName.GetAttribute("value"));

            cardNumber.SendKeys("4242424242424242");
            Assert.AreEqual("4242424242424242", cardNumber.GetAttribute("value"));

            SelectElement expiryMonth = new SelectElement(cardExpiryMonth);
            SelectElement expiryYear = new SelectElement(cardExpiryYear);

            expiryMonth.SelectByText("07");
            Assert.AreEqual("07", expiryMonth.SelectedOption.Text);

            expiryYear.SelectByText("2019");
            Assert.AreEqual("2019", expiryYear.SelectedOption.Text);

            cardSecurityCode.SendKeys("111");
            Assert.AreEqual("111", cardSecurityCode.GetAttribute("value"));

            IWebElement proposerCheckbox = driver.FindElements(By.TagName("label")).Single(d => d.GetAttribute("for") == "proposer");
            proposerCheckbox.Click();

            Thread.Sleep(TimeSpan.FromSeconds(2));

            IWebElement proposerName = driver.FindElement(By.Id("tbProposerName"));
            IWebElement proposerEmail = driver.FindElement(By.Id("tbProposerEmail"));
            IWebElement proposerPhone = driver.FindElement(By.Id("tbProposerPhone"));
            IWebElement whereDidYouHearDropdown = driver.FindElement(By.Id("lbSource"));
            SelectElement hearAboutUsDropdown = new SelectElement(whereDidYouHearDropdown);

            proposerName.SendKeys("Kyle");
            Assert.AreEqual("Kyle", proposerName.GetAttribute("value"));

            proposerEmail.SendKeys("test@test.com");
            Assert.AreEqual("test@test.com", proposerEmail.GetAttribute("value"));

            proposerPhone.SendKeys("07713187347");
            Assert.AreEqual("07713187347", proposerPhone.GetAttribute("value"));

            hearAboutUsDropdown.SelectByText("Social media");
            Assert.AreEqual("Social media", hearAboutUsDropdown.SelectedOption.Text);

            IWebElement completeMyApplication = driver.FindElement(By.Id("btnSelfStep2"));
            completeMyApplication.Click();

            driver.Quit();
        }
    }
}

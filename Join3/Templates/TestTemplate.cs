﻿namespace Join3
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using RandomNameGeneratorLibrary;
    using System;

    public abstract class TestTemplate
    {
        public IWebDriver driver;
        public string forename;
        public string surname;
        public string year;
        public string month;
        public string day;

        public abstract string URL { get; }

        [OneTimeSetUp]
        public void wanTime()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL); //  "https://dev.thewinesociety.com/ApplicationForm2/self/step1");
            PersonNameGenerator p = new PersonNameGenerator();
            forename = p.GenerateRandomMaleFirstName();
            surname = p.GenerateRandomLastName();

            Random r = new Random();
            int yearValue = r.Next(1910, 1999);
            int monthValue = r.Next(01, 12);
            int dayValue = r.Next(01, 31);
            decimal.Round(yearValue);
            decimal.Round(monthValue);
            decimal.Round(dayValue);

            year = yearValue.ToString();
            month = monthValue.ToString();
            day = dayValue.ToString();

            if (dayValue < 10)
            {
                day = string.Format("0" + day);
            }

            if (monthValue < 10)
            {
                month = string.Format("0" + month);
            }

            try
            {
                if (driver.FindElement(By.Id("btn--alert-msg-close")).Displayed)
                {
                    driver.FindElement(By.Id("btn--alert-msg-close")).Click();
                }
            }
            catch (System.Exception)
            {
                // Think of something better than try catch
            }
        }

        [SetUp]
        public void SetUp()
        {
            Random r = new Random();
            int yearValue = r.Next(1910, 1999);
            int monthValue = r.Next(01, 12);
            int dayValue = r.Next(01, 31);
            decimal.Round(yearValue);
            decimal.Round(monthValue);
            decimal.Round(dayValue);

            year = yearValue.ToString();
            month = monthValue.ToString();
            day = dayValue.ToString();

            if (dayValue < 10)
            {
                day = string.Format("0" + day);
            }

            if (monthValue < 10)
            {
                month = string.Format("0" + month);
            }

            PersonNameGenerator p = new PersonNameGenerator();
            forename = p.GenerateRandomMaleFirstName();
            surname = p.GenerateRandomLastName();

            //driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("https://dev.thewinesociety.com/ApplicationForm2/self/step1");

            try
            {
                if (driver.FindElement(By.Id("btn--alert-msg-close")).Displayed)
                {
                    driver.FindElement(By.Id("btn--alert-msg-close")).Click();
                }
            }
            catch (System.Exception)
            {
                // Think of something better than try catch
            }

        }

        [TearDown]
        public void tearDown()
        {
        }

        [OneTimeTearDown]
        public void wanTimeTerDown()
        {
            driver.Quit();
        }
    }
}

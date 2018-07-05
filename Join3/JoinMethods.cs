namespace Join3
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;

    public abstract class JoinMethods
    {
        public void EnterValueIntoField(string value, IWebElement field)
        {
            // Logging goes here ??
            try
            {
                field.Clear();
                field.SendKeys(value);
            }
            catch (Exception)
            {
                // More logging ??
                throw;
            }
        }

        public void SelectFromDropdown(string option, SelectElement dropwDown)
        {
            // Logging goes here ??
            try
            {
                dropwDown.SelectByText(option);
            }
            catch (Exception)
            {
                // More logging ??
                throw;
            }
        }

        public void ClickElement(IWebElement element)
        {
            // Logging goes here ??
            try
            {
                element.Click();
            }
            catch (Exception)
            {
                // More logging ??
                throw;
            }
        }

        public void CompareElementValue(string expected, IWebElement element)
        {
            // Logging goes here ??
            try
            {
                Assert.AreEqual(expected, element.GetAttribute("value"));
            }
            catch (Exception)
            {
                // More logging ??
                throw;
            }
        }
    }
}

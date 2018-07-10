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
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://test.thewinesociety.com/searchProducts.aspx?q=&hPP=15&idx=products_price_asc&p=0&is_v=1");

            IWebElement sortSelector = driver.FindElement(By.ClassName("ais-sort-by-selector"));
            SelectElement tt = new SelectElement(sortSelector);
            tt.SelectByText("Price Low - High");
            Thread.Sleep(2000);

            int products = 1724;
            int updatedCount= 0;
            while (products > updatedCount)
            {
                updatedCount = updatedCount + CheckPricesAndContinue(driver);
            }

            driver.Quit();
        }

        private static int CheckPricesAndContinue(IWebDriver driver)
        {
            int i = driver.FindElements(By.ClassName("ais-hits--item")).Count();
            for (int A = 0; A < i; A++)
            {
                var B = driver.FindElements(By.ClassName("ais-hits--item"));
                string searchPrice;
                try
                {
                    searchPrice = B[A].FindElement(By.ClassName("price")).Text;
                }
                catch (Exception)
                {
                    searchPrice = string.Empty;
                }

                B[A].Click();

                Thread.Sleep(1000);

                try
                {
                    string pagePrice = driver.FindElement(By.ClassName("pnl-buy-pricing")).Text;
                    string productName = driver.FindElement(By.ClassName("productName")).Text;

                    if (!pagePrice.Contains(searchPrice))
                    {
                        Console.WriteLine("Values did not match on {0} is {1} should have been {2}", productName, pagePrice, searchPrice);
                    }

                    driver.Navigate().Back();
                    Thread.Sleep(2000);
                }
                catch (Exception)
                {
                    driver.Navigate().Back();
                    Thread.Sleep(2000);
                }
            }

            var next = driver.FindElements(By.ClassName("ais-pagination--item__next"));
            next[0].Click();
            Thread.Sleep(2000);
            return i;
        }
    }
}

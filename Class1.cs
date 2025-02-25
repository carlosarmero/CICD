using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASk_loc1
{
    internal class Class1
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public Class1(IWebDriver driver) {
            this.driver = driver; wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
        }

        public IWebElement Cookies => wait.Until(d => d.FindElement(By.Id("onetrust-accept-btn-handler")));
        public IWebElement Careers => wait.Until(d => d.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[2]/div[1]/header/div/div/nav/ul/li[5]/span[1]/a")));
        public IWebElement Keywords => wait.Until(d => d.FindElement(By.Id("new_form_job_search-keyword")));
        public IWebElement Location => wait.Until(d => d.FindElement(By.XPath("//*[@id=\"jobSearchFilterForm\"]/div[2]/div/span[1]/span[1]/span")));
        public IWebElement All => wait.Until(d => d.FindElement(By.XPath("//*[@id=\"select2-new_form_job_search-location-results\"]/div[4]/div/div/li[1]/ul")));
        public IWebElement Remote => wait.Until(d => d.FindElement(By.XPath("//*[@id=\"jobSearchFilterForm\"]/fieldset/div/p[1]")));
        public IWebElement Find => wait.Until(d => d.FindElement(By.CssSelector("#jobSearchFilterForm > button")));
        public IList<IWebElement> Items => wait.Until(d => d.FindElements(By.ClassName("search-result__item-controls")));

        


        /*
        //try with colle
        public IWebElement Liston()
        {
            var results = wait.Until(d => d.FindElements(By.ClassName("search-result__item")));

            // Safely get the first result, return null if no results are found
            if (results.Any())
            {
                return results.First();
            }
            else
            {
                return null; // Or handle as per your requirement (e.g., throw exception)
            }
        }*/



    }
}

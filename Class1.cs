using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASk_loc1
{
    internal class Class1
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public Class1(IWebDriver driver) { this.driver = driver; wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));}
        public IWebElement Careers => wait.Until(d => d.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[2]/div[1]/header/div/div/nav/ul/li[5]/span[1]/a")));
        public IWebElement Keywords => wait.Until(d => d.FindElement(By.Id("new_form_job_search-keyword")));
        public IWebElement Location => wait.Until(d => d.FindElement(By.XPath("//*[@id=\"jobSearchFilterForm\"]/div[2]/div/span[1]/span[1]/span")));
        //public IWebElement All => wait.Until(d => d.FindElement(By.Id("select2-new_form_job_search-location-result-go7y-all_locations")));

    }
}

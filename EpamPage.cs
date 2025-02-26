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
    internal class EpamPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public string lang = "C#";

        public EpamPage(IWebDriver driver) {
            this.driver = driver; wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement Cookies => wait.Until(d => d.FindElement(By.Id("onetrust-accept-btn-handler")));
        public IWebElement Careers => wait.Until(d => d.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[2]/div[1]/header/div/div/nav/ul/li[5]/span[1]/a")));
        public IWebElement Keywords => wait.Until(d => d.FindElement(By.Id("new_form_job_search-keyword")));
        public IWebElement Location => wait.Until(d => d.FindElement(By.XPath("//*[@id=\"jobSearchFilterForm\"]/div[2]/div/span[1]/span[1]/span")));
        public IWebElement All => wait.Until(d => d.FindElement(By.XPath("//*[@id=\"select2-new_form_job_search-location-results\"]/div[4]/div/div/li[1]/ul")));
        public IWebElement Remote => wait.Until(d => d.FindElement(By.XPath("//*[@id=\"jobSearchFilterForm\"]/fieldset/div/p[1]")));
        public IWebElement Find => wait.Until(d => d.FindElement(By.CssSelector("#jobSearchFilterForm > button")));
        public IList<IWebElement> Items => wait.Until(d => d.FindElements(By.ClassName("search-result__item-controls")));

    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASk_loc1
{
    internal class EpamPage : IDisposable
    {
        public readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public string lang = "C#";

        public EpamPage() {
            this.driver = new ChromeDriver(); 
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement Cookies => wait.Until(d => d.FindElement(By.Id("onetrust-accept-btn-handler")));
        public IWebElement Careers => wait.Until(d => d.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[2]/div[1]/header/div/div/nav/ul/li[5]/span[1]/a")));
        public IWebElement Keywords => wait.Until(d => d.FindElement(By.Id("new_form_job_search-keyword")));
        public IWebElement Location => wait.Until(d => d.FindElement(By.XPath("//*[@id=\"jobSearchFilterForm\"]/div[2]/div/span[1]/span[1]/span")));
        public IWebElement All => wait.Until(d => d.FindElement(By.XPath("//*[@id=\"select2-new_form_job_search-location-results\"]/div[4]/div/div/li[1]/ul")));
        public IWebElement Remote => wait.Until(d => d.FindElement(By.XPath("//*[@id=\"jobSearchFilterForm\"]/fieldset/div/p[1]")));
        public IWebElement Find => wait.Until(d => d.FindElement(By.CssSelector("#jobSearchFilterForm > button")));
        public IList<IWebElement> Items => wait.Until(d => d.FindElements(By.ClassName("search-result__item-controls")));
        public void GoWeb()
        {
            driver.Navigate().GoToUrl("https://www.epam.com/");
            driver.Manage().Window.Maximize();
        }
        public void AcceptCookies()
        {
            Cookies.Click();
        }
        public void OpenCareers()
        {
            Careers.Click();
        }
        public void EnterSearchTerm(string searchTerm)
        {
            Keywords.SendKeys(searchTerm);
        }
        public void AllLocations()
        {
            Location.Click();
            All.Click();
        }
        public void ClickRemote()
        {
            Remote.Click();
        }
        public void Search()
        {
            Find.Click();
        }
        public void ClickLast()
        {
            Items.Last().Click();
        }/*
        public bool ContaininsTerm(string searchTerm)
        {
            return Items.Last(link => link.Text.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }*/
        public void Dispose()
        {
            driver.Quit();
        }

    }
}

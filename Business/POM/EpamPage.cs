﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TASk_loc1.Business.POM

{
    class EpamPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public EpamPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public IWebElement Cookies => wait.Until(d => d.FindElement(By.Id("onetrust-accept-btn-handler")));
        public IWebElement Careers => wait.Until(d => d.FindElement(By.XPath("//li[contains(@class, 'top-navigation__item')]/span/a[contains(@href, 'careers')]")));
        public IWebElement SearchButton => wait.Until(d => d.FindElement(By.XPath("//div[contains(@class, 'header-search-ui header-search-ui-23 header__control')]/button")));
        public IWebElement SearchInput => wait.Until(d => d.FindElement(By.Name("q")));
        public IWebElement FindButton => wait.Until(d => d.FindElement(By.CssSelector("#wrapper > div.header-container.iparsys.parsys > div.header.section > header > div > div > ul > li:nth-child(3) > div > div > form > div.search-results__action-section > button")));
        public IWebElement About => wait.Until(d => d.FindElement(By.XPath("//li[contains(@class, 'top-navigation__item')]/span/a[contains(@href, 'about')]")));
        public IWebElement Insights => wait.Until(d => d.FindElement(By.XPath("//li[contains(@class, 'top-navigation__item')]/span/a[contains(@href, 'insights')]")));


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
        public void GlobalSearchInfo(string searchTerm)
        {
            SearchButton.Click();
            SearchInput.SendKeys(searchTerm);
            FindButton.Click();
        }
        public void OpenAbout()
        {
            About.Click();
        }
        public void OpenInsights()
        {
            Insights.Click();
        }
    }
}

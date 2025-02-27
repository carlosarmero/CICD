using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TASk_loc1.PageObjects
{
    class Career : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public Career(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public IWebElement Keywords => wait.Until(d => d.FindElement(By.Id("new_form_job_search-keyword")));
        public IWebElement Location => wait.Until(d => d.FindElement(By.XPath("//*[@id=\"jobSearchFilterForm\"]/div[2]/div/span[1]/span[1]/span")));
        public IWebElement All => wait.Until(d => d.FindElement(By.XPath("//*[@id=\"select2-new_form_job_search-location-results\"]/div[4]/div/div/li[1]/ul")));
        public IWebElement Remote => wait.Until(d => d.FindElement(By.XPath("//*[@id=\"jobSearchFilterForm\"]/fieldset/div/p[1]")));
        public IWebElement Find => wait.Until(d => d.FindElement(By.CssSelector("#jobSearchFilterForm > button")));

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
        public void Dispose()
        {
            driver.Quit();
        }

    }
}

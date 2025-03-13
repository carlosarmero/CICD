using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TASk_loc1.PageObjects
{
    class CareerPage : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public CareerPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public IWebElement Keywords => wait.Until(d => d.FindElement(By.Id("new_form_job_search-keyword")));
        public IWebElement Location => wait.Until(d => d.FindElement(By.XPath("//div[contains(@class, 'recruiting-search__location')]/span")));
        public IWebElement All => wait.Until(d => d.FindElement(By.XPath("//li[contains(@class, 'select2-results__option')]")));////*[@id=\"select2-new_form_job_search-location-results\"]/div[4]/div/div/li[1]/ul not visible //div[contains(@class, 'recruiting-search__location')]/select/optgroup/option[contains(@value, 'all_locations')] and //optgroup[contains(@class, 'option-as-group')]/option[contains(@value, 'all_locations')]
        public IWebElement Remote => wait.Until(d => d.FindElement(By.XPath("//div[contains(@class, 'job-search__filter-list')]/p[contains(@class, 'job-search__filter-items job-search__filter-items--remote')]")));////*[@id=\"jobSearchFilterForm\"]/fieldset/div/p[1] 
        public IWebElement Find => wait.Until(d => d.FindElement(By.CssSelector("#jobSearchFilterForm > button")));

        public void SearchDetails(string searchTerm)
        {
            Keywords.SendKeys(searchTerm);
            Location.Click();
            All.Click();
            Remote.Click();
            Find.Click();
        }
        public void Dispose()
        {
            driver.Quit();
        }

    }
}

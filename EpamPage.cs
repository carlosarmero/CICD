using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task
{
    class EpamPage : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public EpamPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public IWebElement Cookies => wait.Until(d => d.FindElement(By.Id("onetrust-accept-btn-handler")));
        public IWebElement Careers => wait.Until(d => d.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[2]/div[1]/header/div/div/nav/ul/li[5]/span[1]/a")));
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
        public void Dispose()
        {
            driver.Quit();
        }

    }
}

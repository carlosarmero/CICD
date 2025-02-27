using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASk_loc1
{
    class Results : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public Results(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public IList<IWebElement> Items => wait.Until(d => d.FindElements(By.ClassName("search-result__item-controls")));
        public void ClickLast()
        {
            Items.Last().Click();
        }
        public void Dispose()
        {
            driver.Quit();
        }
    }
}

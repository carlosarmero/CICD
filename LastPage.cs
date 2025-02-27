using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASk_loc1
{
    class LastPage : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public LastPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public IWebElement body => wait.Until(d => d.FindElement(By.Id("body")));
  //      string pageText = body.Text.ToLower();  // Convert everything to lowercase to make the check case-insensitive

        public string PageText()
        {
            return body.ToString();
        }
        public void Dispose()
        {
            driver.Quit();
        }
    }
}

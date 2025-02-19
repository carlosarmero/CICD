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

        public Class1(IWebDriver driver) { this.driver = driver; wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));}
        public IWebElement Careers => wait.Until(d => d.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[2]/div[1]/header/div/div/nav/ul/li[5]/span[1]/a")));

    }
}

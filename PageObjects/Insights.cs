using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;
using System.IO;

namespace TASk_loc1.PageObjects
{
    class Insights : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public Insights(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public IWebElement Arrow => wait.Until(d => d.FindElement(By.XPath("//button[contains(@class, 'slider__right-arrow slider-navigation-arrow')]")));
        public IWebElement Article => wait.Until(d => d.FindElement(By.XPath("//span[contains(@class, 'rte-text-gradient gradient-text')]")));
        public IWebElement ReadMoreButton => wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/main/div[1]/div[1]/div/div[1]/div[1]/div/div[6]/div/div/div/div[2]/a")));

        public void ClickArrow()
        {
            Arrow.Click();
            Arrow.Click();
        }
        public string GetText()
        {
            return Article.Text.ToLower();
        }

        public void ReadMore()
        {
            ReadMoreButton.Click();
        }
        public void Dispose()
        {
            driver.Quit();
        }
    }
}
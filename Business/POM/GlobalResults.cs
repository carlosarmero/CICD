﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TASk_loc1.Business.POM

{
    class GlobalResults
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public GlobalResults(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public IList<IWebElement> Results => wait.Until(d => d.FindElements(By.ClassName("search-results__description")));
        public bool AreAllResultsContainingTerm(string searchTerm)
        {
            return Results.All(link => link.Text.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }
    }
}

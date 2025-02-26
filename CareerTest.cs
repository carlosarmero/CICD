using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
using OpenQA.Selenium.Chrome;

namespace TASk_loc1
{
    public class CareerTest : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly EpamPage epam;

        public CareerTest()
        { driver = new ChromeDriver(); epam = new EpamPage(driver); }


        [Fact]
        public void TestCareers()
        {
            driver.Navigate().GoToUrl("https://www.epam.com/");
            driver.Manage().Window.Maximize();
            epam.Cookies.Click();
            epam.Careers.Click();
            epam.Keywords.SendKeys("c#");
            epam.Location.Click();
            epam.All.Click();
            epam.Remote.Click();
            epam.Find.Click();
            Thread.Sleep(2000);
            epam.Items.Last().Click();
            //Thread.Sleep(5000);
            Assert.Contains("C#", driver.PageSource);
            Thread.Sleep(3000);
        }
        
        public void Dispose()
        {
            driver.Quit();
        }
    }
}
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
using OpenQA.Selenium.Chrome;

namespace TASk_loc1
{
    public class UnitTest1 : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly Class1 epam;


        public UnitTest1()
        { driver = new ChromeDriver(); epam = new Class1(driver); }


        [Fact]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://www.epam.com/");
            epam.Careers.Click();
        }
        
        public void Dispose()
        {
            driver.Quit();
        }
    }
}
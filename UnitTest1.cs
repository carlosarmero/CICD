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
            driver.Manage().Window.Maximize();
            epam.Cookies.Click();
            epam.Careers.Click();
            epam.Keywords.SendKeys("c#");
            epam.Location.Click();
            epam.All.Click();
            epam.Remote.Click();
            epam.Find.Click();
            Thread.Sleep(1000);
            epam.Items.Last().Click();
            Thread.Sleep(5000);
            // IWebElement lastt = epam.Liston();
            //lastt.FindElement(By.XPath("//*[@id=\"main\"]/div[1]/div[2]/section/div[2]/div/div/section/ul/li[27]/div[3]/div/div/span/button"));
            // Thread.Sleep(9000);
            Assert.Contains("C#", driver.PageSource);
            Thread.Sleep(5000);
        }
        
        public void Dispose()
        {
            driver.Quit();
        }
    }
}
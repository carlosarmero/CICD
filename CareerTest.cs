using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
using OpenQA.Selenium.Chrome;

namespace TASk_loc1
{
    public class CareerTest
    {
        private readonly EpamPage epam;

        public CareerTest()
        { 
            epam = new EpamPage(); 
        }


        [Fact]
        public void TestCareers()
        {
            try
            {
                epam.GoWeb();
                epam.AcceptCookies();
                epam.OpenCareers();
                epam.EnterSearchTerm("c#");
                epam.AllLocations();
                epam.ClickRemote();
                epam.Search();
                Thread.Sleep(2000);
                epam.ClickLast();
                Assert.Contains("Cc#", epam.driver.PageSource);
                Thread.Sleep(3000);
            }
            finally 
            {
                epam.Dispose();
            }
            
        }
        
    }
}
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TASk_loc1.PageObjects;

namespace TASk_loc1.Tests
{
    public class CarouselTest
    {
        private readonly EpamPage epam;
        private readonly Insights insights;
        private readonly Article article;
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public CarouselTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(5);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            epam = new EpamPage(driver, wait);
            insights = new Insights(driver, wait);
            article = new Article(driver, wait);
        }


        [Fact]
        public void TestCareers()
        {
            try
            {
                epam.GoWeb();
                epam.AcceptCookies();
                epam.OpenInsights();
                insights.ClickArrow();
                string articleTitle = insights.GetText();
                insights.ReadMore();
                string articlePageTitle = article.GetText();
                Assert.Equal(articleTitle, articlePageTitle);
            }
            finally
            {
                epam.Dispose();
            }

        }

    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TASk_loc1.PageObjects;

namespace TASk_loc1.Tests 
{
    public class CarouselTest : IDisposable
    {
        private readonly EpamPage epam;
        private readonly InsightsPage insights;
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
            insights = new InsightsPage(driver, wait);
            article = new Article(driver, wait);
        }

        [Fact]
        public void TestCareers()
        {
            epam.GoWeb();
            epam.AcceptCookies();
            epam.OpenInsights();
            insights.ClickArrow();
            string articleTitle = insights.GetArticleTitle();
            insights.ReadMore();
            string articlePageTitle = article.GetTitleText();
            Assert.Equal(articleTitle, articlePageTitle);
        }
        public void Dispose()
        {
            article.Dispose();
        }

    }
}

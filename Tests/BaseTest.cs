using TASk_loc1.PageObjects;
using TASk_loc1.Core;
using OpenQA.Selenium;
using Screens.TestFramework.Core.BrowserUtils;
using System.Threading.Tasks;

namespace TASk_loc1.Tests
{
    public abstract class BaseTest : WebDriverService
    {
        private readonly EpamPage epam;

        public BaseTest()
        {
            epam = new EpamPage(driver, wait);
        }

        protected void InitializeBrowser()
        {
            epam.GoWeb();
            epam.AcceptCookies();
        }

        protected void OpenCareersPage() => epam.OpenCareers();
        protected void OpenAboutPage() => epam.OpenAbout();
        protected void OpenInsightsPage() => epam.OpenInsights();
        protected void PerformGlobalSearch(string searchTerm) => epam.GlobalSearchInfo(searchTerm);
    }
}

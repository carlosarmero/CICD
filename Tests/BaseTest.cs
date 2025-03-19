using TASk_loc1.PageObjects;
using TASk_loc1.Core;

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

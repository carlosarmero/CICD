using TASk_loc1.PageObjects;

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
    }
}

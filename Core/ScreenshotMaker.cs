using OpenQA.Selenium;

namespace Screens
{
    namespace TestFramework.Core.BrowserUtils
    {
        public class ScreenshotMaker
        {
            public static void TakeBrowserScreenshot(ITakesScreenshot screen)
            {
                var screenFolder = Path.Combine(
                   Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName).FullName,
                   "Core/Screenshots");
                var now = DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-fff");
                var screenshotPath = Path.Combine(screenFolder, $"FailDate_{now}.png");
                screen.GetScreenshot().SaveAsFile(screenshotPath);
            }
        }
    }
}

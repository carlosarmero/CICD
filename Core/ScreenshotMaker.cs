using OpenQA.Selenium;
using TASk_loc1.Core;

namespace Screens
{
    namespace TestFramework.Core.BrowserUtils
    {
        public class ScreenshotMaker
        {
            public static void TakeBrowserScreenshot(ITakesScreenshot screen, WebDriverConfiguration config)
            {
                var screenshotDirectory = Path.Combine(Directory.GetCurrentDirectory(), config.ScreenshotDirectory);
                if (!Directory.Exists(screenshotDirectory))
                {
                    Directory.CreateDirectory(screenshotDirectory);
                }
                var timestampFormat = config.ScreenshotTimestampFormat;
                var now = DateTime.Now.ToString(timestampFormat);
                var fileName = config.ScreenshotFileName;

                var screenshotPath = Path.Combine(screenshotDirectory, $"{fileName}_{now}.png");
                screen.GetScreenshot().SaveAsFile(screenshotPath);
            }
        }
    }
}

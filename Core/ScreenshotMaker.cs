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
                var screenshotDirectory = Path.Combine(Directory.GetCurrentDirectory(), config.ScreenshotDirectory) ?? Path.Combine(
                Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName).FullName,
                   "Core/Screenshots");

                // Create directory if it doesn't exist
                if (!Directory.Exists(screenshotDirectory))
                {
                    Directory.CreateDirectory(screenshotDirectory);
                }

                // Get timestamp format from config or use default
                var timestampFormat = config.ScreenshotTimestampFormat ?? "yyyy-MM-dd_hh-mm-ss-fff";
                var now = DateTime.Now.ToString(timestampFormat);

                // Get base filename from config or use default
                var fileName = config.ScreenshotFileName ?? "screenshot";

                var screenshotPath = Path.Combine(screenshotDirectory, $"{fileName}_{now}.png");
                screen.GetScreenshot().SaveAsFile(screenshotPath);
                /*
                var screenFolder = Path.Combine(
                   Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName).FullName,
                   "Core/Screenshots");
                var now = DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-fff");
                var screenshotPath = Path.Combine(screenFolder, $"FailDate_{now}.png");
                screen.GetScreenshot().SaveAsFile(screenshotPath);*/
            }
        }
    }
}

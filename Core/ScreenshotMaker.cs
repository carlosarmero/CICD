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
                if (screen == null) throw new ArgumentNullException(nameof(screen));
                if (config == null) throw new ArgumentNullException(nameof(config));

                var screenshotDirectory = GetScreenshotDirectory(config.ScreenshotDirectory);
                var screenshotPath = GetScreenshotPath(config, screenshotDirectory);

                SaveScreenshot(screen, screenshotPath);
            }

            private static string GetScreenshotDirectory(string relativeDirectory)
            {
                var screenshotDirectory = Path.Combine(Directory.GetCurrentDirectory(), relativeDirectory);
                if (!Directory.Exists(screenshotDirectory))
                {
                    Directory.CreateDirectory(screenshotDirectory);
                }
                return screenshotDirectory;
            }

            private static string GetScreenshotPath(WebDriverConfiguration config, string screenshotDirectory)
            {
                var timestamp = DateTime.UtcNow.ToString(config.ScreenshotTimestampFormat);
                var fileName = config.ScreenshotFileName;
                return Path.Combine(screenshotDirectory, $"{fileName}_{timestamp}.png");
            }

            private static void SaveScreenshot(ITakesScreenshot screen, string screenshotPath)
            {
                var screenshot = screen.GetScreenshot();
                screenshot.SaveAsFile(screenshotPath);
            }
        }
    }
}

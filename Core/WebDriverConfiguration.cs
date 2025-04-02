using System;

namespace TASk_loc1.Core
{
    public class WebDriverConfiguration
    {
        public TimeSpan PageLoadTimeout { get; set; } = TimeSpan.FromMinutes(5);
        public TimeSpan ImplicitWait { get; set; } = TimeSpan.FromSeconds(10);
        public TimeSpan ExplicitWait { get; set; } = TimeSpan.FromSeconds(30);
        public TimeSpan AsynchronousJavascriptTimeout { get; set; } = TimeSpan.FromSeconds(60);
        public bool IsHeadless { get; set; } = true;
        public BrowserType BrowserType { get; set; } = BrowserType.Firefox;
        public string DownloadDirectory { get; set; }
        public string ScreenshotDirectory { get; set; }
        public string ScreenshotTimestampFormat { get; set; } = "yyyyMMddHHmmssfff";
        public string ScreenshotFileName { get; set; } = "screenshot";
    }

    public enum BrowserType
    {
        Chrome,
        Firefox,
        Edge
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium
{
    /// <summary>
    /// Switch browser tab
    /// </summary>
    public static class SwitchToTab
    {
        /// <summary>
        /// Switch to last browser tab
        /// </summary>
        public static void SwitchToLastBrowserTab()
        {
            IWebDriver driver = new ChromeDriver();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }
        
    }
}

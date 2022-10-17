using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium
{
    /// <summary>
    /// Mail.ru page
    /// </summary>
    public static class OpenMailRu
    {
        /// <summary>
        /// Open mail.ru page
        /// </summary>
        public static void OpenStartPage()
        {
            IWebDriver driver = new ChromeDriver();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

    }
}

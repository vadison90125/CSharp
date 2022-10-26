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
            driver.Url = "https:\\www.mail.ru";
            driver.Manage().Window.Maximize();
        }

    }
}

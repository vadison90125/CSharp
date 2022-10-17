using OpenQA.Selenium;

namespace selenium
{
    /// <summary>
    /// Start page Mail.ru
    /// </summary>
    public class StartPage : BasePage
    {
        IWebElement loginPageButton;

        const string loginPageButtonXPath = "//a[@href='https://trk.mail.ru/c/veoz41']";

        public StartPage(IWebDriver driver) : base (driver)
        {
            loginPageButton = FindElementByXPath(loginPageButtonXPath);
        }

        /// <summary>
        /// Open login page
        /// </summary>
        public void LoginPage()
        {
            loginPageButton?.Click();
        }

    }
}

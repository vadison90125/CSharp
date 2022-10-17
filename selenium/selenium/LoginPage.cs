using OpenQA.Selenium;

namespace selenium
{
    /// <summary>
    /// Page for login
    /// </summary>
    public class LoginPage : BasePage
    {
        IWebElement nickEditBox ;
        IWebElement buttonEnterPassword;
        IWebElement passEditBox;

        const string nickEditBoxXPath = "//input[@name='username']";
        const string buttonEnterPasswordXPath = "//span[contains(text(),'Enter password')]";
        const string passEditBoxXPath = "//input[@name='password']";

        public LoginPage(IWebDriver driver) : base(driver)
        {
            nickEditBox = FindElementByXPath(nickEditBoxXPath);
            buttonEnterPassword = FindElementByXPath(buttonEnterPasswordXPath);
            passEditBox = FindElementByXPath(passEditBoxXPath);
        }

        /// <summary>
        /// Input name and password for login
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="password"></param>
        public void Login(string nick, string password)
        {
            nickEditBox?.SendKeys(nick);
            buttonEnterPassword.Click();
            Thread.Sleep(1000);
            passEditBox.SendKeys(password);
            passEditBox.SendKeys(Keys.Enter);
        }

    }
}

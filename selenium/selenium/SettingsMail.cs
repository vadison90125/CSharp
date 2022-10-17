using OpenQA.Selenium;

namespace selenium
{
    /// <summary>
    /// Settings for mail
    /// </summary>
    public class SettingsMail : BasePage
    {
        IWebElement changeMail;

        const string changeMailByXPath = "//span[contains(text(),'test_vadim_mail_1@mail.ru')]";

        public SettingsMail(IWebDriver driver) : base(driver)
        {
            changeMail = FindElementByXPath(changeMailByXPath);
        }

        /// <summary>
        /// Select second mail
        /// </summary>
        public void ChangeMail()
        {
            changeMail?.Click();
        }

    }
}

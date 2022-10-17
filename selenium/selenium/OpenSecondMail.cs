using OpenQA.Selenium;

namespace selenium
{
    /// <summary>
    /// Page second mail
    /// </summary>
    public class OpenSecondMail : BasePage
    {
        IWebElement mail;

        const string mailByXPath = "//span[@class='ll-crpt']";

        public OpenSecondMail(IWebDriver driver) : base(driver)
        {
            mail = FindElementByXPath(mailByXPath);
        }

        /// <summary>
        /// Open mail
        /// </summary>
        public void OpenMail()
        {
            mail?.Click();
        }

    }
}

using OpenQA.Selenium;

namespace selenium
{
    /// <summary>
    /// Page for writing letter text 
    /// </summary>
    public class MailText : BasePage
    {
        IWebElement text;

        const string textByXPath = "//div[contains(text(),'Test Text')]";

        public MailText(IWebDriver driver) : base(driver)
        {
            text = FindElementByXPath(textByXPath);
        }

        /// <summary>
        /// Input letter text
        /// </summary>
        /// <returns></returns>
        public string TextMail()
        {
            return text.Text;
        }

    }
}

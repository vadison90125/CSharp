using OpenQA.Selenium;

namespace selenium
{
    /// <summary>
    /// Page with menu for mail
    /// </summary>
    public class MenuPage : BasePage
    {
        IWebElement buttonCross;
        IWebElement buttonWriteLetter;

        const string buttonCrossByXpath = "//div[@class='ph-project-promo-close-icon svelte-m7oyyo']";
        const string buttonWriteLetterByXpath = "//span[contains(text(),'Написать письмо')]";
       
        public MenuPage(IWebDriver driver) : base(driver)
        {
            buttonCross = FindElementByXPath(buttonCrossByXpath);
            buttonWriteLetter = FindElementByXPath(buttonWriteLetterByXpath);
        }

        /// <summary>
        /// Open page for send mail
        /// </summary>
        public void GoToWriteLetter()
        {
            buttonCross?.Click();
            buttonWriteLetter?.Click();
        }

    }
}

using OpenQA.Selenium;

namespace selenium
{
    /// <summary>
    /// Menu with setting login
    /// </summary>
    public class DropMenu : BasePage
    {
        IWebElement addDrop;

        const string addDropByXPath = "//div[contains(text(),'Выйти')]";

        public DropMenu(IWebDriver driver) : base(driver)
        {
            addDrop = FindElementByXPath(addDropByXPath);
        }

        /// <summary>
        /// Adding second mail
        /// </summary>
        public void AddMail()
        {
            addDrop?.Click();
        }

    }
}

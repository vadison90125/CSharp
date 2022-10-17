using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace selenium
{
    public abstract class BasePage
    {
        protected IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement FindElementByXPath(string xPath)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement element = wait.Until(d => d.FindElement(By.XPath(xPath)));
            return element;
        }

        public IWebElement FindElementsByXPath(string xPath, int numElement)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            ReadOnlyCollection<IWebElement> elements = wait.Until(d => d.FindElements(By.XPath(xPath)));
            return elements[numElement];
        }

    }
}

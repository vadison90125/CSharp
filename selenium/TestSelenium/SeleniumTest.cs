using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using selenium;

namespace selenium
{
    [TestClass]
    public class SeleniumTest
    {
        [TestMethod]
        public void TestTextMessage()
        {
            IWebDriver driver = new ChromeDriver();
            
            OpenMailRu.OpenStartPage();

            string expectedText = "Test Text";
            string email1 = "test_vadim_mail_1";
            string email2 = "test_vadim_mail_2";
            string toEmail2 = "test_vadim_mail_2@mail.ru";
            string password = "xpathidclassname";
            string topicText = "Topic - Test";

            StartPage startPage1 = new StartPage(driver);
            startPage1.LoginPage();

            SwitchToTab.SwitchToLastBrowserTab();

            LoginPage loginPage1 = new LoginPage(driver);
            loginPage1.Login(email1, password);

            MenuPage menuPage = new MenuPage(driver);
            menuPage.GoToWriteLetter();

            Thread.Sleep(3000);
            MailPage mailPage = new MailPage(driver);
            mailPage.SendLetter(toEmail2, topicText, expectedText);

            SettingsMail settingMail = new SettingsMail(driver);
            settingMail.ChangeMail();

            DropMenu addDrop = new DropMenu(driver);
            addDrop.AddMail();

            StartPage startPage2 = new StartPage(driver);
            startPage2.LoginPage();

            SwitchToTab.SwitchToLastBrowserTab();

            LoginPage loginPage2 = new LoginPage(driver);
            loginPage2.Login(email2, password);

            OpenSecondMail mail = new OpenSecondMail(driver);
            mail.OpenMail();

            MailText text = new MailText(driver);
            string actualText = text.TextMail();

            Assert.AreEqual(actualText, expectedText);
            driver.Quit();
        }

    }
}
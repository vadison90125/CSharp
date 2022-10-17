using OpenQA.Selenium;

namespace selenium
{
    /// <summary>
    /// Page with menu for latter
    /// </summary>
    public class MailPage : BasePage
    {
        IWebElement toWhomEdit;
        IWebElement topicEdit;
        IWebElement textLetter;
        IWebElement sendLetter;
     
        const string toWhomEditByXPath = "//input[@class='container--H9L5q size_s_compressed--2c-eV']";
        const string topicEditByXPath = "//input[@class='container--H9L5q size_s_compressed--2c-eV']";
        const string textLetterByXPath = "/html/body/div[1]/div/div[2]/div/div/div/div[2]/div[3]/div[5]/div/div/div[2]/div[1]/div[1]";
        //const string textLetterByXPath = "//div[@class='editable-d3u9 cke_editable cke_editable_inline cke_contents_true cke_show_borders']/div[1]";
        //const string textLetterByClassName = "cke_show_borders";
        const string sendLetterByXPath = "//span[contains(text(),'Отправить')]";

        public MailPage(IWebDriver driver) : base(driver)
        {
            toWhomEdit = FindElementsByXPath(toWhomEditByXPath, 0);
            topicEdit = FindElementsByXPath(topicEditByXPath, 1);
            textLetter = FindElementByXPath(textLetterByXPath);
            //textLetter = FindElementByClassName(textLetterByClassName);
            sendLetter = FindElementByXPath(sendLetterByXPath);
        }

        /// <summary>
        /// Send letter to second mail
        /// </summary>
        /// <param name="whom"></param>
        /// <param name="topic"></param>
        /// <param name="text"></param>
        public void SendLetter(string whom, string topic, string text)
        {
            toWhomEdit?.SendKeys(whom);
            topicEdit?.SendKeys(topic);
            textLetter?.SendKeys(text);
            sendLetter?.Click();
        }

    }
}

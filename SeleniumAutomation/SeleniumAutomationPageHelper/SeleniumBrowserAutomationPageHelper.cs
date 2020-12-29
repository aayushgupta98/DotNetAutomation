using DotNetAutomation.Entities;
using DotNetAutomation.SeleniumAutomation;
using DotNetAutomation.SeleniumAutomation.SeleniumPageObjects;
using NUnit_Demo;
using OpenQA.Selenium;

namespace DotNetAutomation
{
    public class SeleniumBrowserAutomationPageHelper
    {
        protected IWebDriver driver;
        protected readonly Browser_ops browser;
        private SeleniumPageObject seleniumPageObject;
        private SeleniumDownloadsPageObject seleniumDownloadsPageObject;
        private SeleniumSearchPageObject seleniumSearchPageObject;

        public SeleniumBrowserAutomationPageHelper()
        {
            browser = new Browser_ops();
        }

        /// <summary>
        /// Initializing browser
        /// </summary>
        [NUnit.Framework.OneTimeSetUp]
        public void start_Browser()
        {
            browser.Init_Browser();
            driver = browser.getDriver;
            seleniumPageObject = new SeleniumPageObject(driver);
            seleniumDownloadsPageObject = new SeleniumDownloadsPageObject(driver);
            seleniumSearchPageObject = new SeleniumSearchPageObject(driver);
        }

        /// <summary>
        /// closing browser
        /// </summary>
        [NUnit.Framework.OneTimeTearDown]
        public void close_Browser()
        {
            browser.Close();
        }

        /// <summary>
        /// verifying download link
        /// </summary>
        /// <returns></returns>
        public bool? VerifyDownloadLink()
        {
            var element = seleniumPageObject.downloadButton;
            if(element != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sending keys and submit
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public void SearchText(string text)
        {
            seleniumDownloadsPageObject.searchBar.SendKeys(text + Keys.Enter);
        }

        public string SearchedText()
        {
            return seleniumDownloadsPageObject.searchBar.GetAttribute("value");
        }

        public void Click(string button)
        {
            if (button.Equals("ExpandBrowserButton"))
            {
                seleniumDownloadsPageObject.expandBrowserButton.Click();
            }
            else if (button.Equals("FirstLink"))
            {
                seleniumSearchPageObject.searchedPageFirstLink.Click();
                browser.Goto(SeleniumUrls.seleniumUrl);
            }
        }

        public string TextAfterExpand()
        {
            return seleniumSearchPageObject.textAfterExpandElement.Text;
        }
    }
}
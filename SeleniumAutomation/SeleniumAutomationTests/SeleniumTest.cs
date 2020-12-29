using DotNetAutomation.Entities;
using NUnit.Framework;
using System;

namespace DotNetAutomation
{
    /// <summary>
    /// Test class for selenium.dev
    /// </summary>
    [TestFixture]
    public class SeleniumTest : SeleniumBrowserAutomationPageHelper
    {

        [Test, Order(1)]
        public void test_OpenUrl()
        {
            browser.Goto(SeleniumUrls.seleniumUrl);
            Console.WriteLine("URL Opened");

            Assert.AreEqual("SeleniumHQ Browser Automation", driver.Title);
            Assert.AreEqual(SeleniumUrls.seleniumUrl, driver.Url);
        }

        [Test]
        public void test_VerifyDownloadLinkExists()
        {
            browser.Goto(SeleniumUrls.seleniumUrl);
            Assert.IsTrue(VerifyDownloadLink());
        }

        [Test]
        public void test_OpenDownloadPage()
        {
            browser.Goto(SeleniumUrls.seleniumDownloadsUrl);
            Console.WriteLine("Download Section Opened");

            Assert.AreEqual("Downloads", driver.Title);
            Assert.AreEqual(SeleniumUrls.seleniumDownloadsUrl, driver.Url);
        }
    }
}

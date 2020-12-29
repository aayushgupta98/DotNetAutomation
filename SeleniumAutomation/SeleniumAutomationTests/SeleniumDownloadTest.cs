using DotNetAutomation.Entities;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;

namespace DotNetAutomation
{
    [TestFixture]
    public class SeleniumDownloadTest : SeleniumBrowserAutomationPageHelper
    {
        [Test]
        public void test_ExpandTab()
        {
            browser.Goto(SeleniumUrls.seleniumDownloadsUrl);
            Console.WriteLine("Download Section Opened");
            new WebDriverWait(driver, TimeSpan.FromSeconds(4));

            Click("ExpandBrowserButton");
            new WebDriverWait(driver, TimeSpan.FromSeconds(4));

            Assert.NotNull(TextAfterExpand());
            Assert.AreEqual("Firefox", TextAfterExpand());
        }

        [Test]
        public void test_SearchKeyword()
        {
            browser.Goto(SeleniumUrls.seleniumDownloadsUrl);

            SearchText("Selenium");
            Console.WriteLine("Searched Some Text");

            Assert.AreEqual("Programmable Search Engine", driver.Title);
            Assert.NotNull(SearchedText());
            Assert.AreEqual("Selenium", SearchedText());
        }
    }
}

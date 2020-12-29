using DotNetAutomation.Entities;
using NUnit.Framework;
using System;

namespace DotNetAutomation
{
    [TestFixture]
    public class SeleniumSearchPageTest : SeleniumBrowserAutomationPageHelper
    {
    [Test]
    public void test_LinkOnSearchPage()
        {
            browser.Goto(SeleniumUrls.seleniumDownloadsUrl);
            
            SearchText("Selenium");
            Console.WriteLine("Searched Some Text");

            Click("FirstLink");

            Assert.AreEqual("SeleniumHQ Browser Automation", driver.Title);
            Assert.AreEqual(SeleniumUrls.seleniumUrl, driver.Url);
        }
    }
}

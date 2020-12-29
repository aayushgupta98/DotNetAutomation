using NUnit.Framework;
//using excel = Microsoft.Office.Interop.Excel;
using DotNetAutomation.GoogleAutomation.GoogleAutomationPageHelper;
using DotNetAutomation.GoogleAutomation.TestDataAccess;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

namespace DotNetAutomation.GoogleAutomation.GoogleAutomationTests
{
    /// <summary>
    /// class for testing Google Home Page
    /// </summary>
    [TestFixture]
    public class GoogleTest : GoogleBrowserAutomationPageHelper
    {
        
        /// <summary>
        /// creating instance for Google Home Page
        /// </summary>
        GoogleHomePage googleHomePage = new GoogleHomePage();

        ExtentTest extentTest(string testName, string description) => extent.CreateTest(testName, description);

        /// <summary>
        /// test for searching google home page
        /// </summary>
        [Test]
        public void GoogleSearch()
        {
            var test = extentTest("GoogleSearch", "Google Search Test on google home page");
            TestDataAccess.DataAccess dataAccess = new TestDataAccess.DataAccess();
            var testData = dataAccess.GetTestData();

            testData.ForEach(testCase =>
            {
                browser.Goto("https://www.google.com/");
                googleHomePage.Search(testCase.Keyword, googlePageObject);
                Assert.AreEqual(testCase.ExpectedResult, driver.Title);
            });
        }

        /// <summary>
        /// test for searching google home page
        /// </summary>
        [TestCaseSource("GetTestData")]
        public void GoogleSearch1()
        {
            TestDataAccess.DataAccess dataAccess = new TestDataAccess.DataAccess();
            var testData = dataAccess.GetTestData();

            testData.ForEach(testCase =>
            {
                browser.Goto("https://www.google.com/");
                googleHomePage.Search(testCase.Keyword, googlePageObject);
                Assert.AreEqual(testCase.Keyword, driver.Title);
            });
        }
    }
}

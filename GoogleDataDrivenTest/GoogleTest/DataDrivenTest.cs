using AventStack.ExtentReports;
using DotNetAutomation.GoogleDataDrivenTest.GoogleAutomationPageHelper;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DotNetAutomation
{
    public class DataDrivenTest : GoogleHomePageHelper
    {
        /// <summary>
        /// creating instance for Google Home Page
        /// </summary>
        public GoogleHomePage googleHomePage;

        public static List<TestCaseData> TestCases = GoogleDataDrivenTest.TestDataAccess.DataAccess.TestCases;

        ExtentTest extentTest(string testName, string description) => extent.CreateTest(testName, description);

        ExtentTest test = null;

        /// <summary>
        /// test for searching on google home page
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [TestCaseSource("TestCases")]
        public void Test_GoogleSearch(string keyword, string expectedTitle)
        {
            // arrange
            test = extentTest("GoogleSearch", "Google Search Test on google home page");
            googleHomePage = new GoogleHomePage();
            browser.Goto("https://www.google.com/");

            // act
            test.Log(Status.Info, "Test Case Starts.");
            googleHomePage.Search(keyword, googlePageObject);

            // assert
            Assert.AreEqual(expectedTitle, driver.Title);
        }

        /// <summary>
        /// function to perform after test
        /// </summary>
        [TearDown]
        public void StopTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var testCaseArguments = TestContext.CurrentContext.Test.Arguments;
            var expectedTitile = testCaseArguments[1];
            string screenshotPath = Capture(driver, Convert.ToString(testCaseArguments[0]));
            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
                test.Log(Status.Fail, $"Expected Title - {expectedTitile} Test Case Failed.");
            else
                test.Log(Status.Pass, $"Expected Title - {expectedTitile} Test Case Passed.");
            test.AddScreenCaptureFromPath(screenshotPath, Convert.ToString(testCaseArguments[0]));
        }

        //[Test, Order(1)]
        //public void Test_GoogleSearch01()
        //{
        //    // arrange
        //    googleHomePage = new GoogleHomePage();
        //    browser.Goto("https://www.google.com/");

        //    // act
        //    googleHomePage.Search("selenium02", googlePageObject);

        //    // assert
        //    Assert.AreEqual("selenium01 - Google Search", driver.Title);
        //}
    }
}

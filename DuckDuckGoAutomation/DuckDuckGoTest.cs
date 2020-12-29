using AventStack.ExtentReports;
using NUnit.Framework;

namespace DotNetAutomation
{
    /// <summary>
    /// duck duck go website test
    /// </summary>
    [TestFixture]
    public class DuckDuckGoTest : DuckDuckGoPageHelper
    {
        ExtentTest extentTest(string testName, string description) => extent.CreateTest(testName, description);


        /// <summary>
        /// Test for searching text
        /// </summary>
        [Order(1)]
        [Test]
        public void Search_Success()
        {
            var test = extentTest("Search_Success", "DuckDuckGo Search Test on DuckDuckGo home page");
            browser.Goto(Entities.SeleniumUrls.localUrl);
            System.Threading.Thread.Sleep(4000);


            test.Log(Status.Info, "Test Case Starts.");
            SearchText("LambdaTest");

            /* Perform wait to check the output */
            System.Threading.Thread.Sleep(2000);

            try
            {
                Assert.AreEqual("LambdaTest at DuckDuckGo", driver.Title);
                Assert.AreEqual("LambdaTest", SearchedText());
            }
            catch 
            {
                test.Log(Status.Fail, $"Test Case Failed.");
            }
        }

        /// <summary>
        /// Test for clicking add to chrome extension
        /// </summary>
        [Order(2)]
        [Test]
        public void AddToChromeExtension_Success()
        {
            browser.Goto(Entities.SeleniumUrls.localUrl);
            System.Threading.Thread.Sleep(4000);

            ClickAddToChromeOrExpandButton();

            System.Threading.Thread.Sleep(4000);

            Assert.AreEqual("DuckDuckGo Privacy Essentials - Chrome Web Store", driver.Title);
        }

        /// <summary>
        /// Test for expand question
        /// </summary>
        [Test]
        public void ExpandQuestion_Success()
        {
            browser.Goto(Entities.SeleniumUrls.localUrl);
            System.Threading.Thread.Sleep(4000);

            ClickAddToChromeOrExpandButton(true);
            System.Threading.Thread.Sleep(4000);

            var text = ExpandText();

            Assert.NotNull(text);
            Assert.AreEqual("Not only does Google keep your search history forever by default, their trackers have been found on 75% of the top million websites, which means they are tracking most everywhere you go on the Internet (unless you stop them with DuckDuckGo!). And that’s just the tip of the iceberg.", text);
        }
    }
}

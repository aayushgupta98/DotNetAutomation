using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit_Demo;
using OpenQA.Selenium;
using System;
using System.Net;
using NUnit.Framework;

namespace DotNetAutomation.GoogleDataDrivenTest.GoogleAutomationPageHelper
{
    public class GoogleHomePageHelper
    {
        protected IWebDriver driver;
        protected readonly Browser_ops browser;
        protected GooglePageObject.GoogleHomePageObject googlePageObject;
        protected static ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(@"C:\Users\aayush.gupta\source\repos\DotNetAutomation\Reports\index.html");
        protected static ExtentReports extent = new ExtentReports();

        public GoogleHomePageHelper()
        {
            browser = new Browser_ops();
        }

        [SetUp]
        public void Initialize()
        {
            extent.AttachReporter(htmlReporter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="screenshotName"></param>
        /// <returns></returns>
        public static string Capture(IWebDriver driver, string screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string uptoBinPath = path.Substring(0, path.LastIndexOf("bin")) + "Reports/images\\" + screenshotName + ".png";
            string localPath = new Uri(uptoBinPath).LocalPath;
            screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
            return localPath;
        }

        /// <summary>
        /// Initializing browser
        /// </summary>
        [NUnit.Framework.OneTimeSetUp]
        public void start_Browser()
        {
            try
            {
                browser.Init_Browser();
                driver = browser.getDriver;
                googlePageObject = new GooglePageObject.GoogleHomePageObject(driver);
                string hostname = Dns.GetHostName();
                OperatingSystem os = Environment.OSVersion;

                extent.AddSystemInfo("Operating System", os.ToString());
                extent.AddSystemInfo("HostName", hostname);
                extent.AddSystemInfo("Browser", "Google Chrome");
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Exception occured - {e}");
            }
        }

        ///// <summary>
        ///// searching in home page search bar
        ///// </summary>
        ///// <param name="keyword"></param>
        ///// <param name="pageObject"></param>
        //public void Search(string keyword, GooglePageObject.GoogleHomePageObject pageObject)
        //{
        //    try
        //    {
        //        var element = pageObject.searchBar;
        //        element.SendKeys(keyword);
        //        element.Submit();
        //    }
        //    catch(Exception e)
        //    {
        //        System.Diagnostics.Debug.WriteLine($"Exception occured - {e}");
        //    }
        //}

        [TearDown]
        public void CleanUp()
        {
            extent.Flush();
        }

        [NUnit.Framework.OneTimeTearDown]
        public void closeBrowser()
        {
            browser.Close();
        }
    }
}

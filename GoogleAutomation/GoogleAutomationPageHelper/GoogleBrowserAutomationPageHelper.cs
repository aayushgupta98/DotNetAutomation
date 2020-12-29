using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using DotNetAutomation.GoogleAutomation.GooglePageObjects;
using NUnit.Framework;
using NUnit_Demo;
using OpenQA.Selenium;
using System;
using System.Net;

namespace DotNetAutomation.GoogleAutomation.GoogleAutomationPageHelper
{
    /// <summary>
    /// class for google page helper
    /// </summary>
    public class GoogleBrowserAutomationPageHelper
    {
        protected IWebDriver driver;
        protected readonly Browser_ops browser;
        protected GooglePageObject googlePageObject;
        protected static ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(@"C:\Users\aayush.gupta\source\repos\DotNetAutomation\Reports\index.html");
        protected static ExtentReports extent = new ExtentReports();

        /// <summary>
        /// instance for browser
        /// </summary>
        public GoogleBrowserAutomationPageHelper()
        {
            browser = new Browser_ops();
        }

        [SetUp]
        public void Initialize()
        {
            extent.AttachReporter(htmlReporter);
        }

        /// <summary>
        /// Initializing browser
        /// </summary>
        [OneTimeSetUp]
        public void start_Browser()
        {
            browser.Init_Browser();
            driver = browser.getDriver;
            googlePageObject = new GooglePageObject(driver);
            string hostname = Dns.GetHostName();
            OperatingSystem os = Environment.OSVersion;

            extent.AddSystemInfo("Operating System", os.ToString());
            extent.AddSystemInfo("HostName", hostname);
            extent.AddSystemInfo("Browser", "Google Chrome");
        }

        [TearDown]
        public void CleanUp()
        {
            extent.Flush();
        }
    }
}

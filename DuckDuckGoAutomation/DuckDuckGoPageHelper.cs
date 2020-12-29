using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit_Demo;
using OpenQA.Selenium;
using System;
using System.Net;

namespace DotNetAutomation
{
    public class DuckDuckGoPageHelper
    {
        protected IWebDriver driver;
        protected readonly Browser_ops browser;
        protected static ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(@"C:\Users\aayush.gupta\source\repos\DotNetAutomation\Reports\index.html");
        protected static ExtentReports extent = new ExtentReports();

        public DuckDuckGoPageHelper()
        {
            browser = new Browser_ops();

        }

        /// <summary>
        /// Find an element
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public IWebElement FindElement(string Path)
        {
            return driver.FindElement(By.XPath(Path));
        }

        /// <summary>
        /// Sending keys and submit
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public void SearchText(string text)
        {
            var element1 = FindElement(Entities.SeleniumUrls.searchBar);
            element1.SendKeys(text);
            element1.Submit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string SearchedText()
        {
            var element = FindElement("//input[@id='search_form_input']");
            return element.GetAttribute("value");
        }

        /// <summary>
        /// click expand or add to chrome extension
        /// </summary>
        /// <param name="isExpandButton"></param>
        public void ClickAddToChromeOrExpandButton(bool isExpandButton = false)
        {
            if (!isExpandButton)
            {
                FindElement("//span[contains(text(),'Add DuckDuckGo to Chrome')]").Click();
            }
            
            else
            { 
                FindElement("//button[@id='faq-btn-1']").Click();
            }
        }

        [SetUp]
        public void Initialize()
        {
            extent.AttachReporter(htmlReporter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ExpandText()
        {
            return FindElement("//p[contains(text(),'Not only does Google keep your search history fore')]").Text;
        }

        /// <summary>
        /// Initializing browser
        /// </summary>
        [NUnit.Framework.OneTimeSetUp]
        public void start_Browser()
        {
            browser.Init_Browser();
            driver = browser.getDriver;
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

        /// <summary>
        /// closing browser
        /// </summary>
        [NUnit.Framework.OneTimeTearDown]
        public void close_Browser()
        {
            browser.Close();
        }
    }
}

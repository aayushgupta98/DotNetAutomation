using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnit_Demo
{
    public class Browser_ops
    {
        IWebDriver webDriver;
        public void Init_Browser()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
        }
        public void Goto(string url)
        {
            webDriver.Url = url;
        }
        public void Close()
        {
            webDriver.Quit();
        }
        public IWebDriver getDriver
        {
            get { return webDriver; }
        }
    }
}
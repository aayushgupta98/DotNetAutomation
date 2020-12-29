using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetAutomation.SeleniumAutomation.SeleniumPageObjects
{
    public class SeleniumDownloadsPageObject 
    {
        public SeleniumDownloadsPageObject(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='gsc-i-id1']")]
        public IWebElement searchBar { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='browsersExpand']")]
        public IWebElement expandBrowserButton { get; set; }
    }
}

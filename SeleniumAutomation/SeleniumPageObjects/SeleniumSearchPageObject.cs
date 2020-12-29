using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetAutomation.SeleniumAutomation.SeleniumPageObjects
{
    public class SeleniumSearchPageObject 
    {
        public SeleniumSearchPageObject(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//body/div[@id='cse-hosted']/div[@id='cse-body']/div[@id='cse']/div[@id='___gcse_0']/div[1]/div[1]/div[1]/div[5]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/a[1]")]
        public IWebElement searchedPageFirstLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//h3[contains(text(),'Firefox')]")]
        public IWebElement textAfterExpandElement { get; set; }
    }
}

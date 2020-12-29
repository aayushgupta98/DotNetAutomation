using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetAutomation.SeleniumAutomation
{
    public class SeleniumPageObject 
    {
        public SeleniumPageObject(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Downloads')]")]
        public IWebElement downloadButton { get; set; }
    }
}

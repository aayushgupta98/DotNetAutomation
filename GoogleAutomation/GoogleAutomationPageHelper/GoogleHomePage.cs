using DotNetAutomation.GoogleAutomation.GooglePageObjects;

namespace DotNetAutomation.GoogleAutomation.GoogleAutomationPageHelper
{
    /// <summary>
    /// class for providing methods to be tested in Google Home Page
    /// </summary>
    public class GoogleHomePage : GoogleBrowserAutomationPageHelper
    {
        /// <summary>
        /// searching in home page search bar
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageObject"></param>
        public void Search(string keyword, GooglePageObject pageObject)
        {
            var element = pageObject.searchBar;
            element.SendKeys(keyword);
            element.Submit();
        }
    }
}

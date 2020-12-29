using System;

namespace DotNetAutomation.GoogleDataDrivenTest.GoogleAutomationPageHelper
{
    /// <summary>
    /// class for providing methods to be tested in Google Home Page
    /// </summary>
    public class GoogleHomePage : GoogleHomePageHelper
    {
        /// <summary>
        /// searching in home page search bar
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageObject"></param>
        public void Search(string keyword, GooglePageObject.GoogleHomePageObject pageObject)
        {
            try
            {
                var element = pageObject.searchBar;
                element.SendKeys(keyword);
                element.Submit();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Exception occured - {e}");
            }
        }
    }
}

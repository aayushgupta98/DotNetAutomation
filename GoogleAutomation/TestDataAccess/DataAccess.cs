using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DotNetAutomation.GoogleAutomation.TestDataAccess
{
    /// <summary>
    /// class for accessing data from external source
    /// </summary>
    public class DataAccess
    {
        /// <summary>
        /// connection string
        /// </summary>
        string connString = "datasource=localhost;port=3306;username=root;password=Hsuya@1962@;database=productsdb";

        /// <summary>
        /// getting test data
        /// </summary>
        /// <returns></returns>
        public List<TestData> GetTestData()
        {
            List<TestData> testData = new List<TestData>();
            MySqlConnection mySqlConnection = new MySqlConnection(connString);
            try
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("select Keyword, ExpectedResult from productsdb.qaautomation;", mySqlConnection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                if (mySqlDataReader != null && mySqlDataReader.HasRows == true)
                {
                    while (mySqlDataReader.Read())
                    {
                        TestData testDataItem = new TestData();
                        testDataItem.Keyword = mySqlDataReader.GetValue(0).ToString();
                        testDataItem.ExpectedResult = mySqlDataReader.GetValue(1).ToString();
                        testData.Add(testDataItem);
                    }
                    mySqlDataReader.Close();
                }
                mySqlConnection.Close();
                return testData;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Database Exception::::{e.Message}");
            }
            finally
            {

            }
            return testData;
        }
    }
}

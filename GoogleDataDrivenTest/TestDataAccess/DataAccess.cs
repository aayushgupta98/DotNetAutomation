using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace DotNetAutomation.GoogleDataDrivenTest.TestDataAccess
{
    public class DataAccess
    {
        public static List<TestCaseData> TestCases
        {
            get
            {
                var testCases = new List<TestCaseData>();
                try
                {
                    using (var fs = File.OpenRead(@"C:\Users\aayush.gupta\source\repos\DotNetAutomation\GoogleDataDrivenTest\QADataDriven.csv"))
                    using (var sr = new StreamReader(fs))
                    {
                        string line = string.Empty;
                        while (line != null)
                        {
                            line = sr.ReadLine();
                            if (line != null)
                            {
                                string[] split = line.Split(new char[] { ',' }, StringSplitOptions.None);

                                string keyword = split[0].ToString();
                                string expectedTitle = split[1].ToString();

                                //var testCase = new TestCaseData(keyword).Returns(expectedTitle);
                                var testCase = new TestCaseData(keyword, expectedTitle);
                                testCases.Add(testCase);
                            }
                        }
                    }
                    return testCases;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine($"Exception occured - {e}");
                }
                return testCases;
            }
        }
    }
}


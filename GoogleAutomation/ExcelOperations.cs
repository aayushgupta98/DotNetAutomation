using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace DotNetAutomation.GoogleAutomation
{
    public class ExcelOperations
    {
        //private static DataTable ExcelToDataTable()
        //{

        //}

        //public class DataCollection
        //{
        //    public int rollNumber { get; set; }
        //    public string colName { get; set; }
        //    public string colValue { get; set; }
        //}
        public static List<TestCaseData> TestCases
        {
            get
            {
                var testCases = new List<TestCaseData>();

                using (var fs = File.OpenRead(@"Documents\QA.csv"))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;
                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            string[] split = line.Split(new char[] { ',' },
                                StringSplitOptions.None);

                            string keyword = split[0].ToString();
                            string title = split[1].ToString();

                            var testCase = new TestCaseData(keyword).Returns(title);
                            testCases.Add(testCase);
                        }
                    }
                }

                return testCases;
            }
        }
    }
}

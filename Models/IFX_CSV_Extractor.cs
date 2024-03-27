using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace IFX_CSV_Data_Extractor
{
    public class IfxCsvExtractor:IDisposable
    {
        #region Properties
        //Data file path that need to read and extract
        public string DataFileName { get; set; }

        //Data file name/test program name
        public string JOB_NAME { get; set; }

        //DataTable to save all raw data
        public DataTable RawDataTable { get; set; }

        //DataTable to save all test information (test name, limits, unit)
        public DataTable TestInfoTable { get; set; }

        //Index to indicate data column started
        public int DataColumnStartIndex { get; set; } = 11;

        //Index to indicate data column ended
        public int DataColumnEndIndex { get; set; } = 24;
        #endregion


        #region Constructor
        public IfxCsvExtractor(string csvFileName)
        {
            DataFileName = csvFileName;
        }
        public IfxCsvExtractor()
        {

        }
        #endregion


        #region Methods
        //Extract csv file and save all data into datatable
        public void Extract()
        {
            if(string.IsNullOrEmpty(DataFileName) || !File.Exists(DataFileName))
            {
                throw new Exception("Data file is not specified or it does not exist.");
            }
            else
            {
                //use Try-Catch to detect unexpected IO error
                try
                {
                    JOB_NAME = Path.GetFileNameWithoutExtension(DataFileName);
                    FileStream fs = new FileStream(DataFileName, FileMode.Open, FileAccess.Read);
                    StreamReader sw = new StreamReader(fs);
                    string lineText = "";
                    int rowId = 0;
                    //Read 
                    while((lineText=sw.ReadLine())!=null)
                    {
                        //Current line is header
                        List<string> strList = lineText.Split(',').ToList();
                        //Trim each data item (remove unwanted space)
                        strList = strList.Select(d=>d.Trim()).ToList();
                        if(rowId == 0)
                        {
                            RawDataTable = CreateRawTable(JOB_NAME, strList);
                            TestInfoTable = CreateTestInfoTable(JOB_NAME, strList.GetRange(DataColumnStartIndex, DataColumnEndIndex - DataColumnStartIndex + 1));
                        }
                        else
                        {
                            //process data lines
                            if (RawDataTable != null && RawDataTable.Columns.Count >= strList.Count)
                            {
                                DataRow rawRow = RawDataTable.NewRow();
                                for(int col_idx =0; col_idx < strList.Count; col_idx ++)
                                {
                                    if(col_idx < DataColumnStartIndex || col_idx > DataColumnEndIndex)
                                    {
                                        //Info data to be stored in string
                                        if (!string.IsNullOrEmpty(strList[col_idx]))
                                            rawRow[col_idx] = strList[col_idx];
                                    }
                                    else
                                    {
                                        //test result need to be stored in float
                                        if (!string.IsNullOrEmpty(strList[col_idx]))
                                        {
                                            try
                                            {
                                                //convert text to float and store it into table
                                                rawRow[col_idx] = float.Parse(strList[col_idx]);
                                            }
                                            catch(Exception ee)
                                            {
                                                //data convert failed
                                                throw new Exception("Data is not in correct format [float]: " + strList[col_idx]);
                                            }
                                        }
                                    }
                                }
                                RawDataTable.Rows.Add(rawRow);
                            }
                            else
                            {
                                //data is ignored if data structure is not formed or it has more elements than structure
                            }
                        }
                        rowId++;
                    }

                    sw.Close();
                    sw.Dispose();
                    fs.Close();
                    fs.Dispose();
                }
                catch (Exception ee)
                {
                    throw new Exception(ee.Message);
                }
            }
        }

        //compute statistics for all tests (mean, stdev, median, min, max, cpk)
        public DataTable ComputeTestStatistics()
        {
            DataTable dt = new DataTable(RawDataTable.TableName);
            dt.Columns.Add("TEST_NUM", typeof(UInt32));
            dt.Columns.Add("TEST_NAM", typeof(string));
            dt.Columns.Add("LO_LIMIT", typeof(float));
            dt.Columns.Add("HI_LIMIT", typeof(float));
            dt.Columns.Add("UNIT", typeof(string));
            dt.Columns.Add("Mean", typeof(float));
            dt.Columns.Add("Min", typeof(float));
            dt.Columns.Add("Median", typeof(float));
            dt.Columns.Add("Max", typeof(float));
            dt.Columns.Add("Stdev", typeof(float));
            dt.Columns.Add("Cpk", typeof(float));

            for(int i =DataColumnStartIndex; i<=DataColumnEndIndex; i++)
            {
                string testName = RawDataTable.Columns[i].ColumnName;
                //compute current test's statistics
                TestStatistic tso = GetOneTestStatistic(testName);

                //update to data row
                DataRow dr = dt.NewRow();
                dr["TEST_NAM"] = testName;
                dr["TEST_NUM"] = tso.TEST_NUM;
                dr["UNIT"] = tso.UNIT;
                if (tso.LO_LIMIT.HasValue)
                    dr["LO_LIMIT"] = tso.LO_LIMIT.Value;
                if (tso.HI_LIMIT.HasValue)
                    dr["HI_LIMIT"] = tso.HI_LIMIT.Value;
                if (tso.Mean.HasValue)
                    dr["Mean"] = tso.Mean.Value;
                if (tso.Min.HasValue)
                    dr["Min"] = tso.Min.Value;
                if (tso.Median.HasValue)
                    dr["Median"] = tso.Median.Value;
                if (tso.Max.HasValue)
                    dr["Max"] = tso.Max.Value;
                if (tso.Stdev.HasValue)
                    dr["Stdev"] = tso.Stdev.Value;
                if (tso.Cpk.HasValue)
                    dr["Cpk"] = tso.Cpk.Value;

                //add datarow to datatable
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public TestStatistic GetOneTestStatistic(string testName)
        {
            if(!RawDataTable.Columns.Contains(testName))
            {
                return null;
            }
            //Collect all data points of the specified test and store into a List to compute statistics
            List<float> dataList = (from DataRow dr in RawDataTable.AsEnumerable()
                                    where dr[testName] != DBNull.Value && !float.IsNaN(dr.Field<float>(testName)) && !float.IsInfinity(dr.Field<float>(testName))
                                    select dr.Field<float>(testName)).ToList();
            //Check whether there is data collected
            if(dataList == null || dataList.Count == 0)
            {
                return null;
            }

            TestStatistic ts = new TestStatistic()
            {
                TEST_NAM = testName,
                //update limits if there is one
            };

            //sort the list to for Median, Q1, Q2 compute
            dataList.Sort();

            //Compute basic statistics
            ts.Mean = dataList.Average();
            ts.Median = dataList[dataList.Count / 2];
            ts.Q1 = dataList[dataList.Count / 4];
            ts.Q3 = dataList[dataList.Count * 3 / 4];
            ts.Min = dataList.Min();
            ts.Max = dataList.Max();

            //Compute Stdev and CPK
            if(dataList.Count>=2)
            {
                ts.Stdev = GetStdevOfList(dataList, ts.Mean.Value); 
            }
            if (ts.LO_LIMIT.HasValue || ts.HI_LIMIT.HasValue)
            {
                ts.Cpk = CalculateCpk(ts.Mean, ts.Stdev, ts.HI_LIMIT, ts.LO_LIMIT);
            }
            

            return ts;
        }

        //clean up and release memory
        public void Dispose()
        {
            if(RawDataTable!=null)
            {
                RawDataTable.Rows.Clear();
                RawDataTable.Dispose();
                RawDataTable = null;
            }
            if (TestInfoTable != null)
            {
                TestInfoTable.Rows.Clear();
                TestInfoTable.Dispose();
                TestInfoTable = null;
            }
        }
        #endregion


        #region Helper
        //create data table structure to store raw data
        private DataTable CreateRawTable(string tableName, List<string> columnNameList)
        {
            //Used to detect whether there is any duplicated colum name
            DataTable rawTable = new DataTable(tableName);
            int idx = 0;
            //*** It can be improved by hanlding duplicated column name ***
            foreach(string col in columnNameList)
            {
                if(idx <DataColumnStartIndex || idx > DataColumnEndIndex)
                {
                    //Info columns to be stored in String
                    rawTable.Columns.Add(col, typeof(string));
                }
                else
                {
                    //data columns to be stored in Float
                    rawTable.Columns.Add(col, typeof(float));
                }
                idx++;
            }
            return rawTable;
        }

        //create data table structure to store test informaiton
        private DataTable CreateTestInfoTable(string tableName, List<string> testNameList)
        {
            DataTable infotable = new DataTable(tableName);
            infotable.Columns.Add("TEST_NUM", typeof(UInt32));//
            infotable.Columns.Add("TEST_NAME", typeof(string));//
            infotable.Columns.Add("LOW_LIMIT", typeof(float));//
            infotable.Columns.Add("HIGH_LIMIT", typeof(float));//
            infotable.Columns.Add("UNIT", typeof(string));//
            foreach(string col in testNameList)
            {
                DataRow dr = infotable.NewRow();
                dr[1] = col;
                infotable.Rows.Add(dr);
            }
            return infotable;
        }

        //Function to compute Stdev of a data list
        private float? GetStdevOfList(List<float> DataList, float Mean)
        {
            int N = DataList.Count;
            var q = from f in DataList
                    select (f - Mean) * (f - Mean);
            return (float)Math.Sqrt((q.ToList().Sum() / (N - 1)));
        }

        //Calcuate CPK
        private float? CalculateCpk(float? mean, float? stdev, float? hlm, float? llm)
        {

            float? cpl = null;
            float? cpu = 0;
            float? cpk = null;
            if (stdev.HasValue && stdev.Value > 0)
            {
                if (hlm.HasValue)
                {
                    cpu = (hlm.Value - mean.Value) / (3 * stdev.Value);
                }

                if (llm.HasValue)
                {
                    cpl = (mean.Value - llm.Value) / (3 * stdev.Value);
                }

                //CPK
                if (cpu.HasValue)
                {
                    cpk = cpu;
                }
                if(cpl.HasValue)
                {
                    if(!cpk.HasValue)
                    {
                        cpk = cpl;
                    }
                    else
                    {
                        if (cpk.Value > cpl.Value)
                            cpk = cpl;
                    }
                }
            }
            return cpk;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Globalization;

using COVID_Visualization.Data;

namespace COVID_Visualization
{
    class DataParser
    {
        public bool CSVParser(string filepath, out Dictionary<string, DataNational> globalData_dict)
        {
            bool result = true;
            globalData_dict = new Dictionary<string, DataNational>();

            StreamReader csv_reader = new StreamReader(File.OpenRead(filepath));
            List<string> timestamp_list = new List<string>();

            while (!csv_reader.EndOfStream)
            {
                string line = csv_reader.ReadLine();
                if(!string.IsNullOrWhiteSpace(line))
                {
                    if (line.Contains('"'))
                    {
                        line = line.Replace(", ", "; ");
                        line = line.Replace("\"", "");
                    }
                    string[] values = line.Split(',');

                    if (timestamp_list.Count == 0)
                    {
                        // Get header from CSV to get timestamps
                        for (int i = 4; i < values.Length; i++)
                        {
                            timestamp_list.Add(values[i]);
                        }
                    }
                    else
                    {
                        string country = values[1];
                        // Check if country is already added
                        if (globalData_dict.ContainsKey(country))
                        {
                            // Get data with timestamps
                            Dictionary<string, int> temp_dataDict = new Dictionary<string, int>();
                            for (int i = 4; i < values.Length; i++)
                            {
                                temp_dataDict.Add(timestamp_list[i - 4], Convert.ToInt32(values[i]));
                            }

                            // Get timestamp key to add values
                            foreach (string item in timestamp_list)
                            {
                                globalData_dict[country].NATIONAL_DATA.DATA[item] += temp_dataDict[item];
                            }
                        }
                        else
                        {
                            // Get coordinates
                            double[] coordinates = new double[] { Convert.ToDouble(values[2], CultureInfo.InvariantCulture), Convert.ToDouble(values[3], CultureInfo.InvariantCulture) };
                            // Get data with timestamps
                            Dictionary<string, int> dataDict = new Dictionary<string, int>();
                            for (int i = 4; i < values.Length; i++)
                            {
                                dataDict.Add(timestamp_list[i - 4], Convert.ToInt32(values[i]));
                            }

                            DataElement dataElement = new DataElement(coordinates, dataDict);
                            DataNational dataNational = new DataNational(country, dataElement);

                            // Add to global dictionary
                            globalData_dict.Add(country, dataNational);
                        }
                    }
                }
            }

            Debug.WriteLine(globalData_dict.Count);

            return result;
        }
    }
}

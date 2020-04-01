using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

using COVID_Visualization.Data;

namespace COVID_Visualization
{
    class DataParser
    {
        public bool CSVParser(string filepath, out Dictionary<string, DataNational> globalData_dict, out List<string> timestamp_list)
        {
            bool result = true;
            globalData_dict = new Dictionary<string, DataNational>();

            StreamReader csv_reader = new StreamReader(File.OpenRead(filepath));
            timestamp_list = new List<string>();

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

        public bool CSVDailyParser(string filepath, out Dictionary<string, DataLocal> localDataDaily_dict)
        {
            bool result = true;
            localDataDaily_dict = new Dictionary<string, DataLocal>();

            StreamReader csv_reader = new StreamReader(File.OpenRead(filepath));

            int line_counter = 0;
            while (!csv_reader.EndOfStream)
            {
                string line = csv_reader.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    if (line.Contains('"'))
                    {
                        line = line.Replace(", ", "; ");
                        line = line.Replace("\"", "");
                    }
                    string[] values = line.Split(',');

                    if (line_counter != 0)
                    {
                        string prov_country_key = values[3] + "_" + values[2] + "_" + values[1];
                        // Check if province/country key is already added. This should not happen in this database
                        if (localDataDaily_dict.ContainsKey(prov_country_key))
                        {
                            MessageBox.Show(prov_country_key + " already added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Get coordinates
                            if (!string.IsNullOrEmpty(values[5]) && !string.IsNullOrEmpty(values[6]))
                            {
                                double[] coordinates = new double[] { Convert.ToDouble(values[5], CultureInfo.InvariantCulture), Convert.ToDouble(values[6], CultureInfo.InvariantCulture) };
                                // Get confirmed data
                                int daily_confirmed = Convert.ToInt32(values[7]);
                                // Get deaths data
                                int daily_deaths = Convert.ToInt32(values[8]);
                                // Get recovered data
                                int daily_recovered = Convert.ToInt32(values[9]);

                                DataElement dataElement = new DataElement(coordinates, daily_confirmed, daily_deaths, daily_recovered);
                                DataLocal dataLocal = new DataLocal(prov_country_key, dataElement);

                                // Add to global dictionary
                                localDataDaily_dict.Add(prov_country_key, dataLocal);
                            }
                        }
                    }

                    line_counter++;
                }
            }

            Debug.WriteLine(localDataDaily_dict.Count);

            return result;
        }
    }
}

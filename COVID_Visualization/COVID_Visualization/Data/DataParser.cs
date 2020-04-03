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

        public bool CSVSpainDataParser(string filepath, out Dictionary<string, DataNational> spainData_confirmedDict, out Dictionary<string, DataNational> spainData_deathsDict, out Dictionary<string, DataNational> spainData_recoveredDict, out List<string> timestamp_list, out List<string> region_list)
        {
            bool result = true;
            spainData_confirmedDict = new Dictionary<string, DataNational>();
            spainData_deathsDict = new Dictionary<string, DataNational>();
            spainData_recoveredDict = new Dictionary<string, DataNational>();

            StreamReader csv_reader = new StreamReader(File.OpenRead(filepath));
            timestamp_list = new List<string>();
            region_list = new List<string>();

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

                    // Check for null values and set them to 0
                    for (int i = 0; i < values.Length; i++)
                    {
                        if (string.IsNullOrEmpty(values[i]))
                            values[i] = "0";
                    }

                    // If first columns is not two letters is not valid (ISO code for each region)
                    if (values[0].Length == 2)
                    {
                        // Get timestamp. If it is already acquired it is ignored
                        if (!timestamp_list.Contains(values[1]))
                            timestamp_list.Add(values[1]);

                        // Get region. If it is already acquired it is ignored
                        string region = values[0];
                        if (!region_list.Contains(region))
                            region_list.Add(region);

                        // Check if region is already added
                        if (spainData_confirmedDict.ContainsKey(region))
                        {
                            // Add data to its dictionary
                            spainData_confirmedDict[region].NATIONAL_DATA.DATA.Add(values[1], Convert.ToInt32(values[2]));
                            spainData_deathsDict[region].NATIONAL_DATA.DATA.Add(values[1], Convert.ToInt32(values[5]));
                            spainData_recoveredDict[region].NATIONAL_DATA.DATA.Add(values[1], Convert.ToInt32(values[6]));
                        }
                        else
                        {
                            // Get data with timestamps
                            Dictionary<string, int> confirmedDict = new Dictionary<string, int>();
                            confirmedDict.Add(values[1], Convert.ToInt32(values[2]));
                            Dictionary<string, int> deathsDict = new Dictionary<string, int>();
                            deathsDict.Add(values[1], Convert.ToInt32(values[5]));
                            Dictionary<string, int> recoveredDict = new Dictionary<string, int>();
                            recoveredDict.Add(values[1], Convert.ToInt32(values[6]));

                            DataElement confirmedElement = new DataElement(new double[] { 0, 0 }, confirmedDict);
                            DataNational confirmedNational = new DataNational(region, confirmedElement);
                            DataElement deathsElement = new DataElement(new double[] { 0, 0 }, deathsDict);
                            DataNational deathsNational = new DataNational(region, deathsElement);
                            DataElement recoveredElement = new DataElement(new double[] { 0, 0 }, recoveredDict);
                            DataNational recoveredNational = new DataNational(region, recoveredElement);

                            // Add to spain dictionary
                            spainData_confirmedDict.Add(region, confirmedNational);
                            spainData_deathsDict.Add(region, deathsNational);
                            spainData_recoveredDict.Add(region, recoveredNational);
                        }
                    }
                }
            }

            Debug.WriteLine(spainData_confirmedDict.Count);

            return result;
        }
    }
}

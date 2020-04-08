using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Globalization;

using COVID_Visualization.Forms;

namespace COVID_Visualization.Data
{
    class DataPlot
    {
        // Get Confirmed-Deaths-Recovered data to plot
        public List<List<PointF>> GetListOfPoints_CDR(Dictionary<string, DataNational> globalDataConfirmed_dict, Dictionary<string, DataNational> globalDataDeaths_dict, Dictionary<string, DataNational> globalDataRecovered_dict, string country, out List<string> seriesNames)
        {
            List<List<PointF>> result = new List<List<PointF>>();
            seriesNames = new List<string>();

            // Get confirmed cases
            seriesNames.Add("Confirmed");
            List<PointF> confirmed_pointList = new List<PointF>();
            float counter = 0;
            foreach (var item in globalDataConfirmed_dict[country].NATIONAL_DATA.DATA)
            {
                float value = (float)item.Value;
                confirmed_pointList.Add(new PointF(counter, value));
                counter++;
            }
            result.Add(confirmed_pointList);
            counter = 0;

            // Get death cases
            seriesNames.Add("Deaths");
            List<PointF> deaths_pointList = new List<PointF>();
            foreach (var item in globalDataDeaths_dict[country].NATIONAL_DATA.DATA)
            {
                float value = (float)item.Value;
                deaths_pointList.Add(new PointF(counter, value));
                counter++;
            }
            result.Add(deaths_pointList);
            counter = 0;

            // Get recovered cases
            seriesNames.Add("Recovered");
            List<PointF> recovered_pointList = new List<PointF>();
            foreach (var item in globalDataRecovered_dict[country].NATIONAL_DATA.DATA)
            {
                float value = (float)item.Value;
                recovered_pointList.Add(new PointF(counter, value));
                counter++;
            }
            result.Add(recovered_pointList);

            return result;
        }

        // Get global cases to plot
        public List<List<PointF>> GetListOfPoints_GlobalCDR(Dictionary<string, DataNational> globalDataConfirmed_dict, Dictionary<string, DataNational> globalDataDeaths_dict, Dictionary<string, DataNational> globalDataRecovered_dict, out List<string> seriesNames)
        {
            List<List<PointF>> result = new List<List<PointF>>();
            seriesNames = new List<string>();

            List<PointF> confirmed_pointList = new List<PointF>();
            List<PointF> deaths_pointList = new List<PointF>();
            List<PointF> recovered_pointList = new List<PointF>();

            int country_counter = 0;
            foreach (string country in globalDataConfirmed_dict.Keys.ToList())
            {
                // Get confirmed cases
                seriesNames.Add("Confirmed");
                float counter = 0;
                foreach (var item in globalDataConfirmed_dict[country].NATIONAL_DATA.DATA)
                {
                    DateTime datetime = DateTime.ParseExact(item.Key, "M/d/yy", CultureInfo.InvariantCulture);
                    float value = (float)item.Value;
                    if (country_counter == 0)
                    {
                        confirmed_pointList.Add(new PointF(counter, value));
                    }
                    else
                    {
                        PointF _point = new PointF(counter, confirmed_pointList[(int)counter].Y + value);
                        confirmed_pointList[(int)counter] = _point;
                    }
                    counter++;
                }
                counter = 0;

                // Get death cases
                seriesNames.Add("Deaths");
                foreach (var item in globalDataDeaths_dict[country].NATIONAL_DATA.DATA)
                {
                    float value = (float)item.Value;
                    //deaths_pointList.Add(new PointF(counter, value));
                    if (country_counter == 0)
                    {
                        deaths_pointList.Add(new PointF(counter, value));
                    }
                    else
                    {
                        PointF _point = new PointF(counter, deaths_pointList[(int)counter].Y + value);
                        deaths_pointList[(int)counter] = _point;
                    }
                    counter++;
                }
                counter = 0;

                // Get recovered cases
                seriesNames.Add("Recovered");
                foreach (var item in globalDataRecovered_dict[country].NATIONAL_DATA.DATA)
                {
                    float value = (float)item.Value;
                    //recovered_pointList.Add(new PointF(counter, value));
                    if (country_counter == 0)
                    {
                        recovered_pointList.Add(new PointF(counter, value));
                    }
                    else
                    {
                        PointF _point = new PointF(counter, recovered_pointList[(int)counter].Y + value);
                        recovered_pointList[(int)counter] = _point;
                    }
                    counter++;
                }

                country_counter++;
            }
            result.Add(confirmed_pointList);
            result.Add(deaths_pointList);
            result.Add(recovered_pointList);

            return result;
        }

        // Get daily confirmed cases
        public List<List<PointF>> GetListOfPoints_dailyConfirmed(Dictionary<string, DataNational> globalDataConfirmed_dict, string country, out List<string> seriesNames)
        {
            List<List<PointF>> result = new List<List<PointF>>();
            seriesNames = new List<string>();

            // Get confirmed cases
            seriesNames.Add("Confirmed daily");
            List<PointF> dailyConfirmed_pointList = new List<PointF>();
            float counter = 0;

            List<string> keyList = globalDataConfirmed_dict[country].NATIONAL_DATA.DATA.Keys.ToList();
            for (int i = 1; i < globalDataConfirmed_dict[country].NATIONAL_DATA.DATA.Count; i++)
            {
                float postVal = globalDataConfirmed_dict[country].NATIONAL_DATA.DATA[keyList[i]];
                float preVal = globalDataConfirmed_dict[country].NATIONAL_DATA.DATA[keyList[i - 1]];

                float value = postVal - preVal;
                dailyConfirmed_pointList.Add(new PointF(counter, value));
                counter++;
            }

            result.Add(dailyConfirmed_pointList);

            return result;
        }

        // Get daily deaths
        public List<List<PointF>> GetListOfPoints_dailyDeaths(Dictionary<string, DataNational> globalDataDeaths_dict, string country, out List<string> seriesNames)
        {
            List<List<PointF>> result = new List<List<PointF>>();
            seriesNames = new List<string>();

            // Get confirmed cases
            seriesNames.Add("Deaths daily");
            List<PointF> dailyDeaths_pointList = new List<PointF>();
            float counter = 0;

            List<string> keyList = globalDataDeaths_dict[country].NATIONAL_DATA.DATA.Keys.ToList();
            for (int i = 1; i < globalDataDeaths_dict[country].NATIONAL_DATA.DATA.Count; i++)
            {
                float postVal = globalDataDeaths_dict[country].NATIONAL_DATA.DATA[keyList[i]];
                float preVal = globalDataDeaths_dict[country].NATIONAL_DATA.DATA[keyList[i - 1]];

                float value = postVal - preVal;
                dailyDeaths_pointList.Add(new PointF(counter, value));
                counter++;
            }

            result.Add(dailyDeaths_pointList);

            return result;
        }

        // Get daily letality
        public List<List<PointF>> GetListOfPoints_dailyLetality(Dictionary<string, DataNational> globalDataConfirmed_dict, Dictionary<string, DataNational> globalDataDeaths_dict, string country, out List<string> seriesNames)
        {
            List<List<PointF>> result = new List<List<PointF>>();
            seriesNames = new List<string>();

            // Get confirmed cases
            seriesNames.Add(@"Letality daily (%)");
            List<PointF> dailyLetality_pointList = new List<PointF>();
            float counter = 0;

            List<string> keyList = globalDataDeaths_dict[country].NATIONAL_DATA.DATA.Keys.ToList();
            for (int i = 1; i < globalDataDeaths_dict[country].NATIONAL_DATA.DATA.Count; i++)
            {
                float value_confirmed = globalDataConfirmed_dict[country].NATIONAL_DATA.DATA[keyList[i]];
                float value_deaths = globalDataDeaths_dict[country].NATIONAL_DATA.DATA[keyList[i]];

                float value = 0;
                if (value_confirmed > 0)
                    value = value_deaths / value_confirmed * 100;

                dailyLetality_pointList.Add(new PointF(counter, value));
                counter++;
            }

            result.Add(dailyLetality_pointList);

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using COVID_Visualization.Forms;

namespace COVID_Visualization.Data
{
    class DataPlot
    {
        // Get Confirmed-Deaths-Recovered data to plot
        public List<List<PointF>> GetListOfPointsToPlot(Dictionary<string, DataNational> globalDataConfirmed_dict, Dictionary<string, DataNational> globalDataDeaths_dict, Dictionary<string, DataNational> globalDataRecovered_dict, string country, out List<string> seriesNames)
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
    }
}

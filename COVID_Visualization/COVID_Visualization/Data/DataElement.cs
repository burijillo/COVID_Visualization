using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID_Visualization.Data
{
    class DataElement
    {
        public double[] COORDINATES { get; set; }
        public Dictionary<string, int> DATA { get; set; }
        public int LOCAL_DAILY_CONFIRMED { get; set; }
        public int LOCAL_DAILY_DEATHS { get; set; }
        public int LOCAL_DAILY_RECOVERED { get; set; }
        public DataElement(double[] _input_coord, Dictionary<string, int> _input_data)
        {
            COORDINATES = _input_coord;
            DATA = _input_data;
            LOCAL_DAILY_CONFIRMED = 0;          // Confirmed is always greater than 0, so if this is 0, the data is not local daily
            LOCAL_DAILY_DEATHS = 0;
            LOCAL_DAILY_RECOVERED = 0;
        }

        public DataElement(double[] _input_coord, int _input_daily_confirmed, int _input_daily_deaths, int _input_daily_recovered)
        {
            COORDINATES = _input_coord;
            DATA = null;
            LOCAL_DAILY_CONFIRMED = _input_daily_confirmed;
            LOCAL_DAILY_DEATHS = _input_daily_deaths;
            LOCAL_DAILY_RECOVERED = _input_daily_recovered;
        }
    }

    class DataNational
    {
        private string COUNTRY { get; set; }
        public DataElement NATIONAL_DATA { get; set; }
        public Dictionary<string, DataElement> LOCAL_DATA { get; set; }
        public DataNational(string _country, DataElement _data)
        {
            COUNTRY = _country;
            NATIONAL_DATA = _data;
        }

        public DataNational(string _country, DataElement _nationa_data, Dictionary<string, DataElement> _local_data)
        {
            COUNTRY = _country;
            NATIONAL_DATA = _nationa_data;
            LOCAL_DATA = _local_data;
        }
    }

    class DataLocal
    {
        private string STATE_COUNTRY { get; set; }
        public DataElement LOCAL_DATA { get; set; }

        public DataLocal(string _state_country, DataElement _local_data)
        {
            STATE_COUNTRY = _state_country;
            LOCAL_DATA = _local_data;
        }
    }
}

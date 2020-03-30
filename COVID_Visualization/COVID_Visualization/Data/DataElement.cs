using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID_Visualization.Data
{
    class DataElement
    {
        private double[] COORDINATES { get; set; }
        public Dictionary<string, int> DATA { get; set; }
        public DataElement(double[] _input_coord, Dictionary<string, int> _input_data)
        {
            COORDINATES = _input_coord;
            DATA = _input_data;
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
}

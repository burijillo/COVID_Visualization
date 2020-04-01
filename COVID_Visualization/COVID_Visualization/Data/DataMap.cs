using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GMap.NET.WindowsForms;
using GMap.NET;

namespace COVID_Visualization.Data
{
    class DataMap
    {
        public GMapPolygon GetMapCircle(double radious, PointF coordinates, string name)
        {
            GMapPolygon result;
            List<PointLatLng> gpollist = new List<PointLatLng>();

            // Set fixed value of points of the circle (segments)
            int segments = 20;

            double seg = Math.PI * 2 / segments;

            int y = 0;
            for (int i = 0; i < segments; i++)
            {
                double theta = seg * i;
                double a = coordinates.X + Math.Cos(theta) * radious;
                double b = coordinates.Y + Math.Sin(theta) * radious;

                PointLatLng gpoi = new PointLatLng(a, b);

                gpollist.Add(gpoi);
            }
            result = new GMapPolygon(gpollist, name);

            return result;
        }
    }
}

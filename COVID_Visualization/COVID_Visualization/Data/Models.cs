using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;

namespace COVID_Visualization.Data
{
    public enum ModelTypes : int
    {
        Simple = 0
    }

    class Models
    {
        // Based on https://jamesmccaffrey.wordpress.com/2020/02/11/the-kermack-mckendrick-sir-disease-model-using-c/
        public List<List<PointF>> simpleSIR_model(out List<string> series_name)
        {
            /*
            N = S(t) + I(t) + R(t)
            dS/dt = -bSI / N
            dI/dt = bSI/N - aI
            dR/dt = aI

            N = total number people
            t = time
            S = susceptible people
            I = infected people
            R = removed (died or recovered)
            b = infection rate
            a = remove (die or recover) rate
             */

            List<List<PointF>> result = new List<List<PointF>>();
            series_name = new List<string>();

            double N = 47000000;
            double S = N * 0.7;
            double I = 130000;
            double R = 25000;
            double t = 0;

            double scale = 0.1;
            double b = 2.0;
            double a = 0.5;

            List<PointF> S_list = new List<PointF>();
            List<PointF> I_list = new List<PointF>();
            List<PointF> R_list = new List<PointF>();

            for (int i = 0; i < 100; i++)
            {
                Debug.WriteLine(t + ";" + S + ";" + I + ";" + R);

                double dS = (-b * S * I) / N;
                double dI = ((b * S * I) / N) - a * I;
                double dR = a * I;
                double dt = 1;

                S = S + dS * scale;
                I = I + dI * scale;
                R = R + dR * scale;
                t = t + dt * scale;

                S_list.Add(new PointF((float)t, (float)S));
                I_list.Add(new PointF((float)t, (float)I));
                R_list.Add(new PointF((float)t, (float)R));
            }

            result.Add(S_list);
            series_name.Add("Susceptible");
            result.Add(I_list);
            series_name.Add("Infected");
            result.Add(R_list);
            series_name.Add("Recovered");

            return result;
        }
    }
}

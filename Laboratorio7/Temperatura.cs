using System;
using System.Collections;

namespace Laboratorio7 {
    public class Temperature : IComparable
    {
    // The temperature value
        protected double temperatureF;

        public int CompareTo(object obj) {
            if (obj == null) return 1;

            Temperature otherTemperature = obj as Temperature;
            if (otherTemperature != null)
                return this.temperatureF.CompareTo(otherTemperature.temperatureF);
            else
            throw new ArgumentException("Object is not a Temperature");
        }

        public double Fahrenheit
        {
            get
            {
                return this.temperatureF;
            }
            set {
                this.temperatureF = value;
            }
        }

        public double Celsius
        {
            get
            {
                return (this.temperatureF - 32) * (5.0/9);
            }
            set
            {
                this.temperatureF = (value * 9.0/5) + 32;
            }
        }
    }
}
// The example displays the following output to the console (individual
// values may vary because they are randomly generated):
//       2
//       7
//       16
//       17
//       31
//       37
//       58
//       66
//       72
//       95
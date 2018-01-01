using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BasicStockCalculator.Model
{
    public class Calculation
    {
        public string Percentage { get; set; }
        public string Positive { get; set; }
        public string Negative { get; set; }
        public Color BgColorPercentage { get; set; }
        public Color BgColorPositive { get; set; }
        public Color BgColorNegative { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMean_code_study
{
    public class DPoint
    {
        public double X {  get; set; }
        public double Y { get; set; }

        public DPoint()
        {

        }
        public DPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}

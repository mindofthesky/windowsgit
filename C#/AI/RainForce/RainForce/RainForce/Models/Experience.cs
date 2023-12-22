using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainForce.RainForce.Models
{
    public class Experience
    {
        public Matrix PreviousState { get; set; }
        public Matrix NextState { get; set; }
        public int PreviousAction, NextAction;
        public double Reward;
    }
}

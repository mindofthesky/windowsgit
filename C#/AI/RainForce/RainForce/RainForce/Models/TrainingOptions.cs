using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RainForce.RainForce.DEMO;
namespace RainForce.RainForce.Models
{
    public class TrainingOptions
    {
        public UpdateModes UpdateMode { get; }
        public double Gamma { get; }
        public double Epsilon { get; set; }
        public double Alpha { get; set; }
        public bool SmoothPolicyUpdate { get; set; }
        public double Beta { get; set; }
        public int Lambda { get; set; }
        public bool ReplacingTraces { get; set; }
        public int QInitVal { get; set; }
        public int ExperienceAddEvery { get; set; }
        public int ExperienceSize { get; set; }
        public int LearningSteps { get; set; }
        public double ErrorClamp { get; set; }
        public int HiddenUnits { get; set; }
        public int ExperienceStart { get; set; }

        public TrainingOptions()
        {
            UpdateMode = UpdateMode.Qlearn;
            Gamma = 0.9;
        }

        public TrainingOptions(double gamma)
        {
            UpdateMode = UpdateMode.Qlearn;
            Gamma = gamma;
        }
    }
}

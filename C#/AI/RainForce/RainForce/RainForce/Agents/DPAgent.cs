using RainForce.RainForce.Models;
using RainForce.RainForce.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainForce.RainForce.Agents
{
    public abstract class DPAgent
    {
        public TrainingOptions Options { get; private set; }
        public double[] Value { get; private set; }
        public double[] Policy { get; private set; }
        public int NumberOfStates { get; private set; }
        public int NumberOfActions {  get; private set; }

        public  void Reset(int numberOfStates, int numberOfActions, double gamma = 0.75)
        {
            Options = new TrainingOptions();
            NumberOfStates = numberOfStates;
            NumberOfActions = numberOfActions;
            Policy = new double[numberOfActions * numberOfStates];

        }

        protected virtual int[] GetAllowedActions(int s)
        {
            var ck = new int[4];
            for (int i = 0; i < ck.Length; i++)
            {
                ck[i] = i;
            }
            return ck;
        }

        protected virtual int NextStateDistribution(int s, int a)
        {
            return 1;
        }

        protected virtual int Reward(int s, int a, int d)
        {
            return 1;
        }

        public int Act(int state)
        {
            var poss = GetAllowedActions(state);
            var ps = new List<double>();
            var n = poss.Length;
            for (int i = 0; i < n; i++)
            {
                var a = poss[i];
                var prob = Policy[a * NumberOfStates + state];
                ps.Add(prob);

            }
            var maxi = Util.SampleWeightedAction(ps);
            return poss[maxi];
        }
        public void Learn()
        {
            EvaluatePolicy();
            UpdatePolicy();
        }
        public void EvaluatePolicy()
        {
            var Vnew = Util.ArrayOfZeros(this.NumberOfStates);
            for (var s = 0; s < this.NumberOfStates; s++)
            {
                // integrate over actions in a stochastic policy
                // note that we assume that policy probability mass over allowed actions sums to one
                var v = 0.0;
                var poss = GetAllowedActions(s);
                for (int i = 0, n = poss.Length; i < n; i++)
                {
                    var a = poss[i];
                    var prob = Policy[a * this.NumberOfStates + s]; // probability of taking action under policy
                    if (prob == 0)
                    {
                        continue;
                    } // no contribution, skip for speed
                    var ns = NextStateDistribution(s, a);
                    var rs = Reward(s, a, ns); // reward for s->a->ns transition
                    v += prob * (rs + Options.Gamma * Value[ns]);
                }
                Vnew[s] = v;
            }
            Value = Vnew;
        }
        public void UpdatePolicy()
        {

        }


    }
}

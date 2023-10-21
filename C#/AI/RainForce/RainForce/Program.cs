// See https://aka.ms/new-console-template for more information
using RainForce.RainForce.Agents;
using RainForce.RainForce.Models;

namespace RainForce
{

    class Program
    {
        static void Main(string[] args)
        {
            // 오류 역전파
            var rnd = new Random();
            int max = 10;
            int min = 0;
            int nextprint = 0, act1 = 0, act0 = 0;
            double total = 0, correct = 0;
            var state = new[] { rnd.Next(min, max), rnd.Next(min, max), rnd.Next(min, max), rnd.Next(min, max) };
            var opt = new TrainingOptions
            {
                Alpha = 0.001,
                Epsilon = 0,
                ErrorClamp = 0.002,
                ExperienceAddEvery = 10,
                ExperienceStart = 0,
                HiddenUnits = 5,
                LearningSteps = 400
            };

            var agent = new DQNAgent(opt, state.Length, 2);

            while (total < 50000)
            {
                state = new[] { rnd.Next(min, max), rnd.Next(min, max), rnd.Next(min, max) };
                var action = agent.Act(state);
                if (action == 1)
                {
                    act1++;
                }
                else
                {
                    act0++;
                }
                if(state.Average() > 5 && action == 1)
                {
                    agent.Learn(1);
                    correct++;
                }
                else if(state.Average() <= 5 && action == 0)
                {
                    agent.Learn(1);
                    correct++;
                }
                else
                {
                    agent.Learn(-1);
                }
                total++;
                if(total >= nextprint)
                {
                    Console.WriteLine((correct / total).ToString() + "dd " + nextprint);
                    Console.WriteLine("Action 1 : " + act1, act0);
                    nextprint += 1000;

                }
            }
            Console.WriteLine("End");
            File.AppendAllLines(AppDomain.CurrentDomain.BaseDirectory + "" ,agent.AgentToJson());
        }
    }
    public class MyDPAgent : DPAgent
    {
        protected override int[] GetAllowedActions(int s)
        {
            return new[] { 0, 1, 2, 3 };
        }

        protected override int Reward(int s, int a, int d)
        {
            return s * a * d;
        }

        protected override int NextStateDistribution(int s, int a)
        {
            return s * a;
        }
    }
}
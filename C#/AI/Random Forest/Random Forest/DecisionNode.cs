using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Forest
{
    public class DecisionNode
    {
        // 노드 클래스 초기값 선언부 
        public int Index {  get; set; }
        public double Threshold {  get; set; }
        public double InfoGain { get; set; }
        public DecisionNode? LeftNode {  get; set; }
        public DecisionNode? RigthNode { get; set; }
        public int vlaue {  get; set; }
        public bool IsLeft {  get; set; }
    }
}

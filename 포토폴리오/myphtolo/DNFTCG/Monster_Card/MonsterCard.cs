using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNFTCG.Card;
namespace DNFTCG.Monster_Card
{
    public delegate void Monster();
   
    public class monster_information 
    {
        
        public string monster_name {  get; set; }
        public int monster_power { get; set; }
        public int monster_defens { get; set; }
        public int monster_level { get; set; }
        void Monster(string name)
        {
            this.monster_name = name;
            if(monster_name == "고블린 십장")
            {
                monster_power = 300;
                monster_defens = 400;
            }
        }
    }
    
    public class MonsterCard
    {
        // 생각하는 코드는 몬스터를 db에 두지 않은 하드 코딩의 상태에서 정의하자 
        // 어차피 이게 몬스터나 효과는 많지않기에 하드코딩에서 모두 해결 해보자 
        // 잘만들고 나서 DB를 구현하는걸 해야되는거라 이게 지금은 몬스터까지 다 구현하는게 목표다 
        // 10.05

        monster_information monster_inform  = new monster_information();
        

    }
}

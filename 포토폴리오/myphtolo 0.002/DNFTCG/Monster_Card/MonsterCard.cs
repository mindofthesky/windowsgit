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
         
        public string? monster_name {  get; set; }
        public int? monster_power { get; set; }
        public int? monster_defens { get; set; }
        public int? monster_level { get; set; }
        MonsterCard monsters = new MonsterCard();
        

    }
    
    
    public class MonsterCard
    {
        string? monster_name ;
        int? monster_level = 0;
        int? monster_power  = 0;
        int? monster_defens = 0;
        // 생각하는 코드는 몬스터를 db에 두지 않은 하드 코딩의 상태에서 정의하자 
        // 어차피 이게 몬스터나 효과는 많지않기에 하드코딩에서 모두 해결 해보자 
        // 잘만들고 나서 DB를 구현하는걸 해야되는거라 이게 지금은 몬스터까지 다 구현하는게 목표다 
        // 10.05

        

        public  void Monster(string name)
        {
            monster_name = name;
            if (monster_name == "고블린 십장")
            {
                this.monster_power = 300;
                this.monster_defens = 400;
            }
        }
        public void Monster_levelup()
        {
            // test case로 하드 코딩형 10.08
            if (monster_name == "고블린 십장")
            {
                monster_level += 10;
                monster_power += 200;
                monster_defens += 300;
            }

        }
        public void level_down()
        {
            // 규칙이 존재하는데 이걸 이렇게 무턱대고 하는게 맞는가? 그렇다면 분화가 필요한게 아닌가? 
            // 레벨은 무조건적으로 감소한다고 하지만 다른 몬스터카드마다 레벨 다운의 효과는 다를거아닌가? 
            monster_level -= 10;
            monster_power -= 200;
            monster_defens -= 300;
        }

    }
}

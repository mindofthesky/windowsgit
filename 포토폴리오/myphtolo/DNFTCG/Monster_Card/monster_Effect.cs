using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNFTCG.Card;


namespace DNFTCG.Monster_Card
{
    public class monster_Effect { 




    }
    public class monster_level : levels
    {
        int damage;
        int defensive;
        string effect;
        levels levels = new levels();

        public void monsterlevel()
        {
            // 몬스터가 레벨업한 만큼 레벨업이 되는경우가 있거나
            // 몬스터는 레벨업과 동시에 방어력과 공격력이 상승한다 
            // 몬스터 효과도 있다면 effect 도 하나 설정하자

        }
    }
}

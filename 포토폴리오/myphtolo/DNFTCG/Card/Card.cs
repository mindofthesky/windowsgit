using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DNFTCG.Card.Card;
using DNFTCG.Monster_Card;

namespace DNFTCG.Card
{
    

    public class Card : MonsterCard
    {
        // 카드를 통해서 게임을 진행하는 게임이기 때문에 
        // 배열형으로 처리해야하나 동적으로 할당해야 하나 고민을 하게된다 
        // deck 배열적으로 카드의 숫자를 표시한다면, 문제점이 있다 숫자로 덱을 판별할거면 모든 숫자가 나타내는게 있어야한다 
        // string으로 받고 int처럼 Convert를 하는게 낫지않나? 
        private string[] deck = new string[] { }; // 덱

        // 패는 숫자로 int로 선언한이유는 간단하지만 쉽다 패의 소지 매수는 엔드 페이지에 5장으로 만들어야하기 때문에 5장으로 해결할필요가 있다 
        // 패는 직접적으로 효과를 발동 처리부가 아니기때문에 소지 패만 확인 할수만 있어도 충분할거라고 생각한다  23.10.04 
        private int[] hand = new int[] { }; // 패
        // 묘지에서 발동처리하는것은 구현하지 않는다면 묘지는 int로 배열형으로 숫자만 봐도 상관없을것 같다 
        private int[] Gy = new int[] { }; // 묘지
        private string[] banished = new string[] { };
        

        // 카드를 열거형으로 한이유 코드 꼬임이 발생을 방지는 가장 좋은게 열거형이라 생각한다 
        public enum card_effect {
            monster,
            skil,
            cardeffect,
            armor,
            wep,
            leveling,

        }
        // 캐릭터마다 레벨업을 했을경우가 필요한데 열거형을 통해 판별해서 레벨업을 해줘야하지만 
        // 현재 코드를 작성하면서 고민하게 되는점은 가장 쉬운 레벨업인데 
        // 레벨업에서 
        public enum Character
        {
            Gun,
            Magic,
            Sword,
            Fighter,
            Monster

        };
        
        
        
        // 레벨업은 생각해야할점은 현재 캐릭터마다 레벨업 하는게 따로 존재한다는점이고 
        // 단독캐릭, 2캐릭 동시 레벨업도 존재하면서
        // 몬스터 같은 레벨업도 처리가 필요하기때문에 초기값에 선언해주는게 좋다고 생각됨 23.10.04 
       

        

      
    }
    public class levels
    {
        int level = 0;
        //public int Level { get; set; }
        int magic = 0;
        int gun = 0;
        int sword = 0;
        int fighter = 0;
        int monster = 0;
        public void levelup()
        {
            levelup_card_effect();
        }

        public void levelup_card_effect()
        {

            // 왜 열거형 

            // 더 좋게 할수없나 
            // case로 하고싶긴한데

            if (Character.Gun == 0)
            {
                gun += 10;
                level = gun;
            }
            if ((int)Character.Magic == 1)
            {
                magic += 10;
                level = magic;

            }
            if ((int)Character.Sword == 2)
            {
                sword += 10;
                level = sword;
            }
            if ((int)Character.Fighter == 3)
            {
                fighter += 10;
                level = fighter;
            }
            if ((int)Character.Monster == 4)
            {
                monster += 10;
                monster = level;
            }
            // 23.10.05 이구문은 레벨업 구문을 처리한 결과인데 
            // 사실 좀 생각하면 하나하나 다른 메소드로 cast를 하면 메소드를 줄일 순 있을거라고 생각한다
            // Charater 나열형으로 값을 받아오고 값을 casting해서 값이 동일할경우 레벨업이 동작하도록 실행시킨코드지만 
            // 쓸대없는 if문이 많지 않나 생각은 한다.
            // 이런 하드코딩 구문이 많아지면 다른 듀얼 캐릭터가 존재하게되면 이 경우에는 모든 코드를 배수로 증가할수도 있다
            //  card_effect.level = 1;
        }
    }
     

}

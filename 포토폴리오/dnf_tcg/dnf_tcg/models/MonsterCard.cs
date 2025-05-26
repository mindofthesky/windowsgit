// Models/MonsterCard.cs
using System;
using System.Linq;

namespace DnfTcg.Models
{
    public class MonsterCard : Card
    {
        public int AttackPower { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

        public MonsterCard(string name, int levelReq, int atk, int hp)
        {
            Name = name;
            LevelRequirement = levelReq;
            AttackPower = atk;
            MaxHealth = hp;
            CurrentHealth = hp;
            Type = CardType.Monster;
        }

        public override void Play(Player self, Player enemy)
        {
            self.SummonMonster(this);
        }

        public void Recover()
        {
            CurrentHealth = MaxHealth;
        }

        public void TakeDamage(int dmg)
        {
            CurrentHealth -= dmg;
        }

        public void Attack(Player target)
        {
            if (target.Monsters.Any())
            {
                // 첫 번째 몬스터 공격
                var defender = target.Monsters[0];
                Console.WriteLine($"{Name} attacks {defender.Name} for {AttackPower}!");
                defender.TakeDamage(AttackPower);

                if (defender.CurrentHealth <= 0)
                {
                    Console.WriteLine($"{defender.Name} is defeated!");
                    target.Monsters.Remove(defender);
                }
            }
            else
            {
                // 몬스터 없으면 플레이어 직접 타격
                Console.WriteLine($"{Name} attacks {target.Name} for {AttackPower}!");
                target.TakeDamage(AttackPower);
            }
        }
    }
}
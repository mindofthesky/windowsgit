// Models/DeckFactory.cs
using System;
using System.Collections.Generic;
using dnf_tcg.models;
namespace DnfTcg.Models
{
    public static class DeckFactory
    {

        public static List<Card> CreateStarterDeck()
        {

            return new List<Card>
            {
                new WeaponCard("해진 권투글러브", 10, 100),
                new WeaponCard("녹슨 칼", 10, 150),
                new ArmorCard("낡아 빠진 각반", 15, 80),
                new ArmorCard("낡은 흉아 샌들", 15, 120),
                new SkillCard("매직 미사일", 1, (self, enemy, level) =>
                {
                    int dmg = level * 100;
                    enemy.TakeDamage(dmg);
                    System.Console.WriteLine($"Fireball hits {enemy.Name} for {dmg}!");
                }),
                new SkillCard("프로스트 헤드", 200, (self, enemy, level) =>
                {
                    int dmg = level * 80;
                    enemy.TakeDamage(dmg);
                    System.Console.WriteLine($"프로스트 헤드 {enemy.Name} 의 공격 {dmg}!");
                }),
                new MonsterCard("고블린", 10, 50, 200),
                new MonsterCard("타우 비스트", 20, 80, 300),
                new SkillCard("환영검무", 45, 3, (self, enemy, level) =>
                {
                    int dmg = level * 25;
                    enemy.TakeDamage(dmg);
                    Console.WriteLine($"환영검무가 {enemy.Name}에게 {dmg}의 피해를 입혔다!");
                })
            };
        }
    }
}

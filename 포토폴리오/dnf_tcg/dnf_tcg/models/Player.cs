// Models/Player.cs
using System;
using System.Collections.Generic;
using dnf_tcg.models;
namespace DnfTcg.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Level { get; set; } = 0;
        public int MaxLevel { get; set; } = 115;
        public int Health { get; set; } = 4000;
        public int BaseAttack { get; set; } = 0;
        public int BaseDefense { get; set; } = 0;

        public int CubeShards { get; set; } = 0;
        public WeaponCard EquippedWeapon { get; set; }
        public ArmorCard EquippedArmor { get; set; }

        public List<Card> Deck { get; set; } = new List<Card>();
        public List<Card> Hand { get; set; } = new List<Card>();
        public Dictionary<string, SkillCard> Skills { get; set; } = new Dictionary<string, SkillCard>();
        public List<MonsterCard> Monsters { get; set; } = new List<MonsterCard>();

        public bool HasLeveledUpThisTurn { get; set; } = false;

        public void TakeDamage(int rawDamage)
        {
            int reduced = Math.Max(0, rawDamage - BaseDefense);
            Health -= reduced;
            Console.WriteLine($"{Name} took {reduced} damage! (Raw: {rawDamage}, DEF: {BaseDefense})");
        }

        public void EquipWeapon(WeaponCard weapon)
        {
            if (Level < weapon.LevelRequirement)
            {
                Console.WriteLine($"{Name} is too low level to equip {weapon.Name}.");
                return;
            }

            EquippedWeapon = weapon;
            BaseAttack = weapon.AttackBonus;
            Console.WriteLine($"{Name} equipped weapon: {weapon.Name} (+{BaseAttack} ATK)");
        }

        public void EquipArmor(ArmorCard armor)
        {
            if (Level < armor.LevelRequirement)
            {
                Console.WriteLine($"{Name} is too low level to equip {armor.Name}.");
                return;
            }

            EquippedArmor = armor;
            BaseDefense = armor.DefenseBonus;
            Console.WriteLine($"{Name} equipped armor: {armor.Name} (+{BaseDefense} DEF)");
        }

        public void SummonMonster(MonsterCard monster)
        {
            if (Level < monster.LevelRequirement)
            {
                Console.WriteLine($"{Name} is too low level to summon {monster.Name}.");
                return;
            }

            Monsters.Add(monster);
            Console.WriteLine($"{Name} summoned monster: {monster.Name} (ATK: {monster.AttackPower}, HP: {monster.CurrentHealth})");
        }

        public void LevelUp()
        {
            if (HasLeveledUpThisTurn)
            {
                Console.WriteLine($"{Name} already leveled up this turn.");
                return;
            }

            Level+=10;
            HasLeveledUpThisTurn = true;

            // 무색 큐브 지급 로직
            if (Level == 50)
            {
                CubeShards = 1;
            }
            else if (Level % 10 == 0 && Level <= 115)
            {
                CubeShards++;
            }

            // 보너스 지급
            if (Level == 75 || Level == 110)
            {
                CubeShards += 2;
            }

            // 최종 상한 보정
            if (Level > 115)
            {
                CubeShards = 15;
            }

            Console.WriteLine($"{Name} leveled up to Lv{Level} | Cube Shards: {CubeShards}");
            if (Level >= 115) Level = MaxLevel;
        }
    }
}

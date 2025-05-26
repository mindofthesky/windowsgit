
using System;

namespace DnfTcg.Models
{
    public enum CardType
    {
        Weapon,
        Armor,
        Skill,
        Monster,
        Effect
    }

    public abstract class Card
    {
        public string Name { get; set; }
        public int LevelRequirement { get; set; }
        public CardType Type { get; protected set; }

        public abstract void Play(Player self, Player enemy);
    }

    public class WeaponCard : Card
    {
        public int AttackBonus { get; set; }

        public WeaponCard(string name, int levelReq, int atkBonus)
        {
            Name = name;
            LevelRequirement = levelReq;
            AttackBonus = atkBonus;
            Type = CardType.Weapon;
        }

        public override void Play(Player self, Player enemy)
        {
            self.EquipWeapon(this);
        }
    }

    public class ArmorCard : Card
    {
        public int DefenseBonus { get; set; }

        public ArmorCard(string name, int levelReq, int defBonus)
        {
            Name = name;
            LevelRequirement = levelReq;
            DefenseBonus = defBonus;
            Type = CardType.Armor;
        }

        public override void Play(Player self, Player enemy)
        {
            self.EquipArmor(this);
        }
    }

    

   
}

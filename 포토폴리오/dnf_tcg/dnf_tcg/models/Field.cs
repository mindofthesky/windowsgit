using DnfTcg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dnf_tcg.models
{
    public class Field
    {
        public MonsterCard Monster { get; set; }

        public SkillCard Skill1 { get; set; }
        public SkillCard Skill2 { get; set; }
        public SkillCard Skill3 { get; set; }

        public WeaponCard Weapon { get; set; }
        public ArmorCard Armor { get; set; }

        public Card Effect1 { get; set; }
        public Card Effect2 { get; set; }
        public Card Effect3 { get; set; }

        public Card LevelUpCard { get; set; }
    }
}

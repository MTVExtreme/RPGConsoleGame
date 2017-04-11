using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Paladin : PlayerClass
    {
        public int Stamina { get; set; }

        public void Attack(Enemy p)
        {
            Attack(p, Attackz, this.Name);

        }

        public void SpecialAttack(Enemy p)
        {
            SpecialAttack(p, Attackz, specialAttacks, this.Name);

        }

        Dictionary<string, int> specialAttacks = new Dictionary<string, int>
            {
                {"Shield Clash", 12},
                {"Massive Blow", 20},
                {"Hero's Slash", 30},
            };

        public Paladin(string name, string faction, bool npc) : base(name, faction, npc)
        {
            //this.Name = name;
            //this.Faction = faction;
            //this.Level = 1;
            this.Stamina = 40;
            this.HealthPoints = 160;
            this.Speed = 9;
            this.Type = CharacterType.Paladin;
            this.SpecialAttacks = specialAttacks;
        }

        public override string ToString()
        {
            return $"The {this.Type} {this.Name} of {this.Faction} => Health Points: {this.HealthPoints} || Speed: {this.Speed} || Stamina: {this.Stamina}";
        }

        public override string GetExtraStat()
        {
            return "Stamina";
        }

        public override int GetExtraStatValue()
        {
            return this.Stamina;
        }
    }
}

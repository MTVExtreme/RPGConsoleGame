using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Mage : PlayerClass
    {
        public int Mana { get; set; }

        Dictionary<string, int> specialAttacks = new Dictionary<string, int>
            {
                {"Firebolt", 15},
                {"Mystic Sword Slash", 34},
                {"Thunderstorm", 50},
            };

        public Mage(string name, string faction) : base(name, faction)
        {
            this.Mana = 30;
            this.HealthPoints = 80;
            this.Speed = 6;
            this.Type = CharacterType.Mage;
            this.SpecialAttacks = specialAttacks;

        }

        public override string ToString()
        {
            return $"The {this.Type} {this.Name} of {this.Faction} => Health Points: {this.HealthPoints} || Speed: {this.Speed} || Mana: {this.Mana}";
        }

        public override string GetExtraStat()
        {
            return "Mana";
        }

        public override int GetExtraStatValue()
        {
            return this.Mana;
        }
    }
}

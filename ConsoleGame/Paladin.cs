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

        Dictionary<string, int> specialAttacks = new Dictionary<string, int>
            {
                {"Shield Clash", 12},
                {"Massive Blow", 20},
                {"Hero's Slash", 30},
            };

        public Paladin(string name, string faction) : base(name, faction)
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Human : PlayerClass
    {
        public int Stamina { get; set; }

        Dictionary<string, int> specialAttacks = new Dictionary<string, int>
            {
                {"Slash", 10},
                {"Stab", 16},
                {"Heavy Swing", 24},
            };

        public Human(string name, string faction) : base(name, faction)
        {
            this.Stamina = 25;
            this.HealthPoints = 85;
            this.Speed = 16;
            this.Type = CharacterType.Human;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Ninja : PlayerClass
    {
        public int Stamina { get; set; }

        Dictionary<string, int> specialAttacks = new Dictionary<string, int>
            {
                {"Slient Slash", 15},
                {"Throwing Star", 36},
                {"Death from Above", 75},
            };

        public Ninja(string name, string faction) : base(name, faction)
        {
            this.Stamina = 25;
            this.HealthPoints = 85;
            this.Speed = 16;
            this.Type = CharacterType.Ninja;
            this.SpecialAttacks = specialAttacks;
        }

        public override string ToString()
        {
            return $"The {this.Type} {this.Name} of {this.Faction} => Health Points: {this.HealthPoints} || Speed: {this.Speed} || Stamina: {this.Stamina}";
        }
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Ranger : PlayerClass
    {
        public int Ammo { get; set; }

        Dictionary<string, int> specialAttacks = new Dictionary<string, int>
            {
                {"Quick Shot", 12},
                {"Flaming Spiral", 24},
                {"Arrow Storm", 36},
            };

        public Ranger(string name, string faction) : base(name, faction)
        {
            //this.Name = name;
            //this.Faction = faction;
            //this.Level = 1;
            this.Ammo = 12;
            this.HealthPoints = 100;
            this.Speed = 13;
            this.Type = CharacterType.Ranger;
            this.SpecialAttacks = specialAttacks;

        }

        public override string ToString()
        {
            return $"The {this.Type} {this.Name} of {this.Faction} => Health Points: {this.HealthPoints} || Speed: {this.Speed} || Ammo: {this.Ammo}";
        }

        public override string GetExtraStat()
        {
            return "Ammo";
        }

        public override int GetExtraStatValue()
        {
            return this.Ammo;
        }


    }
}

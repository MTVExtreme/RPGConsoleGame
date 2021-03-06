﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Ninja : PlayerClass
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
                {"Slient Slash", 15},
                {"Throwing Star", 36},
                {"Death from Above", 75},
            };

        public Ninja(string name, string faction, bool npc) : base(name, faction, npc)
        {
            this.Stamina = 25;
            this.HealthPoints = 85;
            this.MaxHealthPoints = HealthPoints;
            this.Speed = 16;
            this.Type = CharacterType.Ninja;
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


